<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AanvraagDetailsView.aspx.vb" Inherits="Vakantieplanner.AanvraagDetailsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aanvraag detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
        <li><a>Welkom, <asp:Label ID="lblnaam" runat="server"></asp:Label>
            </a></li>
        
        <li><a class="active" href="Default.aspx">Aanvragen</a></li>
        <li><a href="NieuweAanvraag.aspx">Nieuwe aanvraag</a></li>
        <li style="float:right"><a class="active" href="Account/Logout.aspx">Afmelden</a></li>
             
        <asp:Menu href="Beheerder.aspx" ID="mnubeheer" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/Beheerder.aspx" Text="Beheer" Value="Beheer"></asp:MenuItem>
            </Items>
            </asp:Menu>
    </ul>
    </div>
    <style>
        ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
            height: 54px;
        }

li {
    float: left;
            width: 167px;
        }
.active {
    background-color: #4CAF50;
}
li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
            height: 24px;
        }

li a:hover {
    background-color: #111;
}
    </style>
        <p>
            &nbsp;</p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vakantieplanner %>" DeleteCommand="DELETE FROM aanvraag WHERE (AanvraagNr = @aanvraagnr)" ProviderName="<%$ ConnectionStrings:vakantieplanner.ProviderName %>" SelectCommand="SELECT AanvraagNr, Begin, Einde, Afdeling_AfdelingNaam, Reden, Toestand FROM aanvraag WHERE (AanvraagNr = @aanvraagnr)"></asp:SqlDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" DataSourceID="SqlDataSource1"></asp:DetailsView>
        <asp:Button ID="btnDelete" runat="server" Text="Verwijder" Width="81px" />
        <asp:Button ID="btnaccepteren" runat="server" Text="Accepteren" />
        <asp:Button ID="btnweiger" runat="server" Text="Weigeren" Width="83px" />
    </form>
    </body>
</html>
