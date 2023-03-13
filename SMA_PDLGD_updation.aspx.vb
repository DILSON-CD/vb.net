Imports System.Data
Imports System.Data.OracleClient
Imports System.Globalization

Partial Class Pledge_SMA_classification_SMA_PDLGD_updation
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dtt, dt3 As New DataTable
    Dim sq1, sqll, sql3 As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sq1 = "select -1, '----- Select -----' from dual union ALL select t.product_id, t.product_name from TBL_SMA_PRODUCT t"
            dt = oh.ExecuteDataSet(sq1).Tables(0)
            sqll = "SELECT -1,'-----Select-----' FROM DUAL UNION ALL SELECT T.ID, T.CATOGRY FROM TBL_SMA_STG_SEC_STATS T WHERE T.STATUS = 1"
            dtt = oh.ExecuteDataSet(sqll).Tables(0)
            sql3 = "SELECT -1,'-----Select-----' FROM DUAL UNION ALL SELECT T.ID, T.CATOGRY FROM TBL_SMA_STG_SEC_STATS T WHERE T.STATUS = 2"
            dt3 = oh.ExecuteDataSet(sql3).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.prdct_DropDownList.DataSource = dt
                Me.prdct_DropDownList.DataValueField = dt.Columns(0).ColumnName
                Me.prdct_DropDownList.DataTextField = dt.Columns(1).ColumnName

                Me.prdct_DropDownList.DataBind()
            Else

            End If
            If dtt.Rows.Count > 0 Then
                Me.stage_DropDownList.DataSource = dtt
                Me.stage_DropDownList.DataValueField = dtt.Columns(0).ColumnName
                Me.stage_DropDownList.DataTextField = dtt.Columns(1).ColumnName

                Me.stage_DropDownList.DataBind()
            Else

            End If
            If dt3.Rows.Count > 0 Then
                Me.secured_DropDownList.DataSource = dt3
                Me.secured_DropDownList.DataValueField = dt3.Columns(0).ColumnName
                Me.secured_DropDownList.DataTextField = dt3.Columns(1).ColumnName

                Me.secured_DropDownList.DataBind()
            Else

            End If

            'Me.pd.Attributes.Add("onkeypress", "mob_validation()")
            'Me.lgd.Attributes.Add("onkeypress", "mob_validation()")

        End If


    End Sub

    Protected Sub prdct_DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles prdct_DropDownList.SelectedIndexChanged

        Dim prod As String = prdct_DropDownList.SelectedValue

    End Sub
    Protected Sub stage_DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles stage_DropDownList.SelectedIndexChanged

        Dim stgd As String = stage_DropDownList.SelectedValue

    End Sub
    Protected Sub secured_DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles secured_DropDownList.SelectedIndexChanged

        Dim secd As String = secured_DropDownList.SelectedValue

    End Sub


    Protected Sub emp_confirm_Click(sender As Object, e As EventArgs) Handles emp_confirm.Click
        Dim sql3, sql4, sql5, sql6, sql7, fdt, tdt, oldtdt As String
        Dim dt, dt1 As New DataTable

        If Me.txt_fdate.Text = "" Then
            fdt = DateTime.MinValue
        Else
            fdt = Me.txt_fdate.Text

        End If


        sql4 = "select to_char(to_date('" & fdt & "') + 1825, 'DD/MON/YYYY') from dual"
        dt = oh.ExecuteDataSet(sql4).Tables(0)

        tdt = dt.Rows(0)(0)

        'If Me.to_date.Text = "" Then
        '    tdt = DateTime.MinValue
        'Else
        '    tdt = Me.to_date.Text

        'End If
        sql5 = "SELECT count(to_char(to_date(t.to_dt) , 'DD/MON/YYYY')) FROM TBL_SMA_PDLGD t WHERE t.product= " & Me.prdct_DropDownList.SelectedItem.Value & " AND to_date(SYSDATE) BETWEEN to_date(t.frm_dt) AND to_date(t.to_dt)"
        dt1 = oh.ExecuteDataSet(sql5).Tables(0)

        Dim count As String = dt1.Rows(0)(0)

        If (count <> 0) Then

            sql7 = " update TBL_SMA_PDLGD u set u.to_dt= '" & fdt & "' where u.product = " & Me.prdct_DropDownList.SelectedItem.Value & " and u.to_dt =(select max(u.to_dt) FROM TBL_SMA_PDLGD u where u.product = " & Me.prdct_DropDownList.SelectedItem.Value & ")"
            oh.ExecuteNonQuery(sql7)

            sql6 = "insert into TBL_SMA_PDLGD (product,stage,secured,frm_dt,to_dt,pd,lgd) values('" & Me.prdct_DropDownList.SelectedItem.Value & "','" & Me.stage_DropDownList.SelectedItem.Text & "','" & Me.secured_DropDownList.SelectedItem.Value & "','" & fdt & "','" & tdt & "'," & Me.p_d.Text & "," & Me.lgd.Text & ")"
            oh.ExecuteNonQuery(sql6)


        Else

            sql3 = "insert into TBL_SMA_PDLGD (product,stage,secured,frm_dt,to_dt,pd,lgd) values('" & Me.prdct_DropDownList.SelectedItem.Value & "','" & Me.stage_DropDownList.SelectedItem.Text & "','" & Me.secured_DropDownList.SelectedItem.Value & "','" & fdt & "','" & tdt & "'," & Me.p_d.Text & "," & Me.lgd.Text & ")"
            oh.ExecuteNonQuery(sql3)

        End If


       


        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('success !!!');")
        cl_script1.Append("window.open('SMA_PDLGD_updation.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script1.ToString, True)
        Exit Sub

    End Sub


    Protected Sub txt_fdate_TextChanged(sender As Object, e As EventArgs) Handles txt_fdate.TextChanged
        If txt_fdate.Text < Date.Today Then

            Dim cl_script2 As New System.Text.StringBuilder
            cl_script2.Append("         alert('previous date not allowed !!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script2.ToString, True)


        End If
    End Sub
End Class
