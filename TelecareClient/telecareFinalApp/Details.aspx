<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>TeleCare</title>
    <link rel="stylesheet" href="css/metro-bootstrap.css">
    <link rel="stylesheet" type="text/css" href="css/iconFont.css">
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <script src="js/metro-tab-control.js"></script>
    <script src="js/metro-tile-transform.js"></script>

    <%--<%= ChartData %>--%>

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>--%>
    <style type="text/css">
        $ {
            demo .css;
        }
    </style>

    <%= WeightGraph %>
    <%= StepsGraph %>
    <%= BodyTempGraph %>
    <%= Spo2Graph %>
    <%= BloodGraph %>   

    <style>
        body {
            padding: 80px 100px;
        }

        .showfigure {
            padding-left: 155px;
            padding-top: 20px;
        }

        .window {
            width: 900px;
            margin: 0 auto;
        }

        .window, .frame {
            overflow: auto;
        }

        #header {
            margin: 20px 0 20px 20px !important;
        }

        .tabs {
            padding-left: 16px !important;
        }

        a {
            color: inherit !important;
        }
    </style>
    <script src="highchart.js"></script>
    

</head>
<body class="metro">
    <form id="form1" runat="server">

        <div class="window shadow">
            <div class="caption">
                <span class="icon icon-phone"></span>
                <div class="title">TeleCare</div>
                <button class="btn-min"></button>
                <button class="btn-max"></button>
                <button class="btn-close"></button>
            </div>
            <div class="content  bg-darkCrimson">
                <div class="grid">
                    <div class="row fg-white" id="header">
                        <div class="span4">
                            <h1 class="fg-white">
                                <asp:Label ID="lblUsername" Text="No Data" runat="server"></asp:Label>
                            </h1>
                        </div>
                        <div class="span2">
                            <p class="fg-white">
                                <br>
                                <asp:Label ID="lblGenderAge" Text="" runat="server"></asp:Label><br />
                                <span id="spnCity" runat="server" class="fg-olive"></span>
                            </p>
                        </div>
                    </div>
                </div>


                <div class="tab-control" data-role="tab-control">
                    <ul class="tabs">
                        <li class="active"><a href="#_page_1">Health tracking</a></li>
                        <li><a href="#_page_2">Environment</a></li>
                        <li><a href="#_page_3">Background information</a></li>
                        <a style="color:white!important;" href="UserSearch.aspx">&nbsp;&nbsp;<i class="icon-arrow-left-3"></i></a>
                    </ul>

                    <div class="frames bg-white">

                        <div class="frame" id="_page_1">
                            <div class="tile double" data-click="transform" id="weight_steps" style="background-image: url('images/weight.jpg');">
                                <div class="showfigure">
                                    <span id="spnWeightInfo" runat="server">
                                    </span><br /><br />
                                    <span id="spnWeightTxt" runat="server" style="font-size: 30px; margin-top: 10px;">54</span> kg
                                </div>
                            </div>
                            <div class="tile double" data-click="transform" id="tile_steps" style="background-image: url('images/steps.jpg');">
                                <div class="showfigure">
                                    <span id="spnStepsInfo" runat="server">
                                    </span>
                                    <span id="spnStepsTxt" runat="server" style="font-size: 30px; margin-top: 10px;">54</span>
                                </div>
                            </div>
                            <div class="tile double" data-click="transform" id="bodytemp_steps"  style="background-image: url('images/body_temp.jpg');">
                                <div class="showfigure">
                                    <span id="spnBodyInfo" runat="server">
                                    </span>
                                    <span id="spnBodyTxt" runat="server" style="font-size: 30px; margin-top: 10px;">54</span> &deg;C
                                </div>

                            </div>
                            <div class="tile double op1" data-click="transform" id="spo2_steps"  style="background-image: url('images/spo2.jpg');">
                                <div class="showfigure">
                                    <span id="spnSpo2Info" runat="server"></span>
                                    <span id="spnSpo2Txt" runat="server" style="font-size: 30px; margin-top: 10px;"></span> %
                                </div>
                            </div>
                            <div class="tile double" data-click="transform" id="tile_blood" style="background-image: url('images/blood_press.jpg');">
                                <div class="showfigure">
                                    <span id="spnBloodInfo" runat="server">
                                    </span>
                                    <span id="spnBloodTxt" runat="server" style="font-size: 30px; margin-top: 10px;"></span><br />mm/hg
                                </div>
                            </div>
                        </div>


                        <!-- end of first tiles -->



                        <div class="frame" id="_page_2">
                            <div class="tile double double-vertical" data-click="transform" style="background-image: url('images/motion.jpg');">
                                <div class="showfigure" style="padding-left: 120px;">
                                    <span id="spnMotionInfo" runat="server" style="float: left;">
                                        <br />
                                        <br />
                                    </span>
                                    <span id="spnBedroomTxt" runat="server" style="margin-top: 24px; float: left;"></span>
                                    <br />
                                    <br />
                                    <span id="spnKitchenTxt" runat="server" style="margin-top: 11px; float: left;"></span>
                                    <br />
                                    <br />
                                    <span id="spnBathRoomTxt" runat="server" style="margin-top: 12px; float: left;"></span>
                                    <br />
                                    <span id="spnPiazzaTxt" runat="server" style="margin-top: 10px; float: left;"></span>
                                    <br />
                                </div>
                            </div>
                            <div class="tile double" data-click="transform" style="background-image: url('images/ambient_temp.jpg');">
                                <div class="showfigure">
                                    <span id="spnTempInfo" style="padding-left: 15px;" runat="server">today<br />
                                        <br />
                                    </span>
                                    <span id="spnTempText" runat="server" style="font-size: 30px; margin-top: 10px;"></span> &deg;C
                                </div>
                            </div>
                            <div class="tile double" data-click="transform" style="background-image: url('images/co.jpg');">
                                <div class="showfigure">
                                    <span id="spnCoInfo" runat="server">today<br />
                                        <br />
                                    </span>
                                    <span id="spnCoTxt" runat="server" style="font-size: 30px; margin-top: 10px;"></span> ppm
                                </div>
                            </div>
                            <div class="tile double" data-click="transform" style="background-image: url('images/smoke.jpg');">
                                <div class="showfigure">
                                    <span id="spnSmokeInfo" runat="server">today<br />
                                        <br />
                                    </span>
                                    <span id="spnSmokeTxt" runat="server" style="font-size: 14px; font-weight: bold; margin-top: 10px;"></span>
                                </div>
                            </div>
                        </div>



                        <!-- end of second tiles -->

                        <div class="frame" id="_page_3">
                            <div class="tile double double-vertical" data-click="transform" style="background-image: url('images/conditions.jpg');">
                                <div style="padding: 50px 10px 0px 10px;">
                                    <span id="spnCondition" runat="server">4 days ago<br />
                                        <br />
                                    </span>

                                </div>
                            </div>
                            <div class="tile double double-vertical" data-click="transform" style="background-image: url('images/allergies.jpg');">
                                <div style="padding: 50px 10px 0px 10px;">
                                    <span id="spnAllergies" runat="server">4 days ago<br />
                                        <br />
                                    </span>

                                </div>
                            </div>
                            <div class="tile double double-vertical" data-click="transform" style="background-image: url('images/medications.jpg');">
                                <div style="padding: 50px 10px 0px 10px;">
                                    <span id="spnMedication" runat="server">4 days ago<br />
                                        <br />
                                    </span>

                                </div>
                            </div>
                        </div>

                        <div class="frame" id="_weight_steps">
                            <h2><a href="#" id="weight_close"><i class="icon-arrow-left-3"></i></a>Weight</h2>

                            <div id="container_weight" style="width: 833px; height: 250px; margin: 0 auto; display: block; border: 5px solid #660000;">
                            weight
                            </div>
                        </div>

                        <div class="frame" id="_details_steps">
                            <h2><a href="#" id="steps_close"><i class="icon-arrow-left-3"></i></a>Steps
                            &nbsp;<span id="spnStepsDayCount" runat="server"></span>
                            &nbsp;<span id="spnStepsWeekCount" class="icon-arrow-down-3" runat="server"></span></h2>

                            <div id="container_Steps" style="width: 833px; height: 250px; margin: 0 auto; display: block; border: 5px solid #660000;">
                            steps
                            </div>
                        </div>


                        <div class="frame" id="_bodytemp_steps">
                            <h2><a href="#" id="bodytemp_close"><i class="icon-arrow-left-3"></i></a>Body Temperature</h2>

                            <div id="container_BodyTemp" style="width: 833px; height: 250px; margin: 0 auto; display: block; border: 5px solid #660000;">
                                bodytemp
                            </div>
                        </div>

                        <div class="frame" id="_spo2_steps">
                            <h2><a href="#" id="spo2_close"><i class="icon-arrow-left-3"></i></a>Spo2</h2>

                            <div id="container_Spo2" style="width: 833px; height: 250px; margin: 0 auto; display: block; border: 5px solid #660000;">
                            spo2</div>
                        </div>

                        <div class="frame" id="_blood_pressure">
                            <h2><a href="#" id="blood_close"><i class="icon-arrow-left-3"></i></a>Blood Pressure</h2>

                            <div id="container_blood" style="width: 833px; height: 250px; margin: 0 auto; display: block; border: 5px solid #660000;">
                            blood pressure</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>




        <script src="js/metro.min.html"></script>
        <script>
            $('.tab-control').tabcontrol();

            $("#weight_steps").on('click', function () {
                $('.frame').hide();
                $('#_weight_steps').show();

            });

            $('#weight_close').on('click', function () {
                $('.frame').hide();
                $('#_page_1').show();
            });



            $("#tile_steps").on('click', function () {
                $('.frame').hide();
                $('#_details_steps').show();

            });

            $('#steps_close').on('click', function () {
                $('.frame').hide();
                $('#_page_1').show();
            });


            $("#bodytemp_steps").on('click', function () {
                $('.frame').hide();
                $('#_bodytemp_steps').show();

            });

            $('#bodytemp_close').on('click', function () {
                $('.frame').hide();
                $('#_page_1').show();
            });




            $("#spo2_steps").on('click', function () {
                $('.frame').hide();
                $('#_spo2_steps').show();

            });

            $('#spo2_close').on('click', function () {
                $('.frame').hide();
                $('#_page_1').show();
            });

            
            $("#tile_blood").on('click', function () {
                $('.frame').hide();
                $('#_blood_pressure').show();

            });
            $('#blood_close').on('click', function () {
                $('.frame').hide();
                $('#_page_1').show();
            });

            $('.tile').each(function () {
                var opacity = Math.random();
                $(this).css("background-color", "rgb(238,238,238," + opacity + ")");
            });
        </script>
    </form>

</body>
</html>
