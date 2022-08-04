<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NieuweAanvraag.aspx.vb" Inherits="Vakantieplanner.NieuweAanvraag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nieuwe aanvraag</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <ul>
        <li><a>Welkom, <asp:Label ID="lblnaam" runat="server"></asp:Label>
            </a></li>
        
        <li><a href="Default.aspx">Aanvragen</a></li>
        <li><a class="active" href="NieuweAanvraag.aspx">Nieuwe aanvraag</a></li>
        <li style="float:right"><a class="active" href="Account/Logout.aspx">Afmelden</a></li>
             
        <asp:Menu href="Beheerder.aspx" ID="mnubeheer" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/Beheerder.aspx" Text="Beheer" Value="Beheer"></asp:MenuItem>
            </Items>
            </asp:Menu>
    </ul>
          <br />
        <br />
        
         <p>
             &nbsp;</p>
             <asp:Calendar ID="CalenderBegin" runat="server" TitleStyle-BackColor="#333333" BackColor="White" BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" Width="400px" DayNameFormat="Shortest" TitleFormat="Month">
             <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
                 <DayStyle Width="14%" />
             <NextPrevStyle Font-Size="8pt" ForeColor="White" />
             <OtherMonthDayStyle ForeColor="#999999" />
             <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                 <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
             <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
             <TodayDayStyle BackColor="#CCCC99" />
         </asp:Calendar>
         <asp:Calendar ID="CalenderEinde" runat="server" TitleStyle-BackColor="#333333" BackColor="White" BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" Width="400px" DayNameFormat="Shortest" TitleFormat="Month">
             <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
             <DayStyle Width="14%" />
             <NextPrevStyle Font-Size="8pt" ForeColor="White" />
             <OtherMonthDayStyle ForeColor="#999999" />
             <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
             <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
             <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
             <TodayDayStyle BackColor="#CCCC99" />
         </asp:Calendar>
        </div>
         <div>
        </div>
    <style>
        ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
            height: 48px;
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
}

li a:hover {
    background-color: #111;
}
    </style>
        <p>
            <asp:TextBox ID="txtreden" runat="server" Height="80px" Width="788px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Indienen" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Annuleren" />
        </p>
    </form>
    </body>
</html>
