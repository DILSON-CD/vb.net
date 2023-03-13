<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SMA_Regwise.aspx.vb" Inherits="Pledge_SMA_classification_SMA_Regwise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <script language="javascript" type="text/javascript">

         function GetAreawiseSMA(reg_id,fdt,tdt) {
             window.open('SMA_Areawise.aspx?reg_id=' + reg_id + '&fdt=' + fdt + '&tdt=' + tdt + '', '_self');
         }
</script>
</head>
<body>
    <form id="form2" runat="server">
    <div>
       
            <asp:Button ID="btn_exit" style="font-weight: bold; width: 10%;" runat="server" Text="EXIT" />
        <asp:Button ID="btn_excel" runat="server" Font-Bold="True" Text="Export to Excel branch" />
        <asp:Button ID="btn_excel_p" runat="server" Font-Bold="True" Text="Export to Excel pledgewise" />
        <br />
        <br />

            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
      
    
    </div>
    </form>
</body>
</html>
