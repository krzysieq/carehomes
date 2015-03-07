using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Details : System.Web.UI.Page
{
    public string ChartData = string.Empty;
    public string WeightGraph = string.Empty;
    public string StepsGraph = string.Empty;
    public string BodyTempGraph = string.Empty;
    public string Spo2Graph = string.Empty;
    public string BloodGraph = string.Empty; // for blood

    DBManager db = new DBManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["user_id"] != null && Request.QueryString["user_id"].ToString() != "")
            {
                BindTilesInfo(Request.QueryString["user_id"].ToString());
            }
        }
    }
    public void BindTilesInfo(string id)
    {
        DataTable dtUser = db.RetrieveDatatableIL("select * from telecare_master where user_id=" + id);
        try
        {

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                lblUsername.Text = dtUser.Rows[0]["user_name"].ToString();
                lblGenderAge.Text = dtUser.Rows[0]["user_gender"].ToString() + ", " + dtUser.Rows[0]["user_age"].ToString();
                spnCity.InnerHtml = dtUser.Rows[0]["user_city"].ToString();

                #region Binding Info Spans

                SqlParameter args = new SqlParameter("@id", id);
                DataSet dtInfo = db.RetrieveDataSet("Get_HealthTracking_Front_SP", args);

                if (dtInfo != null)
                {
                    spnWeightInfo.InnerHtml = dtInfo.Tables[0].Rows[0]["days"].ToString();                    
                    spnWeightTxt.InnerHtml = dtInfo.Tables[0].Rows[0]["weight"].ToString();

                    spnStepsDayCount.InnerHtml += dtInfo.Tables[0].Rows[0]["days"].ToString();
                    spnStepsInfo.InnerHtml = dtInfo.Tables[1].Rows[0]["days"].ToString() + "<br /><br />";
                    spnStepsTxt.InnerHtml = dtInfo.Tables[1].Rows[0]["steps"].ToString();

                    spnBodyInfo.InnerHtml = "&nbsp;&nbsp;" + dtInfo.Tables[2].Rows[0]["days"].ToString() + "<br /><br />";
                    spnBodyTxt.InnerHtml = dtInfo.Tables[2].Rows[0]["body_temp"].ToString();

                    spnSpo2Info.InnerHtml = dtInfo.Tables[3].Rows[0]["days"].ToString();
                    spnSpo2Txt.InnerHtml = dtInfo.Tables[3].Rows[0]["spo2"].ToString();

                    if (Convert.ToInt32(dtInfo.Tables[3].Rows[0]["spo2"].ToString()) <= 90)
                    {
                        spnSpo2Info.InnerHtml += "<img src='images/exeed.gif' height='16px' width='16px' /><br /><br />";
                    }

                    spnBloodInfo.InnerHtml = dtInfo.Tables[4].Rows[0]["days"].ToString();


                    int high = Convert.ToInt32(dtInfo.Tables[4].Rows[0]["high"].ToString());
                    int low = Convert.ToInt32(dtInfo.Tables[4].Rows[0]["low"].ToString());

                    if (high >= 140 || low >= 90 || low <= 60)
                    {
                        spnBloodInfo.InnerHtml += "<img src='images/exeed.gif' height='16px' width='16px' />";
                    }


                    spnBloodTxt.InnerHtml = dtInfo.Tables[4].Rows[0]["high"].ToString() + "/" + dtInfo.Tables[4].Rows[0]["low"].ToString();
                }
                #endregion

                #region Binding Envirment

                SqlParameter argsEnvirment = new SqlParameter("@id", id);
                DataTable dtEnvirnment = db.RetrieveDatatable("getenvirment_master_sp", argsEnvirment);

                spnMotionInfo.InnerHtml = "&nbsp;" + dtEnvirnment.Rows[0]["motion"].ToString();
                spnBedroomTxt.InnerHtml = "&nbsp;" + dtEnvirnment.Rows[0]["bedroom"].ToString();
                spnKitchenTxt.InnerHtml = "&nbsp;" + dtEnvirnment.Rows[0]["kitchen"].ToString();
                spnBathRoomTxt.InnerHtml = "&nbsp;" + dtEnvirnment.Rows[0]["bathroom"].ToString();
                spnPiazzaTxt.InnerHtml = "&nbsp;" + dtEnvirnment.Rows[0]["piazza"].ToString();

                spnTempText.InnerHtml = dtEnvirnment.Rows[0]["temperature"].ToString();
                spnCoTxt.InnerHtml = dtEnvirnment.Rows[0]["co"].ToString();

                string smokeDetect = dtEnvirnment.Rows[0]["smoke"].ToString() == "0" ? smokeDetect = "not detected" : smokeDetect = "detected";
                spnSmokeTxt.InnerHtml = smokeDetect;

                #endregion

                #region Bind Third Tiles
                spnAllergies.InnerHtml = dtUser.Rows[0]["allergies"].ToString();
                spnCondition.InnerHtml = dtUser.Rows[0]["conditions"].ToString();
                spnMedication.InnerHtml = dtUser.Rows[0]["medications"].ToString();
                #endregion

                #region Binding Graphs

                //string query = string.Empty;

                //query += "select top 7 weight,DATENAME(dw,create_date) as day from weight_master where user_id=1 order by create_date desc;";
                //query += "select top 7 steps,DATENAME(dw,create_date) as day from steps_master  where user_id=1 order by create_date desc;";
                //query += "select top 7 body_temp,DATENAME(dw,create_date) as day from body_temp_master  where user_id=1 order by create_date desc;";
                //query += "select top 7 spo2,DATENAME(dw,create_date) as day from spo2_master where user_id=1 order by create_date desc;";
                //query += "select top 7 low,high,DATENAME(dw,create_date) as day from blood_master where user_id=1 order by create_date desc;";

                SqlParameter p1 = new SqlParameter("@id", id);
                DataSet dtGraph = db.RetrieveDataSet("GetChartData_SP", p1);

                if (dtGraph.Tables[0] != null)
                {
                    BindWeight(dtGraph);
                }

                if (dtGraph.Tables[1] != null)
                {
                    BindStepsGraph(dtGraph);
                }

                if (dtGraph.Tables[2] != null)
                {
                    BindBodyTempGraph(dtGraph);
                }

                if (dtGraph.Tables[3] != null)
                {
                    BindSpo2Graph(dtGraph);
                }

                if (dtGraph.Tables[4] != null)
                {
                    BindBloodGraph(dtGraph);
                }

                #endregion
            }
        }
        catch (Exception err)
        {
            lblUsername.Text = err.ToString();
            lblUsername.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void BindWeight(DataSet ds)
    {
        DataSet dsdummy = ds;

        WeightGraph = @"<script type=\""text/javascript\"">
        $(function () {
            $('#container_weight').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: 'Weight Measurement'
                },
                subtitle: {
                    text: '" + lblUsername.Text + @"'
                },
                xAxis: {
                    categories: [";

        for (int i = 0; i < dsdummy.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
            {
                WeightGraph += @"'" + dsdummy.Tables[0].Rows[i]["day"].ToString() + "'";
            }
            else
            {
                WeightGraph += @",'" + dsdummy.Tables[0].Rows[i]["day"].ToString() + "'";
            }
        }
        WeightGraph += @"
                ]},
                yAxis: {
                    title: {
                        text: 'Weight'
                    },
                    labels: {
                        formatter: function () {
                            return this.value + '';
                        }
                    }
                },
                tooltip: {
                    crosshairs: true,
                    shared: true
                },
                plotOptions: {
                    spline: {
                        marker: {
                            radius: 4,
                            lineColor: '#666666',
                            lineWidth: 1
                        }
                    }
                },
                series: [";
        foreach (DataColumn column in dsdummy.Tables[0].Columns)
        {
            if (column.ColumnName.ToLower() != "day")
            {
                WeightGraph += @"{
                                                        name: '" + column.ColumnName + @"',
                                                        data: [";
                int counter = 1;
                foreach (DataRow row in dsdummy.Tables[0].Rows)
                {
                    int rowcount = dsdummy.Tables[0].Rows.Count;

                    if (counter == rowcount)
                    {
                        WeightGraph += row[column].ToString();
                    }
                    else
                    {
                        WeightGraph += row[column].ToString() + ",";
                    }
                    counter++;
                }
                if (column.ColumnName == "weight")
                {
                    WeightGraph += "]}";
                }
                else
                {
                    WeightGraph += "]},";
                }
            }
        }
        WeightGraph += @"
                ]
            });
        });
		</script>";

        WeightGraph = WeightGraph.Replace("\\", "");      

    }
    public void BindStepsGraph(DataSet ds)
    {
        StepsGraph = @"<script type=\""text/javascript\"">
        $(function () {
            $('#container_Steps').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Steps Counts'
                },
                subtitle: {
                    text: 'Source: <a href=\""http://en.wikipedia.org/wiki/List_of_cities_proper_by_population\"">Wikipedia</a>'
                },
                xAxis: {
                    type: 'category',
                    labels: {
                        rotation: -45,
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif'
                        }
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'No of Steps'
                    }
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: 'Steps Weeks: <b>{point.y:.0f} </b>'
                },
                series: [{
                    name: 'Population',
                    data: [";

        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            if (i == 0)
            {
                StepsGraph += @"['" + ds.Tables[1].Rows[i]["day"].ToString() + "'," + ds.Tables[1].Rows[i]["steps"].ToString() + "]";
            }
            else
            {
                StepsGraph += @",['" + ds.Tables[1].Rows[i]["day"].ToString() + "'," + ds.Tables[1].Rows[i]["steps"].ToString() + "]";
            }
        }

        StepsGraph += @"
                    ],
                    dataLabels: {
                        enabled: true,
                        rotation: -90,
                        color: '#FFFFFF',
                        align: 'right',
                        x: 4,
                        y: 10,
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif',
                            textShadow: '0 0 3px black'
                        }
                    }
                }]
            });
        });
		</script>";

        StepsGraph = StepsGraph.Replace("\\", "");

        object sumObject;
        sumObject = ds.Tables[1].Compute("Sum(steps)", "");
        spnStepsWeekCount.InnerHtml = " this week " + sumObject.ToString();
    }
    public void BindBodyTempGraph(DataSet ds)
    {
        DataSet dsdummy = ds;

        BodyTempGraph = @"<script type=\""text/javascript\"">
        $(function () {
            $('#container_BodyTemp').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: 'Body Temperature'
                },
                subtitle: {
                    text: '" + lblUsername.Text + @"'
                },
                xAxis: {
                    categories: [";

        for (int i = 0; i < dsdummy.Tables[2].Rows.Count; i++)
        {
            if (i == 0)
            {
                BodyTempGraph += @"'" + dsdummy.Tables[2].Rows[i]["day"].ToString() + "'";
            }
            else
            {
                BodyTempGraph += @",'" + dsdummy.Tables[2].Rows[i]["day"].ToString() + "'";
            }
        }
        BodyTempGraph += @"
                ]},
                yAxis: {
                    title: {
                        text: 'Body Temperature'
                    },
                    labels: {
                        formatter: function () {
                            return this.value + '';
                        }
                    }
                },
                tooltip: {
                    crosshairs: true,
                    shared: true
                },
                plotOptions: {
                    spline: {
                        marker: {
                            radius: 4,
                            lineColor: '#666666',
                            lineWidth: 1
                        }
                    }
                },
                series: [";
        foreach (DataColumn column in dsdummy.Tables[2].Columns)
        {
            if (column.ColumnName.ToLower() != "day")
            {
                BodyTempGraph += @"{
                                                        name: '" + column.ColumnName + @"',
                                                        data: [";
                int counter = 1;
                foreach (DataRow row in dsdummy.Tables[2].Rows)
                {
                    int rowcount = dsdummy.Tables[2].Rows.Count;

                    if (counter == rowcount)
                    {
                        BodyTempGraph += row[column].ToString();
                    }
                    else
                    {
                        BodyTempGraph += row[column].ToString() + ",";
                    }
                    counter++;
                }
                if (column.ColumnName == "body_temp")
                {
                    BodyTempGraph += "]}";
                }
                else
                {
                    BodyTempGraph += "]},";
                }
            }
        }
        BodyTempGraph += @"
                ]
            });
        });
		</script>";

        BodyTempGraph = BodyTempGraph.Replace("\\", "");
    }
    public void BindSpo2Graph(DataSet ds)
    {
        DataSet dsdummy = ds;

        Spo2Graph = @"<script type=\""text/javascript\"">
        $(function () {
            $('#container_Spo2').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: 'Spo2'
                },
                subtitle: {
                    text: '" + lblUsername.Text + @"'
                },
                xAxis: {
                    categories: [";

        for (int i = 0; i < dsdummy.Tables[3].Rows.Count; i++)
        {
            if (i == 0)
            {
                Spo2Graph += @"'" + dsdummy.Tables[3].Rows[i]["day"].ToString() + "'";
            }
            else
            {
                Spo2Graph += @",'" + dsdummy.Tables[3].Rows[i]["day"].ToString() + "'";
            }
        }
        Spo2Graph += @"
                ]},
                yAxis: {
                    title: {
                        text: 'Spo2'
                    },
                    labels: {
                        formatter: function () {
                            return this.value + '';
                        }
                    }
                },
                tooltip: {
                    crosshairs: true,
                    shared: true
                },
                plotOptions: {
                    spline: {
                        marker: {
                            radius: 4,
                            lineColor: '#666666',
                            lineWidth: 1
                        }
                    }
                },
                series: [";
        foreach (DataColumn column in dsdummy.Tables[3].Columns)
        {
            if (column.ColumnName.ToLower() != "day")
            {
                Spo2Graph += @"{
                                                        name: '" + column.ColumnName + @"',
                                                        data: [";
                int counter = 1;
                foreach (DataRow row in dsdummy.Tables[3].Rows)
                {
                    int rowcount = dsdummy.Tables[3].Rows.Count;

                    if (counter == rowcount)
                    {
                        Spo2Graph += row[column].ToString();
                    }
                    else
                    {
                        Spo2Graph += row[column].ToString() + ",";
                    }
                    counter++;
                }
                if (column.ColumnName == "spo2")
                {
                    Spo2Graph += "]}";
                }
                else
                {
                    Spo2Graph += "]},";
                }
            }
        }
        Spo2Graph += @"
                ]
            });
        });
		</script>";

        Spo2Graph = Spo2Graph.Replace("\\", "");
    }
    public void BindBloodGraph(DataSet ds)
    {
        DataSet dsdummy = ds;

        BloodGraph = @"<script type=\""text/javascript\"">
        $(function () {
            $('#container_blood').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: 'Blood Pressure Measurement'
                },
                subtitle: {
                    text: '" + lblUsername.Text + @"'
                },
                xAxis: {
                    categories: [";

        for (int i = 0; i < dsdummy.Tables[4].Rows.Count; i++)
        {
            if (i == 0)
            {
                BloodGraph += @"'" + dsdummy.Tables[4].Rows[i]["day"].ToString() + "'";
            }
            else
            {
                BloodGraph += @",'" + dsdummy.Tables[4].Rows[i]["day"].ToString() + "'";
            }
        }
        BloodGraph += @"
                ]},
                yAxis: {
                    title: {
                        text: 'Blood Pressure Level'
                    },
                    labels: {
                        formatter: function () {
                            return this.value + '';
                        }
                    }
                },
                tooltip: {
                    crosshairs: true,
                    shared: true
                },
                plotOptions: {
                    spline: {
                        marker: {
                            radius: 4,
                            lineColor: '#666666',
                            lineWidth: 1
                        }
                    }
                },
                series: [";
        foreach (DataColumn column in dsdummy.Tables[4].Columns)
        {
            if (column.ColumnName.ToLower() != "day")
            {
                BloodGraph += @"{
                                                        name: '" + column.ColumnName + @"',
                                                        data: [";
                int counter = 1;
                foreach (DataRow row in dsdummy.Tables[4].Rows)
                {
                    int rowcount = dsdummy.Tables[4].Rows.Count;

                    if (counter == rowcount)
                    {
                        BloodGraph += row[column].ToString();
                    }
                    else
                    {
                        BloodGraph += row[column].ToString() + ",";
                    }
                    counter++;
                }
                if (column.ColumnName == "high")
                {
                    BloodGraph += "]}";
                }
                else
                {
                    BloodGraph += "]},";
                }
            }
        }
        BloodGraph += @"
                ]
            });
        });
		</script>";

        BloodGraph = BloodGraph.Replace("\\", "");
    }
}