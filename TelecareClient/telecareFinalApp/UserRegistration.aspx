<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

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
                                <asp:Label ID="lblUsername" Text="User Regisration" runat="server"></asp:Label>
                            </h1>
                        </div>

                    </div>
                </div>


                <div class="tab-control" data-role="tab-control" style="padding: 15px;">
                    <ul class="tabs">
                        <li class="active"><a href="#_page_1">User Regisration</a></li>
                         <a style="color:white!important;" href="UserSearch.aspx">&nbsp;&nbsp;<img title="Home" src="images/home.png" width="30px" height="30px" /> </a>

                    </ul>

                    <table width="100%" border="0" cellspacing="1" cellpadding="0" class="normal">
                       
                        <tr>
                            <td style="padding-left: 10px;" width="5%">User Name
                            </td>
                            <td width="40%">

                                <input name="textfield2" type="text" class="textfield" id="txtname" runat="server" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtname" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="register"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left: 10px;">User Gender
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="textfield">
                                    <%--<asp:ListItem Value="0">select gender</asp:ListItem>--%>
                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                    <asp:ListItem Value="2">Female</asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left: 10px;">Age
                            </td>
                            <td>
                                <input name="textfield5" type="text" class="textfield" id="txtage" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="register"
                                    ControlToValidate="txtage"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left: 10px;">City
                            </td>
                            <td>
                                <select id="ddlcitys" runat="server" class="textfield">
                                    
                                        <option>Bedfordshire</option>
                                        <option>Berkshire</option>
                                        <option>Bristol</option>
                                        <option>Buckinghamshire</option>
                                        <option>Cambridgeshire</option>
                                        <option>Cheshire</option>
                                        <option>City of London</option>
                                        <option>Cornwall</option>
                                        <option>Cumbria</option>
                                        <option>Derbyshire</option>
                                        <option>Devon</option>
                                        <option>Dorset</option>
                                        <option>Durham</option>
                                        <option>East Riding of Yorkshire</option>
                                        <option>East Sussex</option>
                                        <option>Essex</option>
                                        <option>Gloucestershire</option>
                                        <option>Greater London</option>
                                        <option>Greater Manchester</option>
                                        <option>Hampshire</option>
                                        <option>Herefordshire</option>
                                        <option>Hertfordshire</option>
                                        <option>Isle of Wight</option>
                                        <option>Kent</option>
                                        <option>Lancashire</option>
                                        <option>Leicestershire</option>
                                        <option>Lincolnshire</option>
                                        <option>Merseyside</option>
                                        <option>Norfolk</option>
                                        <option>North Yorkshire</option>
                                        <option>Northamptonshire</option>
                                        <option>Northumberland</option>
                                        <option>Nottinghamshire</option>
                                        <option>Oxfordshire</option>
                                        <option>Rutland</option>
                                        <option>Shropshire</option>
                                        <option>Somerset</option>
                                        <option>South Yorkshire</option>
                                        <option>Staffordshire</option>
                                        <option>Suffolk</option>
                                        <option>Surrey</option>
                                        <option>Tyne and Wear</option>
                                        <option>Warwickshire</option>
                                        <option>West Midlands</option>
                                        <option>West Sussex</option>
                                        <option>West Yorkshire</option>
                                        <option>Wiltshire</option>
                                        <option>Worcestershire</option>
                                   
                                        <option>Aberdeenshire</option>
                                        <option>Angus</option>
                                        <option>Argyllshire</option>
                                        <option>Ayrshire</option>
                                        <option>Banffshire</option>
                                        <option>Berwickshire</option>
                                        <option>Buteshire</option>
                                        <option>Cromartyshire</option>
                                        <option>Caithness</option>
                                        <option>Clackmannanshire</option>
                                        <option>Dumfriesshire</option>
                                        <option>Dunbartonshire</option>
                                        <option>East Lothian</option>
                                        <option>Fife</option>
                                        <option>Inverness-shire</option>
                                        <option>Kincardineshire</option>
                                        <option>Kinross</option>
                                        <option>Kirkcudbrightshire</option>
                                        <option>Lanarkshire</option>
                                        <option>Midlothian</option>
                                        <option>Morayshire</option>
                                        <option>Nairnshire</option>
                                        <option>Orkney</option>
                                        <option>Peeblesshire</option>
                                        <option>Perthshire</option>
                                        <option>Renfrewshire</option>
                                        <option>Ross-shire</option>
                                        <option>Roxburghshire</option>
                                        <option>Selkirkshire</option>
                                        <option>Shetland</option>
                                        <option>Stirlingshire</option>
                                        <option>Sutherland</option>
                                        <option>West Lothian</option>
                                        <option>Wigtownshire</option>
                                   
                                        <option>Anglesey</option>
                                        <option>Brecknockshire</option>
                                        <option>Caernarfonshire</option>
                                        <option>Carmarthenshire</option>
                                        <option>Cardiganshire</option>
                                        <option>Denbighshire</option>
                                        <option>Flintshire</option>
                                        <option>Glamorgan</option>
                                        <option>Merioneth</option>
                                        <option>Monmouthshire</option>
                                        <option>Montgomeryshire</option>
                                        <option>Pembrokeshire</option>
                                        <option>Radnorshire</option>
                                   
                                        <option>Antrim</option>
                                        <option>Armagh</option>
                                        <option>Down</option>
                                        <option>Fermanagh</option>
                                        <option>Londonderry</option>
                                        <option>Tyrone</option>
                                    
                                </select>                                
                            </td>

                        </tr>

                        <tr>
                            <td style="padding-left: 10px;">Conditions
                            </td>
                            <td>
                                <textarea name="textfield4" rows="3" class="textfield" id="txtcondition" runat="server" style="width: 250px;"></textarea>
                            </td>

                        </tr>

                        <tr>
                            <td style="padding-left: 10px;">Allergies
                            </td>
                            <td>
                               <textarea name="textfield4" rows="3" class="textfield" id="txtallergies" runat="server" style="width: 250px;"></textarea>
                                
                            </td>

                        </tr>
                        <tr>
                            <td style="padding-left: 10px;">Medications
                            </td>
                            <td>
                                
                                <textarea name="textfield4" rows="3" class="textfield" id="txtmedication" runat="server" style="width: 250px;"></textarea>
                               
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btnregister" runat="server" CssClass="pink-btn" Text="Register"
                                    OnClick="btnregister_Click" ValidationGroup="register" />
                                <input type="reset" value="Reset" />
                            </td>
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
