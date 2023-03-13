<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PledgewiseRpt.aspx.vb" Inherits="SMA_Classification_PledgewiseRpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btn_exit" style="font-weight: bold; width: 10%;" runat="server" Text="EXIT" />
        <asp:Button ID="btn_excel" runat="server" Font-Bold="True" Text="Export to Excel" />
        <br />
        <br />

        
        <asp:Panel ID="Panel1" runat="server" BackColor="#99ccff">
            </asp:Panel>
    </div>
    </form>
</body>
</html>
