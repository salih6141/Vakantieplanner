Imports MySql.Data.MySqlClient
Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Visible = True
        GridView2.Visible = True

        Dim strafdeling As String = "SELECT Afdeling_AfdelingNaam FROM Gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"

        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()

        con.Open()
        'De commands declareren en uitvoeren via executescalar
        Dim cmdafdeling As MySqlCommand = New MySqlCommand(strafdeling, con)

        Session("afdeling") = cmdafdeling.ExecuteScalar().ToString
        'parameters voor gridview2

        Response.Redirect("Default.aspx")


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim strsqlbaas As String = "SELECT Afdeling_AfdelingNaam FROM baas WHERE (Gebruiker_Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strsqlNaam As String = "SELECT Voornaam from gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strRol As String = "SELECT rol FROM gebruiker WHERE (Gebruikersnaam = '" & Session("Gebruikersnaam") & "')"
        Dim strnaam As String

        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()


        con.Open()
        'De commands declareren en uitvoeren via executescalar
        Dim cmdbaas As MySqlCommand = New MySqlCommand(strsqlbaas, con)
        Dim cmd2 As MySqlCommand = New MySqlCommand(strsqlNaam, con)
        Dim cmdRol As MySqlCommand = New MySqlCommand(strRol, con)

        Session("Rol") = cmdRol.ExecuteScalar().ToString
        strnaam = cmd2.ExecuteScalar().ToString


        SqlDataSource2.SelectParameters.Add("afdelingsnaam", Session("afdeling"))
        '
        'De naam invoeren in de label
        lblnaam.Text = strnaam.ToString

        'De select parameter invoeren met de session("Gebruikersnaam")
        SqlDataSource1.SelectParameters.Add("Gebruikersnaam", Session("Gebruikersnaam"))

        'De menu van de beheerder instellen als de rol "beheerder" is.
        If Session("Rol") = "beheerder" Then
            mnubeheer.Visible = True
        Else
            mnubeheer.Visible = False
        End If

        'als de gebruiker te vinden is in de table baas laat je de gridview van de werknemers zien
        If cmdbaas.ExecuteScalar Is Nothing Then
            GridView2.Visible = False
            Label1.Visible = False
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session("aanvraagnr") = GridView1.SelectedValue
        Response.Redirect("AanvraagDetailsView.aspx")
        SqlDataSource1.SelectParameters.Clear()
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        Session("aanvraagnr") = GridView2.SelectedValue
        Response.Redirect("AanvraagDetailsView.aspx")
        SqlDataSource2.SelectParameters.Clear()
    End Sub

End Class