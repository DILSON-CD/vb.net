Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class Marketing_Activities_Po_aprv_details
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim Sql, sql1, Fromdt, Todt, Sql10 As String
    Dim usr(), msg As String
    Dim dt, dt1, dt2, dt3, dt4, dt01 As New DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        usr = Me.Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            Fromdt = Request.QueryString.Get("Fdt")
            Todt = Request.QueryString.Get("Tdt")

            '                                    0            1        2         3          4
            Sql10 = "select b.BRANCH_ID,b.area_id,b.reg_id, e.POST_ID, b.status_id from emp_master e, branch_dtl_new b where e.BRANCH_ID = b.BRANCH_ID and e.EMP_CODE = " & usr(0) & ""
            dt2 = oh.ExecuteDataSet(Sql10).Tables(0)
            Dim sttr = "select t.fzm_id from TBL_FZM_MASTER t,emp_master tt,branch_dtl_new b where  tt.STATUS_ID=1 and b.reg_id=t.region_id and tt.BRANCH_ID=b.BRANCH_ID and tt.EMP_CODE=" & usr(0) & ""
            dt01 = oh.ExecuteDataSet(sttr).Tables(0)

            If dt2.Rows(0)(3) = 136 Or dt2.Rows(0)(3) = 197 Then

                dt3 = oh.ExecuteDataSet("select distinct a.actvty_id, a.brid, bb.BRANCH_NAME, bb.area_name, bb.reg_name, b.po_id, t.description, tt.description status, b.total_amount, a.enter_date, a.enter_by, b.approved_by, b.approved_date, nvl(to_char(b.cancelled_by),'Nil') cancelled_by, nvl(to_char(b.cancel_dt),'Nil') cancel_dt, decode(p.status_id, 0, 'Requested', 1, 'Invoice Paid', 2, 'Invoice Approved', 4, 'Rejected', 5, 'Invoice Rejected by Accounts', 6, 'Invoice Resubmitted', 'Invoice not entered') Invoice_Status, to_date(sysdate) - trunc(b.po_date) LAG_days, decode(sign(sysdate - a.marketing_actvty_strt), 0, 'started', 1, 'started', -1, 'pending') activity_started_status, decode(p.status_id, 0, 'pending', 1, ' Paid', 2, 'paid', 4, 'pending', 5, 'paid', 6, 'paid', 'pending') po_payment_status from mana0809.tbl_marketing_activity_new a, mana0809.TBL_PO_MASTER b left outer join mana0809.TBL_PO_INVOICE_MST p on b.po_id = p.po_id, mana0809.STATUS_MASTER t, MANA0809.TBL_PURCHASE_STATUS_MASTER tt, mana0809.branch_dtl_new bb, mana0809.tbl_fzm_master f where a.actvty_id = b.act_id and t.status_id = a.activity and t.module_id = 535 and t.option_id = 1 and b.status_id = tt.status_id and f.region_id = bb.reg_id and bb.BRANCH_ID = a.brid and tt.module_id = 4 and tt.option_id = 1 and b.status_id not in(2,16) and to_date(a.enter_date) between '" & Fromdt & "' and '" & Todt & "' and bb.area_id = " & dt2.Rows(0)(1) & "").Tables(0)

            ElseIf dt2.Rows(0)(3) = 199 Then
                dt3 = oh.ExecuteDataSet("select distinct a.actvty_id, a.brid, bb.BRANCH_NAME, bb.area_name, bb.reg_name, b.po_id, t.description, tt.description status, b.total_amount, a.enter_date, a.enter_by, b.approved_by, b.approved_date, nvl(to_char(b.cancelled_by),'Nil') cancelled_by, nvl(to_char(b.cancel_dt),'Nil') cancel_dt, decode(p.status_id, 0, 'Requested', 1, 'Invoice Paid', 2, 'Invoice Approved', 4, 'Rejected', 5, 'Invoice Rejected by Accounts', 6, 'Invoice Resubmitted', 'Invoice not entered') Invoice_Status, to_date(sysdate) - trunc(b.po_date) LAG_days, decode(sign(sysdate - a.marketing_actvty_strt), 0, 'started', 1, 'started', -1, 'pending') activity_started_status, decode(p.status_id, 0, 'pending', 1, ' Paid', 2, 'paid', 4, 'pending', 5, 'paid', 6, 'paid', 'pending') po_payment_status from mana0809.tbl_marketing_activity_new a, mana0809.TBL_PO_MASTER b left outer join mana0809.TBL_PO_INVOICE_MST p on b.po_id = p.po_id, mana0809.STATUS_MASTER t, MANA0809.TBL_PURCHASE_STATUS_MASTER tt, mana0809.branch_dtl_new bb, mana0809.tbl_fzm_master f where a.actvty_id = b.act_id and t.status_id = a.activity and t.module_id = 535 and t.option_id = 1 and b.status_id = tt.status_id and f.region_id = bb.reg_id and bb.BRANCH_ID = a.brid and tt.module_id = 4 and tt.option_id = 1 and b.status_id not in(2,16) and to_date(a.enter_date) between '" & Fromdt & "' and '" & Todt & "' and bb.reg_id = " & dt2.Rows(0)(2) & "").Tables(0)

            ElseIf dt2.Rows(0)(3) = -36 Then
                dt3 = oh.ExecuteDataSet("select distinct a.actvty_id, a.brid, bb.BRANCH_NAME, bb.area_name, bb.reg_name, b.po_id, t.description, tt.description status, b.total_amount, a.enter_date, a.enter_by, b.approved_by, b.approved_date, nvl(to_char(b.cancelled_by),'Nil') cancelled_by, nvl(to_char(b.cancel_dt),'Nil') cancel_dt, decode(p.status_id, 0, 'Requested', 1, 'Invoice Paid', 2, 'Invoice Approved', 4, 'Rejected', 5, 'Invoice Rejected by Accounts', 6, 'Invoice Resubmitted', 'Invoice not entered') Invoice_Status, to_date(sysdate) - trunc(b.po_date) LAG_days, decode(sign(sysdate - a.marketing_actvty_strt), 0, 'started', 1, 'started', -1, 'pending') activity_started_status, decode(p.status_id, 0, 'pending', 1, ' Paid', 2, 'paid', 4, 'pending', 5, 'paid', 6, 'paid', 'pending') po_payment_status from mana0809.tbl_marketing_activity_new a, mana0809.TBL_PO_MASTER b left outer join mana0809.TBL_PO_INVOICE_MST p on b.po_id = p.po_id, mana0809.STATUS_MASTER t, MANA0809.TBL_PURCHASE_STATUS_MASTER tt, mana0809.branch_dtl_new bb, mana0809.tbl_fzm_master f where a.actvty_id = b.act_id and t.status_id = a.activity and t.module_id = 535 and t.option_id = 1 and b.status_id = tt.status_id and f.region_id = bb.reg_id and bb.BRANCH_ID = a.brid and tt.module_id = 4 and tt.option_id = 1 and b.status_id not in(2,16) and to_date(a.enter_date) between '" & Fromdt & "' and '" & Todt & "' and f.fzm_id = " & dt01.Rows(0)(0) & "").Tables(0)
            Else
                dt3 = oh.ExecuteDataSet("select distinct a.actvty_id, a.brid, bb.BRANCH_NAME, bb.area_name, bb.reg_name, b.po_id, t.description, tt.description status, b.total_amount, a.enter_date, a.enter_by, b.approved_by, b.approved_date, nvl(to_char(b.cancelled_by),'Nil') cancelled_by, nvl(to_char(b.cancel_dt),'Nil') cancel_dt, decode(p.status_id, 0, 'Requested', 1, 'Invoice Paid', 2, 'Invoice Approved', 4, 'Rejected', 5, 'Invoice Rejected by Accounts', 6, 'Invoice Resubmitted', 'Invoice not entered') Invoice_Status, to_date(sysdate) - trunc(b.po_date) LAG_days, decode(sign(sysdate - a.marketing_actvty_strt), 0, 'started', 1, 'started', -1, 'pending') activity_started_status, decode(p.status_id, 0, 'pending', 1, ' Paid', 2, 'paid', 4, 'pending', 5, 'paid', 6, 'paid', 'pending') po_payment_status from mana0809.tbl_marketing_activity_new a, mana0809.TBL_PO_MASTER b left outer join mana0809.TBL_PO_INVOICE_MST p on b.po_id = p.po_id, mana0809.STATUS_MASTER t, MANA0809.TBL_PURCHASE_STATUS_MASTER tt, mana0809.branch_dtl_new bb, mana0809.tbl_fzm_master f where a.actvty_id = b.act_id and t.status_id = a.activity and t.module_id = 535 and t.option_id = 1 and b.status_id = tt.status_id and f.region_id = bb.reg_id and bb.BRANCH_ID = a.brid and tt.module_id = 4 and tt.option_id = 1 and to_date(a.enter_date) between '" & Fromdt & "' and '" & Todt & "' ").Tables(0)

            End If

            If dt3.Rows.Count > 0 Then
                GridView1.DataSource = dt3
                GridView1.DataBind()
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('NO DATA FOUND');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If

        End If

    End Sub
    Protected Sub Btn_export_Click(sender As Object, e As EventArgs) Handles Btn_export.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New IO.StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim style As String = "<style>  td{mso-number-format:\\@} </style>"

            '  GridView1.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridView1.Rows
                '  row.BackColor = Color.White

                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If

                    cell.CssClass = "textmode"
                Next
            Next

            GridView1.RenderControl(hw)
            'style to format numbers to string

            style = "<style> .textmode { } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End Using
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
    Protected Sub btn_ext_Click(sender As Object, e As EventArgs) Handles btn_ext.Click
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub
End Class
