Imports MySql.Data.MySqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Dim strUser As String = Login1.UserName
        Dim strPassword As String = Login1.Password
        Dim strRol As String
        Dim strSQL As String = "SELECT Rol from gebruiker WHERE (Gebruikersnaam = '" & strUser & "' AND Paswoord = '" & strPassword & "')"

        Dim con As MySqlConnection = New MySqlConnection()

        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("vakantieplanner").ToString()

        Dim cmd As MySqlCommand = New MySqlCommand(strSQL, con)

        'Connectie openen en gegevens verifiëren
        con.Open()
        If cmd.ExecuteScalar() = Nothing Then
            strRol = ""
        Else
            strRol = cmd.ExecuteScalar().ToString
        End If
        If strRol = "gebruiker" Or strRol = "beheerder" Then
            Session("Rol") = strRol
            Session("Gebruikersnaam") = strUser
            FormsAuthentication.RedirectFromLoginPage(strUser, False)
        Else
            Login1.FailureText = "Gebruikersnaam of wachtwoord is onjuist."
        End If


        'Connectie aflsuiten
        con.Close()
    End Sub
End Class