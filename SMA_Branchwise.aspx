<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SMA_Branchwise.aspx.vb" Inherits="Pledge_SMA_classification_SMA_Branchwise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function GetPledgewiseSMA(branch_id,fdt,tdt) {
            window.open('PledgewiseRpt.aspx?branch_id=' + branch_id + '&fdt=' + fdt + '&tdt=' + tdt + '', '_self');
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_exit" style="font-weight: bold; width: 10%;" runat="server" Text="EXIT" />
        <asp:Button ID="btn_excel" runat="server" Font-Bold="True" Text="Export to Excel branchwise" />
        <asp:Button ID="btn_excel_p" runat="server" Font-Bold="True" Text="Export to Excel pledgewise" />
        <br />
        <br />

            <asp:Panel ID="Panel1" runat="server" Height="72px" Width="968px">
            </asp:Panel>
       
    
    </div>
    </form>
</body>
</html>
