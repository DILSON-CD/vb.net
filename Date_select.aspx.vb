Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class Pledge_SMA_classification_Date_select
    Inherits System.Web.UI.Page
    Dim cl_script As New StringBuilder
    Dim user_id, usr() As String
    Dim brid, post, meet_id, sts As Integer
    Dim sql As String
    Dim dt, dt1 As DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim diff As String

    Dim date1, date2 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'user_id = Me.Session("user_id")
        'usr = user_id.Split("!")
        ' brid = Me.Session("branch_id")
        'If brid <> 0 Then

        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.[GetType](), "alert", "alert('You Are Not Authorized To View This Page..!!');window.location.replace('../home.aspx');", True)

        'End If

    End Sub

    Protected Sub btn_show_Click(sender As Object, e As EventArgs) Handles btn_show.Click
        If Me.Text_ToDt.Text = "" Then
            cl_script.Append("alert('Please Select Date'); ")
            Me.Text_ToDt.Text = ""
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

        Else
            date2 = Text_ToDt.Text
            Server.Transfer("SMA_Zonewise.aspx?fdt=" & date2 & "")
        End If
    End Sub

    Protected Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub

End Class