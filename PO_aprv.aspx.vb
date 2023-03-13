Imports System.Data
Imports System.Data.OracleClient
Partial Class Marketing_Activities_PO_aprv
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim usr() As String
    Dim dt3, dt13, dt14, dt11, dt12, dt22, dt4, dt5, dt6, dt7, dt8 As New DataTable
    Dim str, cl As New System.Text.StringBuilder
    Dim a, b, c, d, sql3, sql9 As String
    Dim check_v As Integer
    Dim sql1, sql2, sql4, sql5, sql6, sql7, sql8, Sql10 As String
    Dim Data() As String
    Dim script1 As New System.Text.StringBuilder

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim script_val As String
        Dim user() As String = Session("user_id").ToString.Split("!")
        script_val = "var header;header='" & Me.txt_from.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Me.btn_generate.Attributes.Add("onclick", "return btngenerate()")
        Me.txt_from.Attributes.Add("onkeyup", "return OnkeyUpChqDate('txt_from')")
        Me.txt_to.Attributes.Add("onkeyup", "return OnkeyUpChqDate('txt_to')")
        Me.txt_from.Attributes.Add("onblur", "return check_Fdate('txt_from')")
        Me.txt_to.Attributes.Add("onblur", "return check_Tdate('txt_to')")
        Dim cl_script0 As New System.Text.StringBuilder
        usr = Me.Session("user_id").ToString.Split("!")


        dt = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & usr(0) & " and form_id=5584").Tables(0)

        dt3 = oh.ExecuteDataSet("select count(*) from TBL_FZM_MASTER t, emp_master tt, branch_dtl_new b where t.fzm_empcode = tt.EMP_CODE and tt.STATUS_ID = 1 and b.reg_id = t.region_id and tt.BRANCH_ID = b.BRANCH_ID and  t.fzm_empcode =" & usr(0) & "").Tables(0)

        Sql10 = "select b.BRANCH_ID,b.area_id,b.reg_id, e.POST_ID, b.status_id from emp_master e, branch_dtl_new b where e.BRANCH_ID = b.BRANCH_ID and e.EMP_CODE = " & usr(0) & ""
        dt2 = oh.ExecuteDataSet(Sql10).Tables(0)
        If (dt2.Rows(0)(3) <> 136) And (dt2.Rows(0)(3) <> 197) And (dt2.Rows(0)(3) <> 199) And (dt3.Rows(0)(0) = 0) And (dt.Rows(0)(0) = 0) Then
            Server.Transfer("../show_err.aspx")
        End If
    End Sub

    Protected Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        Server.Transfer("Po_aprv_details.aspx?Fdt=" & Me.txt_from.Text & "&Tdt=" & Me.txt_to.Text)
    End Sub
End Class
