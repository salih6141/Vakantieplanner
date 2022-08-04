Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports System.Net

Public Class NieuweAanvraag
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'code voor toevoegen naam aan menubalk (Welkom , JENAAM)
        Dim strsqlNaam As String = "SELECT Voornaam from gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strafdelingsnaam As String = "SELECT Afdeling_AfdelingNaam FROM gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strafdelingnaam As String
        Dim strnaam As String
        Dim con As MySqlConnection = New MySqlConnection
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()

        con.Open()
        Dim cmdanaam As MySqlCommand = New MySqlCommand(strafdelingsnaam, con)
        Dim cmd2 As MySqlCommand = New MySqlCommand(strsqlNaam, con)
        strafdelingnaam = cmdanaam.ExecuteScalar().ToString
        strnaam = cmd2.ExecuteScalar().ToString
        lblnaam.Text = strnaam.ToString
        Session("Afdelingsnaam") = strafdelingnaam

        If Session("Rol") = "beheerder" Then
            mnubeheer.Visible = True
        Else
            mnubeheer.Visible = False
        End If



    End Sub

    Protected Sub CalendarBegin_SelectionChanged(sender As Object, e As EventArgs) Handles CalenderBegin.SelectionChanged
        Dim begin As Date = CalenderBegin.SelectedDate
        Session("Begin") = begin
    End Sub

    Protected Sub CalenderEinde_SelectionChanged(sender As Object, e As EventArgs) Handles CalenderEinde.SelectionChanged
        Dim einde As Date = CalenderEinde.SelectedDate
        Session("Einde") = einde
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session("Begin") = vbEmpty
        Session("Einde") = vbEmpty
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' integer voor msgbox "Yes" or "No"
        Dim antwoord As Integer
        '
        Dim strvoornaam As String = "SELECT Voornaam FROM Gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strachternaam As String = "SELECT Achternaam FROM Gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strmail As String = "SELECT mailadres FROM gebruiker WHERE (Gebruikersnaam= '" & Session("Gebruikersnaam") & "')"
        Dim strSqlNieuw As String = "INSERT INTO aanvraag(BEGIN , Einde, Gebruiker_Gebruikersnaam, Afdeling_AfdelingNaam, Reden )  VALUES ('" & Session("Begin") & "' , '" & Session("Einde") & "' , '" & Session("Gebruikersnaam") & "' , '" & Session("Afdelingsnaam") & "' , '" & txtreden.Text & "')"
        Dim con As MySqlConnection = New MySqlConnection
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()


        con.Open()
        Dim cmdVoornaam As MySqlCommand = New MySqlCommand(strvoornaam, con)
        Session("Voornaam") = cmdVoornaam.ExecuteScalar().ToString()
        Dim cmdAchternaam As MySqlCommand = New MySqlCommand(strachternaam, con)
        Session("Achternaam") = cmdAchternaam.ExecuteScalar().ToString()
        Dim cmdmail As MySqlCommand = New MySqlCommand(strmail, con)
        Session("Mail") = cmdmail.ExecuteScalar.ToString()
        Dim cmd As MySqlCommand = New MySqlCommand(strSqlNieuw, con)
        If cmd.ExecuteNonQuery() < 1 Then
            MsgBox("De record kon niet toegevoegd worden.")
            Response.Redirect("Default.aspx")
        Else
            antwoord = MsgBox("De record is succesvol toegevoegd, wil je nog een aanvraag indienen?", vbYesNo + vbQuestion, "Nieuwe aanvraag")
            Try
                Dim Smtp_Server As New SmtpClient("smtp.gmail.com")
                Dim e_mail As New MailMessage()

                e_mail.Subject = "Aanvraag ingediend " & Session("Achternaam") & " " & Session("Voornaam")
                e_mail.From = New MailAddress("HelpVakantiePlanner@gmail.com")
                Smtp_Server.Credentials = New System.Net.NetworkCredential("HelpVakantiePlanner@gmail.com", "xdarkthiefx")

                e_mail.To.Add("komutsalih@gmail.com")
                e_mail.Body = Session("Achternaam") & " " & Session("Voornaam") & " " & "heeft een nieuwe aanvraag ingediend." & vbCrLf & "Log in om zijn aanvragen te bekijken."

                Smtp_Server.EnableSsl = True
                Smtp_Server.Port = "587"
                Smtp_Server.Send(e_mail)
                MsgBox("E-mail is verstuurd")

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try

            If antwoord = vbYes Then
                Response.Redirect("NieuweAanvraag.aspx")
            Else
                Response.Redirect("Default.aspx")
            End If


        End If


    End Sub
End Class