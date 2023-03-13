<%@ Page Language="VB" AutoEventWireup="false" CodeFile="marketing_activity_dtslct.aspx.vb" Inherits="marketing_activity_dtslct" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
   <style type="text/css">
        
        .ui-datepicker { font-size:12pt !important}
.ui-tooltip { font-size:12pt  !important}

.ui-helper-hidden {
	display: none;
}

input.ui-button::-moz-focus-inner,
button.ui-button::-moz-focus-inner {
	border: 0;
	padding: 0;
}
.ui-datepicker {
	width: 17em;
	padding: .2em .2em 0;
	display: none;
}
.ui-datepicker .ui-datepicker-header {
	position: relative;
	padding: .2em 0;
}
.ui-datepicker .ui-datepicker-prev,
.ui-datepicker .ui-datepicker-next {
	position: absolute;
	top: 2px;
	width: 1.8em;
	height: 1.8em;
}
.ui-datepicker .ui-datepicker-prev-hover,
.ui-datepicker .ui-datepicker-next-hover {
	top: 1px;
}
.ui-datepicker .ui-datepicker-prev {
	left: 2px;
}
.ui-datepicker .ui-datepicker-next {
	right: 2px;
}
.ui-datepicker .ui-datepicker-prev-hover {
	left: 1px;
}
.ui-datepicker .ui-datepicker-next-hover {
	right: 1px;
}
.ui-datepicker .ui-datepicker-prev span,
.ui-datepicker .ui-datepicker-next span {
	display: block;
	position: absolute;
	left: 50%;
	margin-left: -8px;
	top: 50%;
	margin-top: -8px;
}
.ui-datepicker .ui-datepicker-title {
	margin: 0 2.3em;
	line-height: 1.8em;
	text-align: center;
}
.ui-datepicker .ui-datepicker-title select {
	font-size: 1em;
	margin: 1px 0;
}
.ui-datepicker select.ui-datepicker-month,
.ui-datepicker select.ui-datepicker-year {
	width: 49%;
}
.ui-datepicker table {
    background-color:grey;
	width: 100%;
	font-size: .9em;
	border-collapse: collapse;
	margin: 0 0 .4em;
}
.ui-datepicker th {
	padding: .7em .3em;
	text-align: center;
	font-weight: bold;
	border: 0;
}
.ui-datepicker td {
	border: 0;
	padding: 1px;
}
.ui-datepicker td span,
.ui-datepicker td a {
	display: block;
	padding: .2em;
	text-align: right;
	text-decoration: none;
}
.ui-datepicker .ui-datepicker-buttonpane {
	background-image: none;
	margin: .7em 0 0 0;
	padding: 0 .2em;
	border-left: 0;
	border-right: 0;
	border-bottom: 0;
}
.ui-datepicker .ui-datepicker-buttonpane button {
	float: right;
	margin: .5em .2em .4em;
	cursor: pointer;
	padding: .2em .6em .3em .6em;
	width: auto;
	overflow: visible;
}
.ui-datepicker .ui-datepicker-buttonpane button.ui-datepicker-current {
	float: left;
}

/* with multiple calendars */
.ui-datepicker.ui-datepicker-multi {
	width: auto;
}
.ui-datepicker-multi .ui-datepicker-group {
	float: left;
}
.ui-datepicker-multi .ui-datepicker-group table {
	width: 95%;
	margin: 0 auto .4em;
}
.ui-datepicker-multi-2 .ui-datepicker-group {
	width: 50%;
}
.ui-datepicker-multi-3 .ui-datepicker-group {
	width: 33.3%;
}
.ui-datepicker-multi-4 .ui-datepicker-group {
	width: 25%;
}
.ui-datepicker-multi .ui-datepicker-group-last .ui-datepicker-header,
.ui-datepicker-multi .ui-datepicker-group-middle .ui-datepicker-header {
	border-left-width: 0;
}
.ui-datepicker-multi .ui-datepicker-buttonpane {
	clear: left;
}
.ui-datepicker-row-break {
	clear: both;
	width: 100%;
	font-size: 0;
}

