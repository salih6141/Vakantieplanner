<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Beheerder.aspx.vb" Inherits="Vakantieplanner.Beheerder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beheerder</title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
        <ul>
        <li><a>Welkom, <asp:Label ID="lblnaam" runat="server"></asp:Label>
            </a></li>
        
        <li><a href="Default.aspx">Aanvragen</a></li>
        <li><a href="NieuweAanvraag.aspx">Nieuwe aanvraag</a></li>
        <li style="float:right"><a class="active" href="Account/Logout.aspx">Afmelden</a></li>
        
        <asp:Menu class="active" href="Beheerder.aspx" ID="mnubeheer" runat="server" BackColor="#990000" CssClass="active">
            <Items>
                <asp:MenuItem  NavigateUrl="~/Beheerder.aspx" Text="Beheer" Value="Beheer"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BorderColor="#006600" />
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
            height: 46px;
        }

li {
    float: left;
            width: 167px;
        }
.active {
    background-color: #7d0000;
}
li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
            height: 18px;
        }

li a:hover {
    background-color: #111;
}
    </style>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Arial Black" Font-Overline="False" Text="Gebruikers toevoegen :"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Voornaam :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtVoornaam" runat="server" CausesValidation="True" Width="160px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Achternaam :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAchternaam" runat="server" Width="160px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Gebruikersnaam :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtGebruikersnaam" runat="server" Width="160px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="E-mail :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtmail" runat="server" style="margin-left: 0px" Width="161px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            Afdeling :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtafdeling" runat="server" Width="160px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            <asp:Button ID="btnToevoegen" runat="server" Text="Toevoegen" Width="325px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Arial Black" Font-Overline="False" Text="Gebruikers aanpassen :"></asp:Label>
        </p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vakantieplanner %>" ProviderName="<%$ ConnectionStrings:vakantieplanner.ProviderName %>" SelectCommand="SELECT Voornaam, Achternaam, Gebruikersnaam, Paswoord, Rol, Mailadres FROM gebruiker"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" datakeynames="Gebruikersnaam" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="452px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#006600" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:vakantieplanner %>" ProviderName="<%$ ConnectionStrings:vakantieplanner.ProviderName %>" SelectCommand="SELECT Voornaam, Achternaam, Gebruikersnaam, Paswoord, Rol, Mailadres, Afdeling_AfdelingNaam FROM gebruiker WHERE (Gebruikersnaam = @gebruikersnaam)"></asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:DetailsView ID="DetailsView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Height="50px" Visible="False" Width="263px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
        </p>
        <p>
            <asp:Button ID="btnverwijder" runat="server" Text="Verwijderen" Visible="False" Width="123px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAnnuleren" runat="server" Text="Annuleren" Visible="False" Width="123px" />
        </p>
      
    </form>
</body>
</html>
