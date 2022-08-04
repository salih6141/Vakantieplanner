Imports System.Net.Mail

Imports MySql.Data.MySqlClient
Public Class AanvraagDetailsView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsqlNaam As String = "SELECT Voornaam from gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strsqlbaas As String = "SELECT Afdeling_AfdelingNaam FROM baas WHERE (Gebruiker_Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim toestand As String = "SELECT Toestand FROM aanvraag WHERE (aanvraagnr= '" & Session("aanvraagnr") & "')"
        Dim strnaam As String
        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()


        con.Open()
        Dim cmdtoestand As MySqlCommand = New MySqlCommand(toestand, con)
        Dim cmd2 As MySqlCommand = New MySqlCommand(strsqlNaam, con)
        Dim cmdbaas As MySqlCommand = New MySqlCommand(strsqlbaas, con)
        strnaam = cmd2.ExecuteScalar().ToString
        lblnaam.Text = strnaam.ToString
        SqlDataSource1.SelectParameters.Add("aanvraagnr", Session("aanvraagnr"))

        If Session("Rol") = "beheerder" Then
            mnubeheer.Visible = True
        Else
            mnubeheer.Visible = False
        End If

        If cmdbaas.ExecuteScalar Is Nothing Then
            btnaccepteren.Visible = False
            btnweiger.Visible = False
            btnDelete.Visible = True
        Else
            btnaccepteren.Visible = True
            btnweiger.Visible = True
            btnDelete.Visible = False
        End If
        If cmdtoestand.ExecuteScalar().ToString = "geaccepteerd" Or cmdtoestand.ExecuteScalar().ToString = "geweigerd" Then
            btnDelete.Visible = False
        Else
            btnDelete.Visible = True
        End If

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strsqlDelete As String = "DELETE FROM aanvraag WHERE (AanvraagNr = '" & Session("aanvraagnr") & "')"
        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()
        con.Open()
        Dim cmdDelete As MySqlCommand = New MySqlCommand(strsqlDelete, con)


        If cmdDelete.ExecuteNonQuery() < 1 Then
            MsgBox("Er is iets misgelopen, de aanvraag is niet verwijdert.")
            Response.Redirect("Default.aspx")
        Else
            MsgBox("de aanvraag is verwijdert.")
            Response.Redirect("Default.aspx")
        End If

        con.Close()
    End Sub

    Protected Sub btnaccepteren_Click(sender As Object, e As EventArgs) Handles btnaccepteren.Click
        Dim straccept As String = "UPDATE aanvraag SET Toestand='geaccepteerd' WHERE (aanvraagnr= '" & Session("aanvraagnr") & "') "
        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()
        con.Open()
        Dim cmdAccept As MySqlCommand = New MySqlCommand(straccept, con)
        If cmdAccept.ExecuteNonQuery() < 1 Then
            MsgBox("De aanvraag kon niet geaccepteerd worden." & vbCrLf & "Er is iets misgelopen.")
            Response.Redirect("Default.aspx")
        Else
            MsgBox("De aanvraag is geaccepteerd.")
            Try
                Dim Smtp_Server As New SmtpClient("smtp.gmail.com")
                Dim e_mail As New MailMessage()

                e_mail.Subject = "Aanvraag geaccepteerd "
                e_mail.From = New MailAddress("HelpVakantiePlanner@gmail.com")
                Smtp_Server.Credentials = New System.Net.NetworkCredential("HelpVakantiePlanner@gmail.com", "xdarkthiefx")

                e_mail.To.Add("komutsalih@gmail.com")
                e_mail.Body = "Je aanvraag voor een vakantie is geaccepteerd"

                Smtp_Server.EnableSsl = True
                Smtp_Server.Port = "587"
                Smtp_Server.Send(e_mail)
                MsgBox("E-mail is verstuurd")

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try
            Response.Redirect("Default.aspx")
        End If

    End Sub

    Protected Sub btnweiger_Click(sender As Object, e As EventArgs) Handles btnweiger.Click
        Dim strweiger As String = "UPDATE aanvraag SET Toestand='geweigerd' WHERE (aanvraagnr= '" & Session("aanvraagnr") & "')"
        Dim con As MySqlConnection = New MySqlConnection()
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()
        con.Open()
        Dim cmdweiger As MySqlCommand = New MySqlCommand(strweiger, con)
        If cmdweiger.ExecuteNonQuery() < 1 Then
            MsgBox("De aanvraag kon niet geweigerd worden." & vbCrLf & "Er is iets misgelopen.")
            Response.Redirect("Default.aspx")
        Else
            MsgBox("De aanvraag is geweigerd.")
            Try
                Dim Smtp_Server As New SmtpClient("smtp.gmail.com")
                Dim e_mail As New MailMessage()

                e_mail.Subject = "Aanvraag geweigerd"
                e_mail.From = New MailAddress("HelpVakantiePlanner@gmail.com")
                Smtp_Server.Credentials = New System.Net.NetworkCredential("HelpVakantiePlanner@gmail.com", "xdarkthiefx")

                e_mail.To.Add("komutsalih@gmail.com")
                e_mail.Body = "Je aanvraag voor een vakantie is geweigerd."

                Smtp_Server.EnableSsl = True
                Smtp_Server.Port = "587"
                Smtp_Server.Send(e_mail)
                MsgBox("E-mail is verstuurd")

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class