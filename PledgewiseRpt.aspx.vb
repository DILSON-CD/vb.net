Imports System.Data
Imports System.IO
Partial Class SMA_Classification_PledgewiseRpt
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim sql, sql1, fnm, br_id, zone, sql2, sql3, sql4, sql10 As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt01 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim from_dt, to_dt, zone_id, region, regid, zoneid, area_id As String
    Dim dt_id, str1, agency As String
    'Dim from_dt, to_dt As String
    Dim post, usrID As Integer
    Dim brid As Integer
    Dim total As Integer
    Dim usr(), msg, fdt, tdt As String
    Dim Gobj As New GHelper.Report.ExcelExport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fdt = Request.QueryString("fdt")
        tdt = Request.QueryString("tdt")
        brid = Request.QueryString("branch_id")
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
        Dim tc12 As New TableCell
        tc1.ColumnSpan = 105

        tc1.Text = "<font size=4><b>PLEDGEWISE REPORT</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Wheat
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red

        tr1.Controls.Add(tc1)

        tbl.Controls.Add(tr1)




    End Sub

    Sub FillColumnHeader()
        Dim tr4 As New TableRow
        Dim tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, tc12, tc13, tc14, tc15, tc16, tc17, tc18, tc19, tc20, tc21 As New TableCell

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
        tc17.ColumnSpan = 5
        tc18.ColumnSpan = 5
        tc19.ColumnSpan = 5
        tc20.ColumnSpan = 5
        tc21.ColumnSpan = 5

        tc1.Text = "<font size=2><b> BRANCH ID</font></b>"
        tc2.Text = "<font size=2><b> BRANCH NAME</font></b>"
        tc3.Text = "<font size=2><b>AREA NAME</font></b>"
        tc4.Text = "<font size=2><b>REGION NAME</font></b>"
        tc5.Text = "<font size=2><b>ZONE NAME</font></b>"
        tc6.Text = "<font size=2><b>STATE NAME</font></b>"
        tc7.Text = "<font size=2><b>PLEDGE NO</font></b>"
        tc8.Text = "<font size=2><b>CUSTOMER ID</font></b>"
        tc9.Text = "<font size=2><b>TRANSACTION DATE</font></b>"
        tc10.Text = "<font size=2><b>PLEDGE VALUE</font></b>"
        tc11.Text = "<font size=2><b>NET WEIGHT</font></b>"
        tc12.Text = "<font size=2><b>SCHEME</font></b>"
        tc13.Text = "<font size=2><b>INTREST RATE</font></b>"
        tc14.Text = "<font size=2><b>BALANCE</font></b>"
        tc15.Text = "<font size=2><b>INTREST ACCURED</font></b>"
        tc16.Text = "<font size=2><b>INTREST RECEIVED</font></b>"
        tc17.Text = "<font size=2><b>DUE DATE</font></b>"
        tc18.Text = "<font size=2><b>AUCTION STATUS</font></b>"
        tc19.Text = "<font size=2><b>INTREST PAID STATUS</font></b>"
        tc20.Text = "<font size=2><b>PLEDGE CATEGORY</font></b>"
        tc21.Text = "<font size=2><b>SMA STATUS</font></b>"


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
        tc14.HorizontalAlign = HorizontalAlign.Center
        tc15.HorizontalAlign = HorizontalAlign.Center
        tc16.HorizontalAlign = HorizontalAlign.Center
        tc17.HorizontalAlign = HorizontalAlign.Center
        tc18.HorizontalAlign = HorizontalAlign.Center
        tc19.HorizontalAlign = HorizontalAlign.Center
        tc20.HorizontalAlign = HorizontalAlign.Center
        tc21.HorizontalAlign = HorizontalAlign.Center


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
        tr4.Controls.Add(tc14)
        tr4.Controls.Add(tc15)
        tr4.Controls.Add(tc16)
        tr4.Controls.Add(tc17)
        tr4.Controls.Add(tc18)
        tr4.Controls.Add(tc19)
        tr4.Controls.Add(tc20)
        tr4.Controls.Add(tc21)

        tbl.Controls.Add(tr4)
    End Sub

    Sub FillColumnField()
        If fdt = tdt Then
            Try

                sql = "select p.branch_id, br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, p.tra_dt, p.pledge_val, p.net_weight, p.scheme_nm, p.int_rate, p.balance, SC.NET_ACCRUED, py.INTEREST_RCVD, p.maturity_dt, case when(ps.status_id not in(0) and ps.auction_id=7) then 'In Auction' when (ps.status_id not in(0) and ps.auction_id=0) then 'Live Not in Auction' when (ps.status_id =0 and ps.auction_id=8) then 'Auction Settled' when (ps.status_id =0 and ps.auction_id not in(8,9)) then 'Normal Settled' end Auction_status, decode(py.int_status,1,'paid',0,'not paid',null,'not paid') intrest_status, nvl((select t.status from IRREGULARITY_STATUS t where t.status_id = ps.classification_id), 'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.branch_id =" & brid & " and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            Catch ex As Exception
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('No Data Available...!!!!');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script1.ToString, True)
            End Try
        Else
            Try

                'sql = "select p.branch_id, br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, p.tra_dt, p.pledge_val, p.net_weight, p.scheme_nm, p.int_rate, p.balance, SC.NET_ACCRUED, py.INTEREST_RCVD, p.maturity_dt, ps.auc_att_status, py.INT_STATUS, nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification_his sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.branch_id =" & brid & " and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO and to_date(sc.tra_dt)='" & fdt & "'"
                sql = "select p.branch_id, br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, p.tra_dt, p.pledge_val, p.net_weight, p.scheme_nm, p.int_rate, p.balance, SC.NET_ACCRUED, py.INTEREST_RCVD, p.maturity_dt, case when(ps.status_id not in(0) and ps.auction_id=7) then 'In Auction' when (ps.status_id not in(0) and ps.auction_id=0) then 'Live Not in Auction' when (ps.status_id =0 and ps.auction_id=8) then 'Auction Settled' when (ps.status_id =0 and ps.auction_id not in(8,9)) then 'Normal Settled' end Auction_status, decode(py.int_status,1,'paid',0,'not paid',null,'not paid') intrest_status, nvl((select t.status from IRREGULARITY_STATUS t where t.status_id = ps.classification_id), 'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.branch_id =" & brid & " and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            Catch ex As Exception
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('No Data Available...!!!!');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script1.ToString, True)
            End Try
        End If
      


        For Each dr In dt.Rows

            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.LightGoldenrodYellow

            Dim tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc510, tc511, tc512, tc513, tc514, tc515, tc516, tc517, tc518, tc519, tc520, tc521 As New TableCell


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
            tc514.ColumnSpan = 5
            tc515.ColumnSpan = 5
            tc516.ColumnSpan = 5
            tc517.ColumnSpan = 5
            tc518.ColumnSpan = 5
            tc519.ColumnSpan = 5
            tc520.ColumnSpan = 5
            tc521.ColumnSpan = 5



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
            tc514.Text = "<font size=2>" & dr(13) & "</font>"
            tc515.Text = "<font size=2>" & dr(14) & "</font>"
            tc516.Text = "<font size=2>" & dr(15) & "</font>"
            tc517.Text = "<font size=2>" & dr(16) & "</font>"
            tc518.Text = "<font size=2>" & dr(17) & "</font>"
            tc519.Text = "<font size=2>" & dr(18) & "</font>"
            tc520.Text = "<font size=2>" & dr(19) & "</font>"
            tc521.Text = "<font size=2>" & dr(20) & "</font>"




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
            tc520.HorizontalAlign = HorizontalAlign.Center
            tc521.HorizontalAlign = HorizontalAlign.Center


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
            tc514.ForeColor = Drawing.Color.Black
            tc515.BackColor = Drawing.Color.LightGray
            tc516.ForeColor = Drawing.Color.Black
            tc517.BackColor = Drawing.Color.LightGray
            tc518.ForeColor = Drawing.Color.Black
            tc519.BackColor = Drawing.Color.LightGray
            tc520.ForeColor = Drawing.Color.Black
            tc521.BackColor = Drawing.Color.LightGray



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
            tr5.Controls.Add(tc520)
            tr5.Controls.Add(tc521)

            tbl.Controls.Add(tr5)

            total += 1
        Next

        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.Wheat
        Dim tc61 As New TableCell
        tc61.ColumnSpan = 105

        tc61.Font.Bold = True
        tc61.Font.Size = 10
        tc61.HorizontalAlign = HorizontalAlign.Left

        tc61.Text = "TOTAL: " & total
        tc61.ForeColor = Drawing.Color.Brown

        tr6.Controls.Add(tc61)

        tbl.Controls.Add(tr6)


    End Sub

    

    Protected Sub btn_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        If fdt = tdt Then
            ' sql = "select p.branch_id, br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, p.tra_dt, p.pledge_val, p.net_weight, p.scheme_nm, p.int_rate, p.balance, SC.NET_ACCRUED, py.INTEREST_RCVD, p.maturity_dt, ps.auc_att_status, py.INT_STATUS, nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.branch_id =" & brid & " and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO"
            'sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','STATE NAME','PLEDGE NO','CUSTOMER ID','TRANSACTION DATE','PLEDGE VALUE','NET WEIGHT','SCHEME','INTREST RATE','BALANCE','NET ACCRUED','INTREST RECEIVED','DUE DATE','AUCTION STATUS','INTREST PAID STATUS','PLEDGE CATEGORY','SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(ps.auc_att_status), to_char(py.INT_STATUS), nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO and  p.branch_id =" & brid & ""
            sql1 = "select 'BRANCH ID', 'BRANCH NAME', 'AREA NAME', 'REGION NAME', 'ZONAL NAME', 'STATE NAME', 'PLEDGE NO', 'CUSTOMER ID', 'TRANSACTION DATE', 'PLEDGE VALUE', 'NET WEIGHT', 'SCHEME', 'INTREST RATE', 'BALANCE', 'NET ACCRUED', 'INTREST RECEIVED', 'DUE DATE', 'AUCTION STATUS', 'INTREST PAID STATUS', 'PLEDGE CATEGORY', 'SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(case when(ps.status_id not in (0) and ps.auction_id = 7) then 'In Auction' when (ps.status_id not in (0) and ps.auction_id = 0) then 'Live Not in Auction' when (ps.status_id = 0 and ps.auction_id = 8) then 'Auction Settled' when (ps.status_id = 0 and ps.auction_id not in (8, 9)) then 'Normal Settled' end) Auction_status, to_char(decode(py.int_status, 1, 'paid', 0, 'not paid', null, 'not paid')) intrest_status, to_char(nvl((select t.status from IRREGULARITY_STATUS t where t.status_id = ps.classification_id), 'pure gold')) pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.branch_id = " & brid & "  and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO"

            dt = oh.ExecuteDataSet(sql1).Tables(0)
        Else
            sql1 = "select 'BRANCH ID', 'BRANCH NAME', 'AREA NAME', 'REGION NAME', 'ZONAL NAME', 'STATE NAME', 'PLEDGE NO', 'CUSTOMER ID', 'TRANSACTION DATE', 'PLEDGE VALUE', 'NET WEIGHT', 'SCHEME', 'INTREST RATE', 'BALANCE', 'NET ACCRUED', 'INTREST RECEIVED', 'DUE DATE', 'AUCTION STATUS', 'INTREST PAID STATUS', 'PLEDGE CATEGORY', 'SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(case when(ps.status_id not in (0) and ps.auction_id = 7) then 'In Auction' when (ps.status_id not in (0) and ps.auction_id = 0) then 'Live Not in Auction' when (ps.status_id = 0 and ps.auction_id = 8) then 'Auction Settled' when (ps.status_id = 0 and ps.auction_id not in (8, 9)) then 'Normal Settled' end) Auction_status, to_char(decode(py.int_status, 1, 'paid', 0, 'not paid', null, 'not paid')) intrest_status, to_char(nvl((select t.status from IRREGULARITY_STATUS t where t.status_id = ps.classification_id), 'pure gold')) pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification_his sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.branch_id = " & brid & "  and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO  and to_date(sc.tra_dt)='" & fdt & "'"
            'sql1 = "select 'BRANCH ID','BRANCH NAME','AREA NAME','REGION NAME','ZONAL NAME','STATE NAME','PLEDGE NO','CUSTOMER ID','TRANSACTION DATE','PLEDGE VALUE','NET WEIGHT','SCHEME','INTREST RATE','BALANCE','NET ACCRUED','INTREST RECEIVED','DUE DATE','AUCTION STATUS','INTREST PAID STATUS','PLEDGE CATEGORY','SMA STATUS' FROM DUAL UNION ALL select to_char(p.branch_id), br.BRANCH_NAME, br.area_name, br.reg_name, br.ZONAL_NAME, br.state_name, p.pledge_no, p.cust_id, to_char(p.tra_dt), to_char(p.pledge_val), to_char(p.net_weight), p.scheme_nm, to_char(p.int_rate), to_char(p.balance), to_char(SC.NET_ACCRUED), to_char(py.INTEREST_RCVD), to_char(p.maturity_dt), to_char(ps.auc_att_status), to_char(py.INT_STATUS), nvl((select t.status from IRREGULARITY_STATUS t where t.status_id=ps.classification_id),'pure gold') pledge_category, sc.sma_category from mana0809.pledge_master p, mana0809.branch_dtl_new br, mana0809.pledge_status ps, mana0809.Tbl_Sma_Classification_his sc, mana0809.pledge_yesterday_live py where p.branch_id = br.BRANCH_ID and p.pledge_no = ps.pledge_no and ps.pledge_no = sc.pledge_no and sc.pledge_no = py.PLEDGE_NO and  p.branch_id =" & brid & " and to_date(sc.tra_dt)='" & fdt & "'"
            dt = oh.ExecuteDataSet(sql1).Tables(0)
        End If
        fnm = Gobj.ExportToExcelfile(dt, Me.Server.MapPath(Me.Request.ApplicationPath))
        Response.ContentType = "application/vnd.ms-excel"
        Response.AppendHeader("Content-Disposition", "attachment; filename=pledgewiseRpt.xls")
        Response.TransmitFile(fnm)
        Response.End()
    End Sub

    Protected Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Server.Transfer("../../home.aspx")
    End Sub

End Class
