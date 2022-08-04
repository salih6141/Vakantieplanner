﻿Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Clear()
        Session.Abandon()
        Try
            Session.Abandon()
            FormsAuthentication.SignOut()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Response.Redirect("Login.aspx")
    End Sub

End Class