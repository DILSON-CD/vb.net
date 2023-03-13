
Imports System.Data

Partial Class marketing_activity_dtslct
    Inherits System.Web.UI.Page
    Dim usrID, brid, post As Integer
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usrDtl() As String = CStr(Session("user_id")).Split(CChar("!"))
        usrID = CInt(usrDtl(0))
        brid = Me.Session("branch_id")
        dt2 = oh.ExecuteDataSet("select count(1) from form_accessibility f where f.form_id=5584 and f.emp_id=" & usrID & "").Tables(0)
        If dt2.Rows(0)(0) > 0 Then
            post = 0
        Else

            dt = oh.ExecuteDataSet("select t.post_id,t.department_id from employee_master t where t.emp_code=" & usrID & "  and t.status_id=1 ").Tables(0)
            post = dt.Rows(0)(0)
            If (post = 10 Or post = 198 Or post = 1) Then
                dt1 = oh.ExecuteDataSet("select t.post_id from employee_master t where t.emp_code=" & usrID & "  and t.status_id=1 and t.post_id in (10,198) and t.branch_id=" & brid & " ").Tables(0)
            ElseIf post = 136 Then
                dt1 = oh.ExecuteDataSet("select t.post_id from employee_master t,branch_dtl_new b where t.branch_id=b.branch_id and  t.emp_code=" & usrID & "  and t.status_id=1 and t.post_id =136 and b.area_id in (select q.area_id from branch_dtl_new q where q.branch_id =" & brid & " )").Tables(0)
            ElseIf post = 199 Then
                dt1 = oh.ExecuteDataSet("select t.post_id from employee_master t,branch_dtl_new b where t.branch_id=b.branch_id and  t.emp_code=" & usrID & "  and t.status_id=1 and t.post_id =199 and b.reg_id in (select q.reg_id from branch_dtl_new q where q.branch_id =" & brid & " )").Tables(0)
            ElseIf post = -36 Then
                dt1 = oh.ExecuteDataSet("select * from tbl_fzm_master ff where   ff.fzm_empcode=" & usrID & "   and ff.fzm = (select distinct f.fzm from tbl_fzm_master f, branch_dtl_new q where f.region_id=q.reg_id and  q.branch_id =" & brid & " )").Tables(0)
            Else
                Dim cl_script As New StringBuilder
                cl_script.Append("alert('You Are Not Authorised \n to View This Page !!') ;")
                cl_script.Append("window.open('../../home.aspx', '_self', '');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If

        If IsPostBack Then
            If post = -36 Or post = 0 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('Marketing_activity_tracking_rpt.aspx?dt_id=' +  '" & Me.Text_FromDt.Text & "~" & Me.Text_ToDt.Text & "~" & post & "','_self');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            ElseIf post = 199 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('Marketing_activity_trackingrpt_region.aspx?zone_id=' +  '" & Me.Text_FromDt.Text & "~" & Me.Text_ToDt.Text & "~" & post & "','_self');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            ElseIf post = 136 Or post = 197 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('Marketing_activity_trackingrpt_area.aspx?zone_id=' +  '" & Me.Text_FromDt.Text & "~" & Me.Text_ToDt.Text & "~" & post & "','_self');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            ElseIf post = 1 Or post = 10 Or post = 198 Or post = -265 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('Marketing_activity_trackingrpt_branch.aspx?dt_id=' +  '" & Me.Text_FromDt.Text & "~" & Me.Text_ToDt.Text & "~" & post & "','_self');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End If
            'Dim cl_script1 As New System.Text.StringBuilder
            'cl_script1.Append("window.open('Meeting_scheduler_Report.aspx?dt_id=' +  '" & Me.Text_FromDt.Text & "~" & Me.Text_ToDt.Text & "~" & post & "','_self');")

            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If

    End Sub
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Me.Server.Transfer("../../home.aspx")
    'End Sub
End Class
