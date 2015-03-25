<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSearch.aspx.cs" Inherits="UserSearch" %>

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
    <link href="style.css" rel="stylesheet" type="text/css" />



    <style>
        body {
            padding: 80px 100px;
        }

        .showfigure {
            padding-left: 160px;
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
                        <div class="">
                            <h1 class="fg-white">
                                <asp:Label ID="lblUsername" Text="User Search" runat="server"></asp:Label>
                            </h1>
                        </div>

                    </div>
                </div>


                <div class="tab-control" data-role="tab-control" style="padding: 15px;">
                    <ul class="tabs">
                        <li class="active"><a href="#_page_1">User Search</a></li>

                    </ul>

                    <table width="100%" border="0" cellspacing="1" cellpadding="0" class="normal">
                        <tr>
                            <td colspan="2">
                                <h3>&nbsp;</h3>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px;" width="5%">User Name</td>
                            <td width="40%">

                                <input name="textfield2" type="text" class="textfield" id="txtname" runat="server" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtname" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="register"></asp:RequiredFieldValidator>
                                <asp:Button ID="btnserch" runat="server" CssClass="pink-btn" Text="Search"
                                    OnClick="btnregister_Click" ValidationGroup="register" />
                                &nbsp;&nbsp; <a href="UserRegistration.aspx"><img title="Add New" src="images/addnew.jpg" width="30px" height="30px" /> </a>
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>

                        <tr>
                            <td style="padding-left: 10px;" width="5%">&nbsp;</td>
                            <td width="40%">



                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" PageSize="5" Width="700px" OnRowCommand="GridView1_RowCommand">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="user_id" HeaderText="ID" SortExpression="ID" />
                                        <asp:BoundField DataField="user_name" HeaderText="Name" SortExpression="Name" />

                                        <asp:BoundField DataField="user_gender" HeaderText="Gender" SortExpression="Gender" />
                                        <asp:BoundField DataField="user_age" HeaderText="Age" SortExpression="Age" />
                                        <asp:BoundField DataField="user_city" HeaderText="City" SortExpression="City" />
                                        <asp:TemplateField HeaderText="View/Edit" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <a href="Details.aspx?user_id=<%# Eval("user_id") %>">View</a>
                                                <a href="UserRegistration.aspx?user_id=<%# Eval("user_id") %>">Edit</a>
                                                <asp:LinkButton ID="lnkbtndel" CommandName="btndel" CommandArgument='<%# Eval("user_id") %>' runat="server" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TelecareConnectionString %>" SelectCommand="SELECT [user_name], [user_id], [user_gender], [user_age], [user_city] FROM [telecare_master]"></asp:SqlDataSource>



                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td colspan="3"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <script src="js/metro.min.html"></script>
        <script>
            $('.tab-control').tabcontrol();

            $("#tile_steps").on('click', function () {
                $('.frame').hide();
                $('#_details_steps').show();

            });

            $('#steps_close').on('click', function () {
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
