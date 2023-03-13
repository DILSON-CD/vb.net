<%@ Page Title="" Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeFile="PO_aprv.aspx.vb" Inherits="Marketing_Activities_PO_aprv" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont_name = header.split('txt');
        function btn_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function OnkeyUpChqDate(Control) {
            if (document.getElementById(cont_name[0] + Control).value != "") {
                alert("Select Date from Calender ..!!!!");
                if (Control == "txt_to") {
                    document.getElementById(cont_name[0] + Control).value = document.getElementById(cont_name[0] + "hdn_sysdate").value;
                }
                else {
                    document.getElementById(cont_name[0] + Control).value = document.getElementById(cont_name[0] + "hdn_sysdate1").value;
                }
            }
        }



        function check_Fdate(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(cont_name[0] + Control).value != "") {
                var value1 = document.getElementById(cont_name[0] + Control).value;
                var dt = new Date().format("dd/MMM/yyyy");
                var value2 = dt;

                day1 = value1.substring(0, value1.indexOf("/"));
                month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
                year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

                day2 = value2.substring(0, value2.indexOf("/"));
                month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
                year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

                date1 = year1 + "/" + month1 + "/" + day1;
                date2 = year2 + "/" + month2 + "/" + day2;

                firstDate = Date.parse(date1)
                secondDate = Date.parse(date2)

                msPerDay = 24 * 60 * 60 * 1000

                dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                if (dbd < 0) {
                    alert("Please Do Not Enter Future Date ..!!")
                    document.getElementById(cont_name[0] + Control).value = document.getElementById(cont_name[0] + "hdn_sysdate1").value;
                    document.getElementById(cont_name[0] + Control).focus();
                    return false;
                }
            }

        }
        function check_Tdate(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(cont_name[0] + Control).value != "") {
                var value1 = document.getElementById(cont_name[0] + Control).value;
                var dt = new Date().format("dd/MMM/yyyy");
                var value2 = dt;

                day1 = value1.substring(0, value1.indexOf("/"));
                month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
                year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

                day2 = value2.substring(0, value2.indexOf("/"));
                month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
                year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

                date1 = year1 + "/" + month1 + "/" + day1;
                date2 = year2 + "/" + month2 + "/" + day2;

                firstDate = Date.parse(date1)
                secondDate = Date.parse(date2)

                msPerDay = 24 * 60 * 60 * 1000

                dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);

                check_frmDt();
            }

        }
        function check_frmDt() {
            var value1 = document.getElementById(cont_name[0] + "txt_from").value;
            var value2 = document.getElementById(cont_name[0] + "txt_to").value;

            day1 = value1.substring(0, value1.indexOf("/"));
            month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
            year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

            day2 = value2.substring(0, value2.indexOf("/"));
            month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
            year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

            date1 = year1 + "/" + month1 + "/" + day1;
            date2 = year2 + "/" + month2 + "/" + day2;

            firstDate = Date.parse(date1)
            secondDate = Date.parse(date2)
            msPerDay = 24 * 60 * 60 * 1000

            dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
            if (dbd < 0) {
                alert("Cannot Select From Date Greater than To Date")
                document.getElementById(cont_name[0] + "txt_to").value = document.getElementById(cont_name[0] + "hdn_sysdate").value;
                return false;
            }

        }
        function btngenerate() {
            if (document.getElementById(cont_name[0] + "txt_from").value == "" || document.getElementById(cont_name[0] + "txt_to").value == "") {
                alert('Please Select From and To Date');
                return false;
            }
        }
        function init() {
            document.getElementById(cont_name[0] + "txt_from").value = document.getElementById(cont_name[0] + "hdn_sysdate1").value;
            document.getElementById(cont_name[0] + "txt_to").value = document.getElementById(cont_name[0] + "hdn_sysdate").value;
        }

        window.onload = init;
        // ]]>
</script>
    <br />
    <div style="text-align: center">
        <table border="1" style="width: 40%" align="center">
            <tr>
                <td align="center" colspan="2" valign="middle" style="font-weight: bold; font-size: 18px; color: maroon; background-color: navy; font-variant: normal; height: 24px;">
                    <span style="color: white">MARKETING ACTIVITY PO&nbsp; REPORT</span></td>
            </tr>
            <tr>
                <td align="center" style="width: 25%" valign="middle">
                    From Date</td>
                <td align="center" style="width: 25%" valign="middle">
                    <asp:TextBox ID="txt_from" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" style="width: 25%" valign="middle">
                    To Date</td>
                <td align="center" style="width: 25%" valign="middle">
                    <asp:TextBox ID="txt_to" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 25%" valign="middle">
                    <asp:Button ID="btn_generate" runat="server" Text="Confirm" Font-Bold="True" Width="75px" /></td>
                <td align="left" style="width: 25%" valign="middle">
                    <input id="btn_exit" type="button" value="Exit" style="font-weight: bold; width: 40%;" onclick="return btn_exit_onclick()" /></td>
            </tr>
        </table>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" PopupButtonID="txt_from"
            TargetControlID="txt_from">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" PopupButtonID="txt_to"
            TargetControlID="txt_to">
        </cc1:CalendarExtender>
        <asp:HiddenField ID="hdn_sysdate" runat="server" />
        <asp:HiddenField ID="hdn_sysdate1" runat="server" />
    </div>
</asp:Content>