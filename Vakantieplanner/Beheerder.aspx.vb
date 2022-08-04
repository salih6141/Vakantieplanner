Imports MySql.Data.MySqlClient
Public Class Beheerder
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strsqlNaam As String = "SELECT Voornaam from gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strnaam As String
        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()


        con.Open()
        'De commands declareren en uitvoeren via executescalar
        Dim cmd2 As MySqlCommand = New MySqlCommand(strsqlNaam, con)
        strnaam = cmd2.ExecuteScalar().ToString

        'De naam invoeren in de label
        lblnaam.Text = strnaam.ToString

    End Sub

    Protected Sub btnToevoegen_Click(sender As Object, e As EventArgs) Handles btnToevoegen.Click

        'integer voor de msgbox Yes or No vraag
        Dim antwoord As Integer
        '

        Dim strVnaam As String = txtVoornaam.Text
        Dim strAchternaam As String = txtAchternaam.Text
        Dim strGebuikersnaam As String = txtGebruikersnaam.Text
        Dim strpassword As String = txtVoornaam.Text & "123"
        Dim strrol As String = "gebruiker"
        Dim mail As String = txtmail.Text
        Dim afdeling As String = txtafdeling.Text


        If strAchternaam = "" Or strVnaam = "" Or strGebuikersnaam = "" Or strpassword = "" Or strrol = "" Or mail = "" Or afdeling = "" Then
            MsgBox("Gelieve alle velden in te vullen.")
        Else
            Dim SqlInsert = "INSERT INTO gebruiker (Voornaam,Achternaam,Gebruikersnaam,Paswoord,Rol,Mailadres,Afdeling_AfdelingNaam) VALUES('" & strVnaam & "' , '" & strAchternaam & "' , '" & strGebuikersnaam & "' , '" & strpassword & "' , '" & strrol & "' , '" & Mail & "' , '" & afdeling & "')"
            Dim con As MySqlConnection = New MySqlConnection()
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()

            con.Open()
            Dim cmdInsert As MySqlCommand = New MySqlCommand(SqlInsert, con)

            If cmdInsert.ExecuteNonQuery() < 1 Then
                MsgBox("Er is iets misgelopen, de gebruiker is niet toegevoegd.")
            Else
                antwoord = MsgBox("De gebruiker is succesvol toegevoegd aan de database, Wil je nog een gebruiker toevoegen?", vbYesNo + vbQuestion, "Nieuwe Gerbuiker")
                txtAchternaam.Text = ""
                txtafdeling.Text = ""
                txtGebruikersnaam.Text = ""
                txtmail.Text = ""
                txtVoornaam.Text = ""
                GridView1.DataBind()
                If antwoord = vbYes Then
                    Response.Redirect("Beheerder.aspx")
                Else
                    Response.Redirect("Default.aspx")
                End If

            End If
            End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session("naam") = GridView1.SelectedDataKey.Value.ToString
        DetailsView1.Visible = True
        btnverwijder.Visible = True
        btnAnnuleren.Visible = True
        SqlDataSource2.SelectParameters.Add("Gebruikersnaam", Session("naam"))
        GridView1.Visible = False



    End Sub

    Protected Sub btnverwijder_Click(sender As Object, e As EventArgs) Handles btnverwijder.Click
        Dim strverwijderaanvragen As String = "DELETE FROM Aanvraag WHERE(Gebruiker_Gebruikersnaam= '" & Session("naam") & "')"
        Dim strVerwijderRecord As String = "DELETE FROM Gebruiker WHERE(Gebruikersnaam= '" & Session("naam") & "')"
        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()

        con.Open()
        Dim cmdverwijderaanvragen As MySqlCommand = New MySqlCommand(strverwijderaanvragen, con)
        Dim cmdverwijder As MySqlCommand = New MySqlCommand(strVerwijderRecord, con)
        If cmdverwijderaanvragen.ExecuteNonQuery() < 1 Then
            If cmdverwijder.ExecuteNonQuery() < 1 Then
                MsgBox("Er is iets migelopen tijdens het verwijderen. " & vbCrLf & "De record kon niet verwijdert worden.")

            Else
                MsgBox("De records van de gebruiker en de gebruiker zelf is verwijdert van de database.")
                SqlDataSource2.SelectParameters.Clear()
                GridView1.Visible = True
                DetailsView1.Visible = False
                btnverwijder.Visible = False
                btnAnnuleren.Visible = False
                GridView1.DataBind()
            End If
        Else
            If cmdverwijder.ExecuteNonQuery() < 1 Then
                MsgBox("Er is iets migelopen tijdens het verwijderen. " & vbCrLf & "De record kon niet verwijdert worden.")

            Else
                MsgBox("De records van de gebruiker en de gebruiker zijn verwijdert van de database.")
                SqlDataSource2.SelectParameters.Clear()
                GridView1.Visible = True
                DetailsView1.Visible = False
                btnverwijder.Visible = False
                btnAnnuleren.Visible = False
                GridView1.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnAnnuleren_Click(sender As Object, e As EventArgs) Handles btnAnnuleren.Click
        SqlDataSource2.SelectParameters.Clear()
        GridView1.Visible = True
        DetailsView1.Visible = False
        btnverwijder.Visible = False
        btnAnnuleren.Visible = False

    End Sub
End Class