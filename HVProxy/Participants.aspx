<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Participants.aspx.cs" Inherits="Participants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Participants</title>
    <style>
        table {
            border-collapse: collapse;
        }
        thead {
            font-weight: bold;
        }
        tr {
            border: 1px solid black;
        }
        td {
            padding: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ParticipantId"
                ItemType="HVProxy.Models.Participant" SelectMethod="GetParticipants">
                <LayoutTemplate>
                    <table>
                        <thead>
                            <td>ParticipantId</td>
                            <td>ParticipantName</td>
                            <td>TimeTokenGenerated</td>
                            <td>ParticipantCode</td>
                            <td>SecurityQuestion</td>
                            <td>SecurityAnswer</td>
                            <td>HasAuthorised</td>
                            <td>PersonId</td>
                            <td>RecordId</td>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td><%#:Item.ParticipantId%></td>
                        <td><%#:Item.ParticipantName%></td>
                        <td><%#:Item.TimeTokenGenerated%></td>
                        <td><%#:Item.ParticipantCode%></td>
                        <td><%#:Item.SecurityQuestion%></td>
                        <td><%#:Item.SecurityAnswer%></td>
                        <td><%#:Item.HasAuthorised%></td>
                        <td><%#:Item.PersonId%></td>
                        <td><%#:Item.RecordId%></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        <asp:Button ID="GetValidatedConnectionsBtn" runat="server" Text="Get Validated Connections" />
    </form>
</body>
</html>
