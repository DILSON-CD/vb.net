
Imports System.Data

Partial Class Branch_profile_branch_profile_report
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1, sql2, sql3, sql4, sql5, sql6, fnm, br_id, zone As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6 As New DataTable
    Dim dr As DataRow
    Dim tbl, tbl1, tbl2, tbl3, tbl4, tbl5, tbl6, tbl7, tbl8, tbl9, tbl10, tbl11, tbl12, tbl13, tbl14, tbl15, tbl16, tbl17 As New Table
    Dim fr_dt, to_dt, zoneid, branchid As String
    Dim dt_id, str1 As String
    Dim usrID, areaid As Integer
    Dim brid As Integer
    Dim total As Integer
    Public Class GlobalVariables
        Public Shared post As String
    End Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim usrDtl() As String = CStr(Session("user_id")).Split(CChar("!"))
        usrID = CInt(usrDtl(0))

        GlobalVariables.post = oh.ExecuteDataSet("select t.post_id,t.department_id from employee_master t where t.emp_code=" & usrID & "  and t.status_id=1 ").Tables(0).Rows(0)(0)

        brid = Me.Session("branch_id")
        If brid = 0 Then
            sql = "select count(*) from FORM_ACCESSIBILITY t where t.form_id=7184 and t.emp_id=" & usrID & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows(0)(0) > 0 Then
                GlobalVariables.post = 0
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised to View this Page!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            End If

        End If
        If (GlobalVariables.post = 0 Or GlobalVariables.post = 10 Or GlobalVariables.post = 136 Or GlobalVariables.post = 199 Or GlobalVariables.post = -36) Then
            If GlobalVariables.post = 10 Then
                brid = Me.Session("branch_id")
                Me.tbl_srch.Visible = False
                Fillbranch_details()
                Fill_buisness_highlight_header1()
                Fill_buisness_highlight_header2()
                fill_buisness_highlight_header3()
                fill_buisness_highlight_header4()
                fill_buisness_highlight_header5()
                fill_buisness_highlight_header7()
                Fill_buisness_highlight_header17()
                fill_buisness_highlight_header18()
                Fill_buisness_highlight_header8()
                fill_buisness_highlight_header9()
                Fill_buisness_highlight_header10()
                fill_buisness_highlight_header11()
                Fill_buisness_highlight_header12()
                Fill_buisness_highlight_header13()
                fill_buisness_highlight_header14()
                fill_buisness_highlight_header15()
                fill_buisness_highlight_header16()
               

                Panel1.Controls.Add(tbl)
                Panel2.Controls.Add(tbl1)
                Panel3.Controls.Add(tbl2)
                Panel4.Controls.Add(tbl3)
                Panel5.Controls.Add(tbl4)
                Panel7.Controls.Add(tbl6)
                Panel8.Controls.Add(tbl7)
                Panel17.Controls.Add(tbl16)
                Panel18.Controls.Add(tbl17)
                Panel9.Controls.Add(tbl8)
                Panel10.Controls.Add(tbl9)
                Panel11.Controls.Add(tbl10)
                Panel12.Controls.Add(tbl11)
                Panel13.Controls.Add(tbl12)
                Panel14.Controls.Add(tbl13)
                Panel15.Controls.Add(tbl14)
                Panel16.Controls.Add(tbl15)
               
            End If
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised to View this Page!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
    End Sub
    Sub Fillbranch_details()
        zone = "CENTRAL KERALA"
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        dt = oh.ExecuteDataSet("select t.zonal_name, t.branch_id, t.branch_name, t.reg_name, t.area_name, to_char(t.inauguration_dt),round(((sysdate - t.inauguration_dt) / 365),1), t.bh_name, t.bh_code,  round(((t.total_exp) / 365),1),round( (t.curre_br_exp/365),1) from TABLEAU_BRANCH_PROFILE1 t where t.branch_id = " & brid & " ").Tables(0)
        'If dt.Rows.Count > 0 Then
        Dim branch_age As String = Math.Round(dt.Rows(0)(6), 1)
        Dim bh_tot_exp As String = Math.Round(dt.Rows(0)(9), 1)
        Dim bh_this_brexp As String = Math.Round(dt.Rows(0)(10), 1)
        tbl.Attributes.Add("width", "100%")
        tbl.Attributes.Add("align", "center")
        tbl.Attributes.Add("border", "1")
        tbl.HorizontalAlign = HorizontalAlign.Center
        Dim tr1, tr2, tr3, tr4, tr5 As New TableRow
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24 As New TableCell
        tr2.Attributes.Add("width", "50%")
        tr4.Attributes.Add("width", "50%")
        tr1.Attributes.Add("width", "50%")
        tr5.Attributes.Add("width", "50%")
        tc1.Attributes.Add("height", "35")
        tc2.Attributes.Add("height", "35")
        tc3.Attributes.Add("height", "35")
        tc4.Attributes.Add("height", "35")
        tc5.Attributes.Add("height", "35")
        tc6.Attributes.Add("height", "35")
        tc7.Attributes.Add("height", "35")
        tc8.Attributes.Add("height", "35")
        tc9.Attributes.Add("height", "35")
        tc10.Attributes.Add("height", "35")
        tc11.Attributes.Add("height", "35")
        tc12.Attributes.Add("height", "35")
        tc13.Attributes.Add("height", "35")
        tc14.Attributes.Add("height", "35")
        tc15.Attributes.Add("height", "35")
        tc16.Attributes.Add("height", "35")
        tc17.Attributes.Add("height", "35")
        tc18.Attributes.Add("height", "35")
        tc19.Attributes.Add("height", "35")
        tc20.Attributes.Add("height", "35")
        tc22.Attributes.Add("height", "35")
        tc21.Attributes.Add("height", "35")
        'tc19.Attributes.Add("width", "50%")
        'tc20.Attributes.Add("width", "50%")
        'tc21.Attributes.Add("width", "50%")
        'tc22.Attributes.Add("width", "50%")
        tc1.ColumnSpan = 2
        tc1.Text = "<font size=4><b>Zone Name: </font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Left
        tc1.BackColor = Drawing.Color.Lavender
        tc1.ForeColor = Drawing.Color.Black
        tc2.ColumnSpan = 2
        tc2.Text = "<font size=4><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc2.HorizontalAlign = HorizontalAlign.Left
        tc2.BackColor = Drawing.Color.PowderBlue
        tc2.ForeColor = Drawing.Color.Black
        tc3.ColumnSpan = 2
        tc3.Text = "<font size=4><b>Branch ID:</font></b>"
        tc3.HorizontalAlign = HorizontalAlign.Left
        tc3.BackColor = Drawing.Color.Lavender
        tc3.ForeColor = Drawing.Color.Black
        tc4.ColumnSpan = 2
        tc4.Text = "<font size=4><b>" & dt.Rows(0)(1).ToString() & "</font></b>"
        tc4.HorizontalAlign = HorizontalAlign.Left
        tc4.BackColor = Drawing.Color.PowderBlue
        tc4.ForeColor = Drawing.Color.Black
        tc5.ColumnSpan = 2
        tc5.Text = "<font size=4><b>Branch Name:</font></b>"
        tc5.HorizontalAlign = HorizontalAlign.Left
        tc5.BackColor = Drawing.Color.Lavender
        tc5.ForeColor = Drawing.Color.Black
        tc6.ColumnSpan = 2
        tc6.Text = "<font size=4><b>" & dt.Rows(0)(2).ToString() & "</font></b>"
        tc6.HorizontalAlign = HorizontalAlign.Left
        tc6.BackColor = Drawing.Color.PowderBlue
        tc6.ForeColor = Drawing.Color.Black
        tc7.ColumnSpan = 2
        tc7.Text = "<font size=4><b>Region name:</font></b>"
        tc7.HorizontalAlign = HorizontalAlign.Left
        tc7.BackColor = Drawing.Color.PowderBlue
        tc7.ForeColor = Drawing.Color.Black
        tc8.ColumnSpan = 2
        tc8.Text = "<font size=4><b>" & dt.Rows(0)(3).ToString() & "</font></b>"
        tc8.HorizontalAlign = HorizontalAlign.Left
        tc8.BackColor = Drawing.Color.Lavender
        tc8.ForeColor = Drawing.Color.Black
        tc9.ColumnSpan = 2
        tc9.Text = "<font size=4><b>Area name:</font></b>"
        tc9.HorizontalAlign = HorizontalAlign.Left
        tc9.BackColor = Drawing.Color.PowderBlue
        tc9.ForeColor = Drawing.Color.Black
        tc10.ColumnSpan = 2
        tc10.Text = "<font size=4><b>" & dt.Rows(0)(4).ToString() & "</font></b>"
        tc10.HorizontalAlign = HorizontalAlign.Left
        tc10.BackColor = Drawing.Color.Lavender
        tc10.ForeColor = Drawing.Color.Black
        ' tr5.Attributes.Add("height", "5")
        tc11.ColumnSpan = 2
        tc11.Text = "<font size=4><b>Inaugration Date:</font></b>"
        tc11.HorizontalAlign = HorizontalAlign.Left
        tc11.BackColor = Drawing.Color.PowderBlue
        tc11.ForeColor = Drawing.Color.Black
        tc12.ColumnSpan = 2
        tc12.Text = "<font size=4><b>" & dt.Rows(0)(5).ToString() & "</font></b>"
        tc12.HorizontalAlign = HorizontalAlign.Left
        tc12.BackColor = Drawing.Color.Lavender
        tc12.ForeColor = Drawing.Color.Black
        tc13.ColumnSpan = 2
        tc13.Text = "<font size=4><b>Branch Age:</font></b>"
        tc13.HorizontalAlign = HorizontalAlign.Left
        tc13.BackColor = Drawing.Color.Lavender
        tc13.ForeColor = Drawing.Color.Black
        tc14.ColumnSpan = 2
        tc14.Text = "<font size=4><b>" & branch_age & "years</font></b>"
        tc14.HorizontalAlign = HorizontalAlign.Left
        tc14.BackColor = Drawing.Color.PowderBlue
        tc14.ForeColor = Drawing.Color.Black
        tc15.ColumnSpan = 2
        tc15.Text = "<font size=4><b>BH NAME:</font></b>"
        tc15.HorizontalAlign = HorizontalAlign.Left
        tc15.BackColor = Drawing.Color.Lavender
        tc15.ForeColor = Drawing.Color.Black
        tc16.ColumnSpan = 2
        tc16.Text = "<font size=4><b>" & dt.Rows(0)(7).ToString() & "</font></b>"
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc16.BackColor = Drawing.Color.PowderBlue
        tc16.ForeColor = Drawing.Color.Black
        tc17.ColumnSpan = 2
        tc17.Text = "<font size=4><b>Emp ID:</font></b>"
        tc17.HorizontalAlign = HorizontalAlign.Left
        tc17.BackColor = Drawing.Color.Lavender
        tc17.ForeColor = Drawing.Color.Black
        tc18.ColumnSpan = 2
        tc18.Text = "<font size=4><b>" & dt.Rows(0)(8).ToString() & "</font></b>"
        tc18.HorizontalAlign = HorizontalAlign.Left
        tc18.BackColor = Drawing.Color.PowderBlue
        tc18.ForeColor = Drawing.Color.Black
        tc19.ColumnSpan = 2
        tc19.Text = "<font size=4><b>Total Experience</font></b>"
        tc19.HorizontalAlign = HorizontalAlign.Left
        tc19.BackColor = Drawing.Color.PowderBlue
        tc19.ForeColor = Drawing.Color.Black
        tc20.ColumnSpan = 2
        tc20.Text = "<font size=4><b>" & bh_tot_exp & "years</font></b>"
        tc20.HorizontalAlign = HorizontalAlign.Left
        tc20.BackColor = Drawing.Color.Lavender
        tc20.ForeColor = Drawing.Color.Black
        tc21.ColumnSpan = 2
        tc21.Text = "<font size=4><b>This branch Experience</font></b>"
        tc21.HorizontalAlign = HorizontalAlign.Left
        tc21.BackColor = Drawing.Color.PowderBlue
        tc21.ForeColor = Drawing.Color.Black
        tc22.ColumnSpan = 2
        tc22.Text = "<font size=4><b>" & bh_this_brexp & "years</font></b>"
        tc22.HorizontalAlign = HorizontalAlign.Left
        tc22.BackColor = Drawing.Color.Lavender
        tc22.ForeColor = Drawing.Color.Black
        tc22.ColumnSpan = 3
        tc23.BackColor = Drawing.Color.PowderBlue
        tc23.ForeColor = Drawing.Color.Black
        tc24.BackColor = Drawing.Color.Lavender
        tc24.ForeColor = Drawing.Color.Black
        'tr1.Attributes.Add("border", "bold")
        'tr2.Attributes.Add("border", "1")
        tr1.Controls.Add(tc1)
        tr1.Controls.Add(tc2)
        tr1.Controls.Add(tc3)
        tr1.Controls.Add(tc4)
        tr1.Controls.Add(tc5)
        tr1.Controls.Add(tc6)
        tr2.Controls.Add(tc7)
        tr2.Controls.Add(tc8)
        tr2.Controls.Add(tc9)
        tr2.Controls.Add(tc10)
        tr2.Controls.Add(tc11)
        tr2.Controls.Add(tc12)
        tr4.Controls.Add(tc13)
        tr4.Controls.Add(tc14)
        tr4.Controls.Add(tc15)
        tr4.Controls.Add(tc16)
        tr4.Controls.Add(tc17)
        tr4.Controls.Add(tc18)
        tr5.Controls.Add(tc19)
        tr5.Controls.Add(tc20)
        tr5.Controls.Add(tc21)
        tr5.Controls.Add(tc22)
        tr5.Controls.Add(tc23)
        tr5.Controls.Add(tc24)
        tbl.Controls.Add(tr1)
        ' tbl.Controls.Add(tr5)
        tbl.Controls.Add(tr2)
        tbl.Controls.Add(tr4)
        tbl.Controls.Add(tr5)
        'Else

        'End If
    End Sub
    Sub Fill_buisness_highlight_header1()
        tbl1.Attributes.Add("width", "100%")
        tbl1.Attributes.Add("align", "center")
        tbl1.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 80
        tc1.Text = "<font size=4><b>BUSINESS HIGHLIGHTS</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.LightGray
        tc1.ForeColor = Drawing.Color.Black
        tc1.BorderColor = Drawing.Color.Goldenrod
        'tr1.Attributes.Add("width", "100%")
        'tr1.Attributes.Add("align", "center")
        'tr1.Attributes.Add("border", "2")
        tr1.Controls.Add(tc1)
        tbl1.Controls.Add(tr1)

    End Sub
    'Sub Fill_buisness_highlight_header2()

    'End Sub
    Sub Fill_buisness_highlight_header2()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "select t.mar_19_outstanding, t.mar_19_net_wt, t.mar_19_pl_count, t.mar_19_cust_count, round((t.mar_19_net_wt / t.mar_19_pl_count), 2)avg_coltr_19, round((t.mar_19_outstanding / t.mar_19_cust_count), 2)avg_out_19, t.mar_20_outstanding, t.mar_20_net_wt, t.mar_20_pl_count, t.mar_20_cust_count, round((t.mar_20_net_wt/ t.mar_20_pl_count),2)avg_coltr_20, round((t.mar_20_outstanding/t.mar_20_cust_count),2)avg_out_20, t.mar_21_outstanding, t.mar_21_net_wt, t.mar_21_pl_count, t.mar_21_cust_count, round((t.mar_21_net_wt/t.mar_21_pl_count),2)avg_coltr_21, round((t.mar_21_outstanding/t.mar_21_cust_count),2)avg_out_21, t.mar_22_outstanding, t.mar_22_net_wt, t.mar_22_pl_count, t.mar_22_cust_count, round((t.mar_22_net_wt/t.mar_22_pl_count),2)avg_coltr_22, round((t.mar_22_outstanding/t.mar_22_cust_count),2)avg_out_22, t.apr_22_outstanding, t.apr_22_net_wt, t.apr_22_pl_count, t.apr_22_cust_count, round((t.apr_22_net_wt/ t.apr_22_pl_count),2)avg_coltr_apr22, round((t.apr_22_outstanding/t.apr_22_cust_count),2)avg_out_apr22, t.may_22_outstanding, t.may_22_net_wt, t.may_22_pl_count, t.may_22_cust_count, round((t.may_22_net_wt/t.may_22_pl_count),2)avg_coltr_may22, round((t.may_22_outstanding/t.may_22_cust_count),2)avg_out_may22 from TABLEAU_BRANCH_PROFILE1 t where t.branch_id = " & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Dim a As String = Math.Round((19.9), 1)
        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10 As New TableRow
        tbl1.Attributes.Add("width", "100%")
        tbl1.Attributes.Add("align", "center")
        tbl1.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, tc31, tc22, tc32, tc33, tc34, tc35, tc36, tc37, tc38, tc39, tc40, tc41, tc42, tc43, tc44, tc45, tc46, tc47, tc48, tc49, tc50 As New TableCell

        tc1.ColumnSpan = 10
        'tc2.ColumnSpan = 10
        tc3.ColumnSpan = 10
        tc4.ColumnSpan = 10
        tc5.ColumnSpan = 10
        tc6.ColumnSpan = 10
        tc7.ColumnSpan = 10
        tc8.ColumnSpan = 10
        tc9.ColumnSpan = 10
        tc10.ColumnSpan = 10
        tc11.ColumnSpan = 10
        tc12.ColumnSpan = 10
        tc13.ColumnSpan = 10
        tc14.ColumnSpan = 10
        tc15.ColumnSpan = 10
        tc16.ColumnSpan = 10
        tc17.ColumnSpan = 10
        tc18.ColumnSpan = 10
        tc19.ColumnSpan = 10
        tc20.ColumnSpan = 10
        tc21.ColumnSpan = 10
        tc22.ColumnSpan = 10
        tc23.ColumnSpan = 10
        tc24.ColumnSpan = 10
        tc25.ColumnSpan = 10
        tc26.ColumnSpan = 10
        tc27.ColumnSpan = 10
        tc28.ColumnSpan = 10
        tc29.ColumnSpan = 10
        tc30.ColumnSpan = 10
        tc31.ColumnSpan = 10
        tc32.ColumnSpan = 10
        tc33.ColumnSpan = 10
        tc34.ColumnSpan = 10
        tc35.ColumnSpan = 10
        tc36.ColumnSpan = 10
        tc37.ColumnSpan = 10
        tc38.ColumnSpan = 10
        tc39.ColumnSpan = 10
        tc40.ColumnSpan = 10
        tc41.ColumnSpan = 10
        tc42.ColumnSpan = 10
        tc43.ColumnSpan = 10
        tc44.ColumnSpan = 10
        tc45.ColumnSpan = 10
        tc46.ColumnSpan = 10
        tc47.ColumnSpan = 10
        tc48.ColumnSpan = 10
        tc49.ColumnSpan = 10
        tc50.ColumnSpan = 10



        tc1.Text = "<font size=3><b>Particulars</font></b>"
        'tc2.Text = "<font size=3><b>31-Mar-18</font></b>"
        tc3.Text = "<font size=3><b>31-Mar-19</font></b>"
        tc4.Text = "<font size=3><b>31-Mar-20</font></b>"
        tc5.Text = "<font size=3><b>31.Mar.21</font></b>"
        tc6.Text = "<font size=3><b>31.Mar.22</font></b>"
        tc7.Text = "<font size=3><b>30.Apr.22</font></b>"
        tc8.Text = "<font size=3><b>30.May.22</font></b>"
        tc9.Text = "<font size=3><b>GL Outstanding (Lakhs)</font></b>"
        tc10.Text = "<font size=3><b>Gold Collateral (Kg)</font></b>"
        tc11.Text = "<font size=3><b>No. of Live Accounts</font></b>"
        tc12.Text = "<font size=3><b>No. of Live Customers</font></b>"
        tc13.Text = "<font size=3><b>Avg Collateral / Customer -Gm</font></b>"
        tc14.Text = "<font size=3><b>Avg Outstanding /Customer-Rs</font></b>"
        tc15.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc16.Text = "<font size=3><b>" & dt.Rows(0)(1).ToString() & "</font></b>"
        tc17.Text = "<font size=3><b>" & dt.Rows(0)(2).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt.Rows(0)(3).ToString() & "</font></b>"
        tc19.Text = "<font size=3><b>" & dt.Rows(0)(4).ToString() & "</font></b>"
        tc20.Text = "<font size=3><b>" & dt.Rows(0)(5).ToString() & "</font></b>"
        tc21.Text = "<font size=3><b>" & dt.Rows(0)(6).ToString() & "</font></b>"
        tc22.Text = "<font size=3><b>" & dt.Rows(0)(7).ToString() & "</font></b>"
        tc23.Text = "<font size=3><b>" & dt.Rows(0)(8).ToString() & "</font></b>"
        tc24.Text = "<font size=3><b>" & dt.Rows(0)(9).ToString() & "</font></b>"
        tc25.Text = "<font size=3><b>" & dt.Rows(0)(10).ToString() & "</font></b>"
        tc26.Text = "<font size=3><b>" & dt.Rows(0)(11).ToString() & "</font></b>"
        tc27.Text = "<font size=3><b>" & dt.Rows(0)(12).ToString() & "</font></b>"
        tc28.Text = "<font size=3><b>" & dt.Rows(0)(13).ToString() & "</font></b>"
        tc29.Text = "<font size=3><b>" & dt.Rows(0)(14).ToString() & "</font></b>"
        tc30.Text = "<font size=3><b>" & dt.Rows(0)(15).ToString() & "</font></b>"
        tc31.Text = "<font size=3><b>" & dt.Rows(0)(16).ToString() & "</font></b>"
        tc32.Text = "<font size=3><b>" & dt.Rows(0)(17).ToString() & "</font></b>"
        tc33.Text = "<font size=3><b>" & dt.Rows(0)(18).ToString() & "</font></b>"
        tc34.Text = "<font size=3><b>" & dt.Rows(0)(19).ToString() & "</font></b>"
        tc35.Text = "<font size=3><b>" & dt.Rows(0)(20).ToString() & "</font></b>"
        tc36.Text = "<font size=3><b>" & dt.Rows(0)(21).ToString() & "</font></b>"
        tc37.Text = "<font size=3><b>" & dt.Rows(0)(22).ToString() & "</font></b>"
        tc38.Text = "<font size=3><b>" & dt.Rows(0)(23).ToString() & "</font></b>"
        tc39.Text = "<font size=3><b>" & dt.Rows(0)(24).ToString() & "</font></b>"
        tc40.Text = "<font size=3><b>" & dt.Rows(0)(25).ToString() & "</font></b>"
        tc41.Text = "<font size=3><b>" & dt.Rows(0)(26).ToString() & "</font></b>"
        tc42.Text = "<font size=3><b>" & dt.Rows(0)(27).ToString() & "</font></b>"
        tc43.Text = "<font size=3><b>" & dt.Rows(0)(28).ToString() & "</font></b>"
        tc44.Text = "<font size=3><b>" & dt.Rows(0)(29).ToString() & "</font></b>"
        tc45.Text = "<font size=3><b>" & dt.Rows(0)(30).ToString() & "</font></b>"
        tc46.Text = "<font size=3><b>" & dt.Rows(0)(31).ToString() & "</font></b>"
        tc47.Text = "<font size=3><b>" & dt.Rows(0)(32).ToString() & "</font></b>"
        tc48.Text = "<font size=3><b>" & dt.Rows(0)(33).ToString() & "</font></b>"
        tc49.Text = "<font size=3><b>" & dt.Rows(0)(34).ToString() & "</font></b>"
        tc50.Text = "<font size=3><b>" & dt.Rows(0)(35).ToString() & "</font></b>"

        tc1.HorizontalAlign = HorizontalAlign.Center
        'tc2.HorizontalAlign = HorizontalAlign.Center
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
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc16.HorizontalAlign = HorizontalAlign.Center
        tc17.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        tc21.HorizontalAlign = HorizontalAlign.Center
        tc22.HorizontalAlign = HorizontalAlign.Center
        tc23.HorizontalAlign = HorizontalAlign.Center
        tc24.HorizontalAlign = HorizontalAlign.Center
        tc25.HorizontalAlign = HorizontalAlign.Center
        tc26.HorizontalAlign = HorizontalAlign.Center
        tc27.HorizontalAlign = HorizontalAlign.Center
        tc28.HorizontalAlign = HorizontalAlign.Center
        tc29.HorizontalAlign = HorizontalAlign.Center
        tc30.HorizontalAlign = HorizontalAlign.Center
        tc31.HorizontalAlign = HorizontalAlign.Center
        tc32.HorizontalAlign = HorizontalAlign.Center
        tc33.HorizontalAlign = HorizontalAlign.Center
        tc34.HorizontalAlign = HorizontalAlign.Center
        tc35.HorizontalAlign = HorizontalAlign.Center
        tc36.HorizontalAlign = HorizontalAlign.Center
        tc37.HorizontalAlign = HorizontalAlign.Center
        tc38.HorizontalAlign = HorizontalAlign.Center
        tc39.HorizontalAlign = HorizontalAlign.Center
        tc40.HorizontalAlign = HorizontalAlign.Center
        tc41.HorizontalAlign = HorizontalAlign.Center
        tc42.HorizontalAlign = HorizontalAlign.Center
        tc43.HorizontalAlign = HorizontalAlign.Center
        tc44.HorizontalAlign = HorizontalAlign.Center
        tc45.HorizontalAlign = HorizontalAlign.Center
        tc46.HorizontalAlign = HorizontalAlign.Center
        tc47.HorizontalAlign = HorizontalAlign.Center
        tc48.HorizontalAlign = HorizontalAlign.Center
        tc49.HorizontalAlign = HorizontalAlign.Center
        tc50.HorizontalAlign = HorizontalAlign.Center

        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.LightCyan
        tr7.ForeColor = Drawing.Color.DarkBlue
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue
        tr10.BackColor = Drawing.Color.LightCyan
        tr10.ForeColor = Drawing.Color.DarkBlue

        tr4.Controls.Add(tc1)
        'tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
        tr4.Controls.Add(tc5)
        tr4.Controls.Add(tc6)
        tr4.Controls.Add(tc7)
        tr4.Controls.Add(tc8)

        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc15)
        tr5.Controls.Add(tc21)
        tr5.Controls.Add(tc27)
        tr5.Controls.Add(tc33)
        tr5.Controls.Add(tc39)
        tr5.Controls.Add(tc45)

        tr6.Controls.Add(tc10)
        tr6.Controls.Add(tc16)
        tr6.Controls.Add(tc22)
        tr6.Controls.Add(tc28)
        tr6.Controls.Add(tc34)
        tr6.Controls.Add(tc40)
        tr6.Controls.Add(tc46)

        tr7.Controls.Add(tc11)
        tr7.Controls.Add(tc17)
        tr7.Controls.Add(tc23)
        tr7.Controls.Add(tc29)
        tr7.Controls.Add(tc35)
        tr7.Controls.Add(tc41)
        tr7.Controls.Add(tc47)

        tr8.Controls.Add(tc12)
        tr8.Controls.Add(tc18)
        tr8.Controls.Add(tc24)
        tr8.Controls.Add(tc30)
        tr8.Controls.Add(tc36)
        tr8.Controls.Add(tc42)
        tr8.Controls.Add(tc48)

        tr9.Controls.Add(tc13)
        tr9.Controls.Add(tc19)
        tr9.Controls.Add(tc25)
        tr9.Controls.Add(tc31)
        tr9.Controls.Add(tc37)
        tr9.Controls.Add(tc43)
        tr9.Controls.Add(tc49)

        tr10.Controls.Add(tc14)
        tr10.Controls.Add(tc20)
        tr10.Controls.Add(tc26)
        tr10.Controls.Add(tc32)
        tr10.Controls.Add(tc38)
        tr10.Controls.Add(tc44)
        tr10.Controls.Add(tc50)

        tbl1.Controls.Add(tr4)
        tbl1.Controls.Add(tr5)
        tbl1.Controls.Add(tr6)
        tbl1.Controls.Add(tr7)
        tbl1.Controls.Add(tr8)
        tbl1.Controls.Add(tr9)
        tbl1.Controls.Add(tr10)
    End Sub
    Sub fill_buisness_highlight_header3()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='NCA' and t.branch_id=" & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)
        sql1 = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='OGL NCA' and t.branch_id=" & brid & ""
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        sql2 = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='business associate' and t.branch_id=" & brid & ""
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)
        sql3 = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='NCA DOOR STEP' and t.branch_id=" & brid & ""
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)
        sql4 = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='digital marketing' and t.branch_id=" & brid & ""
        dt4 = oh.ExecuteDataSet(sql4).Tables(0)
        sql5 = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='NCA-NGL' and t.branch_id=" & brid & ""
        dt5 = oh.ExecuteDataSet(sql5).Tables(0)
        sql6 = "select t.prev_fyr_last_mnth,t.two_mnths_prev,t.prev_mnth,t.prev_two_quarter,t.previous_quarter,t.year_to_date,t.prev_fin_year from TBL_BRANCH_NCA t where t.report_name='NCA Run Rate' and t.branch_id=" & brid & ""
        dt6 = oh.ExecuteDataSet(sql6).Tables(0)
        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl2.Attributes.Add("width", "100%")
        tbl2.Attributes.Add("align", "center")
        tbl2.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, tc31, tc32, tc33, tc34, tc35, tc36, tc37, tc38, tc39, tc40, tc41, tc42, tc43, tc44, tc45, tc46, tc47, tc48, tc49, tc50, tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc60, tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc70 As New TableCell

        tc1.ColumnSpan = 10
        tc2.ColumnSpan = 10
        tc3.ColumnSpan = 10
        tc4.ColumnSpan = 10
        tc5.ColumnSpan = 10
        tc6.ColumnSpan = 10
        tc7.ColumnSpan = 10
        tc8.ColumnSpan = 10
        'tc9.ColumnSpan = 10
        'tc10.ColumnSpan = 10
        'tc11.ColumnSpan = 10
        'tc12.ColumnSpan = 10
        tc13.ColumnSpan = 10
        'tc14.ColumnSpan = 10
        tc15.ColumnSpan = 10
        tc16.ColumnSpan = 10
        tc17.ColumnSpan = 10
        tc18.ColumnSpan = 10
        tc19.ColumnSpan = 10
        tc20.ColumnSpan = 10
        tc21.ColumnSpan = 10
        tc22.ColumnSpan = 10
        tc23.ColumnSpan = 10
        tc24.ColumnSpan = 10
        tc25.ColumnSpan = 10
        tc26.ColumnSpan = 10
        tc27.ColumnSpan = 10
        tc28.ColumnSpan = 10
        tc29.ColumnSpan = 10
        tc30.ColumnSpan = 10
        tc31.ColumnSpan = 10
        tc32.ColumnSpan = 10
        tc33.ColumnSpan = 10
        tc34.ColumnSpan = 10
        tc35.ColumnSpan = 10
        tc36.ColumnSpan = 10
        tc37.ColumnSpan = 10
        tc38.ColumnSpan = 10
        tc39.ColumnSpan = 10
        tc40.ColumnSpan = 10
        tc41.ColumnSpan = 10
        tc42.ColumnSpan = 10
        tc43.ColumnSpan = 10
        tc44.ColumnSpan = 10
        tc45.ColumnSpan = 10
        tc46.ColumnSpan = 10
        tc47.ColumnSpan = 10
        tc48.ColumnSpan = 10
        tc49.ColumnSpan = 10
        tc50.ColumnSpan = 10
        tc51.ColumnSpan = 10
        tc52.ColumnSpan = 10
        tc53.ColumnSpan = 10
        tc54.ColumnSpan = 10
        tc55.ColumnSpan = 10
        tc56.ColumnSpan = 10
        tc57.ColumnSpan = 10
        tc58.ColumnSpan = 10
        tc59.ColumnSpan = 10
        tc60.ColumnSpan = 10
        tc61.ColumnSpan = 10
        tc62.ColumnSpan = 10
        tc63.ColumnSpan = 10
        tc64.ColumnSpan = 10
        tc65.ColumnSpan = 10
        tc66.ColumnSpan = 10
        tc67.ColumnSpan = 10
        tc68.ColumnSpan = 10
        tc69.ColumnSpan = 10


        tc1.Text = "<font size=3><b>Particulars</font></b>"
        tc2.Text = "<font size=3><b>Three_mnths_previous</font></b>"
        tc3.Text = "<font size=3><b>Two_mnths_previous</font></b>"
        tc4.Text = "<font size=3><b>Previous_month</font></b>"
        tc5.Text = "<font size=3><b>Q4FY22</font></b>"
        tc6.Text = "<font size=3><b>Q1FY23</font></b>"
        tc7.Text = "<font size=3><b>YTD</font></b>"
        tc8.Text = "<font size=3><b>FY 21-22</font></b>"
        'tc9.Text = "<font size=3><b>AUM Growth Target -Lakhs</font></b>"
        'tc10.Text = "<font size=3><b>AUM Growth Actual -Lakhs</font></b>"
        'tc11.Text = "<font size=3><b>Target Achievement %</font></b>"
        'tc12.Text = "<font size=3><b>GL Collateral Growth -Kg</font></b>"
        tc13.Text = "<font size=3><b>New Customer Count</font></b>"
        'tc14.Text = "<font size=3><b>Avg Outstanding /Customer-Rs</font></b>"
        tc15.Text = "<font size=3><b>NCA Run Rate</font></b>"
        tc16.Text = "<font size=3><b>OGL NCA</font></b>"
        tc17.Text = "<font size=3><b>NCA: Business Associates</font></b>"
        tc18.Text = "<font size=3><b>NCA: Doorstep</font></b>"
        tc19.Text = "<font size=3><b>NCA: Digital Marketing</font></b>"
        tc20.Text = "<font size=3><b>NCA: NGL</font></b>"
        tc21.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc22.Text = "<font size=3><b>" & dt.Rows(0)(1).ToString() & "</font></b>"
        tc23.Text = "<font size=3><b>" & dt.Rows(0)(2).ToString() & "</font></b>"
        tc24.Text = "<font size=3><b>" & dt.Rows(0)(3).ToString() & "</font></b>"
        tc25.Text = "<font size=3><b>" & dt.Rows(0)(4).ToString() & "</font></b>"
        tc26.Text = "<font size=3><b>" & dt.Rows(0)(5).ToString() & "</font></b>"
        tc27.Text = "<font size=3><b>" & dt.Rows(0)(6).ToString() & "</font></b>"
        tc28.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc29.Text = "<font size=3><b>" & dt1.Rows(0)(1).ToString() & "</font></b>"
        tc30.Text = "<font size=3><b>" & dt1.Rows(0)(2).ToString() & "</font></b>"
        tc31.Text = "<font size=3><b>" & dt1.Rows(0)(3).ToString() & "</font></b>"
        tc32.Text = "<font size=3><b>" & dt1.Rows(0)(4).ToString() & "</font></b>"
        tc33.Text = "<font size=3><b>" & dt1.Rows(0)(5).ToString() & "</font></b>"
        tc34.Text = "<font size=3><b>" & dt1.Rows(0)(6).ToString() & "</font></b>"
        tc35.Text = "<font size=3><b>" & dt2.Rows(0)(0).ToString() & "</font></b>"
        tc36.Text = "<font size=3><b>" & dt2.Rows(0)(1).ToString() & "</font></b>"
        tc37.Text = "<font size=3><b>" & dt2.Rows(0)(2).ToString() & "</font></b>"
        tc38.Text = "<font size=3><b>" & dt2.Rows(0)(3).ToString() & "</font></b>"
        tc39.Text = "<font size=3><b>" & dt2.Rows(0)(4).ToString() & "</font></b>"
        tc40.Text = "<font size=3><b>" & dt2.Rows(0)(5).ToString() & "</font></b>"
        tc41.Text = "<font size=3><b>" & dt2.Rows(0)(6).ToString() & "</font></b>"
        tc42.Text = "<font size=3><b>" & dt3.Rows(0)(0).ToString() & "</font></b>"
        tc43.Text = "<font size=3><b>" & dt3.Rows(0)(1).ToString() & "</font></b>"
        tc44.Text = "<font size=3><b>" & dt3.Rows(0)(2).ToString() & "</font></b>"
        tc45.Text = "<font size=3><b>" & dt3.Rows(0)(3).ToString() & "</font></b>"
        tc46.Text = "<font size=3><b>" & dt3.Rows(0)(4).ToString() & "</font></b>"
        tc47.Text = "<font size=3><b>" & dt3.Rows(0)(5).ToString() & "</font></b>"
        tc48.Text = "<font size=3><b>" & dt3.Rows(0)(6).ToString() & "</font></b>"
        tc49.Text = "<font size=3><b>" & dt4.Rows(0)(0).ToString() & "</font></b>"
        tc50.Text = "<font size=3><b>" & dt4.Rows(0)(1).ToString() & "</font></b>"
        tc51.Text = "<font size=3><b>" & dt4.Rows(0)(2).ToString() & "</font></b>"
        tc52.Text = "<font size=3><b>" & dt4.Rows(0)(3).ToString() & "</font></b>"
        tc53.Text = "<font size=3><b>" & dt4.Rows(0)(4).ToString() & "</font></b>"
        tc54.Text = "<font size=3><b>" & dt4.Rows(0)(5).ToString() & "</font></b>"
        tc55.Text = "<font size=3><b>" & dt4.Rows(0)(6).ToString() & "</font></b>"
        tc56.Text = "<font size=3><b>" & dt5.Rows(0)(0).ToString() & "</font></b>"
        tc57.Text = "<font size=3><b>" & dt5.Rows(0)(1).ToString() & "</font></b>"
        tc58.Text = "<font size=3><b>" & dt5.Rows(0)(2).ToString() & "</font></b>"
        tc59.Text = "<font size=3><b>" & dt5.Rows(0)(3).ToString() & "</font></b>"
        tc60.Text = "<font size=3><b>" & dt5.Rows(0)(4).ToString() & "</font></b>"
        tc61.Text = "<font size=3><b>" & dt5.Rows(0)(5).ToString() & "</font></b>"
        tc62.Text = "<font size=3><b>" & dt5.Rows(0)(6).ToString() & "</font></b>"
        tc63.Text = "<font size=3><b>" & dt6.Rows(0)(0).ToString() & "</font></b>"
        tc64.Text = "<font size=3><b>" & dt6.Rows(0)(1).ToString() & "</font></b>"
        tc65.Text = "<font size=3><b>" & dt6.Rows(0)(2).ToString() & "</font></b>"
        tc66.Text = "<font size=3><b>" & dt6.Rows(0)(3).ToString() & "</font></b>"
        tc67.Text = "<font size=3><b>" & dt6.Rows(0)(4).ToString() & "</font></b>"
        tc68.Text = "<font size=3><b>" & dt6.Rows(0)(5).ToString() & "</font></b>"
        tc69.Text = "<font size=3><b>" & dt6.Rows(0)(6).ToString() & "</font></b>"

        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc6.HorizontalAlign = HorizontalAlign.Center
        tc7.HorizontalAlign = HorizontalAlign.Center
        tc8.HorizontalAlign = HorizontalAlign.Center
        'tc9.HorizontalAlign = HorizontalAlign.Center
        'tc10.HorizontalAlign = HorizontalAlign.Center
        'tc11.HorizontalAlign = HorizontalAlign.Center
        'tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc16.HorizontalAlign = HorizontalAlign.Center
        tc17.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        tc21.HorizontalAlign = HorizontalAlign.Center
        tc22.HorizontalAlign = HorizontalAlign.Center
        tc23.HorizontalAlign = HorizontalAlign.Center
        tc24.HorizontalAlign = HorizontalAlign.Center
        tc25.HorizontalAlign = HorizontalAlign.Center
        tc26.HorizontalAlign = HorizontalAlign.Center
        tc27.HorizontalAlign = HorizontalAlign.Center
        tc28.HorizontalAlign = HorizontalAlign.Center
        tc29.HorizontalAlign = HorizontalAlign.Center
        tc30.HorizontalAlign = HorizontalAlign.Center
        tc31.HorizontalAlign = HorizontalAlign.Center
        tc32.HorizontalAlign = HorizontalAlign.Center
        tc33.HorizontalAlign = HorizontalAlign.Center
        tc34.HorizontalAlign = HorizontalAlign.Center
        tc35.HorizontalAlign = HorizontalAlign.Center
        tc36.HorizontalAlign = HorizontalAlign.Center
        tc37.HorizontalAlign = HorizontalAlign.Center
        tc38.HorizontalAlign = HorizontalAlign.Center
        tc39.HorizontalAlign = HorizontalAlign.Center
        tc40.HorizontalAlign = HorizontalAlign.Center
        tc41.HorizontalAlign = HorizontalAlign.Center
        tc42.HorizontalAlign = HorizontalAlign.Center
        tc43.HorizontalAlign = HorizontalAlign.Center
        tc44.HorizontalAlign = HorizontalAlign.Center
        tc45.HorizontalAlign = HorizontalAlign.Center
        tc46.HorizontalAlign = HorizontalAlign.Center
        tc47.HorizontalAlign = HorizontalAlign.Center
        tc48.HorizontalAlign = HorizontalAlign.Center
        tc49.HorizontalAlign = HorizontalAlign.Center
        tc50.HorizontalAlign = HorizontalAlign.Center
        tc51.HorizontalAlign = HorizontalAlign.Center
        tc52.HorizontalAlign = HorizontalAlign.Center
        tc53.HorizontalAlign = HorizontalAlign.Center
        tc54.HorizontalAlign = HorizontalAlign.Center
        tc55.HorizontalAlign = HorizontalAlign.Center
        tc56.HorizontalAlign = HorizontalAlign.Center
        tc57.HorizontalAlign = HorizontalAlign.Center
        tc58.HorizontalAlign = HorizontalAlign.Center
        tc59.HorizontalAlign = HorizontalAlign.Center
        tc60.HorizontalAlign = HorizontalAlign.Center
        tc61.HorizontalAlign = HorizontalAlign.Center
        tc62.HorizontalAlign = HorizontalAlign.Center
        tc63.HorizontalAlign = HorizontalAlign.Center
        tc64.HorizontalAlign = HorizontalAlign.Center
        tc65.HorizontalAlign = HorizontalAlign.Center
        tc66.HorizontalAlign = HorizontalAlign.Center
        tc67.HorizontalAlign = HorizontalAlign.Center
        tc68.HorizontalAlign = HorizontalAlign.Center
        tc69.HorizontalAlign = HorizontalAlign.Center

        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.LightCyan
        tr7.ForeColor = Drawing.Color.DarkBlue
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        'tr9.BackColor = Drawing.Color.Snow
        'tr9.ForeColor = Drawing.Color.DarkBlue
        tr10.BackColor = Drawing.Color.LightCyan
        tr10.ForeColor = Drawing.Color.DarkBlue
        tr11.BackColor = Drawing.Color.LightCyan
        tr11.ForeColor = Drawing.Color.DarkBlue
        tr12.BackColor = Drawing.Color.LightCyan
        tr12.ForeColor = Drawing.Color.DarkBlue
        tr13.BackColor = Drawing.Color.LightCyan
        tr13.ForeColor = Drawing.Color.DarkBlue
        tr14.BackColor = Drawing.Color.LightCyan
        tr14.ForeColor = Drawing.Color.DarkBlue
        tr15.BackColor = Drawing.Color.LightCyan
        tr15.ForeColor = Drawing.Color.DarkBlue
        tr16.BackColor = Drawing.Color.LightCyan
        tr16.ForeColor = Drawing.Color.DarkBlue


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
        tr4.Controls.Add(tc5)
        tr4.Controls.Add(tc6)
        tr4.Controls.Add(tc7)
        tr4.Controls.Add(tc8)

        'tr5.Controls.Add(tc21)
        'tr6.Controls.Add(tc10)
        'tr7.Controls.Add(tc11)
        'tr8.Controls.Add(tc12)
        'tr9.Attributes.Add("height", "10px")
        tc14.Attributes.Add("border", "1")
        tr4.Attributes.Add("width", "50%")
        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        'tr9.Attributes.Add("width", "50%")

        tc14.ColumnSpan = 90

        'tr9.Controls.Add(tc14)
        tr10.Controls.Add(tc13)
        tr10.Controls.Add(tc21)
        tr10.Controls.Add(tc22)
        tr10.Controls.Add(tc23)
        tr10.Controls.Add(tc24)
        tr10.Controls.Add(tc25)
        tr10.Controls.Add(tc26)
        tr10.Controls.Add(tc27)



        tr11.Controls.Add(tc15)
        tr11.Controls.Add(tc63)
        tr11.Controls.Add(tc64)
        tr11.Controls.Add(tc65)
        tr11.Controls.Add(tc66)
        tr11.Controls.Add(tc67)
        tr11.Controls.Add(tc68)
        tr11.Controls.Add(tc69)


        tr12.Controls.Add(tc16)
        tr12.Controls.Add(tc28)
        tr12.Controls.Add(tc29)
        tr12.Controls.Add(tc30)
        tr12.Controls.Add(tc31)
        tr12.Controls.Add(tc32)
        tr12.Controls.Add(tc33)
        tr12.Controls.Add(tc34)

        tr13.Controls.Add(tc17)
        tr13.Controls.Add(tc35)
        tr13.Controls.Add(tc36)
        tr13.Controls.Add(tc37)
        tr13.Controls.Add(tc38)
        tr13.Controls.Add(tc39)
        tr13.Controls.Add(tc40)
        tr13.Controls.Add(tc41)

        tr14.Controls.Add(tc18)
        tr14.Controls.Add(tc42)
        tr14.Controls.Add(tc43)
        tr14.Controls.Add(tc44)
        tr14.Controls.Add(tc45)
        tr14.Controls.Add(tc46)
        tr14.Controls.Add(tc47)
        tr14.Controls.Add(tc48)

        tr15.Controls.Add(tc19)
        tr15.Controls.Add(tc49)
        tr15.Controls.Add(tc50)
        tr15.Controls.Add(tc51)
        tr15.Controls.Add(tc52)
        tr15.Controls.Add(tc53)
        tr15.Controls.Add(tc54)
        tr15.Controls.Add(tc55)
        'tr15.Controls.Add(tc56)
        'tr15.Controls.Add(tc57)

        tr16.Controls.Add(tc20)
        tr16.Controls.Add(tc56)
        tr16.Controls.Add(tc57)
        tr16.Controls.Add(tc58)
        tr16.Controls.Add(tc59)
        tr16.Controls.Add(tc60)
        tr16.Controls.Add(tc61)
        tr16.Controls.Add(tc62)


        tbl2.Controls.Add(tr4)
        tbl2.Controls.Add(tr5)
        tbl2.Controls.Add(tr6)
        tbl2.Controls.Add(tr7)
        tbl2.Controls.Add(tr8)
        'tbl2.Controls.Add(tr9)
        tbl2.Controls.Add(tr10)
        tbl2.Controls.Add(tr11)
        tbl2.Controls.Add(tr12)
        tbl2.Controls.Add(tr13)
        tbl2.Controls.Add(tr14)
        tbl2.Controls.Add(tr15)
        tbl2.Controls.Add(tr16)
    End Sub
    Sub fill_buisness_highlight_header4()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "select t.ogl_mar_19_outstanding,t.ogl_mar_20_outstanding,t.ogl_mar_21_outstanding,t.ogl_mar_22_outstanding,t.ogl_apr_22_outstanding,t.ogl_may_22_outstanding,t.ogl_mar_19_net_wt,t.ogl_mar_20_net_wt,t.ogl_mar_21_net_wt,t.ogl_mar_22_net_wt,t.ogl_apr_22_net_wt,t.ogl_may_22_net_wt,t.ogl_mar_19_cust_count,t.ogl_mar_20_cust_count,t.ogl_mar_21_cust_count,t.ogl_mar_22_cust_count,t.ogl_apr_22_cust_count,t.ogl_may_22_cust_count from TABLEAU_BRANCH_PROFILE1 t where branch_id = " & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl3.Attributes.Add("width", "100%")
        tbl3.Attributes.Add("align", "center")
        tbl3.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        tc1.ColumnSpan = 10
        tc2.ColumnSpan = 10
        tc3.ColumnSpan = 10
        tc4.ColumnSpan = 10
        tc5.ColumnSpan = 10
        tc6.ColumnSpan = 10
        tc7.ColumnSpan = 10
        ' tc8.ColumnSpan = 10
        tc9.ColumnSpan = 10
        tc10.ColumnSpan = 10
        tc11.ColumnSpan = 10
        tc12.ColumnSpan = 10
        tc13.ColumnSpan = 10
        tc14.ColumnSpan = 10
        tc15.ColumnSpan = 10
        tc16.ColumnSpan = 10
        tc17.ColumnSpan = 10
        tc18.ColumnSpan = 10
        tc19.ColumnSpan = 10
        tc20.ColumnSpan = 10
        tc21.ColumnSpan = 10
        tc22.ColumnSpan = 10
        tc23.ColumnSpan = 10
        tc24.ColumnSpan = 10
        tc25.ColumnSpan = 10
        tc26.ColumnSpan = 10
        tc27.ColumnSpan = 10
        tc28.ColumnSpan = 10
        tc29.ColumnSpan = 10


        tc1.Text = "<font size=3><b>OGL Business</font></b>"
        tc2.Text = "<font size=3><b>31-Mar-19</font></b>"
        tc3.Text = "<font size=3><b>31-Mar-20</font></b>"
        tc4.Text = "<font size=3><b>31-Mar-21</font></b>"
        tc5.Text = "<font size=3><b>31-Mar-22</font></b>"
        tc6.Text = "<font size=3><b>30-Apr-22</font></b>"
        tc7.Text = "<font size=3><b>30-May-22</font></b>"
        ' tc8.Text = "<font size=3><b>OGL Regd but CGL Customer</font></b>"
        tc9.Text = "<font size=3><b>OGL Outstanding -Lakhs</font></b>"
        tc10.Text = "<font size=3><b>OGL Collateral -Kg</font></b>"
        tc11.Text = "<font size=3><b>OGL Live Customer Count</font></b>"
        tc12.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt.Rows(0)(1).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt.Rows(0)(2).ToString() & "</font></b>"
        tc15.Text = "<font size=3><b>" & dt.Rows(0)(3).ToString() & "</font></b>"
        tc16.Text = "<font size=3><b>" & dt.Rows(0)(4).ToString() & "</font></b>"
        tc17.Text = "<font size=3><b>" & dt.Rows(0)(5).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt.Rows(0)(6).ToString() & "</font></b>"
        tc19.Text = "<font size=3><b>" & dt.Rows(0)(7).ToString() & "</font></b>"
        tc20.Text = "<font size=3><b>" & dt.Rows(0)(8).ToString() & "</font></b>"
        tc21.Text = "<font size=3><b>" & dt.Rows(0)(9).ToString() & "</font></b>"
        tc22.Text = "<font size=3><b>" & dt.Rows(0)(10).ToString() & "</font></b>"
        tc23.Text = "<font size=3><b>" & dt.Rows(0)(11).ToString() & "</font></b>"
        tc24.Text = "<font size=3><b>" & dt.Rows(0)(12).ToString() & "</font></b>"
        tc25.Text = "<font size=3><b>" & dt.Rows(0)(13).ToString() & "</font></b>"
        tc26.Text = "<font size=3><b>" & dt.Rows(0)(14).ToString() & "</font></b>"
        tc27.Text = "<font size=3><b>" & dt.Rows(0)(15).ToString() & "</font></b>"
        tc28.Text = "<font size=3><b>" & dt.Rows(0)(16).ToString() & "</font></b>"
        tc29.Text = "<font size=3><b>" & dt.Rows(0)(17).ToString() & "</font></b>"

        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc6.HorizontalAlign = HorizontalAlign.Center
        tc7.HorizontalAlign = HorizontalAlign.Center
        ' tc8.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        tc10.HorizontalAlign = HorizontalAlign.Center
        tc11.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc16.HorizontalAlign = HorizontalAlign.Center
        tc17.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        tc21.HorizontalAlign = HorizontalAlign.Center
        tc22.HorizontalAlign = HorizontalAlign.Center
        tc23.HorizontalAlign = HorizontalAlign.Center
        tc24.HorizontalAlign = HorizontalAlign.Center
        tc25.HorizontalAlign = HorizontalAlign.Center
        tc26.HorizontalAlign = HorizontalAlign.Center
        tc27.HorizontalAlign = HorizontalAlign.Center
        tc28.HorizontalAlign = HorizontalAlign.Center
        tc29.HorizontalAlign = HorizontalAlign.Center


        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.LightCyan
        tr7.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
        tr4.Controls.Add(tc5)
        tr4.Controls.Add(tc6)
        tr4.Controls.Add(tc7)
        '  tr4.Controls.Add(tc8)


        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)
        tr5.Controls.Add(tc15)
        tr5.Controls.Add(tc16)
        tr5.Controls.Add(tc17)


        tr6.Controls.Add(tc10)
        tr6.Controls.Add(tc18)
        tr6.Controls.Add(tc19)
        tr6.Controls.Add(tc20)
        tr6.Controls.Add(tc21)
        tr6.Controls.Add(tc22)
        tr6.Controls.Add(tc23)


        tr7.Controls.Add(tc11)
        tr7.Controls.Add(tc24)
        tr7.Controls.Add(tc25)
        tr7.Controls.Add(tc26)
        tr7.Controls.Add(tc27)
        tr7.Controls.Add(tc28)
        tr7.Controls.Add(tc29)

        tbl3.Controls.Add(tr4)
        tbl3.Controls.Add(tr5)
        tbl3.Controls.Add(tr6)
        tbl3.Controls.Add(tr7)
    End Sub

    Sub fill_buisness_highlight_header5()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "SELECT SUM(T.Receivable_Perc)/ 25  FROM TABLEAU_BRANCH_PROFILE_2 T WHERE T.DT BETWEEN trunc(SYSDATE-90) AND trunc(SYSDATE-60) AND T.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(P.Receivable_Perc) / 25  FROM TABLEAU_BRANCH_PROFILE_2 P WHERE P.DT BETWEEN trunc(SYSDATE-60) AND trunc(SYSDATE-30) AND P.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(K.Receivable_Perc) / 25  FROM TABLEAU_BRANCH_PROFILE_2 K WHERE K.DT BETWEEN trunc(SYSDATE-30) AND trunc(SYSDATE) AND K.BRANCH_ID = " & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "SELECT SUM(T.INT_SERVICE_PERC) / 25  FROM TABLEAU_BRANCH_PROFILE_2 T WHERE T.DT BETWEEN trunc(SYSDATE-90) AND trunc(SYSDATE-60) AND T.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(P.INT_SERVICE_PERC) / 25  FROM TABLEAU_BRANCH_PROFILE_2 P WHERE P.DT BETWEEN trunc(SYSDATE-60) AND trunc(SYSDATE-30) AND P.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(K.INT_SERVICE_PERC) /25  FROM TABLEAU_BRANCH_PROFILE_2 K WHERE K.DT BETWEEN trunc(SYSDATE-30) AND trunc(SYSDATE) AND K.BRANCH_ID =" & brid & " "
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        sql2 = "SELECT SUM(T.REPLEDGE_PEND_PERC) / 25  FROM TABLEAU_BRANCH_PROFILE_2 T WHERE T.DT BETWEEN trunc(SYSDATE-90) AND trunc(SYSDATE-60) AND T.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(P.REPLEDGE_PEND_PERC) / 25  FROM TABLEAU_BRANCH_PROFILE_2 P WHERE P.DT BETWEEN trunc(SYSDATE-60) AND trunc(SYSDATE-30) AND P.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(K.REPLEDGE_PEND_PERC) / 25  FROM TABLEAU_BRANCH_PROFILE_2 K WHERE K.DT BETWEEN trunc(SYSDATE-30) AND trunc(SYSDATE) AND K.BRANCH_ID = " & brid & " "
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)

        sql3 = "SELECT SUM(T.AUCTION_OS) / 25  FROM TABLEAU_BRANCH_PROFILE_2 T WHERE T.DT BETWEEN trunc(SYSDATE-90) AND trunc(SYSDATE-60) AND T.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(P.AUCTION_OS) / 25 FROM TABLEAU_BRANCH_PROFILE_2 P WHERE P.DT BETWEEN trunc(SYSDATE-60) AND trunc(SYSDATE-30) AND P.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(K.AUCTION_OS) / 25  FROM TABLEAU_BRANCH_PROFILE_2 K WHERE K.DT BETWEEN trunc(SYSDATE-30) AND trunc(SYSDATE) AND K.BRANCH_ID = " & brid & " "
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)

        sql4 = "SELECT SUM(T.NPA_OUTSTAND) /25  FROM TABLEAU_BRANCH_PROFILE_2 T WHERE T.DT BETWEEN trunc(SYSDATE-90) AND trunc(SYSDATE-60) AND T.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(P.NPA_OUTSTAND) /25  FROM TABLEAU_BRANCH_PROFILE_2 P WHERE P.DT BETWEEN trunc(SYSDATE-60) AND trunc(SYSDATE-30) AND P.BRANCH_ID = " & brid & " UNION ALL SELECT SUM(K.NPA_OUTSTAND) / 25  FROM TABLEAU_BRANCH_PROFILE_2 K WHERE K.DT BETWEEN trunc(SYSDATE-30) AND trunc(SYSDATE) AND K.BRANCH_ID = " & brid & " "
        dt4 = oh.ExecuteDataSet(sql4).Tables(0)

        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl4.Attributes.Add("width", "100%")
        tbl4.Attributes.Add("align", "center")
        tbl4.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc31, tc32, tc33, tc34, tc35, tc36, tc37, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        tc1.ColumnSpan = 10
        tc2.ColumnSpan = 10
        tc3.ColumnSpan = 10
        tc4.ColumnSpan = 10
     
        tc9.ColumnSpan = 10
        tc10.ColumnSpan = 10
        tc11.ColumnSpan = 10
        tc12.ColumnSpan = 10
        tc13.ColumnSpan = 10
        tc14.ColumnSpan = 10
      
        tc18.ColumnSpan = 10
        tc19.ColumnSpan = 10
        tc20.ColumnSpan = 10
     
        tc24.ColumnSpan = 10
        tc25.ColumnSpan = 10
        tc26.ColumnSpan = 10
       
        tc30.ColumnSpan = 10
        tc31.ColumnSpan = 10
        tc32.ColumnSpan = 10
        tc33.ColumnSpan = 10
        tc34.ColumnSpan = 10
        tc35.ColumnSpan = 10
        tc36.ColumnSpan = 10
        tc37.ColumnSpan = 10


        tc1.Text = "<font size=3><b>collection parameters</font></b>"
        tc2.Text = "<font size=3><b>Three_months_previous</font></b>"
        tc3.Text = "<font size=3><b>Two_months_previous</font></b>"
        tc4.Text = "<font size=3><b>previous_months</font></b>"
   
        tc9.Text = "<font size=3><b>Interest Receivable %</font></b>"
        tc10.Text = "<font size=3><b>Interest Servicing Portfolio %</font></b>"
        tc11.Text = "<font size=3><b>Repledge Pending %</font></b>"
        tc12.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt.Rows(1)(0).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt.Rows(2)(0).ToString() & "</font></b>"
      
        tc18.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc19.Text = "<font size=3><b>" & dt1.Rows(1)(0).ToString() & "</font></b>"
        tc20.Text = "<font size=3><b>" & dt1.Rows(2)(0).ToString() & "</font></b>"

       
        tc24.Text = "<font size=3><b>" & dt2.Rows(0)(0).ToString() & "</font></b>"
        tc25.Text = "<font size=3><b>" & dt2.Rows(1)(0).ToString() & "</font></b>"
        tc26.Text = "<font size=3><b>" & dt2.Rows(2)(0).ToString() & "</font></b>"
       
        tc30.Text = "<font size=3><b>M-o-M Auction %</font></b>"
        tc31.Text = "<font size=3><b>Exp NPA %</font></b>"
        tc32.Text = "<font size=3><b>" & dt3.Rows(0)(0).ToString() & "</font></b>"
        tc33.Text = "<font size=3><b>" & dt3.Rows(1)(0).ToString() & "</font></b>"
        tc34.Text = "<font size=3><b>" & dt3.Rows(2)(0).ToString() & "</font></b>"

        tc35.Text = "<font size=3><b>" & dt4.Rows(0)(0).ToString() & "</font></b>"
        tc36.Text = "<font size=3><b>" & dt4.Rows(1)(0).ToString() & "</font></b>"
        tc37.Text = "<font size=3><b>" & dt4.Rows(2)(0).ToString() & "</font></b>"

        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
       
        tc9.HorizontalAlign = HorizontalAlign.Center
        tc10.HorizontalAlign = HorizontalAlign.Center
        tc11.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
       
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
  
        tc24.HorizontalAlign = HorizontalAlign.Center
        tc25.HorizontalAlign = HorizontalAlign.Center
        tc26.HorizontalAlign = HorizontalAlign.Center
        tc27.HorizontalAlign = HorizontalAlign.Center
        tc28.HorizontalAlign = HorizontalAlign.Center
        tc29.HorizontalAlign = HorizontalAlign.Center
        tc30.HorizontalAlign = HorizontalAlign.Center
        tc31.HorizontalAlign = HorizontalAlign.Center
        tc32.HorizontalAlign = HorizontalAlign.Center
        tc33.HorizontalAlign = HorizontalAlign.Center
        tc34.HorizontalAlign = HorizontalAlign.Center
        tc35.HorizontalAlign = HorizontalAlign.Center
        tc36.HorizontalAlign = HorizontalAlign.Center
        tc37.HorizontalAlign = HorizontalAlign.Center


        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.LightCyan
        tr7.ForeColor = Drawing.Color.DarkBlue
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        tr9.Attributes.Add("width", "50%")


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
      


        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)
       

        tr6.Controls.Add(tc10)
        tr6.Controls.Add(tc18)
        tr6.Controls.Add(tc19)
        tr6.Controls.Add(tc20)
       


        tr7.Controls.Add(tc11)
        tr7.Controls.Add(tc24)
        tr7.Controls.Add(tc25)
        tr7.Controls.Add(tc26)
      
        tr8.Controls.Add(tc30)
        tr8.Controls.Add(tc32)
        tr8.Controls.Add(tc33)
        tr8.Controls.Add(tc34)

        tr9.Controls.Add(tc31)
        tr9.Controls.Add(tc35)
        tr9.Controls.Add(tc36)
        tr9.Controls.Add(tc37)


        tbl4.Controls.Add(tr4)
        tbl4.Controls.Add(tr5)
        tbl4.Controls.Add(tr6)
        tbl4.Controls.Add(tr7)
        tbl4.Controls.Add(tr8)
        tbl4.Controls.Add(tr9)
    End Sub
  
    Sub fill_buisness_highlight_header7()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "SELECT sum(actualshortage) SHORTAGE from tableau_punch_shortdata_new p, mana0809.branch_dtl_new k WHERE trunc(PR_DATE)=(select max(trunc(pr_date)) from tableau_punch_shortdata_new) and p.branch is not null and p.branch=k.branch_name AND k.branch_id=" & brid & " group by branch,k.branch_id"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "select a.brid branch_id, a.BRANCH_NAME, decode(a.bm_bhstatus, '', 'NU', 'U') BH_STATUS, decode(a.abhstatus, '', 'NU', 'U') ABH_STATUS, decode(a.staff_status, '', 'NU', 'U') STAFF_STATUS, nvl(to_date(sysdate) - to_date(a.twonilldt), 0) Lag_days from mana0809.AUTHORISED_SIG_STATUS a, mana0809.branch_master s, mana0809.branch_detail d, mana0809.tbl_fzm_master m where s.branch_id = a.brid and s.branch_id = d.BRANCH_ID and d.reg_id = m.region_id AND a.brid =" & brid & " and s.firm_id = 1 and s.status_id = 1 and to_date(sysdate) - to_date(s.inauguration_dt) > 10 group by a.brid, a.BRANCH_NAME, a.bm_bhstatus, a.abhstatus, a.staff_status, a.twonilldt order by a.brid"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        sql2 = "select count(decode(t.status, 1, 1)) from mana0809.tbl_daily_reminder_call t where to_date(t.insertdt) BETWEEN trunc((sysdate-30),'month') AND trunc(SYSDATE) and t.branch_id = " & brid & "union all select sum(tt.BALANCE) from MANA0809.TBL_DAILY_REMINDER_CALL t, MANA0809.pledge_yesterday_live tt where t.cust_id = tt.CUST_ID and t.insertdt BETWEEN trunc((sysdate-30),'month') AND trunc(SYSDATE) and t.status = 1 and t.branch_id=" & brid & " UNION ALL select nvl(sum(t.attrition_percent),0) from mana0809.TBL_ATTRITION_BRANCH t where t.branch_id = " & brid & " and to_date(t.enterdt) between to_date('01-04-' || EXTRACT(YEAR FROM ADD_MONTHS(sysdate, -3)), 'dd-mm-yyyy') and to_date(sysdate) "
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)

        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl6.Attributes.Add("width", "100%")
        tbl6.Attributes.Add("align", "center")
        tbl6.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        tc1.ColumnSpan = 10
        tc2.ColumnSpan = 10
        tc9.ColumnSpan = 10
        tc10.ColumnSpan = 10
        tc12.ColumnSpan = 10
        tc18.ColumnSpan = 10
        tc19.ColumnSpan = 10
        tc20.ColumnSpan = 10
        tc21.ColumnSpan = 10
        tc22.ColumnSpan = 10
        tc23.ColumnSpan = 10
        tc24.ColumnSpan = 10
     


        tc1.Text = "<font size=3><b>Pending</font></b>"
        tc2.Text = "<font size=3><b>count</font></b>"
        tc9.Text = "<font size=3><b>Authorized Signatory Pending</font></b>"
        tc10.Text = "<font size=3><b>employee shortage</font></b>"
        tc12.Text = "<font size=3><b>" & dt1.Rows(0)(5).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc19.Text = "<font size=3><b>Promise to Pay - Count</font></b>"
        tc20.Text = "<font size=3><b>Promise to Pay - Amount in Lakhs</font></b>"
        tc21.Text = "<font size=3><b>YTD Attrition %</font></b>"
        tc22.Text = "<font size=3><b>" & dt2.Rows(0)(0).ToString() & "</font></b>"
        tc23.Text = "<font size=3><b>" & dt2.Rows(1)(0).ToString() & "</font></b>"
        tc24.Text = "<font size=3><b>" & dt2.Rows(2)(0).ToString() & "</font></b>"

        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        tc10.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        tc21.HorizontalAlign = HorizontalAlign.Center
        tc22.HorizontalAlign = HorizontalAlign.Center
        tc23.HorizontalAlign = HorizontalAlign.Center
        tc24.HorizontalAlign = HorizontalAlign.Center

        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.LightCyan
        tr7.ForeColor = Drawing.Color.DarkBlue
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)

        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)

        tr6.Controls.Add(tc10)
        tr6.Controls.Add(tc18)

        tr7.Controls.Add(tc19)
        tr7.Controls.Add(tc22)


        tr8.Controls.Add(tc20)
        tr8.Controls.Add(tc23)


        tr9.Controls.Add(tc21)
        tr9.Controls.Add(tc24)

        
       


      

        tbl6.Controls.Add(tr4)
        tbl6.Controls.Add(tr5)
        tbl6.Controls.Add(tr6)
        tbl6.Controls.Add(tr7)
        tbl6.Controls.Add(tr8)
        tbl6.Controls.Add(tr9)

    End Sub
    Sub Fill_buisness_highlight_header17()
        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 80
        tc1.Text = "<font size=4><b>MTD Attrition %</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.LightGray
        tc1.ForeColor = Drawing.Color.Black
        tc1.BorderColor = Drawing.Color.Goldenrod

        tr1.Controls.Add(tc1)
        tbl9.Controls.Add(tr1)

    End Sub
    Sub fill_buisness_highlight_header18()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        'headings of months
        sql = "SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -3), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -3)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -2), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -2)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -1), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -1)) FROM DUAL"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Lost Customers Called' AND t.branch_id=" & brid & ""
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        ' sql2 = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Lost Customers Activated' AND t.branch_id=" & brid & ""
        ' dt2 = oh.ExecuteDataSet(sql2).Tables(0)


        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc31, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        ' tc1.ColumnSpan = 10
        tc2.ColumnSpan = 26
        tc3.ColumnSpan = 26
        tc4.ColumnSpan = 26
        '  tc9.ColumnSpan = 10
        ' tc10.ColumnSpan = 10
        tc12.ColumnSpan = 26
        tc13.ColumnSpan = 26
        tc14.ColumnSpan = 26
        ' tc18.ColumnSpan = 5
        '' tc19.ColumnSpan = 5
        'tc20.ColumnSpan = 5
        ' tc21.ColumnSpan = 10



        'tc1.Text = "<font size=3><b></font></b>"
        tc2.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc3.Text = "<font size=3><b>" & dt.Rows(1)(0).ToString() & "</font></b>"
        tc4.Text = "<font size=3><b>" & dt.Rows(2)(0).ToString() & "</font></b>"
        'tc9.Text = "<font size=3><b>Lost Customer Called</font></b>"
        ' tc10.Text = "<font size=3><b>Lost Customer Activated</font></b>"
        tc12.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt1.Rows(0)(1).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt1.Rows(0)(2).ToString() & "</font></b>"
        'tc18.Text = "<font size=3><b>" & dt2.Rows(0)(0).ToString() & "</font></b>"
        ' tc19.Text = "<font size=3><b>" & dt2.Rows(0)(1).ToString() & "</font></b>"
        ' tc20.Text = "<font size=3><b>" & dt2.Rows(0)(2).ToString() & "</font></b>"
        ' tc21.Text = "<font size=3><b>Lost Customer</font></b>"
        ' tc22.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"


        'tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        ' tc9.HorizontalAlign = HorizontalAlign.Center
        ' tc10.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        ' tc18.HorizontalAlign = HorizontalAlign.Center
        ' tc19.HorizontalAlign = HorizontalAlign.Center
        ' tc20.HorizontalAlign = HorizontalAlign.Center
        'tc21.HorizontalAlign = HorizontalAlign.Center
        ' tc22.HorizontalAlign = HorizontalAlign.Center



        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.Yellow
        tr7.ForeColor = Drawing.Color.Red
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        tr9.Attributes.Add("width", "50%")


        'tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)



        ' tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)



        'tr6.Controls.Add(tc10)
        ' tr6.Controls.Add(tc18)
        ' tr6.Controls.Add(tc19)
        ' tr6.Controls.Add(tc20)

        ' tr7.Controls.Add(tc21)
        ' tr7.Controls.Add(tc22)



        tbl9.Controls.Add(tr4)
        tbl9.Controls.Add(tr5)
        tbl9.Controls.Add(tr6)
        tbl9.Controls.Add(tr7)
        tbl9.Controls.Add(tr8)
        tbl9.Controls.Add(tr9)
    End Sub
    Sub Fill_buisness_highlight_header8()
        tbl7.Attributes.Add("width", "100%")
        tbl7.Attributes.Add("align", "center")
        tbl7.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 80
        tc1.Text = "<font size=4><b>Interest Collection -Lakhs</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.LightGray
        tc1.ForeColor = Drawing.Color.Black
        tc1.BorderColor = Drawing.Color.Goldenrod
      
        tr1.Controls.Add(tc1)
        tbl7.Controls.Add(tr1)

    End Sub
    Sub fill_buisness_highlight_header9()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Interest Collection' AND t.branch_id= " & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "SELECT SUM(T.INTEREST) FROM BRANCH_PROF_ONLINE_COLLECTION T WHERE T.DT BETWEEN trunc(SYSDATE-90) AND trunc(SYSDATE-60) AND BRID = " & brid & " UNION ALL SELECT SUM(K.INTEREST) FROM BRANCH_PROF_ONLINE_COLLECTION K WHERE K.DT BETWEEN trunc(SYSDATE-60) AND trunc(SYSDATE-30) AND BRID = " & brid & " UNION ALL SELECT SUM(P.INTEREST) FROM BRANCH_PROF_ONLINE_COLLECTION P WHERE P.DT BETWEEN trunc(SYSDATE-30) AND trunc(SYSDATE) AND BRID = " & brid & ""
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)



        Dim onl_pr As Double

        onl_pr = (Convert.ToInt32(dt1.Rows(2)(0)) / Convert.ToInt32(dt.Rows(0)(2))) * 100
        Dim online_per As String = FormatNumber(onl_pr, 2)


        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl7.Attributes.Add("width", "100%")
        tbl7.Attributes.Add("align", "center")
        tbl7.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc31, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        tc1.ColumnSpan = 10
        tc2.ColumnSpan = 10
        tc3.ColumnSpan = 10
        tc4.ColumnSpan = 10
        tc9.ColumnSpan = 10
        tc10.ColumnSpan = 10
        tc12.ColumnSpan = 10
        tc13.ColumnSpan = 10
        tc14.ColumnSpan = 10
        tc18.ColumnSpan = 10
        tc19.ColumnSpan = 10
        tc20.ColumnSpan = 10
        tc21.ColumnSpan = 10
        tc22.ColumnSpan = 10
       


        tc1.Text = "<font size=3><b></font></b>"
        tc2.Text = "<font size=3><b>Three_months_previous</font></b>"
        tc3.Text = "<font size=3><b>Two_months_previous</font></b>"
        tc4.Text = "<font size=3><b>previous_months</font></b>"
       tc9.Text = "<font size=3><b>total collection</font></b>"
        tc10.Text = "<font size=3><b>online collection</font></b>"
        tc12.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt.Rows(0)(1).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt.Rows(0)(2).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc19.Text = "<font size=3><b>" & dt1.Rows(1)(0).ToString() & "</font></b>"
        tc20.Text = "<font size=3><b>" & dt1.Rows(2)(0).ToString() & "</font></b>"
        'tc21.Text = "<font size=3><b>online %</font></b>"
        'tc22.Text = "<font size=3><b>" & online_per & "</font></b>"
    

        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        tc10.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
       tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        'tc21.HorizontalAlign = HorizontalAlign.Center
        'tc22.HorizontalAlign = HorizontalAlign.Center
      

        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.Yellow
        tr7.ForeColor = Drawing.Color.Red
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        tr9.Attributes.Add("width", "50%")


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
     


        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)
    


        tr6.Controls.Add(tc10)
        tr6.Controls.Add(tc18)
        tr6.Controls.Add(tc19)
        tr6.Controls.Add(tc20)

        'tr7.Controls.Add(tc21)
        'tr7.Controls.Add(tc22)
      


        tbl7.Controls.Add(tr4)
        tbl7.Controls.Add(tr5)
        tbl7.Controls.Add(tr6)
        tbl7.Controls.Add(tr7)
        tbl7.Controls.Add(tr8)
        tbl7.Controls.Add(tr9)
    End Sub
    Sub Fill_buisness_highlight_header10()
        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 80
        tc1.Text = "<font size=4><b>Lost Customer Activation -Nos</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.LightGray
        tc1.ForeColor = Drawing.Color.Black
        tc1.BorderColor = Drawing.Color.Goldenrod

        tr1.Controls.Add(tc1)
        tbl9.Controls.Add(tr1)

    End Sub
    Sub fill_buisness_highlight_header11()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "select SUM(t.three_month_prev + t.two_month_prev + t.previous_month) from tableau_lostcustomer_collection t WHERE t.report_name IN('Lost Customers Called','Lost Customers Activated') AND t.branch_id= " & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Lost Customers Called' AND t.branch_id=" & brid & ""
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        sql2 = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Lost Customers Activated' AND t.branch_id=" & brid & ""
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)


        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc31, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        tc1.ColumnSpan = 20
        tc2.ColumnSpan = 20
        tc3.ColumnSpan = 20
        tc4.ColumnSpan = 20
        tc9.ColumnSpan = 20
        tc10.ColumnSpan = 20
        tc12.ColumnSpan = 20
        tc13.ColumnSpan = 20
        tc14.ColumnSpan = 20
        tc18.ColumnSpan = 20
        tc19.ColumnSpan = 20
        tc20.ColumnSpan = 20
        tc21.ColumnSpan = 20



        tc1.Text = "<font size=3><b></font></b>"
        tc2.Text = "<font size=3><b>Three_months_previous</font></b>"
        tc3.Text = "<font size=3><b>Two_months_previous</font></b>"
        tc4.Text = "<font size=3><b>previous_months</font></b>"
        tc9.Text = "<font size=3><b>Lost Customer Called</font></b>"
        tc10.Text = "<font size=3><b>Lost Customer Activated</font></b>"
        tc12.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt1.Rows(0)(1).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt1.Rows(0)(2).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt2.Rows(0)(0).ToString() & "</font></b>"
        tc19.Text = "<font size=3><b>" & dt2.Rows(0)(1).ToString() & "</font></b>"
        tc20.Text = "<font size=3><b>" & dt2.Rows(0)(2).ToString() & "</font></b>"
        tc21.Text = "<font size=3><b>Lost Customer</font></b>"
        tc22.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"


        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        tc10.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        tc21.HorizontalAlign = HorizontalAlign.Center
        tc22.HorizontalAlign = HorizontalAlign.Center



        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.Yellow
        tr7.ForeColor = Drawing.Color.Red
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        tr9.Attributes.Add("width", "50%")


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)



        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)



        tr6.Controls.Add(tc10)
        tr6.Controls.Add(tc18)
        tr6.Controls.Add(tc19)
        tr6.Controls.Add(tc20)

        tr7.Controls.Add(tc21)
        tr7.Controls.Add(tc22)



        tbl9.Controls.Add(tr4)
        tbl9.Controls.Add(tr5)
        tbl9.Controls.Add(tr6)
        tbl9.Controls.Add(tr7)
        tbl9.Controls.Add(tr8)
        tbl9.Controls.Add(tr9)
    End Sub

    Sub Fill_buisness_highlight_header12()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "select sum(t.eighteen_new), sum(t.fifteen_new), sum(t.twelve_new), sum(t.one_perc), sum(t.three_perc), sum(t.eighteen_new+t.fifteen_new+t.twelve_new+t.one_perc+t.three_perc), sum(t.one_reg_com) FROM TBL_OGL_REBATE_REPORT2 t WHERE t.branch_id =" & brid & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl3.Attributes.Add("width", "100%")
        tbl3.Attributes.Add("align", "center")
        tbl3.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        tc1.ColumnSpan = 8
        tc2.ColumnSpan = 8
        tc3.ColumnSpan = 8
        tc4.ColumnSpan = 8
        tc5.ColumnSpan = 8
        tc6.ColumnSpan = 8
        tc7.ColumnSpan = 8
        tc8.ColumnSpan = 12
        tc9.ColumnSpan = 8
        tc10.ColumnSpan = 8
        tc11.ColumnSpan = 8
        tc12.ColumnSpan = 8
        tc13.ColumnSpan = 8
        tc14.ColumnSpan = 8
        tc15.ColumnSpan = 8
        tc16.ColumnSpan = 8
        tc17.ColumnSpan = 8
        tc18.ColumnSpan = 12
        tc19.ColumnSpan = 8
        tc20.ColumnSpan = 8
        tc21.ColumnSpan = 8
        tc22.ColumnSpan = 8
        tc23.ColumnSpan = 8
        tc24.ColumnSpan = 8
        tc25.ColumnSpan = 8
        tc26.ColumnSpan = 8
        tc27.ColumnSpan = 8
        tc28.ColumnSpan = 8
        tc29.ColumnSpan = 8


        tc1.Text = "<font size=3><b>OGL Special Rebate Scheme</font></b>"
        tc2.Text = "<font size=3><b>18% int Rate</font></b>"
        tc3.Text = "<font size=3><b>15% int Rate</font></b>"
        tc4.Text = "<font size=3><b>12% int Rate</font></b>"
        tc5.Text = "<font size=3><b>1% Rebate</font></b>"
        tc6.Text = "<font size=3><b>3% Rebate</font></b>"
        tc7.Text = "<font size=3><b>Tot Cust Count</font></b>"
        tc8.Text = "<font size=3><b>OGL Regd but CGL Customer</font></b>"
        tc9.Text = "<font size=3><b> </font></b>"
        ' tc10.Text = "<font size=3><b>OGL Collateral -Kg</font></b>"
        'tc11.Text = "<font size=3><b>OGL Live Customer Count</font></b>"
        tc12.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt.Rows(0)(1).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt.Rows(0)(2).ToString() & "</font></b>"
        tc15.Text = "<font size=3><b>" & dt.Rows(0)(3).ToString() & "</font></b>"
        tc16.Text = "<font size=3><b>" & dt.Rows(0)(4).ToString() & "</font></b>"
        tc17.Text = "<font size=3><b>" & dt.Rows(0)(5).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt.Rows(0)(6).ToString() & "</font></b>"
        'tc19.Text = "<font size=3><b>" & dt.Rows(0)(7).ToString() & "</font></b>"
        'tc20.Text = "<font size=3><b>" & dt.Rows(0)(8).ToString() & "</font></b>"
        'tc21.Text = "<font size=3><b>" & dt.Rows(0)(9).ToString() & "</font></b>"
        'tc22.Text = "<font size=3><b>" & dt.Rows(0)(10).ToString() & "</font></b>"
        'tc23.Text = "<font size=3><b>" & dt.Rows(0)(11).ToString() & "</font></b>"
        'tc24.Text = "<font size=3><b>" & dt.Rows(0)(12).ToString() & "</font></b>"
        'tc25.Text = "<font size=3><b>" & dt.Rows(0)(13).ToString() & "</font></b>"
        'tc26.Text = "<font size=3><b>" & dt.Rows(0)(14).ToString() & "</font></b>"
        'tc27.Text = "<font size=3><b>" & dt.Rows(0)(15).ToString() & "</font></b>"
        'tc28.Text = "<font size=3><b>" & dt.Rows(0)(16).ToString() & "</font></b>"
        'tc29.Text = "<font size=3><b>" & dt.Rows(0)(17).ToString() & "</font></b>"

        tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc6.HorizontalAlign = HorizontalAlign.Center
        tc7.HorizontalAlign = HorizontalAlign.Center
        tc8.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        'tc10.HorizontalAlign = HorizontalAlign.Center
        ' tc11.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc16.HorizontalAlign = HorizontalAlign.Center
        tc17.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        'tc19.HorizontalAlign = HorizontalAlign.Center
        'tc20.HorizontalAlign = HorizontalAlign.Center
        'tc21.HorizontalAlign = HorizontalAlign.Center
        'tc22.HorizontalAlign = HorizontalAlign.Center
        'tc23.HorizontalAlign = HorizontalAlign.Center
        'tc24.HorizontalAlign = HorizontalAlign.Center
        'tc25.HorizontalAlign = HorizontalAlign.Center
        'tc26.HorizontalAlign = HorizontalAlign.Center
        'tc27.HorizontalAlign = HorizontalAlign.Center
        'tc28.HorizontalAlign = HorizontalAlign.Center
        'tc29.HorizontalAlign = HorizontalAlign.Center


        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.LightCyan
        tr7.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")


        tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
        tr4.Controls.Add(tc5)
        tr4.Controls.Add(tc6)
        tr4.Controls.Add(tc7)
        tr4.Controls.Add(tc8)


        tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)
        tr5.Controls.Add(tc15)
        tr5.Controls.Add(tc16)
        tr5.Controls.Add(tc17)
        tr5.Controls.Add(tc18)


        'tr6.Controls.Add(tc10)
        'tr6.Controls.Add(tc18)
        'tr6.Controls.Add(tc19)
        'tr6.Controls.Add(tc20)
        'tr6.Controls.Add(tc21)
        'tr6.Controls.Add(tc22)
        'tr6.Controls.Add(tc23)


        ' tr7.Controls.Add(tc11)
        'tr7.Controls.Add(tc24)
        'tr7.Controls.Add(tc25)
        'tr7.Controls.Add(tc26)
        'tr7.Controls.Add(tc27)
        'tr7.Controls.Add(tc28)
        ' tr7.Controls.Add(tc29)

        tbl3.Controls.Add(tr4)
        tbl3.Controls.Add(tr5)
        tbl3.Controls.Add(tr6)
        tbl3.Controls.Add(tr7)

    End Sub
    Sub Fill_buisness_highlight_header13()
        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 80
        tc1.Text = "<font size=4><b>Relationship Executive (RE) NCA</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.LightGray
        tc1.ForeColor = Drawing.Color.Black
        tc1.BorderColor = Drawing.Color.Goldenrod

        tr1.Controls.Add(tc1)
        tbl9.Controls.Add(tr1)

    End Sub
    Sub fill_buisness_highlight_header14()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -3), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -3)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -2), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -2)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -1), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -1)) FROM DUAL"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "select count(t.cust_id) from mana0809.tbl_drstp_gl_data_sale t,mana0809.tbl_drstp_cust_visit_sale a,mana0809.employee_master e where t.cust_id = a.cust_id and a.emp_code=e.emp_code and e.branch_id=" & brid & " and to_date(t.tra_dt) BETWEEN trunc((sysdate-90),'month') AND to_date(LAST_DAY(sysdate-90)) union all select count(t.cust_id) from mana0809.tbl_drstp_gl_data_sale t,mana0809.tbl_drstp_cust_visit_sale a,mana0809.employee_master e where t.cust_id = a.cust_id and a.emp_code=e.emp_code and e.branch_id=" & brid & " and to_date(t.tra_dt)BETWEEN trunc((sysdate-60),'month') AND to_date(LAST_DAY(sysdate-60)) union all select count(t.cust_id) from mana0809.tbl_drstp_gl_data_sale t,mana0809.tbl_drstp_cust_visit_sale a,mana0809.employee_master e where t.cust_id = a.cust_id and a.emp_code=e.emp_code and e.branch_id=" & brid & " and to_date(t.tra_dt) BETWEEN trunc((sysdate-30),'month') AND to_date(LAST_DAY(sysdate-30)) "
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        ' sql2 = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Lost Customers Activated' AND t.branch_id=" & brid & ""
        ' dt2 = oh.ExecuteDataSet(sql2).Tables(0)


        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc31, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        ' tc1.ColumnSpan = 10
        tc2.ColumnSpan = 26
        tc3.ColumnSpan = 26
        tc4.ColumnSpan = 26
        '  tc9.ColumnSpan = 10
        ' tc10.ColumnSpan = 10
        tc12.ColumnSpan = 26
        tc13.ColumnSpan = 26
        tc14.ColumnSpan = 26
        ' tc18.ColumnSpan = 5
        '' tc19.ColumnSpan = 5
        'tc20.ColumnSpan = 5
        ' tc21.ColumnSpan = 10



        'tc1.Text = "<font size=3><b></font></b>"
        tc2.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc3.Text = "<font size=3><b>" & dt.Rows(1)(0).ToString() & "</font></b>"
        tc4.Text = "<font size=3><b>" & dt.Rows(2)(0).ToString() & "</font></b>"
        'tc9.Text = "<font size=3><b>Lost Customer Called</font></b>"
        ' tc10.Text = "<font size=3><b>Lost Customer Activated</font></b>"
        tc12.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt1.Rows(1)(0).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt1.Rows(2)(0).ToString() & "</font></b>"
        'tc18.Text = "<font size=3><b>" & dt2.Rows(0)(0).ToString() & "</font></b>"
        ' tc19.Text = "<font size=3><b>" & dt2.Rows(0)(1).ToString() & "</font></b>"
        ' tc20.Text = "<font size=3><b>" & dt2.Rows(0)(2).ToString() & "</font></b>"
        ' tc21.Text = "<font size=3><b>Lost Customer</font></b>"
        ' tc22.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"


        'tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        ' tc9.HorizontalAlign = HorizontalAlign.Center
        ' tc10.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        ' tc18.HorizontalAlign = HorizontalAlign.Center
        ' tc19.HorizontalAlign = HorizontalAlign.Center
        ' tc20.HorizontalAlign = HorizontalAlign.Center
        'tc21.HorizontalAlign = HorizontalAlign.Center
        ' tc22.HorizontalAlign = HorizontalAlign.Center



        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.Yellow
        tr7.ForeColor = Drawing.Color.Red
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        tr9.Attributes.Add("width", "50%")


        'tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)



        ' tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)



        'tr6.Controls.Add(tc10)
        ' tr6.Controls.Add(tc18)
        ' tr6.Controls.Add(tc19)
        ' tr6.Controls.Add(tc20)

        ' tr7.Controls.Add(tc21)
        ' tr7.Controls.Add(tc22)



        tbl9.Controls.Add(tr4)
        tbl9.Controls.Add(tr5)
        tbl9.Controls.Add(tr6)
        tbl9.Controls.Add(tr7)
        tbl9.Controls.Add(tr8)
        tbl9.Controls.Add(tr9)
    End Sub

    Sub Fill_buisness_highlight_header15()
        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 80
        tc1.Text = "<font size=4><b>Bucket wise Collection</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.LightGray
        tc1.ForeColor = Drawing.Color.Black
        tc1.BorderColor = Drawing.Color.Goldenrod

        tr1.Controls.Add(tc1)
        tbl9.Controls.Add(tr1)

    End Sub
    Sub fill_buisness_highlight_header16()
        If GlobalVariables.post = 10 Then
            brid = Me.Session("branch_id")
        Else
            brid = Me.txt1.Text.ToString
        End If
        sql = "SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -4), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -4)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -3), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -3)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -2), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -2)) FROM DUAL UNION ALL SELECT TO_CHAR(ADD_MONTHS(SYSDATE, -1), 'MON') || '-' || EXTRACT(YEAR FROM ADD_MONTHS(SYSDATE, -1)) FROM DUAL"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql1 = "select nvl(t.percentage3,0) from mana0809.pledge_report_branch t where t.disb_dt = trunc((SYSDATE - 120), 'month') and t.branch_id = " & brid & " union all select nvl(t.percentage3,0) from mana0809.pledge_report_branch t where t.disb_dt = trunc((SYSDATE - 90), 'month') and t.branch_id = " & brid & " union all select nvl(t.percentage3,0) from mana0809.pledge_report_branch t where t.disb_dt = trunc((SYSDATE - 60), 'month') and t.branch_id = " & brid & " union all select nvl(t.percentage3,0) from mana0809.pledge_report_branch t where t.disb_dt = trunc((SYSDATE - 30), 'month') and t.branch_id = " & brid & ""
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        ' sql2 = "select t.three_month_prev,t.two_month_prev,t.previous_month from tableau_lostcustomer_collection t WHERE t.report_name ='Lost Customers Activated' AND t.branch_id=" & brid & ""
        ' dt2 = oh.ExecuteDataSet(sql2).Tables(0)


        Dim tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12, tr13, tr14, tr15, tr16, tr17 As New TableRow

        tbl9.Attributes.Add("width", "100%")
        tbl9.Attributes.Add("align", "center")
        tbl9.Attributes.Add("border", "1")
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc31, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21, tc22, tc23, tc24, tc25, tc26, tc27, tc28, tc29, tc30, v As New TableCell
        ' tc1.ColumnSpan = 10
        tc2.ColumnSpan = 20
        tc3.ColumnSpan = 20
        tc4.ColumnSpan = 20
        tc9.ColumnSpan = 20
        ' tc10.ColumnSpan = 10
        tc12.ColumnSpan = 20
        tc13.ColumnSpan = 20
        tc14.ColumnSpan = 20
        tc18.ColumnSpan = 20
        '' tc19.ColumnSpan = 5
        'tc20.ColumnSpan = 5
        ' tc21.ColumnSpan = 10



        'tc1.Text = "<font size=3><b></font></b>"
        tc2.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"
        tc3.Text = "<font size=3><b>" & dt.Rows(1)(0).ToString() & "</font></b>"
        tc4.Text = "<font size=3><b>" & dt.Rows(2)(0).ToString() & "</font></b>"
        tc9.Text = "<font size=3><b>" & dt.Rows(3)(0).ToString() & "</font></b>"
        ' tc10.Text = "<font size=3><b>Lost Customer Activated</font></b>"
        tc12.Text = "<font size=3><b>" & dt1.Rows(0)(0).ToString() & "</font></b>"
        tc13.Text = "<font size=3><b>" & dt1.Rows(1)(0).ToString() & "</font></b>"
        tc14.Text = "<font size=3><b>" & dt1.Rows(2)(0).ToString() & "</font></b>"
        tc18.Text = "<font size=3><b>" & dt1.Rows(3)(0).ToString() & "</font></b>"
        ' tc19.Text = "<font size=3><b>" & dt2.Rows(0)(1).ToString() & "</font></b>"
        ' tc20.Text = "<font size=3><b>" & dt2.Rows(0)(2).ToString() & "</font></b>"
        ' tc21.Text = "<font size=3><b>Lost Customer</font></b>"
        ' tc22.Text = "<font size=3><b>" & dt.Rows(0)(0).ToString() & "</font></b>"


        'tc1.HorizontalAlign = HorizontalAlign.Center
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc9.HorizontalAlign = HorizontalAlign.Center
        ' tc10.HorizontalAlign = HorizontalAlign.Center
        tc12.HorizontalAlign = HorizontalAlign.Center
        tc13.HorizontalAlign = HorizontalAlign.Center
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        ' tc19.HorizontalAlign = HorizontalAlign.Center
        ' tc20.HorizontalAlign = HorizontalAlign.Center
        'tc21.HorizontalAlign = HorizontalAlign.Center
        ' tc22.HorizontalAlign = HorizontalAlign.Center



        tr4.BackColor = Drawing.Color.Honeydew
        tr4.ForeColor = Drawing.Color.Brown
        tr5.BackColor = Drawing.Color.LightCyan
        tr5.ForeColor = Drawing.Color.DarkBlue
        tr6.BackColor = Drawing.Color.LightCyan
        tr6.ForeColor = Drawing.Color.DarkBlue
        tr7.BackColor = Drawing.Color.Yellow
        tr7.ForeColor = Drawing.Color.Red
        tr8.BackColor = Drawing.Color.LightCyan
        tr8.ForeColor = Drawing.Color.DarkBlue
        tr9.BackColor = Drawing.Color.LightCyan
        tr9.ForeColor = Drawing.Color.DarkBlue

        tr5.Attributes.Add("width", "50%")
        tr6.Attributes.Add("width", "50%")
        tr7.Attributes.Add("width", "50%")
        tr8.Attributes.Add("width", "50%")
        tr9.Attributes.Add("width", "50%")


        'tr4.Controls.Add(tc1)
        tr4.Controls.Add(tc2)
        tr4.Controls.Add(tc3)
        tr4.Controls.Add(tc4)
        tr4.Controls.Add(tc9)



        ' tr5.Controls.Add(tc9)
        tr5.Controls.Add(tc12)
        tr5.Controls.Add(tc13)
        tr5.Controls.Add(tc14)
        tr5.Controls.Add(tc18)



        'tr6.Controls.Add(tc10)
        ' tr6.Controls.Add(tc18)
        ' tr6.Controls.Add(tc19)
        ' tr6.Controls.Add(tc20)

        ' tr7.Controls.Add(tc21)
        ' tr7.Controls.Add(tc22)



        tbl9.Controls.Add(tr4)
        tbl9.Controls.Add(tr5)
        tbl9.Controls.Add(tr6)
        tbl9.Controls.Add(tr7)
        tbl9.Controls.Add(tr8)
        tbl9.Controls.Add(tr9)
    End Sub

    
    Protected Sub serch_btn_Click(sender As Object, e As EventArgs) Handles serch_btn.Click
        br_id = Me.Session("branch_id")
        If GlobalVariables.post = -36 Then

            sql = "select f.fzm_id from branch_dtl_new b,tbl_fzm_master f where b.reg_id=f.region_id and b.BRANCH_ID=" & br_id & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            sql1 = "select f.fzm_id from branch_dtl_new b,tbl_fzm_master f where b.reg_id=f.region_id And b.BRANCH_ID=" & Me.txt1.Text.ToString & ""
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
            If dt.Rows(0)(0).ToString <> dt1.Rows(0)(0).ToString Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('Please enter branch ID in your Zone');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
        ElseIf GlobalVariables.post = 199 Then

            sql = "select b.reg_id from branch_dtl_new b where b.BRANCH_ID =" & br_id & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            sql1 = "select b.reg_id from branch_dtl_new b where b.BRANCH_ID=" & Me.txt1.Text.ToString & ""
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
            If dt.Rows(0)(0).ToString <> dt1.Rows(0)(0).ToString Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('Please enter branch ID in your Region');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
        ElseIf GlobalVariables.post = 136 Then

            sql = "select b.area_id from branch_dtl_new b where b.BRANCH_ID =" & br_id & ""
            dt = oh.ExecuteDataSet(sql).Tables(0)
            sql1 = "select b.area_id from branch_dtl_new b where b.BRANCH_ID=" & Me.txt1.Text.ToString & ""
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
            If dt.Rows(0)(0).ToString <> dt1.Rows(0)(0).ToString Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('Please enter branch ID in your Area');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
        End If

        brid = Me.txt1.Text.ToString
        sql6 = "select count(*) from TABLEAU_BRANCH_PROFILE1 t where t.branch_id=" & brid & ""
        dt6 = oh.ExecuteDataSet(sql6).Tables(0)
        If dt6.Rows(0)(0).ToString = 0 Then
            Me.txt1.Text = ""
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("alert('Please enter valid branch ID');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
        Fillbranch_details()
        Fill_buisness_highlight_header1()
        Fill_buisness_highlight_header2()
        fill_buisness_highlight_header3()
        fill_buisness_highlight_header4()
        fill_buisness_highlight_header5()
        fill_buisness_highlight_header7()
        Fill_buisness_highlight_header8()
        fill_buisness_highlight_header9()
        Fill_buisness_highlight_header10()
        fill_buisness_highlight_header11()
        Fill_buisness_highlight_header12()
        Fill_buisness_highlight_header13()
        fill_buisness_highlight_header14()
        Fill_buisness_highlight_header15()
        fill_buisness_highlight_header16()
        Fill_buisness_highlight_header17()
        Fill_buisness_highlight_header18()



        Panel1.Controls.Add(tbl)
        Panel2.Controls.Add(tbl1)
        Panel3.Controls.Add(tbl2)
        Panel4.Controls.Add(tbl3)
        Panel5.Controls.Add(tbl4)
        Panel7.Controls.Add(tbl6)
        Panel8.Controls.Add(tbl7)
        Panel9.Controls.Add(tbl8)
        Panel10.Controls.Add(tbl9)
        Panel11.Controls.Add(tbl10)
        Panel12.Controls.Add(tbl11)
        Panel13.Controls.Add(tbl12)
        Panel14.Controls.Add(tbl13)
        Panel15.Controls.Add(tbl14)
        Panel16.Controls.Add(tbl15)
        Panel17.Controls.Add(tbl16)
        Panel18.Controls.Add(tbl17)

    End Sub
End Class
