Imports System.Data
Imports System.Data.OracleClient

Partial Class Pledge_SMA_classification_SMA_Zonewise
    Inherits System.Web.UI.Page

    Dim oh As New helper.oracle.OracleHelper
    Dim Gobj As New GHelper.Report.ExcelExport
    Dim sql, sql1, sql2 As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim tot_glwt, tot_glos, sma0_amt, sma1_amt, sma2_amt, sma3_amt, npa_per, tot_per, tot_lncnt, sma0_cnt, sma1_cnt, sma2_cnt, sma3_cnt, nodue_cnt, nodue_amt, nodue_per, due_cnt, due_amt, due_per, non_npa_amt, tot_npa_per, tot_npa_amt, npa_common_amt, npa_common, tot_npa_common As Double
    Dim fnm, fdt, tdt As String
    Dim non_npa_cnt As Integer
    Dim emp As Array

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim usr As String = Session("user_id")
        emp = usr.Split("!")
        fdt = Request.QueryString("fdt")
        dt2 = oh.ExecuteDataSet("select to_char(sysdate - 1,'dd/Mon/yyyy') from dual").Tables(0)
        tdt = dt2.Rows(0)(0)
        'If fdt > tdt Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.[GetType](), "alert", "alert('select a valid date..!!');window.location.replace('../../home.aspx');", True)

        'End If
        FillReportHeader()
        FillColumnHeader()
        FillColumnField()
        FillSummaryField()
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
        tc1.ColumnSpan = 54
        tc1.Text = "<font size=5><b>" & Session("firm_name") & "</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Gold
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red
        tr1.Controls.Add(tc1)
        tbl.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.ColumnSpan = 54
        tc2.Text = "<font size=2><b> BRANCH NAME : " & Session("branch_name") & " -- BRANCH ID : " & Session("branch_id") & " </font></b>"
        tc2.HorizontalAlign = HorizontalAlign.Center
        tr2.Controls.Add(tc2)
        tbl.Controls.Add(tr2)
        Dim tr3 As New TableRow
        Dim tc3 As New TableCell
        Dim tc31 As New TableCell
        Dim tc32 As New TableCell
        tc3.ColumnSpan = 12
        tc31.ColumnSpan = 29
        tc32.ColumnSpan = 13
        tc3.Text = "<font size=2><b>" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        tc3.HorizontalAlign = HorizontalAlign.Left


        'dt = oh.ExecuteDataSet("select to_char(sysdate-1,'dd/MON/yyyy') from dual").Tables(0)
        tc31.Text = "<font color='#663366' size=2><b>ZONEWISE SMA REPORT AS ON  " & fdt & "</font></b>"
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
        Dim tc41, tc42, tc43, tc44 As New TableCell
        tc41.ColumnSpan = 12
        tc42.ColumnSpan = 6
        tc43.ColumnSpan = 6
        tc44.ColumnSpan = 30
     
        tc41.Text = "<font size=2><b>SMA CLASSIFICATION REPORT</font></b>"
        tc42.Text = "<font size=2><b>NO DUES ACCOUNTS</font></b>"
        tc43.Text = "<font size=2><b>DUES ACCOUNTS</font></b>"
        tc44.Text = "<font size=2><b>BUCKETWISE DUE ACCOUNTS</font></b>"
      


        tc41.HorizontalAlign = HorizontalAlign.Center
        tc42.HorizontalAlign = HorizontalAlign.Center
        tc43.HorizontalAlign = HorizontalAlign.Center
        tc44.HorizontalAlign = HorizontalAlign.Center
    


        tr4.BackColor = Drawing.Color.DarkGray
        tr4.ForeColor = Drawing.Color.Black

        tr4.Controls.Add(tc41)
        tr4.Controls.Add(tc42)
        tr4.Controls.Add(tc43)
        tr4.Controls.Add(tc44)
      

        tbl.Controls.Add(tr4)

        Dim tr5 As New TableRow
        Dim tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc510, tc511, tc512, tc513, tc514, tc515, tc516 As New TableCell

        tc51.ColumnSpan = 5
        ' tc52.ColumnSpan = 2
        tc53.ColumnSpan = 4
        tc54.ColumnSpan = 3
        tc55.ColumnSpan = 4
        tc56.ColumnSpan = 2
        tc57.ColumnSpan = 4
        tc58.ColumnSpan = 2
        tc59.ColumnSpan = 4
        tc510.ColumnSpan = 4
        tc511.ColumnSpan = 4
        tc512.ColumnSpan = 6
        tc513.ColumnSpan = 4

        tc514.ColumnSpan = 3
        tc515.ColumnSpan = 4
        tc516.ColumnSpan = 1

        tc51.Text = "<font size=2><b>ZONE</font></b>"
        ' tc52.Text = "<font size=2><b>GL WT</font></b>"
        tc53.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc54.Text = "<font size=2><b>GL O/S</font></b>"
        tc55.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc56.Text = "<font size=2><b>GL O/S</font></b>"
        tc57.Text = "<font size=2><b>LOAN COUNT</font></b>"
        tc58.Text = "<font size=2><b>GL O/S</font></b>"
        tc59.Text = "<font size=2><b>SMA-0</font></b>"
        tc510.Text = "<font size=2><b>SMA-1</font></b>"
        tc511.Text = "<font size=2><b>SMA-2</font></b>"
        tc512.Text = "<font size=2><b>SMA-3</font></b>"
        tc513.Text = "<font size=2><b>NON-NPA</font></b>"
        tc514.Text = "<font size=2><b>Total</font></b>"
        tc515.Text = "<font size=2><b>NON-NPA CROSS</font></b>"
        tc516.Text = "<font size=2><b>NON-NPA TOTAL</font></b>"

        tc51.HorizontalAlign = HorizontalAlign.Center
        'tc52.HorizontalAlign = HorizontalAlign.Center
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
        tc51.BackColor = Drawing.Color.DarkGray
        'tc52.BackColor = Drawing.Color.DarkGray
        tc53.BackColor = Drawing.Color.DarkGray
        tc54.BackColor = Drawing.Color.DarkGray
        tc55.BackColor = Drawing.Color.DarkGray
        tc56.BackColor = Drawing.Color.DarkGray
        tc57.BackColor = Drawing.Color.DarkGray
        tc58.BackColor = Drawing.Color.DarkGray
        tc59.BackColor = Drawing.Color.YellowGreen
        tc510.BackColor = Drawing.Color.Yellow
        tc511.BackColor = Drawing.Color.Orange
        tc512.BackColor = Drawing.Color.Red
        tc513.BackColor = Drawing.Color.DarkGray
        tc514.BackColor = Drawing.Color.DarkGray
        tc515.BackColor = Drawing.Color.DarkGray
        tc516.BackColor = Drawing.Color.DarkGray

        tr5.ForeColor = Drawing.Color.Black

        tr5.Controls.Add(tc51)
        ' tr5.Controls.Add(tc52)
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
        tr5.Controls.Add(tc515)
        tr5.Controls.Add(tc516)
        tr5.Controls.Add(tc514)

        tbl.Controls.Add(tr5)

        Dim tr6 As New TableRow
        Dim tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc610, tc611, tc612, tc613, tc614, tc615, tc616, tc617, tc618, tc619, tc620, tc621, tc622, tc623, tc624, tc625, tc626 As New TableCell

        tc61.ColumnSpan = 5
        'tc62.ColumnSpan = 2
        tc63.ColumnSpan = 4
        tc64.ColumnSpan = 3
        tc65.ColumnSpan = 4
        tc66.ColumnSpan = 1
        tc67.ColumnSpan = 1
        tc68.ColumnSpan = 4
        tc69.ColumnSpan = 1
        tc610.ColumnSpan = 1
        tc611.ColumnSpan = 2
        tc612.ColumnSpan = 2
        tc613.ColumnSpan = 2
        tc614.ColumnSpan = 2
        tc615.ColumnSpan = 2
        tc616.ColumnSpan = 2
        tc617.ColumnSpan = 2
        tc618.ColumnSpan = 2
        tc619.ColumnSpan = 2
        tc620.ColumnSpan = 2
        tc621.ColumnSpan = 2
        tc622.ColumnSpan = 2
        tc623.ColumnSpan = 2
        tc624.ColumnSpan = 1
        tc625.ColumnSpan = 2
        tc626.ColumnSpan = 1
        tc61.Text = "<font size=2><b></font></b>"
        ' tc62.Text = "<font size=2><b>KG</font></b>"
        tc63.Text = "<font size=2><b>Number</font></b>"
        tc64.Text = "<font size=2><b>Crore</font></b>"
        tc65.Text = "<font size=2><b>Number</font></b>"
        tc66.Text = "<font size=2><b>Crore</font></b>"
        tc67.Text = "<font size=2><b>%</font></b>"
        tc68.Text = "<font size=2><b>Number</font></b>"
        tc69.Text = "<font size=2><b>Crore</font></b>"
        tc610.Text = "<font size=2><b>%</font></b>"
        tc611.Text = "<font size=2><b>Count</font></b>"
        tc612.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc613.Text = "<font size=2><b>Count</font></b>"
        tc614.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc615.Text = "<font size=2><b>Count</font></b>"
        tc616.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc617.Text = "<font size=2><b>Count</font></b>"
        tc618.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc619.Text = "<font size=2><b>%</font></b>"
        tc620.Text = "<font size=2><b>Count</font></b>"
        tc621.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc622.Text = "<font size=2><b>Count</font></b>"
        tc623.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc624.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc625.Text = "<font size=2><b>Amt-Cr</font></b>"
        tc626.Text = "<font size=2><b>%</font></b>"

        tc61.HorizontalAlign = HorizontalAlign.Center
        'tc62.HorizontalAlign = HorizontalAlign.Center
        tc63.HorizontalAlign = HorizontalAlign.Center
        tc64.HorizontalAlign = HorizontalAlign.Center
        tc65.HorizontalAlign = HorizontalAlign.Center
        tc66.HorizontalAlign = HorizontalAlign.Center
        tc67.HorizontalAlign = HorizontalAlign.Center
        tc68.HorizontalAlign = HorizontalAlign.Center
        tc69.HorizontalAlign = HorizontalAlign.Center
        tc610.HorizontalAlign = HorizontalAlign.Center
        tc611.HorizontalAlign = HorizontalAlign.Center
        tc612.HorizontalAlign = HorizontalAlign.Center
        tc613.HorizontalAlign = HorizontalAlign.Center
        tc614.HorizontalAlign = HorizontalAlign.Center
        tc615.HorizontalAlign = HorizontalAlign.Center
        tc616.HorizontalAlign = HorizontalAlign.Center
        tc617.HorizontalAlign = HorizontalAlign.Center
        tc618.HorizontalAlign = HorizontalAlign.Center
        tc619.HorizontalAlign = HorizontalAlign.Center
        tc620.HorizontalAlign = HorizontalAlign.Center
        tc621.HorizontalAlign = HorizontalAlign.Center
        tc622.HorizontalAlign = HorizontalAlign.Center
        tc623.HorizontalAlign = HorizontalAlign.Center
        tc624.HorizontalAlign = HorizontalAlign.Center
        tc625.HorizontalAlign = HorizontalAlign.Center
        tc626.HorizontalAlign = HorizontalAlign.Center

        tc61.BackColor = Drawing.Color.DarkGray
        ' tc62.BackColor = Drawing.Color.DarkGray
        tc63.BackColor = Drawing.Color.DarkGray
        tc64.BackColor = Drawing.Color.DarkGray
        tc65.BackColor = Drawing.Color.DarkGray
        tc66.BackColor = Drawing.Color.DarkGray
        tc67.BackColor = Drawing.Color.DarkGray
        tc68.BackColor = Drawing.Color.DarkGray
        tc69.BackColor = Drawing.Color.DarkGray
        tc610.BackColor = Drawing.Color.DarkGray
        tc611.BackColor = Drawing.Color.YellowGreen
        tc612.BackColor = Drawing.Color.YellowGreen
        tc613.BackColor = Drawing.Color.Yellow
        tc614.BackColor = Drawing.Color.Yellow
        tc615.BackColor = Drawing.Color.Orange
        tc616.BackColor = Drawing.Color.Orange
        tc617.BackColor = Drawing.Color.Red
        tc618.BackColor = Drawing.Color.Red
        tc619.BackColor = Drawing.Color.Red
        tc620.BackColor = Drawing.Color.DarkGray
        tc621.BackColor = Drawing.Color.DarkGray
        tc622.BackColor = Drawing.Color.DarkGray
        tc623.BackColor = Drawing.Color.DarkGray
        tc624.BackColor = Drawing.Color.DarkGray
        tc625.BackColor = Drawing.Color.DarkGray
        tc626.BackColor = Drawing.Color.DarkGray

        tr6.ForeColor = Drawing.Color.Black

        tr6.Controls.Add(tc61)
        ' tr6.Controls.Add(tc62)
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
        tr6.Controls.Add(tc620)
        tr6.Controls.Add(tc621)
        tr6.Controls.Add(tc622)
        tr6.Controls.Add(tc623)
        tr6.Controls.Add(tc624)
        tr6.Controls.Add(tc625)
        tr6.Controls.Add(tc626)

        tbl.Controls.Add(tr6)
    End Sub
    Sub FillColumnField()

        tot_glwt = 0
        tot_lncnt = 0
        tot_glos = 0
        nodue_cnt = 0
        nodue_amt = 0
        nodue_per = 0
        due_cnt = 0
        due_amt = 0
        due_per = 0
        sma0_cnt = 0
        sma0_amt = 0
        sma1_cnt = 0
        sma1_amt = 0
        sma2_cnt = 0
        sma2_amt = 0
        sma3_cnt = 0
        sma3_amt = 0
        non_npa_cnt = 0
        non_npa_amt = 0
        npa_per = 0
        tot_per = 0
        tot_npa_per = 0
        tot_npa_amt = 0
        npa_common = 0
        npa_common_amt = 0
        tot_npa_common = 0
        If fdt = tdt Then
            sql = "select f.fzm, round(sum(S.COL_GL_WT) / 1000, 2) GL_WEIGHT, sum(s.col_total_ln_cnt) PLEDGE_COUNT, round(sum(s.col_total_ln_bal) / 10000000, 2) PLEDGE_AMOUNT, sum(s.col_nodue_ln_cnt) NO_DUE_COUNT, round(sum(s.col_nodue_ln_bal) / 10000000, 2) NO_DUE_AMOUNT, round((sum(s.col_nodue_ln_bal) / 10000000) /(sum(s.col_total_ln_bal) / 10000000) * 100, 2) NO_DUE_PERCENTAGE, sum(nvl(s.col_sma0_ln_cnt, 0) + nvl(s.col_sma1_ln_cnt, 0) + nvl(s.col_sma2_ln_cnt, 0) + nvl(s.col_sma3_ln_cnt, 0)) DUES_COUNT, round(sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0)), 2) DUES_AMOUNT, round((sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0))) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) DUES_PERCENTAGE, sum(s.col_sma0_ln_cnt) SMA0_COUNT, round(sum(s.col_sma0_ln_bal) / 10000000, 2) SMA0_AMOUNT, sum(s.col_sma1_ln_cnt) SMA1_COUNT, round(sum(s.col_sma1_ln_bal) / 10000000, 2) SMA1_AMOUNT, sum(s.col_sma2_ln_cnt) SMA2_COUNT, round(sum(s.col_sma2_ln_bal) / 10000000, 2) SMA2_AMOUNT, sum(s.col_sma3_ln_cnt) SMA3_COUNT, round(sum(s.col_sma3_ln_bal) / 10000000, 2) SMA3_AMOUNT, round((sum(s.col_sma3_ln_bal) / 10000000) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) NPA_PERCENTAGE, f.fzm_id zoneid, nvl(sum(s.col_nonnpa_cnt), 0) NONNPA_COUNT, nvl(round(sum(s.col_nonnpa_bal) / 10000000, 2), 0) NONNPA_BALANCE, nvl(sum(s.col_nonnpa_common_cnt), 0) NONNPACommon_COUNT, nvl(round(sum(s.col_nonnpa_common_bal) / 10000000, 2), 0) NONNPACommon_BALANCE, round(nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL_NONNPA_COMMON, round((sum(s.col_sma3_ln_bal) / 10000000) + nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL, round((nvl((sum(s.col_sma3_ln_bal) / 10000000), 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0)) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) TOTAL_PERCENTAGE from mana0809.tbl_sma_classification_branch_dtl s, mana0809.branch_dtl_new b, mana0809.tbl_fzm_master f where s.col_brid = b.BRANCH_ID and b.reg_id = f.region_id group by f.fzm, f.fzm_id order by f.fzm_id "
            'sql = "select f.fzm, round(sum(S.COL_GL_WT) / 1000, 2) GL_WEIGHT, sum(s.col_total_ln_cnt) PLEDGE_COUNT, round(sum(s.col_total_ln_bal) / 10000000, 2) PLEDGE_AMOUNT, sum(s.col_nodue_ln_cnt) NO_DUE_COUNT, round(sum(s.col_nodue_ln_bal) / 10000000, 2) NO_DUE_AMOUNT, round((sum(s.col_nodue_ln_bal) / 10000000) /(sum(s.col_total_ln_bal) / 10000000) * 100, 2) NO_DUE_PERCENTAGE, sum(nvl(s.col_sma0_ln_cnt, 0) + nvl(s.col_sma1_ln_cnt, 0) + nvl(s.col_sma2_ln_cnt, 0) + nvl(s.col_sma3_ln_cnt, 0)) DUES_COUNT, round(sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0)), 2) DUES_AMOUNT, round((sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0))) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) DUES_PERCENTAGE, sum(s.col_sma0_ln_cnt) SMA0_COUNT, round(sum(s.col_sma0_ln_bal) / 10000000, 2) SMA0_AMOUNT, sum(s.col_sma1_ln_cnt) SMA1_COUNT, round(sum(s.col_sma1_ln_bal) / 10000000, 2) SMA1_AMOUNT, sum(s.col_sma2_ln_cnt) SMA2_COUNT, round(sum(s.col_sma2_ln_bal) / 10000000, 2) SMA2_AMOUNT, sum(s.col_sma3_ln_cnt) SMA3_COUNT, round(sum(s.col_sma3_ln_bal) / 10000000, 2) SMA3_AMOUNT, round((sum(s.col_sma3_ln_bal) / 10000000) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) NPA_PERCENTAGE, f.fzm_id zoneid,nvl(sum(s.col_nonnpa_cnt),0) NONNPA_COUNT, nvl(round(sum(s.col_nonnpa_bal) / 10000000, 2),0) NONNPA_BALANCE, round((sum(s.col_sma3_ln_bal) / 10000000) + nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL,round((nvl((sum(s.col_sma3_ln_bal) / 10000000),0) + nvl(sum(s.col_nonnpa_bal) / 10000000,0))/(sum(s.col_total_ln_bal) / 10000000) * 100,2) TOTAL_PERCENTAGE, nvl(sum(s.col_nonnpa_common_cnt), 0) NONNPACommon_COUNT, nvl(round(sum(s.col_nonnpa_common_bal) / 10000000, 2), 0) NONNPACommon_BALANCE, round(nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL_NONNPA_COMMON from tbl_sma_classification_branch_dtl s,branch_dtl_new b,tbl_fzm_master f where s.col_brid=b.BRANCH_ID and b.reg_id=f.region_id group by f.fzm,f.fzm_id order by f.fzm_id"
            dt = oh.ExecuteDataSet(sql).Tables(0)
        Else
            sql = "select f.fzm, round(sum(S.COL_GL_WT) / 1000, 2) GL_WEIGHT, sum(s.col_total_ln_cnt) PLEDGE_COUNT, round(sum(s.col_total_ln_bal) / 10000000, 2) PLEDGE_AMOUNT, sum(s.col_nodue_ln_cnt) NO_DUE_COUNT, round(sum(s.col_nodue_ln_bal) / 10000000, 2) NO_DUE_AMOUNT, round((sum(s.col_nodue_ln_bal) / 10000000) /(sum(s.col_total_ln_bal) / 10000000) * 100, 2) NO_DUE_PERCENTAGE, sum(nvl(s.col_sma0_ln_cnt, 0) + nvl(s.col_sma1_ln_cnt, 0) + nvl(s.col_sma2_ln_cnt, 0) + nvl(s.col_sma3_ln_cnt, 0)) DUES_COUNT, round(sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0)), 2) DUES_AMOUNT, round((sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0))) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) DUES_PERCENTAGE, sum(s.col_sma0_ln_cnt) SMA0_COUNT, round(sum(s.col_sma0_ln_bal) / 10000000, 2) SMA0_AMOUNT, sum(s.col_sma1_ln_cnt) SMA1_COUNT, round(sum(s.col_sma1_ln_bal) / 10000000, 2) SMA1_AMOUNT, sum(s.col_sma2_ln_cnt) SMA2_COUNT, round(sum(s.col_sma2_ln_bal) / 10000000, 2) SMA2_AMOUNT, sum(s.col_sma3_ln_cnt) SMA3_COUNT, round(sum(s.col_sma3_ln_bal) / 10000000, 2) SMA3_AMOUNT, round((sum(s.col_sma3_ln_bal) / 10000000) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) NPA_PERCENTAGE, f.fzm_id zoneid, nvl(sum(s.col_nonnpa_cnt), 0) NONNPA_COUNT, nvl(round(sum(s.col_nonnpa_bal) / 10000000, 2), 0) NONNPA_BALANCE, nvl(sum(s.col_nonnpa_common_cnt), 0) NONNPACommon_COUNT, nvl(round(sum(s.col_nonnpa_common_bal) / 10000000, 2), 0) NONNPACommon_BALANCE, round(nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL_NONNPA_COMMON, round((sum(s.col_sma3_ln_bal) / 10000000) + nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL, round((nvl((sum(s.col_sma3_ln_bal) / 10000000), 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0)) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) TOTAL_PERCENTAGE from mana0809.tbl_sma_classification_branch_dtl_his s, mana0809.branch_dtl_new b, mana0809.tbl_fzm_master f where s.col_brid = b.BRANCH_ID and b.reg_id = f.region_id and to_date(s.col_updt_date)='" & fdt & "' group by f.fzm, f.fzm_id order by f.fzm_id "
            'sql = "select f.fzm, round(sum(S.COL_GL_WT) / 1000, 2) GL_WEIGHT, sum(s.col_total_ln_cnt) PLEDGE_COUNT, round(sum(s.col_total_ln_bal) / 10000000, 2) PLEDGE_AMOUNT, sum(s.col_nodue_ln_cnt) NO_DUE_COUNT, round(sum(s.col_nodue_ln_bal) / 10000000, 2) NO_DUE_AMOUNT, round((sum(s.col_nodue_ln_bal) / 10000000) /(sum(s.col_total_ln_bal) / 10000000) * 100, 2) NO_DUE_PERCENTAGE, sum(nvl(s.col_sma0_ln_cnt, 0) + nvl(s.col_sma1_ln_cnt, 0) + nvl(s.col_sma2_ln_cnt, 0) + nvl(s.col_sma3_ln_cnt, 0)) DUES_COUNT, round(sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0)), 2) DUES_AMOUNT, round((sum(nvl(s.col_sma0_ln_bal / 10000000, 0) + nvl(s.col_sma1_ln_bal / 10000000, 0) + nvl(s.col_sma2_ln_bal / 10000000, 0) + nvl(s.col_sma3_ln_bal / 10000000, 0))) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) DUES_PERCENTAGE, sum(s.col_sma0_ln_cnt) SMA0_COUNT, round(sum(s.col_sma0_ln_bal) / 10000000, 2) SMA0_AMOUNT, sum(s.col_sma1_ln_cnt) SMA1_COUNT, round(sum(s.col_sma1_ln_bal) / 10000000, 2) SMA1_AMOUNT, sum(s.col_sma2_ln_cnt) SMA2_COUNT, round(sum(s.col_sma2_ln_bal) / 10000000, 2) SMA2_AMOUNT, sum(s.col_sma3_ln_cnt) SMA3_COUNT, round(sum(s.col_sma3_ln_bal) / 10000000, 2) SMA3_AMOUNT, round((sum(s.col_sma3_ln_bal) / 10000000) / (sum(s.col_total_ln_bal) / 10000000) * 100, 2) NPA_PERCENTAGE, f.fzm_id zoneid,nvl(sum(s.col_nonnpa_cnt),0) NONNPA_COUNT, nvl(round(sum(s.col_nonnpa_bal) / 10000000, 2),0) NONNPA_BALANCE, round((sum(s.col_sma3_ln_bal) / 10000000) + nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL,round((nvl((sum(s.col_sma3_ln_bal) / 10000000),0) + nvl(sum(s.col_nonnpa_bal) / 10000000,0))/(sum(s.col_total_ln_bal) / 10000000) * 100,2) TOTAL_PERCENTAGE, nvl(sum(s.col_nonnpa_common_cnt), 0) NONNPACommon_COUNT, nvl(round(sum(s.col_nonnpa_common_bal) / 10000000, 2), 0) NONNPACommon_BALANCE, round(nvl(sum(s.col_nonnpa_common_bal) / 10000000, 0) + nvl(sum(s.col_nonnpa_bal) / 10000000, 0), 2) TOTAL_NONNPA_COMMON from tbl_sma_classification_branch_dtl_his s,branch_dtl_new b,tbl_fzm_master f where s.col_brid=b.BRANCH_ID and b.reg_id=f.region_id and to_date(s.col_updt_date)='" & fdt & "' group by f.fzm,f.fzm_id order by f.fzm_id"
            dt = oh.ExecuteDataSet(sql).Tables(0)
        End If
        
        Dim color As Integer = 0
        For Each dr In dt.Rows

            Dim tr7 As New TableRow
            tr7.Height = "20"
            Dim tc71, tc72, tc73, tc74, tc75, tc76, tc77, tc78, tc79, tc710, tc711, tc712, tc713, tc714, tc715, tc716, tc717, tc718, tc719, tc720, tc721, tc722, tc723, tc724, tc725, tc726 As New TableCell
            If color = 0 Then
                tr7.BackColor = Drawing.Color.AliceBlue
                color = 1
            Else
                tr7.BackColor = Drawing.Color.LightGray
                color = 0
            End If
            tc71.ColumnSpan = 5
            'tc72.ColumnSpan = 2
            tc73.ColumnSpan = 4
            tc74.ColumnSpan = 3
            tc75.ColumnSpan = 4
            tc76.ColumnSpan = 1
            tc77.ColumnSpan = 1
            tc78.ColumnSpan = 4
            tc79.ColumnSpan = 1
            tc710.ColumnSpan = 1
            tc711.ColumnSpan = 2
            tc712.ColumnSpan = 2
            tc713.ColumnSpan = 2
            tc714.ColumnSpan = 2
            tc715.ColumnSpan = 2
            tc716.ColumnSpan = 2
            tc717.ColumnSpan = 2
            tc718.ColumnSpan = 2
            tc719.ColumnSpan = 2
            tc720.ColumnSpan = 2
            tc721.ColumnSpan = 2
            tc722.ColumnSpan = 2
            tc723.ColumnSpan = 2
            tc724.ColumnSpan = 1
            tc725.ColumnSpan = 2
            tc726.ColumnSpan = 1

            tc71.Text = "<font size=2><a href = javascript:GetRegionwiseSMA(" & dr(19) & ",'" & fdt & "','" & tdt & "') > " & dr(0) & "</a></font>" 'zone id
            ' tc72.Text = "<font size=2>" & dr(1) & "</font>" 'glwt
            tc73.Text = "<font size=2>" & dr(2) & "</font>"
            tc74.Text = "<font size=2>" & dr(3) & "</font>"
            tc75.Text = "<font size=2>" & dr(4) & "</font>"
            tc76.Text = "<font size=2>" & dr(5) & "</font>"
            tc77.Text = "<font size=2>" & dr(6) & "%</font>"
            tc78.Text = "<font size=2>" & dr(7) & "</font>"
            tc79.Text = "<font size=2>" & dr(8) & "</font>"
            tc710.Text = "<font size=2>" & dr(9) & "%</font>"
            tc711.Text = "<font size=2>" & dr(10) & "</font>"
            tc712.Text = "<font size=2>" & dr(11) & "</font>"
            tc713.Text = "<font size=2>" & dr(12) & "</font>"
            tc714.Text = "<font size=2>" & dr(13) & "</font>"
            tc715.Text = "<font size=2>" & dr(14) & "</font>"
            tc716.Text = "<font size=2>" & dr(15) & "</font>"
            tc717.Text = "<font size=2>" & dr(16) & "</font>"
            tc718.Text = "<font size=2>" & dr(17) & "</font>"
            tc719.Text = "<font size=2>" & dr(18) & "%</font>"
            tc720.Text = "<font size=2>" & dr(20) & "</font>"
            tc721.Text = "<font size=2>" & dr(21) & "</font>"
            tc722.Text = "<font size=2>" & dr(22) & "</font>"
            tc723.Text = "<font size=2>" & dr(23) & "</font>"
            tc724.Text = "<font size=2>" & dr(24) & "</font>"
            tc725.Text = "<font size=2>" & dr(25) & "</font>"
            tc726.Text = "<font size=2>" & dr(26) & "%</font>"

            tc71.HorizontalAlign = HorizontalAlign.Left
            ' tc72.HorizontalAlign = HorizontalAlign.Left
            tc73.HorizontalAlign = HorizontalAlign.Left
            tc74.HorizontalAlign = HorizontalAlign.Left
            tc75.HorizontalAlign = HorizontalAlign.Left
            tc76.HorizontalAlign = HorizontalAlign.Left
            tc77.HorizontalAlign = HorizontalAlign.Left
            tc78.HorizontalAlign = HorizontalAlign.Left
            tc79.HorizontalAlign = HorizontalAlign.Left
            tc710.HorizontalAlign = HorizontalAlign.Left
            tc711.HorizontalAlign = HorizontalAlign.Left
            tc712.HorizontalAlign = HorizontalAlign.Left
            tc713.HorizontalAlign = HorizontalAlign.Left
            tc714.HorizontalAlign = HorizontalAlign.Left
            tc715.HorizontalAlign = HorizontalAlign.Left
            tc716.HorizontalAlign = HorizontalAlign.Left
            tc717.HorizontalAlign = HorizontalAlign.Left
            tc718.HorizontalAlign = HorizontalAlign.Left
            tc719.HorizontalAlign = HorizontalAlign.Left
            tc720.HorizontalAlign = HorizontalAlign.Left
            tc721.HorizontalAlign = HorizontalAlign.Left
            tc722.HorizontalAlign = HorizontalAlign.Left
            tc723.HorizontalAlign = HorizontalAlign.Left
            tc724.HorizontalAlign = HorizontalAlign.Left
            tc725.HorizontalAlign = HorizontalAlign.Left
            tc726.HorizontalAlign = HorizontalAlign.Left
            'tc71.BackColor = Drawing.Color.AliceBlue
            'tc72.BackColor = Drawing.Color.RoyalBlue
            'tc73.BackColor = Drawing.Color.RoyalBlue
            'tc74.BackColor = Drawing.Color.RoyalBlue
            'tc75.BackColor = Drawing.Color.Green
            'tc76.BackColor = Drawing.Color.Green
            'tc77.BackColor = Drawing.Color.Green
            'tc78.BackColor = Drawing.Color.DarkRed
            'tc79.BackColor = Drawing.Color.DarkRed
            'tc710.BackColor = Drawing.Color.DarkRed
            tc711.BackColor = Drawing.Color.YellowGreen
            tc712.BackColor = Drawing.Color.YellowGreen
            tc713.BackColor = Drawing.Color.Yellow
            tc714.BackColor = Drawing.Color.Yellow
            tc715.BackColor = Drawing.Color.Orange
            tc716.BackColor = Drawing.Color.Orange
            tc717.BackColor = Drawing.Color.Red
            tc718.BackColor = Drawing.Color.Red
            tc719.BackColor = Drawing.Color.Red
            'tc720.BackColor = Drawing.Color.MistyRose
            'tc721.BackColor = Drawing.Color.MistyRose

            tr7.ForeColor = Drawing.Color.Black

            tr7.Controls.Add(tc71)
            ' tr7.Controls.Add(tc72)
            tr7.Controls.Add(tc73)
            tr7.Controls.Add(tc74)
            tr7.Controls.Add(tc75)
            tr7.Controls.Add(tc76)
            tr7.Controls.Add(tc77)
            tr7.Controls.Add(tc78)
            tr7.Controls.Add(tc79)
            tr7.Controls.Add(tc710)
            tr7.Controls.Add(tc711)
            tr7.Controls.Add(tc712)
            tr7.Controls.Add(tc713)
            tr7.Controls.Add(tc714)
            tr7.Controls.Add(tc715)
            tr7.Controls.Add(tc716)
            tr7.Controls.Add(tc717)
            tr7.Controls.Add(tc718)
            tr7.Controls.Add(tc719)
            tr7.Controls.Add(tc720)
            tr7.Controls.Add(tc721)
            tr7.Controls.Add(tc722)
            tr7.Controls.Add(tc723)
            tr7.Controls.Add(tc724)
            tr7.Controls.Add(tc725)
            tr7.Controls.Add(tc726)


            tbl.Controls.Add(tr7)

            ' tot_glwt += dr(1)
            tot_lncnt += dr(2)
            tot_glos += dr(3)
            nodue_cnt += dr(4)
            nodue_amt += dr(5)
            due_cnt += dr(7)
            due_amt += dr(8)
            sma0_cnt += dr(10)
            sma0_amt += dr(11)
            sma1_cnt += dr(12)
            sma1_amt += dr(13)
            sma2_cnt += dr(14)
            sma2_amt += dr(15)
            sma3_cnt += dr(16)
            sma3_amt += dr(17)
            non_npa_cnt += dr(20)
            non_npa_amt += dr(21)
            npa_common += dr(22)
            npa_common_amt += dr(23)
            tot_npa_common += dr(24)
            tot_npa_amt += dr(25)

        Next
        nodue_per = (nodue_amt / tot_glos) * 100
        due_per = (due_amt / tot_glos) * 100
        tot_per = (sma3_amt / tot_glos) * 100
        tot_npa_per = (tot_npa_amt / tot_glos) * 100


    End Sub
    Sub FillSummaryField()
       
        Dim tr25 As New TableRow
        Dim tcc1, tcc2, tcc3, tcc4, tcc5, tcc6, tcc7, tcc8, tcc9, tcc10, tcc11, tcc12, tcc13, tcc14, tcc15, tcc16, tcc17, tcc18, tcc19, tcc20, tcc21, tcc22, tcc23, tcc24, tcc25, tcc26 As New TableCell
        tcc1.ColumnSpan = 5
        'tcc2.ColumnSpan = 2
        tcc3.ColumnSpan = 4
        tcc4.ColumnSpan = 3
        tcc5.ColumnSpan = 4
        tcc6.ColumnSpan = 1
        tcc7.ColumnSpan = 1
        tcc8.ColumnSpan = 4
        tcc9.ColumnSpan = 1
        tcc10.ColumnSpan = 1
        tcc11.ColumnSpan = 2
        tcc12.ColumnSpan = 2
        tcc13.ColumnSpan = 2
        tcc14.ColumnSpan = 2
        tcc15.ColumnSpan = 2
        tcc16.ColumnSpan = 2
        tcc17.ColumnSpan = 2
        tcc18.ColumnSpan = 2
        tcc19.ColumnSpan = 2
        tcc20.ColumnSpan = 2
        tcc21.ColumnSpan = 2
        tcc22.ColumnSpan = 2
        tcc23.ColumnSpan = 2
        tcc24.ColumnSpan = 1
        tcc25.ColumnSpan = 2
        tcc26.ColumnSpan = 1
       

        tr25.BackColor = Drawing.Color.BlanchedAlmond

        tcc1.Text = "<font size=3><b>TOTAL </font></b>"
        ' tcc2.Text = "<font size=3><b>" & tot_glwt & "</font></b>"
        tcc3.Text = "<font size=2><b>" & tot_lncnt & "</font></b>"
        tcc4.Text = "<font size=3><b>" & tot_glos & "</font></b>"
        tcc5.Text = "<font size=2><b>" & nodue_cnt & "</font></b>"
        tcc6.Text = "<font size=3><b>" & nodue_amt & "</font></b>"
        tcc7.Text = "<font size=2><b>" & Math.Round(nodue_per, 2) & "%</font></b>"
        tcc8.Text = "<font size=2><b>" & due_cnt & "</font></b>"
        tcc9.Text = "<font size=2><b>" & due_amt & "</font></b>"
        tcc10.Text = "<font size=2><b>" & Math.Round(due_per, 2) & "%</font></b>"
        tcc11.Text = "<font size=2><b>" & sma0_cnt & "</font></b>"
        tcc12.Text = "<font size=2><b>" & sma0_amt & "</font></b>"
        tcc13.Text = "<font size=2><b>" & sma1_cnt & "</font></b>"
        tcc14.Text = "<font size=2><b>" & sma1_amt & "</font></b>"
        tcc15.Text = "<font size=2><b>" & sma2_cnt & "</font></b>"
        tcc16.Text = "<font size=2><b>" & sma2_amt & "</font></b>"
        tcc17.Text = "<font size=2><b>" & sma3_cnt & "</font></b>"
        tcc18.Text = "<font size=2><b>" & sma3_amt & "</font></b>"
        tcc19.Text = "<font size=2><b>" & Math.Round(tot_per, 2) & "%</font></b>"
        tcc20.Text = "<font size=2><b>" & non_npa_cnt & "</font></b>"
        tcc21.Text = "<font size=2><b>" & non_npa_amt & "</font></b>"
        tcc22.Text = "<font size=2><b>" & npa_common & "</font></b>"
        tcc23.Text = "<font size=2><b>" & npa_common_amt & "</font></b>"
        tcc24.Text = "<font size=2><b>" & tot_npa_common & "</font></b>"
        tcc25.Text = "<font size=2><b>" & tot_npa_amt & "</font></b>"
        tcc26.Text = "<font size=2><b>" & Math.Round(tot_npa_per, 2) & "%</font></b>"

        'tcc1.BackColor = Drawing.Color.RoyalBlue
        'tcc2.BackColor = Drawing.Color.RoyalBlue
        'tcc3.BackColor = Drawing.Color.RoyalBlue
        'tcc4.BackColor = Drawing.Color.RoyalBlue
        'tcc5.BackColor = Drawing.Color.Green
        'tcc6.BackColor = Drawing.Color.Green
        'tcc7.BackColor = Drawing.Color.Green
        'tcc8.BackColor = Drawing.Color.DarkRed
        'tcc9.BackColor = Drawing.Color.DarkRed
        'tcc10.BackColor = Drawing.Color.DarkRed
        tcc11.BackColor = Drawing.Color.YellowGreen
        tcc12.BackColor = Drawing.Color.YellowGreen
        tcc13.BackColor = Drawing.Color.Yellow
        tcc14.BackColor = Drawing.Color.Yellow
        tcc15.BackColor = Drawing.Color.Orange
        tcc16.BackColor = Drawing.Color.Orange
        tcc17.BackColor = Drawing.Color.Red
        tcc18.BackColor = Drawing.Color.Red
        tcc19.BackColor = Drawing.Color.Red
        'tcc20.BackColor = Drawing.Color.MistyRose
        'tcc21.BackColor = Drawing.Color.MistyRose


        tr25.Controls.Add(tcc1)
        ' tr25.Controls.Add(tcc2)
        tr25.Controls.Add(tcc3)
        tr25.Controls.Add(tcc4)
        tr25.Controls.Add(tcc5)
        tr25.Controls.Add(tcc6)
        tr25.Controls.Add(tcc7)
        tr25.Controls.Add(tcc8)
        tr25.Controls.Add(tcc9)
        tr25.Controls.Add(tcc10)
        tr25.Controls.Add(tcc11)
        tr25.Controls.Add(tcc12)
        tr25.Controls.Add(tcc13)
        tr25.Controls.Add(tcc14)
        tr25.Controls.Add(tcc15)
        tr25.Controls.Add(tcc16)
        tr25.Controls.Add(tcc17)
        tr25.Controls.Add(tcc18)
        tr25.Controls.Add(tcc19)
        tr25.Controls.Add(tcc20)
        tr25.Controls.Add(tcc21)
        tr25.Controls.Add(tcc22)
        tr25.Controls.Add(tcc23)
        tr25.Controls.Add(tcc24)
        tr25.Controls.Add(tcc25)
        tr25.Controls.Add(tcc26)

        tbl.Controls.Add(tr25)
    End Sub

    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        If fdt = tdt Then
            'sql1 = "select t.col_brid, t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, t.col_total_ln_cnt, t.col_total_ln_bal, t.col_nodue_ln_cnt, t.col_nodue_ln_bal, t.col_sma0_ln_cnt, t.col_sma0_ln_bal, t.col_sma1_ln_cnt, t.col_sma1_ln_bal, t.col_sma2_ln_cnt, t.col_sma2_ln_bal, t.col_sma3_ln_cnt, t.col_sma3_ln_bal from tbl_sma_classification_branch_dtl t, branch_dtl_new b,tbl_fzm_master f where t.col_brid = b.BRANCH_ID and b.reg_id=f.region_id"
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','TOTAL COUNT','TOTAL BALANCE','NODUE COUNT','NODUE BALANCE','SMA0 COUNT','SMA0 BALANCE','SMA1 COUNT','SMA1 BALANCE','SMA2 COUNT','SMA2 BALANCE','SMA3 COUNT','SMA3 BALANCE','NON-NPA COUNT','NON-NPA BALANCE' from dual union all select to_char(t.col_brid), t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, to_char(t.col_total_ln_cnt), to_char(t.col_total_ln_bal), to_char(t.col_nodue_ln_cnt), to_char(t.col_nodue_ln_bal), to_char(t.col_sma0_ln_cnt), to_char(t.col_sma0_ln_bal), to_char(t.col_sma1_ln_cnt), to_char(t.col_sma1_ln_bal), to_char(t.col_sma2_ln_cnt), to_char(t.col_sma2_ln_bal), to_char(t.col_sma3_ln_cnt), to_char(t.col_sma3_ln_bal),to_char(nvl(t.col_nonnpa_cnt,0)),to_char(nvl(t.col_nonnpa_bal,0)) from tbl_sma_classification_branch_dtl t, branch_dtl_new b,tbl_fzm_master f where t.col_brid = b.BRANCH_ID and b.reg_id=f.region_id"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Else
            'sql1 = "select t.col_brid, t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, t.col_total_ln_cnt, t.col_total_ln_bal, t.col_nodue_ln_cnt, t.col_nodue_ln_bal, t.col_sma0_ln_cnt, t.col_sma0_ln_bal, t.col_sma1_ln_cnt, t.col_sma1_ln_bal, t.col_sma2_ln_cnt, t.col_sma2_ln_bal, t.col_sma3_ln_cnt, t.col_sma3_ln_bal from tbl_sma_classification_branch_dtl_his t, branch_dtl_new b,tbl_fzm_master f where t.col_brid = b.BRANCH_ID and b.reg_id=f.region_id and to_date(t.col_updt_date)='" & fdt & "'"
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','TOTAL COUNT','TOTAL BALANCE','NODUE COUNT','NODUE BALANCE','SMA0 COUNT','SMA0 BALANCE','SMA1 COUNT','SMA1 BALANCE','SMA2 COUNT','SMA2 BALANCE','SMA3 COUNT','SMA3 BALANCE','NON-NPA COUNT','NON-NPA BALANCE' from dual union all select to_char(t.col_brid), t.col_brnch_nm, t.col_area_nm, t.col_reg_nm, t.col_zone_nm, to_char(t.col_total_ln_cnt), to_char(t.col_total_ln_bal), to_char(t.col_nodue_ln_cnt), to_char(t.col_nodue_ln_bal), to_char(t.col_sma0_ln_cnt), to_char(t.col_sma0_ln_bal), to_char(t.col_sma1_ln_cnt), to_char(t.col_sma1_ln_bal), to_char(t.col_sma2_ln_cnt), to_char(t.col_sma2_ln_bal), to_char(t.col_sma3_ln_cnt), to_char(t.col_sma3_ln_bal),to_char(nvl(t.col_nonnpa_cnt,0)),to_char(nvl(t.col_nonnpa_bal,0)) from tbl_sma_classification_branch_dtl_his t, branch_dtl_new b,tbl_fzm_master f where t.col_brid = b.BRANCH_ID and b.reg_id=f.region_id and to_date(t.col_updt_date)='" & fdt & "'"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        End If
        
        fnm = Gobj.ExportToExcelfile(dt1, Me.Server.MapPath(Me.Request.ApplicationPath))
        Response.ContentType = "application/vnd.ms-excel"
        Response.AppendHeader("Content-Disposition", "attachment; filename=ZONEWISE SMA CLASSIFICATION(branch).xls")
        Response.TransmitFile(fnm)
        Response.End()
    End Sub

    Protected Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Server.Transfer("../../home.aspx")
    End Sub

    Protected Sub btn_excel_p_Click(sender As Object, e As EventArgs) Handles btn_excel_p.Click
        If fdt = tdt Then
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','STATE NAME','PLEDGE NO','CUSTOMER ID','TRANSACTION DATE','PLEDGE VALUE','NET WEIGHT','SCHEME','INTREST RATE','BALANCE','NET ACCRUED','INTREST RECEIVED','DUE DATE','AUCTION STATUS','INTREST PAID STATUS','PLEDGE CATEGORY','SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(ps.auc_att_status), to_char(py.INT_STATUS), nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Else
            sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','STATE NAME','PLEDGE NO','CUSTOMER ID','TRANSACTION DATE','PLEDGE VALUE','NET WEIGHT','SCHEME','INTREST RATE','BALANCE','NET ACCRUED','INTREST RECEIVED','DUE DATE','AUCTION STATUS','INTREST PAID STATUS','PLEDGE CATEGORY','SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(ps.auc_att_status), to_char(py.INT_STATUS), nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification_his sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO and to_date(sc.tra_d)t='" & fdt & "'"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        End If
        
        fnm = Gobj.ExportToExcelfile(dt1, Me.Server.MapPath(Me.Request.ApplicationPath))
        Response.ContentType = "application/vnd.ms-excel"
        Response.AppendHeader("Content-Disposition", "attachment; filename=ZONEWISE SMA CLASSIFICATION(pledge).xls")
        Response.TransmitFile(fnm)
        Response.End()
    End Sub
End Class
