
Imports System.Data

Partial Class Marketing_activity_trackingrpt_region
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1, fnm, br_id, zone, sql2, sql3, sql4 As String
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim fr_dt, to_dt, zone_id, region, regid, zoneid As String
    Dim dt_id, str1 As String
    Dim post, usrID As Integer
    Dim brid As Integer
    Dim total As Integer
    Dim Gobj As New GHelper.Report.ExcelExport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        zone = Me.Request.QueryString("zone_id")
        '  brid = Me.Session("branch_id")
        Dim usrDtl() As String = CStr(Session("user_id")).Split(CChar("!"))
        usrID = CInt(usrDtl(0))
        brid = Me.Session("branch_id")
        Dim str() As String
        str = zone.Split("~")
        zoneid = str(2)
        fr_dt = str(0)
        to_dt = str(1)
        'If brid > 0 Then
        '    post = oh.ExecuteDataSet("select t.post_id,t.department_id from employee_master t where t.emp_code=" & usrID & "  and t.status_id=1 ").Tables(0).Rows(0)(0)
        regid = oh.ExecuteDataSet("select b.reg_id from branch_dtl_new b where b.BRANCH_ID=" & brid & "").Tables(0).Rows(0)(0)

        'End If
        FillReportHeader()

        FillColumnHeader()
        FillColumnField()
        Panel1.Controls.Add(tbl)

    End Sub

    Sub FillReportHeader()
        tbl.Attributes.Add("width", "100%")
        tbl.Attributes.Add("align", "center")
        tbl.Attributes.Add("border", "0")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        Dim tc11 As New TableCell
        tc1.ColumnSpan = 90

        tc1.Text = "<font size=4><b> Marketing activity status Region wise Report</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Wheat
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red

        tr1.Controls.Add(tc1)

        tbl.Controls.Add(tr1)




    End Sub

    Sub FillColumnHeader()
        Dim tr4 As New TableRow
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20 As New TableCell

        tc1.ColumnSpan = 5
        tc2.ColumnSpan = 5
        tc3.ColumnSpan = 5
        tc4.ColumnSpan = 5
        tc5.ColumnSpan = 5
        tc6.ColumnSpan = 5
        tc7.ColumnSpan = 5
        tc8.ColumnSpan = 5
        tc9.ColumnSpan = 5
        tc10.ColumnSpan = 5
        tc11.ColumnSpan = 5
        tc12.ColumnSpan = 5
        tc13.ColumnSpan = 5
        tc14.ColumnSpan = 5
        tc15.ColumnSpan = 5
        tc16.ColumnSpan = 5




        'tc1.Text = "<font size=2><b>Region id</font></b>"
        tc1.Text = "<font size=2><b>Region name</font></b>"
        tc2.Text = "<font size=2><b>Area Name</font></b>"
        tc3.Text = "<font size=2><b>Branch name</font></b>"
        tc4.Text = "<font size=2><b>Branch ID</font></b>"
        tc5.Text = "<font size=2><b>Activity ID</font></b>"
        tc6.Text = "<font size=2><b>PO ID</font></b>"
        tc7.Text = "<font size=2><b>Description</font></b>"
        tc8.Text = "<font size=2><b>Status</font></b>"
        tc9.Text = "<font size=2><b>TotalAmount</font></b>"
        tc10.Text = "<font size=2><b>Enter Date</font></b>"
        tc11.Text = "<font size=2><b>EnteR BY</font></b>"
        tc12.Text = "<font size=2><b>Approved BY</font></b>"
        tc13.Text = "<font size=2><b>Image uploaded status</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc6.HorizontalAlign = HorizontalAlign.Center
        tc7.HorizontalAlign = HorizontalAlign.Center
        tc8.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        tc10.HorizontalAlign = HorizontalAlign.Center
        tc11.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        'tc14.HorizontalAlign = HorizontalAlign.Center
        'tc15.HorizontalAlign = HorizontalAlign.Center
        'tc16.HorizontalAlign = HorizontalAlign.Center
        'tc17.HorizontalAlign = HorizontalAlign.Center



        tr4.BackColor = Drawing.Color.LightGray
        tr4.ForeColor = Drawing.Color.Brown

        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
        tr4.Controls.Add(tc5)
        tr4.Controls.Add(tc6)
        tr4.Controls.Add(tc7)
        tr4.Controls.Add(tc8)
        tr4.Controls.Add(tc9)
        tr4.Controls.Add(tc10)
        tr4.Controls.Add(tc11)
        tr4.Controls.Add(tc12)
        tr4.Controls.Add(tc13)
        'tr4.Controls.Add(tc14)
        'tr4.Controls.Add(tc15)
        'tr4.Controls.Add(tc16)
        'tr4.Controls.Add(tc17)




        tbl.Controls.Add(tr4)
    End Sub
    Sub FillColumnField()
        'If post = -36 Or brid = 0 Then
        '    sql = "select f.region_id,d.reg_name, d.area_name, d.BRANCH_NAME, d.BRANCH_ID, a.actvty_id, b.po_id, s.description, tt.description status, b.total_amount, to_char(a.enter_date), a.enter_by, b.approved_by, case when m.m_photo is null then 'No' else 'Yes' end from mana0809.tbl_marketing_activity_new a, mana0809.branch_dtl_new d, mana0809.tbl_fzm_master f, mana0809.STATUS_MASTER s, mana0809.TBL_PURCHASE_STATUS_MASTER tt, mana0809.TBL_PO_MASTER b, dms.marketing_photo_upload m where a.actvty_id = b.act_id and a.brid = d.BRANCH_ID and d.reg_id = f.region_id and a.activity = s.status_id and b.status_id = tt.status_id and s.module_id = 535 and tt.module_id = 4 and tt.option_id = 1 and s.option_id = 1 and m.activity_id = a.actvty_id and f.fzm = '" & zoneid & "' and b.po_date between '" & fr_dt & "' and '" & to_dt & "'"


        'ElseIf post = 199 Then
        sql = "select d.reg_name, d.area_name, d.BRANCH_NAME, d.BRANCH_ID, a.actvty_id, b.po_id, s.description, tt.description status, b.total_amount, to_char(a.enter_date), a.enter_by, b.approved_by, case when m.status in(1, 2) then 'YES' else 'NO' end from mana0809.tbl_marketing_activity_new a, mana0809.branch_dtl_new d, mana0809.STATUS_MASTER s, mana0809.TBL_PURCHASE_STATUS_MASTER tt, mana0809.TBL_PO_MASTER b, TBL_MARKETING_PHOTO_STATUS m where a.actvty_id = b.act_id and a.brid = d.BRANCH_ID and a.activity = s.status_id and b.status_id = tt.status_id and s.module_id = 535 and tt.module_id = 4 and tt.option_id = 1 and s.option_id = 1 and m.actvty_id = a.actvty_id and d.reg_id = " & regid & " and b.po_date between '" & fr_dt & "' and '" & to_dt & "' "

        'End If


        dt = oh.ExecuteDataSet(sql).Tables(0)


        total = 0

        For Each dr In dt.Rows

            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.LightGoldenrodYellow

            Dim tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc510, tc511, tc512, tc513, tc514, tc515, tc516, tc517, tc518, tc519, tc520 As New TableCell


            tc51.ColumnSpan = 5
            tc52.ColumnSpan = 5
            tc53.ColumnSpan = 5
            tc54.ColumnSpan = 5
            tc55.ColumnSpan = 5
            tc56.ColumnSpan = 5
            tc57.ColumnSpan = 5
            tc58.ColumnSpan = 5
            tc59.ColumnSpan = 5
            tc510.ColumnSpan = 5
            tc511.ColumnSpan = 5
            tc512.ColumnSpan = 5
            tc513.ColumnSpan = 5
            'tc514.ColumnSpan = 5
            'tc515.ColumnSpan = 5
            'tc516.ColumnSpan = 5
            'tc517.ColumnSpan = 5
            ' region = dr(0)



            tc51.Text = "<font size=2>" & dr(0) & "</font>"
            tc52.Text = "<font size=2>" & dr(1) & "</font>"
            tc53.Text = "<font size=2>" & dr(2) & "</font>"
            tc54.Text = "<font size=2>" & dr(3) & "</font>"
            tc55.Text = "<font size=2>" & dr(4) & "</font>"
            tc56.Text = "<font size=2>" & dr(5) & "</font>"
            tc57.Text = "<font size=2>" & dr(6) & "</font>"
            tc58.Text = "<font size=2>" & dr(7) & "</font>"
            tc59.Text = "<font size=2>" & dr(8) & "</font>"
            tc510.Text = "<font size=2>" & dr(9) & "</font>"
            tc511.Text = "<font size=2>" & dr(10) & "</font>"
            tc512.Text = "<font size=2>" & dr(11) & "</font>"
            tc513.Text = "<font size=2>" & dr(12) & "</font>"
            'tc514.Text = "<font size=2>" & dr(13) & "</font>"
            'tc515.Text = "<font size=2>" & dr(14) & "</font>"
            'tc516.Text = "<font size=2>" & dr(15) & "</font>"
            'tc517.Text = "<font size=2>" & dr(16) & "</font>"


            tc51.HorizontalAlign = HorizontalAlign.Center
            tc52.HorizontalAlign = HorizontalAlign.Center
            tc53.HorizontalAlign = HorizontalAlign.Center
            tc54.HorizontalAlign = HorizontalAlign.Center
            tc55.HorizontalAlign = HorizontalAlign.Center
            tc56.HorizontalAlign = HorizontalAlign.Center
            tc57.HorizontalAlign = HorizontalAlign.Center
            tc58.HorizontalAlign = HorizontalAlign.Center
            tc59.HorizontalAlign = HorizontalAlign.Center
            tc510.HorizontalAlign = HorizontalAlign.Center
            tc511.HorizontalAlign = HorizontalAlign.Center
            tc512.HorizontalAlign = HorizontalAlign.Center
            tc513.HorizontalAlign = HorizontalAlign.Center
            'tc514.HorizontalAlign = HorizontalAlign.Center
            'tc515.HorizontalAlign = HorizontalAlign.Center
            'tc516.HorizontalAlign = HorizontalAlign.Center
            'tc517.HorizontalAlign = HorizontalAlign.Center

            tc51.BackColor = Drawing.Color.LightGray
            tc52.ForeColor = Drawing.Color.Black
            tc53.BackColor = Drawing.Color.LightGray
            tc54.ForeColor = Drawing.Color.Black
            tc55.BackColor = Drawing.Color.LightGray
            tc56.ForeColor = Drawing.Color.Black
            tc57.BackColor = Drawing.Color.LightGray
            tc58.ForeColor = Drawing.Color.Black
            tc59.BackColor = Drawing.Color.LightGray
            tc510.ForeColor = Drawing.Color.Black
            tc511.BackColor = Drawing.Color.LightGray
            tc512.ForeColor = Drawing.Color.Black
            tc513.BackColor = Drawing.Color.LightGray
            ' tc514.ForeColor = Drawing.Color.Black
            'tc515.BackColor = Drawing.Color.LightGray
            'tc516.ForeColor = Drawing.Color.Black
            'tc517.ForeColor = Drawing.Color.Black

            tr5.Controls.Add(tc51)
            tr5.Controls.Add(tc52)
            tr5.Controls.Add(tc53)
            tr5.Controls.Add(tc54)
            tr5.Controls.Add(tc55)
            tr5.Controls.Add(tc56)
            tr5.Controls.Add(tc57)
            tr5.Controls.Add(tc58)
            tr5.Controls.Add(tc59)
            tr5.Controls.Add(tc510)
            tr5.Controls.Add(tc511)
            tr5.Controls.Add(tc512)
            tr5.Controls.Add(tc513)
            'tr5.Controls.Add(tc514)
            'tr5.Controls.Add(tc515)
            'tr5.Controls.Add(tc516)
            'tr5.Controls.Add(tc517)
            tbl.Controls.Add(tr5)

            total += 1
        Next

        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.Wheat
        Dim tc61 As New TableCell
        tc61.ColumnSpan = 90

        tc61.Font.Bold = True
        tc61.Font.Size = 10
        tc61.HorizontalAlign = HorizontalAlign.Left

        tc61.Text = "TOTAL: " & total
        tc61.ForeColor = Drawing.Color.Brown

        tr6.Controls.Add(tc61)

        tbl.Controls.Add(tr6)

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("window.open('../../home.aspx','_self');")

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub
    Protected Sub Export_Click(sender As Object, e As EventArgs) Handles Export.Click
        Dim sql1 = "insert into crf_util_rpt(brid,firm_id,emp_code,tra_dt,tradate,crf_id,application)values(" & brid & ",1," & usrID & ",trunc(sysdate),sysdate,'102436','Marketing activity tracking report')"
        oh.ExecuteNonQuery(sql1)
        Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        Response.Clear()
        Response.Charset = ""
        Response.ContentEncoding = System.Text.Encoding.UTF8
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=Newscheme_callreport.xls")
        Panel1.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.[End]()
    End Sub
End Class

