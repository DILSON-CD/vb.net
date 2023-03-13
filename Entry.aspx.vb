Imports System.Data
Imports System.Data.OracleClient
Partial Class Marketing_Activities_Entry
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt01, dt011, dt12, dt13, dt14, dt15, dt6, dt4 As New DataTable
    Dim usr(), msg As String
    Dim sql3, sql9, sql1, Sql, Sql12, Sql13, Sql14, Sql15, sql2 As String
    Dim v1n, v2n, v3n As String
    Dim branchID As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        usr = Me.Session("user_id").ToString.Split("!")
        branchID = Me.Session("branch_id")

        dt = oh.ExecuteDataSet("select e.EMP_CODE from emp_master e where e.POST_ID in (54, 56, 67, 58, 793, 795, 870, 110, 239, 240, 241, 859, 860, 861, 508, 530, 794, 109,1,622) and e.EMP_CODE  = " & Session("user_id").ToString().Split("!")(0) & "").Tables(0)
        If Not IsPostBack Then

            Me.HiddenField2.Value = 0
            If (dt.Rows.Count > 0) Then
                dt = oh.ExecuteDataSet("select -1, '----- Select -----' from dual union all select t.status_id, t.description from STATUS_MASTER t where t.module_id = 535 and t.option_id = 1").Tables(0)
                DrpActivity.DataSource = dt
                DrpActivity.DataValueField = dt.Columns(0).ColumnName
                DrpActivity.DataTextField = dt.Columns(1).ColumnName
                DrpActivity.DataBind()
                dt = oh.ExecuteDataSet("select a.fzm, b.reg_name,  b.area_name,  b.BRANCH_NAME,  to_char(bm.inauguration_dt),  nvl(g.gold_kg, 0) || ' kg',b.state_id  from emp_master  e,   branch_dtl_new  b,  BRANCH_master   bm,  STAFF_NORMS_MONTH_BALANCE g, tbl_fzm_master a where e.BRANCH_ID = b.BRANCH_ID and bm.branch_id = b.BRANCH_ID and a.region_id = b.reg_id and b.BRANCH_ID = g.branch_id(+)  and e.EMP_CODE = " & Session("user_id").ToString().Split("!")(0) & "").Tables(0)
                Label_zone.Text = dt.Rows(0)(0).ToString()
                Labelregn.Text = dt.Rows(0)(1).ToString()
                Labelarea.Text = dt.Rows(0)(2).ToString()
                Labelbrnch.Text = dt.Rows(0)(3).ToString()
                lblopng_brnch.Text = dt.Rows(0)(4).ToString()
                Label_gl.Text = dt.Rows(0)(5).ToString()
                HiddenField3.Value = dt.Rows(0)(6).ToString()


            Else

                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.[GetType](), "alert", "alert('You Are Not Authorized To View This Page..!!');window.location.replace('../home.aspx');", True)
            End If
            btn_vendr.Visible = False
            hr.Visible = False
        End If
    End Sub

    Protected Sub DrpActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpActivity.SelectedIndexChanged



        ' ----------CRF_101605
        Sql13 = "select t.quantity_type from STATUS_MASTER_QTY t where t.activity_id = " & DrpActivity.SelectedValue & ""
        dt3 = oh.ExecuteDataSet(Sql13).Tables(0)

        '-----crf 101860
       
        If dt3.Rows(0)(0).ToString() = "1" Then  'Unit

            b.Visible = False
            c.Visible = False
            a.Visible = True
            hr.Visible = False
            txt_amnt.Text = ""
            TxtFAmt.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""

            TxtMnt.Text = ""
            TxtDay.Text = ""
            txt_count.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""
            txt_unt_prc.Text = ""
            txt_amnt.Text = ""
            txtstartdate.Text = ""
            txtenddate.Text = ""
            vendr1_nme.Text = ""
            Txt_amnt_vendr1.Text = ""
            Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
            Txt_amnt_vendr2.Text = ""
            Txt_amnt_vendr3.Text = ""
            TxtFAmt.Text = ""
            btn_calc.Visible = True
            i.Visible = False
            
        ElseIf dt3.Rows(0)(0).ToString() = "2" Then 'Sqft


            a.Visible = False
            c.Visible = False
            b.Visible = True
            hr.Visible = False
            txt_amnt.Text = ""
            TxtFAmt.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""


            TxtMnt.Text = ""
            TxtDay.Text = ""
            txt_count.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""
            txt_unt_prc.Text = ""
            txt_amnt.Text = ""
            txtstartdate.Text = ""
            txtenddate.Text = ""
            vendr1_nme.Text = ""
            Txt_amnt_vendr1.Text = ""
            Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
            Txt_amnt_vendr2.Text = ""
            Txt_amnt_vendr3.Text = ""
            TxtFAmt.Text = ""
            btn_calc.Visible = True
            i.Visible = False
            
        ElseIf dt3.Rows(0)(0).ToString() = "3" Then 'Duration


            a.Visible = False
            b.Visible = False
            c.Visible = True
            hr.Visible = False
            txt_amnt.Text = ""
            TxtFAmt.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""


            TxtMnt.Text = ""
            TxtDay.Text = ""
            txt_count.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""
            txt_unt_prc.Text = ""
            txt_amnt.Text = ""
            txtstartdate.Text = ""
            txtenddate.Text = ""
            vendr1_nme.Text = ""
            Txt_amnt_vendr1.Text = ""
            Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
            Txt_amnt_vendr2.Text = ""
            Txt_amnt_vendr3.Text = ""
            TxtFAmt.Text = ""
            btn_calc.Visible = True
            i.Visible = False
            
          
        End If


        ' ----------CRF_101605----- end

        '---- '-----crf 101860 start
       

        If DrpActivity.SelectedValue = 1 Or DrpActivity.SelectedValue = 2 Or DrpActivity.SelectedValue = 26 Or DrpActivity.SelectedValue = 27 Or DrpActivity.SelectedValue = 29 Or DrpActivity.SelectedValue = 30 Or DrpActivity.SelectedValue = 31 Or DrpActivity.SelectedValue = 34 Or DrpActivity.SelectedValue = 36 Or DrpActivity.SelectedValue = 37 Or DrpActivity.SelectedValue = 38 Then
            a.Visible = False
            c.Visible = False
            b.Visible = True
            hr.Visible = False
            txt_amnt.Text = ""
            TxtFAmt.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""
            TxtMnt.Text = ""
            TxtDay.Text = ""
            txt_count.Text = ""
            txt_unt_prc.Text = ""
            txtstartdate.Text = ""
            txtenddate.Text = ""
            vendr1_nme.Text = ""
            Txt_amnt_vendr1.Text = ""
            Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
            Txt_amnt_vendr2.Text = ""
            Txt_amnt_vendr3.Text = ""

            btn_calc.Visible = True
            i.Visible = False
           
        ElseIf DrpActivity.SelectedValue = "28" Then
            a.Visible = False
            c.Visible = False
            b.Visible = True
            hr.Visible = False
            txt_amnt.Text = ""
            TxtFAmt.Text = ""
            txt_unit.Text = ""
            txt_sqft.Text = ""
            txt_sec.Text = ""
            TxtMnt.Text = ""
            TxtDay.Text = ""
            txt_count.Text = ""
            txt_unt_prc.Text = ""
            txtstartdate.Text = ""
            txtenddate.Text = ""
            vendr1_nme.Text = ""
            Txt_amnt_vendr1.Text = ""
            Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
            Txt_amnt_vendr2.Text = ""
            Txt_amnt_vendr3.Text = ""

            btn_calc.Visible = True
            i.Visible = False
           


            Sql = "SELECT tt.count, tt.duration_mnth, tt.duration_days FROM TBL_MARKETING_SHOP tt WHERE tt.branch_id=" & branchID & " and tt.status = 1 and tt.enter_date = (SELECT MAX(t.enter_date) FROM TBL_MARKETING_SHOP t where t.branch_id=" & branchID & "and t.status = 1)"
            dt = oh.ExecuteDataSet(Sql).Tables(0)

            If dt.Rows.Count > 0 Then

                txt_count.Text = dt.Rows(0)(0).ToString()
                TxtMnt.Text = dt.Rows(0)(1).ToString()
                TxtDay.Text = dt.Rows(0)(2).ToString()
            End If

            ElseIf DrpActivity.SelectedValue = 7 Or DrpActivity.SelectedValue = 8 Then

                a.Visible = False
                b.Visible = False
                c.Visible = False
                hr.Visible = False
                txt_amnt.Text = ""
                TxtFAmt.Text = ""
                txt_unit.Text = ""
                txt_sqft.Text = ""
                txt_sec.Text = ""
                TxtMnt.Text = ""
                TxtDay.Text = ""
                txt_count.Text = ""
                txt_unt_prc.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
            vendr1_nme.Text = ""
                Txt_amnt_vendr1.Text = ""
                Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
                Txt_amnt_vendr2.Text = ""
                Txt_amnt_vendr3.Text = ""

                btn_calc.Visible = True
            i.Visible = False
            
                Sql = "select t.unit_cost  from TBL_MRKT_ACT_UNIT_PRCE t where t.state_id=" & HiddenField3.Value & " and t.activity_id=" & DrpActivity.SelectedValue & ""
                dt3 = oh.ExecuteDataSet(Sql).Tables(0)
                txt_unt_prc.Text = dt3.Rows(0)(0).ToString()
                txt_amnt.Text = dt3.Rows(0)(0).ToString()



            ElseIf DrpActivity.SelectedValue = 5 Or DrpActivity.SelectedValue = 6 Or DrpActivity.SelectedValue = 9 Or DrpActivity.SelectedValue = 10 Or DrpActivity.SelectedValue = 11 Or DrpActivity.SelectedValue = 12 Or DrpActivity.SelectedValue = 13 Or DrpActivity.SelectedValue = 14 Or DrpActivity.SelectedValue = 15 Or DrpActivity.SelectedValue = 16 Or DrpActivity.SelectedValue = 17 Or DrpActivity.SelectedValue = 18 Or DrpActivity.SelectedValue = 20 Or DrpActivity.SelectedValue = 21 Or DrpActivity.SelectedValue = 22 Or DrpActivity.SelectedValue = 25 Or DrpActivity.SelectedValue = 32 Or DrpActivity.SelectedValue = 40 Then
                b.Visible = False
                c.Visible = False
                a.Visible = True
                hr.Visible = False
                txt_amnt.Text = ""
                TxtFAmt.Text = ""
                txt_unit.Text = ""
                txt_sqft.Text = ""
                txt_sec.Text = ""
                TxtMnt.Text = ""
                TxtDay.Text = ""
                txt_count.Text = ""
                txt_unt_prc.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
            vendr1_nme.Text = ""
                Txt_amnt_vendr1.Text = ""
                Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
                Txt_amnt_vendr2.Text = ""
                Txt_amnt_vendr3.Text = ""
                TxtFAmt.Text = ""
                btn_calc.Visible = True
                i.Visible = False
           

            ElseIf DrpActivity.SelectedValue = 19 Or DrpActivity.SelectedValue = 33 Or DrpActivity.SelectedValue = 35 Then
                a.Visible = False
                b.Visible = False
                c.Visible = True
                hr.Visible = False
                txt_amnt.Text = ""
                TxtFAmt.Text = ""
                txt_unit.Text = ""
                txt_sqft.Text = ""
                txt_sec.Text = ""
                TxtMnt.Text = ""
                TxtDay.Text = ""
                txt_count.Text = ""
                txt_unt_prc.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
            vendr1_nme.Text = ""
                Txt_amnt_vendr1.Text = ""
                Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
                Txt_amnt_vendr2.Text = ""
                Txt_amnt_vendr3.Text = ""
                btn_calc.Visible = True
                i.Visible = False

            ElseIf DrpActivity.SelectedValue = 24 Then
                hr.Visible = True
                txt_amnt.Text = ""
                TxtFAmt.Text = ""
                txt_unit.Text = ""
                txt_sqft.Text = ""
                txt_sec.Text = ""
                TxtMnt.Text = ""
                TxtDay.Text = ""
                txt_count.Text = ""
                txt_unt_prc.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
            vendr1_nme.Text = ""
                Txt_amnt_vendr1.Text = ""
                Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
                Txt_amnt_vendr2.Text = ""
                Txt_amnt_vendr3.Text = ""


                btn_calc.Visible = True
                i.Visible = False
                b.Visible = False
                c.Visible = False
                a.Visible = True

            ElseIf DrpActivity.SelectedValue = 3 Or DrpActivity.SelectedValue = 4 Or DrpActivity.SelectedValue = 19 Or DrpActivity.SelectedValue = 23 Then
                a.Visible = False
                b.Visible = False
                c.Visible = False
                hr.Visible = False
                txt_unit.Text = ""
                txt_sqft.Text = ""
                txt_sec.Text = ""
                TxtMnt.Text = ""
                TxtDay.Text = ""
                txt_count.Text = ""
                txt_unt_prc.Text = ""
                txt_amnt.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
            vendr1_nme.Text = ""
                Txt_amnt_vendr1.Text = ""
                Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
                Txt_amnt_vendr2.Text = ""
                Txt_amnt_vendr3.Text = ""

                TxtFAmt.Text = ""
                btn_calc.Visible = False
                i.Visible = False
           
                Sql = "select t.unit_cost  from TBL_MRKT_ACT_UNIT_PRCE t where t.state_id=" & HiddenField3.Value & " and t.activity_id=" & DrpActivity.SelectedValue & ""
                dt3 = oh.ExecuteDataSet(Sql).Tables(0)
                txt_unt_prc.Text = dt3.Rows(0)(0).ToString()
                txt_amnt.Text = dt3.Rows(0)(0).ToString()

            ElseIf DrpActivity.SelectedValue = 39 Then

                a.Visible = False
                c.Visible = False
                b.Visible = True
                hr.Visible = False
                txt_amnt.Text = ""
                TxtFAmt.Text = ""
                txt_unit.Text = ""
                txt_sqft.Text = ""
                txt_sec.Text = ""
                TxtMnt.Text = ""
                TxtDay.Text = ""
                txt_count.Text = ""
                txt_unt_prc.Text = ""
                txtstartdate.Text = ""
                txtenddate.Text = ""
            vendr1_nme.Text = ""
                Txt_amnt_vendr1.Text = ""
                Textjust.Text = ""
            vendor2_name.Text = ""
            vendor3_name.Text = ""
                Txt_amnt_vendr2.Text = ""
                Txt_amnt_vendr3.Text = ""


                btn_calc.Visible = True
                i.Visible = True
          
                Sql12 = "select (-1), to_char('---Select---') from dual union all select t.locality_id, t.locality from TBL_MRKTNG_ACT_LOCALTY t where t.ACTVTY_ID=" & DrpActivity.SelectedValue & ""
                dt12 = oh.ExecuteDataSet(Sql12).Tables(0)
                Me.Drp_lclty.DataSource = dt12
                Me.Drp_lclty.DataValueField = dt12.Columns(0).ColumnName
                Me.Drp_lclty.DataTextField = dt12.Columns(1).ColumnName
                Me.Drp_lclty.DataBind()
                Drp_lclty.Focus()


            End If


            Sql = "select t.unit_cost  from TBL_MRKT_ACT_UNIT_PRCE t where t.state_id=" & HiddenField3.Value & " and t.activity_id=" & DrpActivity.SelectedValue & ""
            dt3 = oh.ExecuteDataSet(Sql).Tables(0)
            txt_unt_prc.Text = dt3.Rows(0)(0).ToString()


    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        dt = oh.ExecuteDataSet("select count(*) from TBL_MARKETING_ACT_VENDR_CHK where BRID = " & branchID & " and STATUS =3 and ACTIVITY= " & DrpActivity.SelectedValue & "").Tables(0)
        If dt.Rows(0)(0) > 0 Then
            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('Already One Request is Pending');")
            c1_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
            Exit Sub
        End If

        If CheckBox1.Checked = False Then
            d.Visible = False
            ab.Visible = True
            ac.Visible = True
            aa.Visible = True
            f.Visible = True
            a1.Visible = True
            a2.Visible = True
            a3.Visible = True
            a4.Visible = True
            c1.Visible = True
            aa21.Visible = True
            aa23.Visible = True
            aa24.Visible = True
            aa25.Visible = True
            x1.Visible = True
            x2.Visible = False
            no_multivendor.Visible = True
            multivendor2.Visible = True
            multivendor3.Visible = True
            '  btn_vendr.Visible = True

        ElseIf CheckBox1.Checked = True Then

            dt01 = oh.ExecuteDataSet("select count(*) from TBL_MARKETING_ACT_VENDR_CHK where BRID = " & branchID & " and STATUS =1 and ACTIVITY= " & DrpActivity.SelectedValue & "").Tables(0)
            If dt01.Rows(0)(0) > 0 Then

                d.Visible = True
                a1.Visible = True
                a2.Visible = True
                a3.Visible = True
                a4.Visible = True
                c1.Visible = True
                c2.Visible = True
                aa21.Visible = True
                aa23.Visible = True
                aa24.Visible = True
                aa25.Visible = True
                x1.Visible = True
                ab.Visible = True
                aa.Visible = False
                f.Visible = False
                ab.Visible = False
                ac.Visible = False
                no_multivendor.Visible = True
                x2.Visible = False
                '     btn_vendr.Visible = False

            ElseIf dt01.Rows(0)(0) = 0 Then

                '   If Me.HiddenField2.Value = 2 Then
                aa.Visible = False
                f.Visible = False
                ab.Visible = False
                ac.Visible = False
                d.Visible = True
                a1.Visible = True
                'a2.Visible = False
                a3.Visible = False
                a4.Visible = False
                'c1.Visible = False
                c1.Visible = True
                c2.Visible = False
                aa21.Visible = False
                aa23.Visible = False
                aa24.Visible = False
                aa25.Visible = False
                x1.Visible = False
                btn_vendr.Visible = True
                no_multivendor.Visible = True
                multivendor2.Visible = False
                multivendor3.Visible = False
                x2.Visible = True
                Dim cl_script2 As New System.Text.StringBuilder
                Dim c1_script3 As New System.Text.StringBuilder
                cl_script2.Append("alert('Please fill all details and take approvel from AH/RM/FZM!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script2.ToString, True)
                c1_script3.Append("window.open('../../home.aspx','_self');")


            End If
        End If

    End Sub
    Protected Sub Confirm_Click(sender As Object, e As EventArgs) Handles Confirm.Click

        Dim ab As String

        If Me.CheckBox1.Checked = True Then
            ab = "1"
        ElseIf CheckBox1.Checked = False Then
            ab = "2"
        End If

        If Me.FileUpload1.HasFile Then
            Dim fileExtension As String
            fileExtension = System.IO.Path. _
                GetExtension(Me.FileUpload1.FileName).ToLower()
            Dim allowedExtensions As String() = _
                {".jpg", ".jpeg", ".pdf"}
            Dim fileok As Boolean
            fileok = False
            For i As Integer = 0 To allowedExtensions.Length - 1
                If fileExtension = allowedExtensions(i) Then
                    fileok = True
                End If
            Next
            If Not (fileok) Then

                Lblerr1.Text = "Attachement Type like jpg,jpeg,pdf are only Supported"

                Exit Sub
            End If

        End If

        If Me.FileUpload2.FileName = "" Then

        Else
            If Me.FileUpload2.HasFile Then
                Dim fileExtension As String
                fileExtension = System.IO.Path. _
                    GetExtension(Me.FileUpload2.FileName).ToLower()
                Dim allowedExtensions As String() = _
                    {".jpg", ".jpeg", ".pdf"}
                Dim fileok As Boolean
                fileok = False
                For i As Integer = 0 To allowedExtensions.Length - 1
                    If fileExtension = allowedExtensions(i) Then
                        fileok = True
                    End If
                Next
                If Not (fileok) Then

                    Lblerr2.Text = "Attachement Type like jpg,jpeg,pdf are only Supported"

                    Exit Sub
                End If

            End If
        End If
        If Me.FileUpload3.FileName = "" Then

        Else
            If Me.FileUpload3.HasFile Then
                Dim fileExtension As String
                fileExtension = System.IO.Path. _
                    GetExtension(Me.FileUpload3.FileName).ToLower()
                Dim allowedExtensions As String() = _
                    {".jpg", ".jpeg", ".pdf"}
                Dim fileok As Boolean
                fileok = False
                For i As Integer = 0 To allowedExtensions.Length - 1
                    If fileExtension = allowedExtensions(i) Then
                        fileok = True
                    End If
                Next
                If Not (fileok) Then

                    Lblerr3.Text = "Attachement Type like jpg,jpeg,pdf are only Supported"

                    Exit Sub
                End If

            End If
        End If

        ' If txt_amnt.Text < Txt_amnt_vendr1.Text Or txt_amnt.Text < Txt_amnt_vendr2.Text Or txt_amnt.Text < Txt_amnt_vendr3.Text Or txt_amnt.Text < TxtFAmt.Text Then

        '  If txt_amnt.Text > Txt_amnt_vendr1.Text Or txt_amnt.Text > Txt_amnt_vendr2.Text Or txt_amnt.Text > Txt_amnt_vendr3.Text Or txt_amnt.Text > TxtFAmt.Text Then


        '    Dim cl_script1 As New System.Text.StringBuilder
        '    cl_script1.Append("alert('Your proposal unit price more than approved limit,take approvel from AH/RM/FZM!!');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        '    Exit Sub
        'Else

        'End If

        '      

        If CInt(TxtFAmt.Text) > CInt(txt_amnt.Text) Then

            '                                   1                         2                   3                      4                     5                     6               7                8                         9                        10                        11                      12                          13                               14                     15                        16                17                   18                        19                       20                         21                     22                           23                                  24                        25                      26                    27                         28
            Dim p_indata As String = DrpActivity.SelectedValue + "µ" + TxtMnt.Text + "µ" + TxtDay.Text + "µ" + txt_unit.Text + "µ" + txt_sqft.Text + "µ" + txt_sec.Text + "µ" + ab + "µ" + vendor_drp1.SelectedItem.Value + "µ" + vendor_drp2.SelectedItem.Value + "µ" + vendor_drp3.SelectedItem.Value + "µ" + Textjust.Text + "µ" + Txt_amnt_vendr1.Text + "µ" + Txt_amnt_vendr2.Text + "µ" + Txt_amnt_vendr3.Text + "µ" + vendor_drpf.SelectedItem.Value + "µ" + TxtFAmt.Text + "µ" + DrpPay.Text + "µ" + TextRem.Text + "µ" + Txt_vilge_10.Text + "µ" + Txt_vilge_20.Text + "µ" + Txt_vilge_30.Text + "µ" + TxtCovered.Text + "µ" + Session("branch_id").ToString() + "µ" + txtstartdate.Text + "µ" + txtenddate.Text + "µ" + txt_others.Text + "µ" + txt_amnt.Text + "µ" + Drp_lclty.SelectedValue

            Dim conf_par(8) As OracleParameter
            conf_par(0) = New OracleParameter("entrdby", OracleType.Number)
            conf_par(0).Direction = ParameterDirection.Input
            conf_par(0).Value = CInt(usr(0))

            conf_par(1) = New OracleParameter("p_indata", OracleType.VarChar, 5000)
            conf_par(1).Direction = ParameterDirection.Input
            conf_par(1).Value = p_indata

            conf_par(2) = New OracleParameter("ERR_MSG", OracleType.VarChar, 150)
            conf_par(2).Direction = ParameterDirection.Output

            conf_par(3) = New OracleParameter("ERR_STAT", OracleType.Number)
            conf_par(3).Direction = ParameterDirection.Output

            conf_par(4) = New OracleParameter("ACT_ID", OracleType.Number)
            conf_par(4).Direction = ParameterDirection.Output

            conf_par(5) = New OracleParameter("stat", OracleType.Number)
            conf_par(5).Direction = ParameterDirection.Input
            conf_par(5).Value = 6

            conf_par(6) = New OracleParameter("APrvd_by", OracleType.Number)
            conf_par(6).Direction = ParameterDirection.Input
            conf_par(6).Value = 0

            conf_par(7) = New OracleParameter("Rejct_by", OracleType.Number)
            conf_par(7).Direction = ParameterDirection.Input
            conf_par(7).Value = 0

            conf_par(8) = New OracleParameter("APV_REJ_RKS", OracleType.VarChar)
            conf_par(8).Direction = ParameterDirection.Input
            conf_par(8).Value = ""

            oh.ExecuteNonQuery("proc_markting_proposal", conf_par)
            msg = conf_par(2).Value.ToString()



            If DrpActivity.SelectedValue = 28 Then


                sql2 = "update TBL_MARKETING_SHOP a set a.STATUS=2 where a.branch_id=" & branchID & " and a.status=1"
                oh.ExecuteNonQuery(sql2)


            End If

            Dim str1() As String
            str1 = msg.ToString.Split(":")
            Me.HiddenField1.Value = str1(1)

            Dim ACT_ID As String = HiddenField1.Value
            Dim fileName As String = ""
            Dim cp As String = Me.Server.MapPath(Me.Request.ApplicationPath)

            Dim file1 As String = Server.MapPath("~/image") & "\" & hidImg.Value & ".tif"
            fileName = file1
            Dim fl As New IO.FileInfo(file1)
            If fl.Exists = True Then
                Dim fs As New IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bl(fs.Length) As Byte
                fs.Read(bl, 0, fs.Length)
                fs.Close()
                Dim fp As New IO.FileInfo(fileName)

                If fp.Exists Then
                    fp.Delete()
                End If

                Dim SQL As String
                SQL = "UPDATE tbl_marketing_activity_new SET VENDOR1QUTN=:SBP WHERE ACTVTY_ID=" & ACT_ID & " "
                Dim parm(0) As OracleParameter
                parm(0) = New OracleParameter
                parm(0).ParameterName = "SBP"
                parm(0).OracleType = OracleType.Blob
                parm(0).Direction = ParameterDirection.Input
                parm(0).Value = bl
                oh.ExecuteNonQuery(SQL, parm)
            End If


            If conf_par(3).Value.ToString = "" Then

                Dim fnm, fnm1, fnm2, dirpath, sql As String
                dirpath = Me.Server.MapPath("image")

                fnm = GetUniqueFilename(dirpath + "/photo1.jpg")
                fnm1 = GetUniqueFilename(dirpath + "/photo2.jpg")
                fnm2 = GetUniqueFilename(dirpath + "/photo3.jpg")


                If Me.FileUpload1.HasFile Then
                    Me.FileUpload1.SaveAs(fnm)
                    Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl(fs.Length) As Byte
                    fs.Read(bl, 0, fs.Length)
                    fs.Close()
                    sql = "update tbl_marketing_activity_new t  set t.VENDOR1QUTN=:photo1  where t.ACTVTY_ID=" & ACT_ID & ""
                    Dim parm_coll(0) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "photo1"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl
                    oh.ExecuteNonQuery(sql, parm_coll)

                End If

                If Me.FileUpload2.HasFile Then
                    Me.FileUpload2.SaveAs(fnm1)
                    Dim fs1 As New IO.FileStream(fnm1, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl2(fs1.Length) As Byte
                    fs1.Read(bl2, 0, fs1.Length)
                    fs1.Close()
                    sql = "update TBL_MARKETING_ACTIVITY_NEW t  set t.VENDOR2QUTN=:photo2  where t.ACTVTY_ID=" & ACT_ID & ""
                    Dim parm_coll(0) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "photo2"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl2
                    oh.ExecuteNonQuery(sql, parm_coll)


                End If

                If Me.FileUpload3.HasFile Then
                    Me.FileUpload3.SaveAs(fnm2)
                    Dim fs2 As New IO.FileStream(fnm2, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl3(fs2.Length) As Byte
                    fs2.Read(bl3, 0, fs2.Length)
                    fs2.Close()
                    sql = "update TBL_MARKETING_ACTIVITY_NEW t  set t.VENDOR3QUTN=:photo3  where t.ACTVTY_ID=" & ACT_ID & ""
                    Dim parm_coll(0) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "photo3"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl3
                    oh.ExecuteNonQuery(sql, parm_coll)
                End If


                Dim fp As New IO.FileInfo(fnm)
                If fp.Exists Then
                    fp.Delete()
                End If

                Dim fp1 As New IO.FileInfo(fnm1)
                If fp1.Exists Then
                    fp1.Delete()
                End If

                Dim fp2 As New IO.FileInfo(fnm2)
                If fp2.Exists Then
                    fp2.Delete()
                End If


                Dim c1_script33 As New System.Text.StringBuilder
                c1_script33.Append("alert('" & msg & "');")
                c1_script33.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script33.ToString, True)
            End If
        Else

            '                                   1                           2                   3                   4                     5                      6               7                8                    9                         10                      11                      12                           13                             14                      15                         16                  17                   18                     19                       20                        21                        22                            23                                  24                        25                       26                       27                         28                      29
            Dim p_indata As String = DrpActivity.SelectedValue + "µ" + TxtMnt.Text + "µ" + TxtDay.Text + "µ" + txt_unit.Text + "µ" + txt_sqft.Text + "µ" + txt_sec.Text + "µ" + ab + "µ" + vendor_drp1.SelectedItem.Value + "µ" + vendor_drp2.SelectedItem.Value + "µ" + vendor_drp3.SelectedItem.Value + "µ" + Textjust.Text + "µ" + Txt_amnt_vendr1.Text + "µ" + Txt_amnt_vendr2.Text + "µ" + Txt_amnt_vendr3.Text + "µ" + vendor_drpf.SelectedItem.Value + "µ" + TxtFAmt.Text + "µ" + DrpPay.Text + "µ" + TextRem.Text + "µ" + Txt_vilge_10.Text + "µ" + Txt_vilge_20.Text + "µ" + Txt_vilge_30.Text + "µ" + TxtCovered.Text + "µ" + Session("branch_id").ToString() + "µ" + txtstartdate.Text + "µ" + txtenddate.Text + "µ" + txt_others.Text + "µ" + txt_amnt.Text + "µ" + Drp_lclty.SelectedValue + "µ" + txt_count.Text

            Dim conf_par(8) As OracleParameter
            conf_par(0) = New OracleParameter("entrdby", OracleType.Number)
            conf_par(0).Direction = ParameterDirection.Input
            conf_par(0).Value = CInt(usr(0))

            conf_par(1) = New OracleParameter("p_indata", OracleType.VarChar, 5000)
            conf_par(1).Direction = ParameterDirection.Input
            conf_par(1).Value = p_indata

            conf_par(2) = New OracleParameter("ERR_MSG", OracleType.VarChar, 150)
            conf_par(2).Direction = ParameterDirection.Output

            conf_par(3) = New OracleParameter("ERR_STAT", OracleType.Number)
            conf_par(3).Direction = ParameterDirection.Output

            conf_par(4) = New OracleParameter("ACT_ID", OracleType.Number)
            conf_par(4).Direction = ParameterDirection.Output

            conf_par(5) = New OracleParameter("stat", OracleType.Number)
            conf_par(5).Direction = ParameterDirection.Input
            conf_par(5).Value = 0

            conf_par(6) = New OracleParameter("APrvd_by", OracleType.Number)
            conf_par(6).Direction = ParameterDirection.Input
            conf_par(6).Value = 0

            conf_par(7) = New OracleParameter("Rejct_by", OracleType.Number)
            conf_par(7).Direction = ParameterDirection.Input
            conf_par(7).Value = 0

            conf_par(8) = New OracleParameter("APV_REJ_RKS", OracleType.VarChar)
            conf_par(8).Direction = ParameterDirection.Input
            conf_par(8).Value = ""

            oh.ExecuteNonQuery("proc_markting_proposal", conf_par)
            msg = conf_par(2).Value.ToString()


            If DrpActivity.SelectedValue = 28 Then

                sql2 = "update TBL_MARKETING_SHOP a set a.STATUS=2 where a.branch_id=" & branchID & " and a.status=1"
                oh.ExecuteNonQuery(sql2)

            End If


            Dim str1() As String
            str1 = msg.ToString.Split(":")
            Me.HiddenField1.Value = str1(1)

            Dim act_id As String = Me.HiddenField1.Value
            Dim fileName As String = ""
            Dim cp As String = Me.Server.MapPath(Me.Request.ApplicationPath)

            Dim file1 As String = Server.MapPath("~/image") & "\" & hidImg.Value & ".tif"
            fileName = file1
            Dim fl As New IO.FileInfo(file1)
            If fl.Exists = True Then
                Dim fs As New IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bl(fs.Length) As Byte
                fs.Read(bl, 0, fs.Length)
                fs.Close()
                Dim fp As New IO.FileInfo(fileName)

                If fp.Exists Then
                    fp.Delete()
                End If

                Dim SQL As String
                SQL = "UPDATE tbl_marketing_activity_new SET VENDOR1QUTN=:SBP WHERE ACTVTY_ID=" & act_id & " "
                Dim parm(0) As OracleParameter
                parm(0) = New OracleParameter
                parm(0).ParameterName = "SBP"
                parm(0).OracleType = OracleType.Blob
                parm(0).Direction = ParameterDirection.Input
                parm(0).Value = bl
                oh.ExecuteNonQuery(SQL, parm)
            End If

            If conf_par(5).Value = 0 Then
                Dim fnm, fnm1, fnm2, dirpath, sql As String
                dirpath = Me.Server.MapPath("image")

                fnm = GetUniqueFilename(dirpath + "/photo1.jpg")
                fnm1 = GetUniqueFilename(dirpath + "/photo2.jpg")
                fnm2 = GetUniqueFilename(dirpath + "/photo3.jpg")


                If Me.FileUpload1.HasFile Then
                    Me.FileUpload1.SaveAs(fnm)
                    Dim fs As New IO.FileStream(fnm, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl(fs.Length) As Byte
                    fs.Read(bl, 0, fs.Length)
                    fs.Close()
                    sql = "update tbl_marketing_activity_new t  set t.VENDOR1QUTN=:photo1  where t.ACTVTY_ID=" & act_id & ""
                    Dim parm_coll(0) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "photo1"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl
                    oh.ExecuteNonQuery(sql, parm_coll)

                End If

                If Me.FileUpload2.HasFile Then
                    Me.FileUpload2.SaveAs(fnm1)
                    Dim fs1 As New IO.FileStream(fnm1, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl2(fs1.Length) As Byte
                    fs1.Read(bl2, 0, fs1.Length)
                    fs1.Close()
                    sql = "update TBL_MARKETING_ACTIVITY_NEW t  set t.VENDOR2QUTN=:photo2  where t.ACTVTY_ID=" & act_id & ""

                    '   sql = "Insert into DMS.TBL_MRKT_ACTVTY_VENDOR_QUTN (activity_id,VENDOR1QUTN,ENTER_DATE) values (" & act_id & "," & " :photo2,sysdate ) "

                    ' values (SEQ_CRM_QUICK_REF_HLDY.NEXTVAL," & " :BlobParameter,'" & FileExtension & "','" & fileName & "',sysdate)"


                    Dim parm_coll(0) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "photo2"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl2
                    oh.ExecuteNonQuery(sql, parm_coll)


                End If

                If Me.FileUpload3.HasFile Then
                    Me.FileUpload3.SaveAs(fnm2)
                    Dim fs2 As New IO.FileStream(fnm2, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim bl3(fs2.Length) As Byte
                    fs2.Read(bl3, 0, fs2.Length)
                    fs2.Close()
                    sql = "update TBL_MARKETING_ACTIVITY_NEW t  set t.VENDOR3QUTN=:photo3  where t.ACTVTY_ID=" & act_id & ""
                    Dim parm_coll(0) As OracleParameter
                    parm_coll(0) = New OracleParameter
                    parm_coll(0).ParameterName = "photo3"
                    parm_coll(0).OracleType = OracleType.Blob
                    parm_coll(0).Direction = ParameterDirection.Input
                    parm_coll(0).Value = bl3
                    oh.ExecuteNonQuery(sql, parm_coll)
                End If


                Dim fp As New IO.FileInfo(fnm)
                If fp.Exists Then
                    fp.Delete()
                End If

                Dim fp1 As New IO.FileInfo(fnm1)
                If fp1.Exists Then
                    fp1.Delete()
                End If

                Dim fp2 As New IO.FileInfo(fnm2)
                If fp2.Exists Then
                    fp2.Delete()
                End If

                Dim c1_script33 As New System.Text.StringBuilder
                c1_script33.Append("alert('" & msg & "');")
                c1_script33.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script33.ToString, True)
            End If
        End If
        Exit Sub
    End Sub
    Public Shared Function GetUniqueFilename(ByVal FileName As String) As String
        Dim count As Integer = 0
        Dim Name As String = ""
        If System.IO.File.Exists(FileName) Then
            Dim f As New System.IO.FileInfo(FileName)
            If Not String.IsNullOrEmpty(f.Extension) Then
                Name = f.FullName.Substring(0, f.FullName.LastIndexOf("."))
            Else
                Name = f.FullName
            End If
            While System.IO.File.Exists(FileName)
                count += 1
                FileName = Name + count.ToString() + f.Extension
            End While
        End If
        Return FileName
    End Function
    Protected Sub btn_ext_Click(sender As Object, e As EventArgs) Handles btn_ext.Click
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "", "window.open('../Home.aspx','_self');", True)
    End Sub

    Protected Sub btn_vew_Click(sender As Object, e As EventArgs) Handles btn_vew.Click
        Dim ad As Integer
        ad = DrpActivity.SelectedValue
        Response.Redirect("activity_descrptn.aspx?act=" & ad)

    End Sub

    Protected Sub btn_vendr_Click(sender As Object, e As EventArgs) Handles btn_vendr.Click

        Dim p_indata As String = DrpActivity.SelectedValue + "µ" + TxtMnt.Text + "µ" + TxtDay.Text + "µ" + txt_unit.Text + "µ" + txt_sqft.Text + "µ" + txt_sec.Text + "µ" + vendor_drp1.SelectedItem.Value + "µ" + Textjust.Text + "µ" + Txt_amnt_vendr1.Text + "µ" + Session("branch_id").ToString() + "µ" + txtstartdate.Text + "µ" + txtenddate.Text + "µ" + txt_others.Text + "µ" + txt_count.Text

        Dim conf_par(8) As OracleParameter
        conf_par(0) = New OracleParameter("entrdby", OracleType.Number)
        conf_par(0).Direction = ParameterDirection.Input
        conf_par(0).Value = CInt(usr(0))

        conf_par(1) = New OracleParameter("p_indata", OracleType.VarChar, 5000)
        conf_par(1).Direction = ParameterDirection.Input
        conf_par(1).Value = p_indata

        conf_par(2) = New OracleParameter("ERR_MSG", OracleType.VarChar, 150)
        conf_par(2).Direction = ParameterDirection.Output

        conf_par(3) = New OracleParameter("ERR_STAT", OracleType.Number)
        conf_par(3).Direction = ParameterDirection.Output

        conf_par(4) = New OracleParameter("ACT_ID", OracleType.Number)
        conf_par(4).Direction = ParameterDirection.Output

        conf_par(5) = New OracleParameter("stat", OracleType.Number)
        conf_par(5).Direction = ParameterDirection.Input
        conf_par(5).Value = 3

        conf_par(6) = New OracleParameter("APrvd_by", OracleType.Number)
        conf_par(6).Direction = ParameterDirection.Input
        conf_par(6).Value = 0

        conf_par(7) = New OracleParameter("Rejct_by", OracleType.Number)
        conf_par(7).Direction = ParameterDirection.Input
        conf_par(7).Value = 0

        conf_par(8) = New OracleParameter("APV_REJ_RKS", OracleType.VarChar)
        conf_par(8).Direction = ParameterDirection.Input
        conf_par(8).Value = ""

        oh.ExecuteNonQuery("proc_markting_proposal", conf_par)
        msg = conf_par(2).Value.ToString()

        Dim c1_script33 As New System.Text.StringBuilder
        c1_script33.Append("alert('" & msg & "');")
        c1_script33.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script33.ToString, True)

    End Sub

    Protected Sub btn_calc_Click(sender As Object, e As EventArgs) Handles btn_calc.Click


        ' ----------CRF_101605
        Sql13 = "select t.quantity_type from STATUS_MASTER_QTY t where t.activity_id = " & DrpActivity.SelectedValue & ""
        dt3 = oh.ExecuteDataSet(Sql13).Tables(0)
        If dt3.Rows(0)(0).ToString() = "1" Then  'Unit
  Dim a As Decimal = (Convert.ToDecimal(txt_unit.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a

        ElseIf dt3.Rows(0)(0).ToString() = "2" Then 'Sqft


           Dim a As Decimal = (Convert.ToDecimal(txt_sqft.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a

        ElseIf dt3.Rows(0)(0).ToString() = "3" Then 'DurationInSeconds


            Dim a As Decimal = (Convert.ToDecimal(txt_sec.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a

        ElseIf dt3.Rows(0)(0).ToString() = "4" Then 'Month&Days

Dim a As Decimal = (Convert.ToDecimal(TxtDay.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a

        End If

        ' ----------CRF_101605----- end



        ' If Convert.ToDecimal(txt_unit.Text) <> 0 Then
        If DrpActivity.SelectedValue = 5 Or DrpActivity.SelectedValue = 6 Or DrpActivity.SelectedValue = 9 Or DrpActivity.SelectedValue = 10 Or DrpActivity.SelectedValue = 11 Or DrpActivity.SelectedValue = 12 Or DrpActivity.SelectedValue = 13 Or DrpActivity.SelectedValue = 14 Or DrpActivity.SelectedValue = 15 Or DrpActivity.SelectedValue = 16 Or DrpActivity.SelectedValue = 17 Or DrpActivity.SelectedValue = 18 Or DrpActivity.SelectedValue = 20 Or DrpActivity.SelectedValue = 21 Or DrpActivity.SelectedValue = 22 Or DrpActivity.SelectedValue = 25 Or DrpActivity.SelectedValue = 32 Or DrpActivity.SelectedValue = 24 Or DrpActivity.SelectedValue = 40 Then

            Dim a As Decimal = (Convert.ToDecimal(txt_unit.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a

            '   ElseIf Convert.ToDecimal(txt_sqft.Text) <> 0 Then

        ElseIf DrpActivity.SelectedValue = 1 Or DrpActivity.SelectedValue = 2 Or DrpActivity.SelectedValue = 26 Or DrpActivity.SelectedValue = 27 Or DrpActivity.SelectedValue = 28 Or DrpActivity.SelectedValue = 29 Or DrpActivity.SelectedValue = 30 Or DrpActivity.SelectedValue = 31 Or DrpActivity.SelectedValue = 34 Or DrpActivity.SelectedValue = 36 Or DrpActivity.SelectedValue = 37 Or DrpActivity.SelectedValue = 38 Or DrpActivity.SelectedValue = 39 Then

            Dim a As Decimal = (Convert.ToDecimal(txt_sqft.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a

            '  ElseIf Convert.ToDecimal(txt_sec.Text) <> 0 Then
        ElseIf DrpActivity.SelectedValue = 19 Or DrpActivity.SelectedValue = 33 Or DrpActivity.SelectedValue = 35 Then

            Dim a As Decimal = (Convert.ToDecimal(txt_sec.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a



            ' ElseIf Convert.ToDecimal(TxtDay.Text) <> 0 Then
        ElseIf DrpActivity.SelectedValue = 7 Or DrpActivity.SelectedValue = 8 Then

            Dim a As Decimal = (Convert.ToDecimal(TxtDay.Text) * (Convert.ToDecimal(txt_unt_prc.Text)))

            txt_amnt.Text = a


        End If

    End Sub

    Protected Sub Drp_lclty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Drp_lclty.SelectedIndexChanged
        dt12 = oh.ExecuteDataSet("select t.cost from TBL_MRKTNG_ACT_LOCALTY t where t.locality_id =" & Drp_lclty.SelectedValue & "").Tables(0)
        txt_unt_prc.Text = dt12.Rows(0)(0).ToString()
    End Sub

    Protected Sub txt_count_TextChanged(sender As Object, e As EventArgs) Handles txt_count.TextChanged

   
        Sql14 = "select t.status_id from STATUS_MASTER t where t.module_id = 535 and t.option_id = 1 and t.status_id = " & DrpActivity.SelectedValue & ""
        dt14 = oh.ExecuteDataSet(Sql14).Tables(0)

        If dt14.Rows(0)(0).ToString() = "28" Then


            Sql15 = "select count(*) from TBL_MARKETING_SHOP t where t.status=0 and t.branch_id=" & branchID & ""
            dt1 = oh.ExecuteDataSet(Sql15).Tables(0)

            If dt1.Rows(0)(0) > 0 Then

                Dim cl_script As New StringBuilder
                cl_script.Append("alert('Already One Request is Pending!!') ;")
                cl_script.Append("window.open('shop_bord.aspx', '_self', '');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If

            Sql = "SELECT tt.count, tt.duration_mnth, tt.duration_days FROM TBL_MARKETING_SHOP tt WHERE tt.branch_id=" & branchID & " and tt.status = 1 and tt.enter_date = (SELECT MAX(t.enter_date) FROM TBL_MARKETING_SHOP t where t.branch_id=" & branchID & "and t.status = 1)"
            dt = oh.ExecuteDataSet(Sql).Tables(0)

            If dt.Rows.Count > 0 Then

                txt_count.Text = dt.Rows(0)(0).ToString()
                TxtMnt.Text = dt.Rows(0)(1).ToString()
                TxtDay.Text = dt.Rows(0)(2).ToString()
                Exit Sub
            End If



            '                                        1                       2                  3                      4                             5  
            Dim p_indata1 As String = DrpActivity.SelectedValue + "µ" + TxtMnt.Text + "µ" + TxtDay.Text + "µ" + txt_count.Text + "µ" + Session("branch_id").ToString()

            Dim conf_par(3) As OracleParameter
            conf_par(0) = New OracleParameter("entrdby", OracleType.Number)
            conf_par(0).Direction = ParameterDirection.Input
            conf_par(0).Value = CInt(usr(0))

            conf_par(1) = New OracleParameter("p_indata", OracleType.VarChar, 5000)
            conf_par(1).Direction = ParameterDirection.Input
            conf_par(1).Value = p_indata1

            conf_par(2) = New OracleParameter("ERR_MSG", OracleType.VarChar, 150)
            conf_par(2).Direction = ParameterDirection.Output

            conf_par(3) = New OracleParameter("stat", OracleType.Number)
            conf_par(3).Direction = ParameterDirection.Input
            conf_par(3).Value = 0

            oh.ExecuteNonQuery("proc_marketing_shopborad", conf_par)
            msg = conf_par(2).Value.ToString()

            Response.Redirect("shop_bord.aspx")


        End If


    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If vendr1_nme.Text <> "" Then
            Dim prefixText As String
            prefixText = vendr1_nme.Text

            prefixText = prefixText.ToUpper()

            prefixText = prefixText + "%"
            Dim sql As String
            sql = "select t.vendor_id,t.vendor_name|| '~' ||t.vendor_id  from TBL_VENDOR_MASTER t where t.vendor_name like '" & prefixText & "' "
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet(sql).Tables(0)

            If dt.Rows.Count > 0 Then


                vendor_drp1.DataSource = dt
                vendor_drp1.DataValueField = dt.Columns(0).ColumnName
                vendor_drp1.DataTextField = dt.Columns(1).ColumnName
                vendor_drp1.DataBind()
            Else
                sql = "select 'no data found','no data found' from dual"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                vendor_drp1.DataSource = dt
                vendor_drp1.DataTextField = dt.Columns(0).ColumnName
                vendor_drp1.DataValueField = dt.Columns(1).ColumnName
                vendor_drp1.DataBind()


            End If
        Else
            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('Please Enter first few alphabets of Vendor name and click view');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If vendor2_name.Text <> "" Then
            Dim prefixText As String
            prefixText = vendor2_name.Text

            prefixText = prefixText.ToUpper()

            prefixText = prefixText + "%"
            Dim sql As String
            sql = "select t.vendor_id,t.vendor_name|| '~' ||t.vendor_id  from TBL_VENDOR_MASTER t where t.vendor_name like '" & prefixText & "' "
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet(sql).Tables(0)

            If dt.Rows.Count > 0 Then


                vendor_drp2.DataSource = dt
                vendor_drp2.DataValueField = dt.Columns(0).ColumnName
                vendor_drp2.DataTextField = dt.Columns(1).ColumnName
                vendor_drp2.DataBind()
            Else
                sql = "select 'no data found','no data found' from dual"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                vendor_drp2.DataSource = dt
                vendor_drp2.DataTextField = dt.Columns(0).ColumnName
                vendor_drp2.DataValueField = dt.Columns(1).ColumnName
                vendor_drp2.DataBind()
            End If
        Else
            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('Please Enter first few alphabets of Vendor name and click view');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If vendor3_name.Text <> "" Then
            Dim prefixText As String
            prefixText = vendor3_name.Text

            prefixText = prefixText.ToUpper()

            prefixText = prefixText + "%"
            Dim sql As String
            sql = "select t.vendor_id,t.vendor_name || '~' ||t.vendor_id  from TBL_VENDOR_MASTER t where t.vendor_name like '" & prefixText & "' "
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet(sql).Tables(0)

            If dt.Rows.Count > 0 Then


                vendor_drp3.DataSource = dt
                vendor_drp3.DataValueField = dt.Columns(0).ColumnName
                vendor_drp3.DataTextField = dt.Columns(1).ColumnName
                vendor_drp3.DataBind()
            Else
                sql = "select 'no data found','no data found' from dual"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                vendor_drp3.DataSource = dt
                vendor_drp3.DataTextField = dt.Columns(0).ColumnName
                vendor_drp3.DataValueField = dt.Columns(1).ColumnName
                vendor_drp3.DataBind()
            End If
        Else
            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('Please Enter first few alphabets of Vendor name and click view');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
        End If
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If vendor_drp1.SelectedValue = "" Or vendor_drp2.SelectedValue = "" Or vendor_drp3.SelectedValue = "" Then
            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('Please fill all vendor');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
        ElseIf Txt_amnt_vendr1.Text = "" Or Txt_amnt_vendr2.Text = "" Or Txt_amnt_vendr3.Text = "" Then
            Dim c1_script As New System.Text.StringBuilder
            c1_script.Append("alert('Please fill all Quatation amount');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", c1_script.ToString, True)
        Else

            v1n = vendor_drp1.SelectedItem.Value
            v2n = vendor_drp2.SelectedItem.Value
            v3n = vendor_drp3.SelectedItem.Value
           

            Sql = "select '-1','--select--' from dual union all select tv.vendor_id,tv.vendor_name|| '~' ||tv.vendor_id  from TBL_VENDOR_MASTER tv where tv.vendor_id in('" & v1n & "','" & v2n & "','" & v3n & "')"
            dt = oh.ExecuteDataSet(Sql).Tables(0)
            vendor_drpf.DataSource = dt
            vendor_drpf.DataTextField = dt.Columns(1).ColumnName
            vendor_drpf.DataValueField = dt.Columns(0).ColumnName
            vendor_drpf.DataBind()
        End If

    End Sub

    Protected Sub vendor_drpf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vendor_drpf.SelectedIndexChanged
        Dim v1t, v2t, v3t As String
        v1n = vendor_drp1.SelectedItem.Value
        v2n = vendor_drp2.SelectedItem.Value
        v3n = vendor_drp3.SelectedItem.Value
        v1t = Txt_amnt_vendr1.Text
        v2t = Txt_amnt_vendr2.Text
        v3t = Txt_amnt_vendr3.Text
        If vendor_drpf.SelectedItem.Value = v1n Then
            TxtFAmt.Text = v1t
        ElseIf vendor_drpf.SelectedItem.Value = v2n Then
            TxtFAmt.Text = v2t
        ElseIf vendor_drpf.SelectedItem.Value = v3n Then
            TxtFAmt.Text = v3t
        Else
            TxtFAmt.Text = ""
        End If
    End Sub

    Protected Sub txt_amnt_TextChanged(sender As Object, e As EventArgs) Handles txt_amnt.TextChanged

    End Sub
End Class
