<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Vakantieplanner._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aanvragen</title>
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
            height: 47px;
        }

li {
    float: left;
            width: 167px;
            height: 52px;
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
}

li a:hover {
    background-color: #111;
}
    </style>
        <p>
            &nbsp;</p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vakantieplanner %>" ProviderName="<%$ ConnectionStrings:vakantieplanner.ProviderName %>" SelectCommand="SELECT AanvraagNr, Begin, Einde, Reden, Toestand FROM aanvraag WHERE (Gebruiker_Gebruikersnaam = @Gebruikersnaam) ORDER BY Begin" DeleteCommand="DELETE FROM aanvraag WHERE (AanvraagNr = @aanvraagnr)">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="AanvraagNr" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="530px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="AanvraagNr" HeaderText="AanvraagNr" InsertVisible="false" ReadOnly="true" SortExpression="AanvraagNr" />
                <asp:BoundField DataField="Begin" HeaderText="Begin" SortExpression="Begin" />
                <asp:BoundField DataField="Einde" HeaderText="Einde" SortExpression="Einde" />
                <asp:BoundField DataField="Reden" HeaderText="Reden" SortExpression="Reden" />
                <asp:BoundField DataField="Toestand" HeaderText="Toestand" SortExpression="Toestand" />

            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="anvragen werknemers" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="GridView2" runat="server" DataKeyNames="AanvraagNr" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Width="535px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:vakantieplanner %>" ProviderName="<%$ ConnectionStrings:vakantieplanner.ProviderName %>" SelectCommand="SELECT AanvraagNr, Begin, Einde, Gebruiker_Gebruikersnaam AS Expr1, Toestand, Reden, Afdeling_AfdelingNaam FROM aanvraag WHERE (Afdeling_AfdelingNaam = @afdelingsnaam) AND (Toestand LIKE '%open%')" UpdateCommand="UPDATE aanvraag SET Toestand = @Toestand WHERE (AanvraagNr = @aanvraagnr)"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" Text="Aanvragen werknemers" Visible="False" />
    </form>
    </body>
</html>
