<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enroll.aspx.cs" Inherits="Enroll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enroll a Participant</title>
    <style>
        .form-inner {
            display: table;
        }
        .form-row {
            display: table-row;
        }
        .form-row>* {
            display: table-cell;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="form-inner">
        <div class="form-row">
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
        </div>
        <div class="form-row">
            <asp:Label ID="Label2" runat="server" Text="Security Question"></asp:Label>
            <asp:TextBox ID="QuestionTextBox" runat="server"></asp:TextBox>
        </div>
        <div class="form-row">
            <asp:Label ID="Label3" runat="server" Text="Security Answer"></asp:Label>
            <asp:TextBox ID="AnswerTextBox" runat="server"></asp:TextBox>
        </div>
    </div>
        <p>
            <asp:Button ID="SubmitBtn" runat="server" Text="Enroll" />
        </p>
    <div class="form-inner">
        <div class="form-row">
            <asp:Label ID="Label4" runat="server" Text="Activation Code"></asp:Label>
            <asp:TextBox ID="CodeTextBox" runat="server"></asp:TextBox>
        </div>
    </div>
    </form>
</body>
</html>
