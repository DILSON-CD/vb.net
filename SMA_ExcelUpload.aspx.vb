Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Partial Class Pledge_SMA_classification_SMA_ExcelUpload
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim RESULT As String
    Dim dt, dt1, dt2, dt3 As New DataTable

    Dim Gobj As New GHelper.Report.ExcelExport
    Dim usr() As String
    Dim results As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usr = Me.Session("user_id").ToString.Split("!")
        Dim UserID() As String = Session("user_id").ToString.Split("!")

        dt = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & UserID(0) & " and form_id=7180").Tables(0)
        'If dt.Rows(0)(0) = 0 Then
        '    Server.Transfer("../../show_err.aspx")
        'End If
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If results <> "1" Then
            Dim str As String


            Try
                Dim msg As String = ""
                results = ""

                Dim connectionString As String = ""
                If Me.file_upload.HasFile = False Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('Please browse excel');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                    Exit Sub
                Else
                    Dim fileName As String = Path.GetFileName(file_upload.PostedFile.FileName)
                    Dim fileExtension As String = Path.GetExtension(file_upload.PostedFile.FileName)
                    Dim fileLocation As String = Server.MapPath(fileName)
                    file_upload.SaveAs(fileLocation)

                    If fileExtension = ".xls" Then
                        If Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") = "x86" Then
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=YES;"""
                        Else
                            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
                        End If
                    Else
                        Dim cl_script2 As New System.Text.StringBuilder
                        cl_script2.Append(" alert('Uploaded Only Excel file with Extention .xls, Ex::sample.xls ');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script2.ToString, True)
                        Exit Sub
                    End If
                    Dim con As New OleDbConnection(connectionString)
                    Dim cmd As New OleDbCommand()
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.Connection = con
                    Dim dAdapter As New OleDbDataAdapter(cmd)
                    Dim dtExcelRecords As New DataTable()
                    con.Open()
                    Dim dtExcelSheetName As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
                    cmd.CommandText = "SELECT * FROM [" & getExcelSheetName & "]"
                    dAdapter.SelectCommand = cmd
                    dAdapter.Fill(dtExcelRecords)
                    con.Close()


                    If dtExcelRecords.Rows.Count > 50002 Then
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("alert('Only a Maximum of 50000 Records can be Uploaded at a Time..!!!');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script1.ToString, True)
                        Exit Sub
                    End If
                    Dim dr As DataRow
                    Try
                        For Each dr In dtExcelRecords.Rows
                           
                            Dim pledgeNo As String = ""
                            Dim Reversalamnt As String = ""

                            pledgeNo = dr(0).ToString
                            Reversalamnt = dr(1).ToString
                            
                            Dim res, Sql As String
                            con.Open()
                            Sql = "insert into tbl_sma_reversal_excel(pledgeNo, Reversalamnt) values(  '" & pledgeNo & "','" & Reversalamnt & "')"
                            results = oh.ExecuteNonQuery(Sql)
                            con.Close()
                            txtuploadDetails.Text += pledgeNo + "  |  " + " | " + Reversalamnt + " | " + Environment.NewLine

                            If (results = "1") Then

                                'Dim to_mailid As String = "377129@manappuram.com"
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("alert('Successfully Completed...!!!!');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)


                            End If


                        Next
                    Catch ex As Exception
                        msg = ex.Message
                        Dim cl_script2 As New System.Text.StringBuilder
                        cl_script2.Append("alert('" & msg & "');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script2.ToString, True)
                    End Try


                    Dim fp As New IO.FileInfo(fileLocation)
                    If fp.Exists Then
                        fp.Delete()
                    End If


                End If

            Catch ex As Exception
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('" & ex.Message.ToString & "');")
                'cl_script1.Append("window.open('Upload_Exel.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End Try
        End If

    End Sub
End Class
