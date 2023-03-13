<%@ Page Title="" Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeFile="SMA_ExcelUpload.aspx.vb" Inherits="Pledge_SMA_classification_SMA_ExcelUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <script language="javascript" type="text/javascript">
        function BtnExit_onclick() {
            history.go(-1);
            return false;
        }
    </script>
    <asp:ScriptManager ID="scriptManager_billupload" runat="server"></asp:ScriptManager>



    <div style="text-align: center">
        &nbsp;
       <table border="1" style="text-align: center; width: 50%; height: 28%; background-color: #FFFFFF; border-right: red 1px solid; border-top: red 1px solid; border-left: red 1px solid; border-bottom: red 1px solid;" id="TABLE1">

           <tr>
               <td align="center" colspan="4" style="height: 29px; background-color: tomato; font-weight: bold; color: white;">SMA EXCEL UPLOAD</td>
           </tr>
            <tr>
     <td style="height: 30px; width: 277px;text-align:right ;background-color: #F3FFFF;"><asp:Label runat="server" ID="lbl_excel" Text="Choose file to upload (Format:xls)" Font-Names="Tahoma" Font-Size="Small"></asp:Label>  :</td>
      
        <td colspan="2" style="height: 30px; background-color: #f3ffff; text-align: left; width: 231px;"> 
            <asp:FileUpload ID="file_upload" Height="24px" runat="server" Font-Names="Tahoma" Font-Size="Small"/></td>
    </tr>
    <tr>
    <td colspan="4" style="background-color: #F3FFFF; height: 26px;">
    <asp:Button ID="btn_upload" ValidationGroup ="ff"  runat="server" Font-Bold="True" Text="Upload" Width="88px" OnClick="btn_upload_Click"/>&nbsp;
        
      <input id="BtnExit" style="width: 54px" type="button" value="Exit" onclick="return BtnExit_onclick()" />
    </td>
    </tr>
    <tr>                    
    
    <td colspan="4" style="background-color: #F3FFFF;">
        <asp:TextBox ID="txtuploadDetails" Width="100%" Height ="160px" ReadOnly ="true" runat="server" TextMode="MultiLine" BackColor="ButtonFace"></asp:TextBox>
    </td>
    </tr>
       </table>
         &nbsp;<asp:Label ID="lbl_head" runat="server" Width="592px"></asp:Label><br />
    </div>
</asp:Content>

