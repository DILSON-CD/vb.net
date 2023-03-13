<%@ Page Title="" Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeFile="Po_aprv_details.aspx.vb" Inherits="Marketing_Activities_Po_aprv_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
      <table style="width: 3040px; margin-left: 0px; height: 184px;" align="center">
       
        <tr>
            <td style="width: 1096px; height: 24px; background-color: white; color: #FFFFFF;" align="center">
                <span style="background-color: #009900; ">
                  <strong>&nbsp;&nbsp;&nbsp;
                  MARKETING ACTIVITY PO REPORT&nbsp;&nbsp; </strong></span></td>
        </tr>
        <tr>
            <td style="width: 1096px; height: 24px; background-color: white; color: #FFFFFF;" align="center">
                <asp:Button ID="Btn_export" runat="server" Text="Export" Width="106px" style="background-color: #66CCFF" />
                <asp:Button ID="btn_ext" runat="server" style="margin-left: 40px; background-color: #66CCFF;" Text="Exit" Width="83px" />
            </td>
        </tr>
        <tr>
 <asp:GridView ID="GridView1" runat="server"  EnableModelValidation="True" CellPadding="3" style="background-color: silver; margin-top: 0px; text-align: center;" GridLines="Vertical" Height="158px" Width="3035px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" autogeneratecolumns="false">
      <Columns>
      <asp:BoundField DataField="actvty_id"   HeaderText="Activity Id" >
                    <HeaderStyle Font-Names="Calibri" />
                     </asp:BoundField>
                     <asp:BoundField DataField="brid" HeaderText="Branch id" />
           <asp:BoundField DataField="BRANCH_NAME" HeaderText="Branch Name" />
           <asp:BoundField DataField="area_name" HeaderText="Area name" />
                     <asp:BoundField DataField="reg_name" HeaderText="Region name" />
           <asp:BoundField DataField="po_id" HeaderText="po_id" />
                                    <asp:BoundField DataField="description" HeaderText="description" />
                                 <asp:BoundField DataField="status" HeaderText="status" />

           <asp:BoundField DataField="total_amount" HeaderText="Total_amount" />
           <asp:BoundField DataField="enter_date" HeaderText="Enter_date" />
                       <asp:BoundField DataField="enter_by" HeaderText="enter_by" />
                     <asp:BoundField DataField="approved_by" HeaderText="Approved by" />
                       <asp:BoundField DataField="approved_date" HeaderText="Approved date" />
           <asp:BoundField DataField="cancelled_by" HeaderText="Cancelled by" />
                     <asp:BoundField DataField="cancel_dt" HeaderText="Cancell date" />
          <asp:BoundField DataField="invoice_status" HeaderText="invoice_status" />
                                <asp:BoundField DataField="LAG_days" HeaderText="LAG_days" />
                          <asp:BoundField DataField="activity_started_status" HeaderText="activity_started_status" />   
                      <asp:BoundField DataField="po_payment_status" HeaderText="po_payment_status" />
           </Columns>
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
      
     </asp:GridView>
</tr>

    </table>

</asp:Content>