/* RTL support */
.ui-datepicker-rtl {
	direction: rtl;
}
.ui-datepicker-rtl .ui-datepicker-prev {
	right: 2px;
	left: auto;
}
.ui-datepicker-rtl .ui-datepicker-next {
	left: 2px;
	right: auto;
}
.ui-datepicker-rtl .ui-datepicker-prev:hover {
	right: 1px;
	left: auto;
}
.ui-datepicker-rtl .ui-datepicker-next:hover {
	left: 1px;
	right: auto;
}
.ui-datepicker-rtl .ui-datepicker-buttonpane {
	clear: right;
}
.ui-datepicker-rtl .ui-datepicker-buttonpane button {
	float: left;
}
.ui-datepicker-rtl .ui-datepicker-buttonpane button.ui-datepicker-current,
.ui-datepicker-rtl .ui-datepicker-group {
	float: right;
}
.ui-datepicker-rtl .ui-datepicker-group-last .ui-datepicker-header,
.ui-datepicker-rtl .ui-datepicker-group-middle .ui-datepicker-header {
	border-right-width: 0;
	border-left-width: 1px;
}
        .auto-style2 {
            height: 30%;
            width: 67%;
        }
    </style>
 
     <link href="../../CSS/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../script/jquery-1.10.2.js" type="text/javascript" language="javascript"></script>
    <script src="../../script/jquery-ui-1.10.4.custom.min.js" type="text/javascript" language="javascript"></script>
     <script type="text/javascript">
         function Button1_onclick() {
             window.open("../../home.aspx", "_self");
         }
         function DtFocus() {
             $(function () {
                 $("#<%=Text_FromDt.ClientID%>").datepicker({
                     defaultDate: "+1w",
                     changeMonth: true,
                     changeYear: true,
                     dateFormat: 'dd/M/yy',
                     maxDate: new Date(),
                     onClose: function (selectedDate) {
                         $("#<%=Text_ToDt.ClientID%>").datepicker("option", "minDate", selectedDate);
                         $("#<%=Text_ToDt.ClientID%>").datepicker("option", "maxDate", "+12m");
                     }
                 });
                 $("#<%=Text_FromDt.ClientID%>").datepicker("option", "showAnim", "clip");

                 $("#<%=Text_ToDt.ClientID%>").datepicker({
                     defaultDate: "+1w",
                     changeMonth: true,
                     changeYear: true,
                     dateFormat: 'dd/M/yy',
                     minDate: new Date(),
                     onClose: function (selectedDate) {
                         if (document.getElementById('<%=Text_ToDt.ClientID %>').value == "") {
                             $("#<%=Text_FromDt.ClientID%>").datepicker("option", "maxDate", new Date());
                         }
                         else {
                             $("#<%=Text_FromDt.ClientID%>").datepicker("option", "maxDate", selectedDate);
                         }
                     }
                 });
                 $("#<%=Text_ToDt.ClientID%>").datepicker("option", "showAnim", "clip");
             });
         }
</script>
</head>
<body>
 <form id="form1" runat="server">
        <div style="width:100%; text-align:center;  height:100%">
          <asp:HiddenField ID="HdnUtr" runat="server" />
             <br />
            <table style="width:50%">
                <tr style="align-items:center">
                    <th style="width:20%; border-right: white 2px solid; border-top: white 2px solid; border-left: white 2px solid; color: #f00; border-bottom: white 2px solid; background-color: #ffd800 ; height: 43px;" colspan="4">
                       Marketing activity status Report</th>
                  </tr>
          <tr>
            <td align="left" style="background-color: white; text-align: center"
                valign="middle" class="auto-style2">
                From Date <asp:TextBox ID="Text_FromDt" runat="server" Width="25%" onkeydown="false" onkeypress="false" onmousedown="return DtFocus()" ></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="background-color: white; text-align: center"
                valign="middle" class="auto-style2">
                To Date<asp:TextBox ID="Text_ToDt" runat="server" Width="25%" onkeydown="false" onkeypress="false"
                    onmousedown="return DtFocus()" style="margin-left: 18px" AutoPostBack="true"></asp:TextBox></td>
        </tr>
                        <tr>
                
          <td style="background-color: #ffd800" >
              <br />
             
                 <input id="Btn_exit" style="width: 123px" type="button" value="EXIT" onclick="return Button1_onclick()" />
              <br />
           </td>
        </tr>
                
                               <asp:Panel ID="Panel1" runat="server" Height="80px" Width="800px">
        </asp:Panel>
              </table>
        
        
           
            <%--  </table>--%>
            <asp:HiddenField ID="hdnamt" runat="server" />
        </div>
    </form>
</body>
</html>