Imports System.Data
Imports System.Data.OracleClient
Partial Class Pledge_SMA_classification_SMA_Branchwise
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim Gobj As New GHelper.Report.ExcelExport
    Dim sql, sql1, sql2 As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim cnt, npa_cnt, non_npa_cnt, tot_npa As Integer
    Dim areaid As Integer
    Dim emp As Array
    Dim fnm, fdt, tdt As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usr As String = Session("user_id")
        emp = usr.Split("!")
        areaid = Request.QueryString("area_id")
        fdt = Request.QueryString("fdt")
        tdt = Request.QueryString("tdt")
        FillReportHeader()
        FillColumnHeader()
        FillColumnField()
        'FillSummaryField()
        Panel1.Controls.Add(tbl)
    End Sub

    Sub FillReportHeader()

        tbl.Attributes.Add("width", "100%")
        tbl.Attributes.Add("align", "center")
        tbl.Attributes.Add("border", "1")
        tbl.BorderStyle = BorderStyle.Solid
        tbl.BorderColor = Drawing.Color.WhiteSmoke

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 72
        tc1.Text = "<font size=5><b>" & Session("firm_name") & "</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Gold
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red
        tr1.Controls.Add(tc1)
        tbl.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.ColumnSpan = 72
        tc2.Text = "<font size=2><b> BRANCH NAME : " & Session("branch_name") & " -- BRANCH ID : " & Session("branch_id") & " </font></b>"
        tc2.HorizontalAlign = HorizontalAlign.Center
        tr2.Controls.Add(tc2)
        tbl.Controls.Add(tr2)
        Dim tr3 As New TableRow
        Dim tc3 As New TableCell
        Dim tc31 As New TableCell
        Dim tc32 As New TableCell
        tc3.ColumnSpan = 8
        tc31.ColumnSpan = 52
        tc32.ColumnSpan = 12
        tc3.Text = "<font size=2><b>" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tc3.HorizontalAlign = HorizontalAlign.Left


        dt = oh.ExecuteDataSet("select to_char(sysdate-1,'dd/MON/yyyy') from dual").Tables(0)
        tc31.Text = "<font color='#663366' size=2><b>BRANCHWISE SMA REPORT  " & fdt & "</font></b>"
        tc31.HorizontalAlign = HorizontalAlign.Center
        tc32.Text = "<font color='#663366' size=2><B>" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tc32.HorizontalAlign = HorizontalAlign.Right
        tr3.BackColor = Drawing.Color.DarkGray
        tr3.ForeColor = Drawing.Color.Brown
        tr3.Controls.Add(tc3)
        tr3.Controls.Add(tc31)
        tr3.Controls.Add(tc32)
        tbl.Controls.Add(tr3)


        tc32.Text = "<font size=2><B>" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tc32.HorizontalAlign = HorizontalAlign.Right
        tc31.HorizontalAlign = HorizontalAlign.Center
        tr3.BackColor = Drawing.Color.DarkGray
        tr3.ForeColor = Drawing.Color.Brown
        tr3.Controls.Add(tc3)
        tr3.Controls.Add(tc31)
        tr3.Controls.Add(tc32)
        tbl.Controls.Add(tr3)

    End Sub

    Sub FillColumnHeader()

        Dim tr4 As New TableRow
        Dim tc41, tc42, tc43, tc44, tc45, tc46, tc47, tc48, tc49, tc410, tc411, tc412 As New TableCell
        tc41.ColumnSpan = 4
        tc42.ColumnSpan = 4
        tc43.ColumnSpan = 4
        tc44.ColumnSpan = 4
        tc45.ColumnSpan = 4
        tc46.ColumnSpan = 8
        tc47.ColumnSpan = 8
        tc48.ColumnSpan = 8
        tc49.ColumnSpan = 8
        tc410.ColumnSpan = 8
        tc411.ColumnSpan = 8
        tc412.ColumnSpan = 4



        tc41.Text = "<font size=2><b>BRANCH ID</font></b>"
        tc42.Text = "<font size=2><b>BRANCH NAME</font></b>"
        tc43.Text = "<font size=2><b>AREA NAME</font></b>"
        tc44.Text = "<font size=2><b>REGION NAME</font></b>"
        tc45.Text = "<font size=2><b>ZONE NAME</font></b>"
        tc46.Text = "<font size=2><b>TOTAL LOAN</font></b>"
        tc47.Text = "<font size=2><b>NOTDUE LOAN</font></b>"
        tc48.Text = "<font size=2><b>SMA0</font></b>"
        tc49.Text = "<font size=2><b>SMA1</font></b>"
        tc410.Text = "<font size=2><b>SMA2</font></b>"
        tc411.Text = "<font size=2><b>SMA3</font></b>"
        tc412.Text = "<font size=2><b>NON-NPA</font></b>"

        tc41.HorizontalAlign = HorizontalAlign.Center
        tc42.HorizontalAlign = HorizontalAlign.Center
        tc43.HorizontalAlign = HorizontalAlign.Center
        tc44.HorizontalAlign = HorizontalAlign.Center
        tc45.HorizontalAlign = HorizontalAlign.Center
        tc46.HorizontalAlign = HorizontalAlign.Center
        tc47.HorizontalAlign = HorizontalAlign.Center
        tc48.HorizontalAlign = HorizontalAlign.Center
        tc49.HorizontalAlign = HorizontalAlign.Center
        tc410.HorizontalAlign = HorizontalAlign.Center
        tc411.HorizontalAlign = HorizontalAlign.Center
        tc412.HorizontalAlign = HorizontalAlign.Center

        tr4.BackColor = Drawing.Color.DarkGray
        tr4.ForeColor = Drawing.Color.Brown

        tr4.Controls.Add(tc41)
        tr4.Controls.Add(tc42)
        tr4.Controls.Add(tc43)
        tr4.Controls.Add(tc44)
        tr4.Controls.Add(tc45)
        tr4.Controls.Add(tc46)
        tr4.Controls.Add(tc47)
        tr4.Controls.Add(tc48)
        tr4.Controls.Add(tc49)
        tr4.Controls.Add(tc410)
        tr4.Controls.Add(tc411)
        tr4.Controls.Add(tc412)

        tbl.Controls.Add(tr4)

        Dim tr5 As New TableRow
        tr5.Height = "15"
        Dim tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc510, tc511, tc512, tc513, tc514, tc515, tc516, tc517, tc518, tc519 As New TableCell

        tc51.ColumnSpan = 4
        tc52.ColumnSpan = 4
        tc53.ColumnSpan = 4
        tc54.ColumnSpan = 4
        tc55.ColumnSpan = 4
        tc56.ColumnSpan = 4
        tc57.ColumnSpan = 4
        tc58.ColumnSpan = 4
        tc59.ColumnSpan = 4
        tc510.ColumnSpan = 4
        tc511.ColumnSpan = 4
        tc512.ColumnSpan = 4
        tc513.ColumnSpan = 4
        tc514.ColumnSpan = 4
        tc515.ColumnSpan = 4
        tc516.ColumnSpan = 4
        tc517.ColumnSpan = 4
        tc518.ColumnSpan = 2
        tc519.ColumnSpan = 2

        tc51.Text = "<font size=2><b></font></b>"
        tc52.Text = "<font size=2><b></font></b>"
        tc53.Text = "<font size=2><b></font></b>"
        tc54.Text = "<font size=2><b></font></b>"
        tc55.Text = "<font size=2><b></font></b>"
        tc56.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc57.Text = "<font size=2><b>LOAN BALANCE</font></b>"
        tc58.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc59.Text = "<font size=2><b>LOAN BALANCE</font></b>"
        tc510.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc511.Text = "<font size=2><b>LOAN BALANCE</font></b>"
        tc512.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc513.Text = "<font size=2><b>LOAN BALANCE</font></b>"
        tc514.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc515.Text = "<font size=2><b>LOAN BALANCE</font></b>"
        tc516.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc517.Text = "<font size=2><b>LOAN BALANCE</font></b>"
        tc518.Text = "<font size=2><b>NON-NPA COUNT</font></b>"
        tc519.Text = "<font size=2><b>NON_NPA BALANCE</font></b>"

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
        tc514.HorizontalAlign = HorizontalAlign.Center
        tc515.HorizontalAlign = HorizontalAlign.Center
        tc516.HorizontalAlign = HorizontalAlign.Center
        tc517.HorizontalAlign = HorizontalAlign.Center
        tc518.HorizontalAlign = HorizontalAlign.Center
        tc519.HorizontalAlign = HorizontalAlign.Center

        tr5.BackColor = Drawing.Color.DarkGray
        tr5.ForeColor = Drawing.Color.Brown

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
        tr5.Controls.Add(tc514)
        tr5.Controls.Add(tc515)
        tr5.Controls.Add(tc516)
        tr5.Controls.Add(tc517)
        tr5.Controls.Add(tc518)
        tr5.Controls.Add(tc519)

        tbl.Controls.Add(tr5)
    End Sub

    Sub FillColumnField()
        If fdt = tdt Then
            sql = "select t.col_brid, t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, t.col_total_ln_cnt, t.col_total_ln_bal, t.col_nodue_ln_cnt, t.col_nodue_ln_bal, t.col_sma0_ln_cnt, t.col_sma0_ln_bal, t.col_sma1_ln_cnt, t.col_sma1_ln_bal, t.col_sma2_ln_cnt, t.col_sma2_ln_bal, t.col_sma3_ln_cnt, t.col_sma3_ln_bal,nvl(t.col_nonnpa_cnt,0),nvl(t.col_nonnpa_bal,0) from tbl_sma_classification_branch_dtl t, branch_dtl_new b where t.col_brid = b.BRANCH_ID and b.area_id = " & areaid & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
        Else
            sql = "select t.col_brid, t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, t.col_total_ln_cnt, t.col_total_ln_bal, t.col_nodue_ln_cnt, t.col_nodue_ln_bal, t.col_sma0_ln_cnt, t.col_sma0_ln_bal, t.col_sma1_ln_cnt, t.col_sma1_ln_bal, t.col_sma2_ln_cnt, t.col_sma2_ln_bal, t.col_sma3_ln_cnt, t.col_sma3_ln_bal,nvl(t.col_nonnpa_cnt,0),nvl(t.col_nonnpa_bal,0) from tbl_sma_classification_branch_dtl_his t, branch_dtl_new b where t.col_brid = b.BRANCH_ID and b.area_id = " & areaid & " and to_date(t.col_updt_date)='" & fdt & "'"
            dt = oh.ExecuteDataSet(sql).Tables(0)
        End If
        

        Dim color As Integer = 0
        For Each dr In dt.Rows

            Dim tr6 As New TableRow
            tr6.Height = "15"
            Dim tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc610, tc611, tc612, tc613, tc614, tc615, tc616, tc617, tc618, tc619 As New TableCell
            If color = 0 Then
                tr6.BackColor = Drawing.Color.AliceBlue
                color = 1
            Else
                tr6.BackColor = Drawing.Color.LightGray
                color = 0
            End If
            tc61.ColumnSpan = 4
            tc62.ColumnSpan = 4
            tc63.ColumnSpan = 4
            tc64.ColumnSpan = 4
            tc65.ColumnSpan = 4
            tc66.ColumnSpan = 4
            tc67.ColumnSpan = 4
            tc68.ColumnSpan = 4
            tc69.ColumnSpan = 4
            tc610.ColumnSpan = 4
            tc611.ColumnSpan = 4
            tc612.ColumnSpan = 4
            tc613.ColumnSpan = 4
            tc614.ColumnSpan = 4
            tc615.ColumnSpan = 4
            tc616.ColumnSpan = 4
            tc617.ColumnSpan = 4
            tc618.ColumnSpan = 2
            tc619.ColumnSpan = 2

            tc61.Text = "<font size=2><a href = javascript:GetPledgewiseSMA(" & dr(0) & ",'" & fdt & "','" & tdt & "') > " & dr(0) & "</a></font>"
            tc62.Text = "<font size=2>" & dr(1) & "</font>"
            tc63.Text = "<font size=2>" & dr(2) & "</font>"
            tc64.Text = "<font size=2>" & dr(3) & "</font>"
            tc65.Text = "<font size=2>" & dr(4) & "</font>"
            tc66.Text = "<font size=2>" & dr(5) & "</font>"
            tc67.Text = "<font size=2>" & dr(6) & "</font>"
            tc68.Text = "<font size=2>" & dr(7) & "</font>"
            tc69.Text = "<font size=2>" & dr(8) & "</font>"
            tc610.Text = "<font size=2>" & dr(9) & "</font>"
            tc611.Text = "<font size=2>" & dr(10) & "</font>"
            tc612.Text = "<font size=2>" & dr(11) & "</font>"
            tc613.Text = "<font size=2>" & dr(12) & "</font>"
            tc614.Text = "<font size=2>" & dr(13) & "</font>"
            tc615.Text = "<font size=2>" & dr(14) & "</font>"
            tc616.Text = "<font size=2>" & dr(15) & "</font>"
            tc617.Text = "<font size=2>" & dr(16) & "</font>"
            tc618.Text = "<font size=2>" & dr(17) & "</font>"
            tc619.Text = "<font size=2>" & dr(18) & "</font>"

            


            tc61.HorizontalAlign = HorizontalAlign.Left
            tc62.HorizontalAlign = HorizontalAlign.Justify
            tc63.HorizontalAlign = HorizontalAlign.Justify
            tc64.HorizontalAlign = HorizontalAlign.Justify
            tc65.HorizontalAlign = HorizontalAlign.Justify
            tc66.HorizontalAlign = HorizontalAlign.Justify
            tc67.HorizontalAlign = HorizontalAlign.Justify
            tc68.HorizontalAlign = HorizontalAlign.Justify
            tc69.HorizontalAlign = HorizontalAlign.Justify
            tc610.HorizontalAlign = HorizontalAlign.Justify
            tc611.HorizontalAlign = HorizontalAlign.Justify
            tc612.HorizontalAlign = HorizontalAlign.Justify
            tc613.HorizontalAlign = HorizontalAlign.Justify
            tc614.HorizontalAlign = HorizontalAlign.Justify
            tc615.HorizontalAlign = HorizontalAlign.Justify
            tc616.HorizontalAlign = HorizontalAlign.Justify
            tc617.HorizontalAlign = HorizontalAlign.Justify
            tc618.HorizontalAlign = HorizontalAlign.Justify
            tc619.HorizontalAlign = HorizontalAlign.Justify

            tr6.Controls.Add(tc61)
            tr6.Controls.Add(tc62)
            tr6.Controls.Add(tc63)
            tr6.Controls.Add(tc64)
            tr6.Controls.Add(tc65)
            tr6.Controls.Add(tc66)
            tr6.Controls.Add(tc67)
            tr6.Controls.Add(tc68)
            tr6.Controls.Add(tc69)
            tr6.Controls.Add(tc610)
            tr6.Controls.Add(tc611)
            tr6.Controls.Add(tc612)
            tr6.Controls.Add(tc613)
            tr6.Controls.Add(tc614)
            tr6.Controls.Add(tc615)
            tr6.Controls.Add(tc616)
            tr6.Controls.Add(tc617)
            tr6.Controls.Add(tc618)
            tr6.Controls.Add(tc619)

            tbl.Controls.Add(tr6)
           

        Next

    End Sub

    'Sub FillSummaryField()
    '    '---------------------------
    '    Dim tabline1 As New TableRow
    '    tabline1.Width = 10

    '    Dim tabcellline1 As New TableCell
    '    tabcellline1.ColumnSpan = 14
    '    tabcellline1.Text = "<hr>"
    '    ' tabcellline1.BorderColor = Drawing.Color.Red

    '    tabline1.Controls.Add(tabcellline1)
    '    tbl.Controls.Add(tabline1)
    '    '---------------------------
    '    Dim tr25 As New TableRow
    '    Dim tcc1, tcc2, tcc3, tcc4, tcc5, tcc6, tcc7, tcc8, tcc9, tcc10 As New TableCell
    '    tcc1.ColumnSpan = 3
    '    tcc2.ColumnSpan = 1
    '    tcc3.ColumnSpan = 1
    '    tcc4.ColumnSpan = 1
    '    tcc5.ColumnSpan = 1
    '    tcc6.ColumnSpan = 1
    '    tcc6.ColumnSpan = 1
    '    tcc7.ColumnSpan = 1
    '    tcc8.ColumnSpan = 2
    '    tcc9.ColumnSpan = 2



    '    tr25.BackColor = Drawing.Color.BlanchedAlmond

    '    tcc1.Text = "<font size=3><b>TOTAL :- " & cnt & "</font></b>"
    '    tcc2.Text = "<font size=3><b>" & npa_cnt & "</font></b>"
    '    tcc3.Text = "<font size=2><b>" & FormatNumber(npa_tot) & "</font></b>"
    '    tcc4.Text = "<font size=3><b>" & non_npa_cnt & "</font></b>"
    '    tcc5.Text = "<font size=2><b>" & FormatNumber(non_npa_tot) & "</font></b>"
    '    tcc6.Text = "<font size=2><b>" & tot_npa & "</font></b>"
    '    tcc7.Text = "<font size=2><b>" & FormatNumber(tot_npa_sum) & "</font></b>"
    '    tcc8.Text = "<font size=2><b>" & FormatNumber(tot_os) & "</font></b>"
    '    tcc9.Text = "<font size=2><b>" & FormatNumber(tot_perc) & "%</font></b>"

    '    tr25.Controls.Add(tcc1)
    '    tr25.Controls.Add(tcc2)
    '    tr25.Controls.Add(tcc3)
    '    tr25.Controls.Add(tcc4)
    '    tr25.Controls.Add(tcc5)
    '    tr25.Controls.Add(tcc6)
    '    tr25.Controls.Add(tcc7)
    '    tr25.Controls.Add(tcc8)
    '    tr25.Controls.Add(tcc9)


    '    tbl.Controls.Add(tr25)
    'End Sub

    Protected Sub btn_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        If fdt = tdt Then
            'sql1 = "select t.col_brid, t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, t.col_total_ln_cnt, t.col_total_ln_bal, t.col_nodue_ln_cnt, t.col_nodue_ln_bal, t.col_sma0_ln_cnt, t.col_sma0_ln_bal, t.col_sma1_ln_cnt, t.col_sma1_ln_bal, t.col_sma2_ln_cnt, t.col_sma2_ln_bal, t.col_sma3_ln_cnt, t.col_sma3_ln_bal from tbl_sma_classification_branch_dtl t, branch_dtl_new b where t.col_brid = b.BRANCH_ID and b.area_id = " & areaid & ""
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','TOTAL COUNT','TOTAL BALANCE','NODUE COUNT','NODUE BALANCE','SMA0 COUNT','SMA0 BALANCE','SMA1 COUNT','SMA1 BALANCE','SMA2 COUNT','SMA2 BALANCE','SMA3 COUNT','SMA3 BALANCE','NON-NPA COUNT','NON-NPA BALANCE' from dual union all select to_char(t.col_brid), t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, to_char(t.col_total_ln_cnt), to_char(t.col_total_ln_bal), to_char(t.col_nodue_ln_cnt), to_char(t.col_nodue_ln_bal), to_char(t.col_sma0_ln_cnt), to_char(t.col_sma0_ln_bal), to_char(t.col_sma1_ln_cnt), to_char(t.col_sma1_ln_bal), to_char(t.col_sma2_ln_cnt), to_char(t.col_sma2_ln_bal), to_char(t.col_sma3_ln_cnt), to_char(t.col_sma3_ln_bal),to_char(nvl(t.col_nonnpa_cnt,0)),to_char(nvl(t.col_nonnpa_bal,0)) from tbl_sma_classification_branch_dtl t, branch_dtl_new b,tbl_fzm_master f where t.col_brid = b.BRANCH_ID and b.reg_id=f.region_id and b.area_id = " & areaid & ""
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Else
            'sql1 = "select t.col_brid, t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, t.col_total_ln_cnt, t.col_total_ln_bal, t.col_nodue_ln_cnt, t.col_nodue_ln_bal, t.col_sma0_ln_cnt, t.col_sma0_ln_bal, t.col_sma1_ln_cnt, t.col_sma1_ln_bal, t.col_sma2_ln_cnt, t.col_sma2_ln_bal, t.col_sma3_ln_cnt, t.col_sma3_ln_bal from tbl_sma_classification_branch_dtl_his t, branch_dtl_new b where t.col_brid = b.BRANCH_ID and b.area_id = " & areaid & " and to_date(t.col_updt_date)='" & fdt & "'"
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','TOTAL COUNT','TOTAL BALANCE','NODUE COUNT','NODUE BALANCE','SMA0 COUNT','SMA0 BALANCE','SMA1 COUNT','SMA1 BALANCE','SMA2 COUNT','SMA2 BALANCE','SMA3 COUNT','SMA3 BALANCE','NON-NPA COUNT','NON-NPA BALANCE' from dual union all select to_char(t.col_brid), t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, to_char(t.col_total_ln_cnt), to_char(t.col_total_ln_bal), to_char(t.col_nodue_ln_cnt), to_char(t.col_nodue_ln_bal), to_char(t.col_sma0_ln_cnt), to_char(t.col_sma0_ln_bal), to_char(t.col_sma1_ln_cnt), to_char(t.col_sma1_ln_bal), to_char(t.col_sma2_ln_cnt), to_char(t.col_sma2_ln_bal), to_char(t.col_sma3_ln_cnt), to_char(t.col_sma3_ln_bal),to_char(nvl(t.col_nonnpa_cnt,0)),to_char(nvl(t.col_nonnpa_bal,0)) from tbl_sma_classification_branch_dtl_his t, branch_dtl_new b,tbl_fzm_master f where t.col_brid = b.BRANCH_ID and b.reg_id=f.region_id and b.area_id = " & areaid & " and to_date(t.col_updt_date)='" & fdt & "'"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        End If
       
        fnm = Gobj.ExportToExcelfile(dt1, Me.Server.MapPath(Me.Request.ApplicationPath))
        Response.ContentType = "application/vnd.ms-excel"
        Response.AppendHeader("Content-Disposition", "attachment; filename=ZONEWISE SMA CLASSIFICATION.xls")
        Response.TransmitFile(fnm)
        Response.End()
    End Sub

    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Server.Transfer("../../home.aspx")
    End Sub

    Protected Sub btn_excel_p_Click(sender As Object, e As EventArgs) Handles btn_excel_p.Click
        If fdt = tdt Then
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','STATE NAME','PLEDGE NO','CUSTOMER ID','TRANSACTION DATE','PLEDGE VALUE','NET WEIGHT','SCHEME','INTREST RATE','BALANCE','NET ACCRUED','INTREST RECEIVED','DUE DATE','AUCTION STATUS','INTREST PAID STATUS','PLEDGE CATEGORY','SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(ps.auc_att_status), to_char(py.INT_STATUS), nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO and br.area_id = " & areaid & ""
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Else
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','STATE NAME','PLEDGE NO','CUSTOMER ID','TRANSACTION DATE','PLEDGE VALUE','NET WEIGHT','SCHEME','INTREST RATE','BALANCE','NET ACCRUED','INTREST RECEIVED','DUE DATE','AUCTION STATUS','INTREST PAID STATUS','PLEDGE CATEGORY','SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(ps.auc_att_status), to_char(py.INT_STATUS), nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification_his sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO and br.area_id = " & areaid & " and to_date(sc.tra_d)t='" & fdt & "'"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        End If
        
        fnm = Gobj.ExportToExcelfile(dt1, Me.Server.MapPath(Me.Request.ApplicationPath))
        Response.ContentType = "application/vnd.ms-excel"
        Response.AppendHeader("Content-Disposition", "attachment; filename=ZONEWISE SMA CLASSIFICATION(pledge).xls")
        Response.TransmitFile(fnm)
        Response.End()
    End Sub
End Class
