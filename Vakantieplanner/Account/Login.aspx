<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Vakantieplanner.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="right">
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx" LoginButtonText="Aanmelden" PasswordLabelText="Wachtwoord:" RememberMeText="Onthoud mijn gegevens." style="margin-right: 0px" TitleText="Aanmelden" UserNameLabelText="Gebruikersnaam:">
        </asp:Login>
    </div>
        <div style="height: 500px">
            <img alt="" class="auto-style" src="../Foto's/YUs5qbQb.png" />
        </div>
    </form>
    <style>
        body {
            height: 100%;
            background: linear-gradient(90deg, #000000 70%, #ffffff 30%);
        }
        .auto-style{
            width: 649px;
            height: 537px;
            margin-left: 76px;
        }
    </style>
</body>
</html>
