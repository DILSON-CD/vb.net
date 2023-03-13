<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Date_select.aspx.vb" Inherits="Pledge_SMA_classification_Date_select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../CSS/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../script/jquery-1.10.2.js" type="text/javascript" language="javascript"></script>
    <script src="../../script/jquery-ui-1.10.4.custom.min.js" type="text/javascript" language="javascript"></script>
    <title></title>

    <style type="text/css">
        .auto-style1 {
            width: 50%;
            border:solid;
            border-color:purple;
        }
        .auto-style2 {
            text-decoration: underline;
            color: #660066;
            font-size: x-large;
        }
    </style>
</head>
    <script language="javascript" type="text/javascript">
        // <!CDATA[


        function DtFocus() {
            $(function () {
               
                $("#<%=Text_ToDt.ClientID%>").datepicker({
                    defaultDate: "+1w",
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd/M/yy',
                    maxDate: new Date(),
                    onClose: function (selectedDate) {
                      
                    }
                });
                $("#<%=Text_ToDt.ClientID%>").datepicker("option", "showAnim", "clip");
            });
        }

        // ]]>
</script>
<body>
    <form id="form2" runat="server">
    <div style="text-align: center">
    
        <br />
        <br />
        <br />
        <br />
        <br />
    
        <table class="auto-style1" align="center" >
            <tr>
                <td colspan="2" class="auto-style2" style="background-color: #FFCCFF"><strong>SMA REPORT</strong></td>
            </tr>
         <%--   <tr>
                <td style="width: 50%;"><strong>From Date</strong></td>
                <td style="width: 50%;">
                    <asp:TextBox ID="Text_FromDt" runat="server" onkeydown="false"  onmousedown="return DtFocus()"  Width="60%"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td style="width: 50%;"><strong>Process Date</strong></td>
                <td style="width: 50%;">
                    <asp:TextBox ID="Text_ToDt" runat="server" onkeydown="false"  onmousedown="return DtFocus()"  Width="60%"></asp:TextBox>
                </td>
            </tr>
           
        
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_show" runat="server" Text="Generate" BackColor="#660033" Font-Bold="True" ForeColor="White" Width="30%" />
                    &nbsp;
                    <asp:Button ID="btn_exit" runat="server" Text="EXIT"  BackColor="#660033" Font-Bold="True" ForeColor="White" Width="30%" />
                          &nbsp;
                    
                </td>
            </tr>
           
        </table>
    
    </div>
    </form>
</body>
</html>
