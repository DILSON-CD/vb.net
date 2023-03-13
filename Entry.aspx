<%@ Page Title="" Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeFile="Entry.aspx.vb" Inherits="Marketing_Activities_Entry" MaintainScrollPositionOnPostback="true" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <script language="javascript" type="text/javascript">
       function validation()
           //debugger;
       {

           var act = "<%=DrpActivity.ClientID%>";
           if (document.getElementById(act).value == -1 || document.getElementById(act).value == -1) {
               alert("Please select Activity Type");
               document.getElementById(act).focus();
               return false;
           }

           var mnth = "<%=TxtMnt.ClientID%>";
           if (document.getElementById(mnth).value == "" || document.getElementById(mnth).value == null) {
               alert("Please Enter Duration of Activity (Month)");
               document.getElementById(mnth).focus();
               return false;
           } 
           var day = "<%=TxtDay.ClientID%>";
           if (document.getElementById(day).value == "" || document.getElementById(day).value == null) {
               alert("Please Enter Duration of Activity (day)");
               document.getElementById(day).focus();
               return false;
           } 
           var stdte = "<%=txtstartdate.ClientID%>";
           if (document.getElementById(stdte).value == "" || document.getElementById(stdte).value == null) {
               alert("Please Select Start Date");
               document.getElementById(stdte).focus();
               return false;
           }
           var edte = "<%=txtenddate.ClientID%>";
           if (document.getElementById(edte).value == "" || document.getElementById(edte).value == null) {
               alert("Please select End Date");
               document.getElementById(edte).focus();
               return false;
           }

           var v1 = "<%=vendor_drp1.ClientID%>";
           var v1t = "<%=vendr1_nme.ClientID%>";
           if (document.getElementById(v1).value == "" || document.getElementById(v1).value == null) {
               alert("Please Enter first few alphabets of Vendor name and click view");
               document.getElementById(v1t).focus();
               return false;
           }
           if (document.getElementById(v1).value == "no data found") {
               alert("Please Enter valid vendor name");
               document.getElementById(v1t).focus();
               return false;
           }

           var amnt1 = "<%=Txt_amnt_vendr1.ClientID%>";
           if (document.getElementById(amnt1).value == "" || document.getElementById(amnt1).value == null) {
               alert("Please Enter Quotation Proposed Amount -vendor1");
               document.getElementById(amnt1).focus();
               return false;
           }
          
               var v2 = "<%=vendor_drp2.ClientID%>";
               var v2t = "<%=vendor2_name.ClientID%>";
               if (document.getElementById(v2).value == "" || document.getElementById(v2).value == null) {
                   alert("Please Enter first few alphabets of Vendor name and click view");
                   document.getElementById(v2t).focus();
                   return false;
               }
               if (document.getElementById(v2).value == "no data found") {
                   alert("Please Enter vallid vendor name");
                   document.getElementById(v2t).focus();
                   return false;
               }

               var v3 = "<%=vendor_drp3.ClientID%>";
               var v3t = "<%=vendor3_name.ClientID%>";
               if (document.getElementById(v3).value == "" || document.getElementById(v3).value == null) {
                   alert("Please Enter first few alphabets of Vendor name and click view");
                   document.getElementById(v3t).focus();
                   return false;
               }
               if (document.getElementById(v3).value == "no data found") {
                   alert("Please Enter valid vendor name");
                   document.getElementById(v3t).focus();
                   return false;
               }
           var amntv2 = "<%=Txt_amnt_vendr2.ClientID%>";
           if (document.getElementById(amntv2).value == "" || document.getElementById(amntv2).value == null) {
               alert("Please Enter Quotation Proposed Amount -vendor2 ");
               document.getElementById(amntv2).focus();
               return false;
           }


           var amntv3 = "<%=Txt_amnt_vendr3.ClientID%>";
           if (document.getElementById(amntv3).value == "" || document.getElementById(amntv3).value == null) {
               alert("Please Enter Quotation Proposed Amount -vendor3 ");
               document.getElementById(amntv3).focus();
               return false;
           }


           var fnl = "<%=vendor_drpf.ClientID%>";
           if (document.getElementById(fnl).value == "" || document.getElementById(fnl).value == null) {
               alert("Please click view");
               document.getElementById(fnl).focus();
               return false;
           }
          



           var famt = "<%=TxtFAmt.ClientID%>";
           if (document.getElementById(famt).value == "" || document.getElementById(famt).value == null) {
               alert("Please Enter Final Amount");
               document.getElementById(famt).focus();
               return false;
           }
           

           var pay = "<%=DrpPay.ClientID%>";
           if (document.getElementById(pay).value == -1 || document.getElementById(pay).value == -1) {
               alert("Please select Payment Terms");
               document.getElementById(pay).focus();
               return false;
           }
           var rks = "<%=TextRem.ClientID%>";
           if (document.getElementById(rks).value == "" || document.getElementById(rks).value == null) {
               alert("Please Enter Remarks");
               document.getElementById(rks).focus();
               return false;
           }
           var v10 = "<%=Txt_vilge_10.ClientID%>";
           if (document.getElementById(v10).value == "" || document.getElementById(v10).value == null) {
               alert("Please Enter Village with in 10 km");
               document.getElementById(v10).focus();
               return false;
           }
           var v20 = "<%=Txt_vilge_20.ClientID%>";
           if (document.getElementById(v20).value == "" || document.getElementById(v20).value == null) {
               alert("Please Enter Village 10 to 20 km");
               document.getElementById(v20).focus();
               return false;
           }
           var v30 = "<%=Txt_vilge_30.ClientID%>";
           if (document.getElementById(v30).value == "" || document.getElementById(v30).value == null) {
               alert("Please Enter Village 20 to 30 km");
               document.getElementById(v30).focus();
               return false;
           }
           var cvd = "<%=TxtCovered.ClientID%>";
           if (document.getElementById(cvd).value == "" || document.getElementById(cvd).value == null) {
               alert("Please Enter Total Num Of Branch Covered ");
               document.getElementById(cvd).focus();
               return false;
           }
           var small = "";
           var a = parseInt(document.getElementById("<%=Txt_amnt_vendr1.ClientID%>").value);
           var b = parseInt(document.getElementById("<%=Txt_amnt_vendr2.ClientID%>").value);
           var c = parseInt(document.getElementById("<%=Txt_amnt_vendr3.ClientID%>").value);
          
          
          if (a <= b && a <= c) 
               small = a;
           
           else if (b <= a && b <= c) 

               small = b;
           
           else 
               small = c;
               
           var f = parseInt(document.getElementById("<%=TxtFAmt.ClientID%>").value);
           if (f > small) {
               alert("Please choose the vendor that provides lowest Quotation amount ");
               document.getElementById("<%=TxtFAmt.ClientID%>").focus();
               return false;
           }
           var tamt = parseInt(document.getElementById("<%=txt_amnt.ClientID%>").value);
          if (f > tamt) {
              alert("Your proposal unit price more than approved limit!please check ");
              document.getElementById("<%=TxtFAmt.ClientID%>").focus();
              return false;
           }

       }

       function validation1() 
           //debugger;
       {

           var act1 = "<%=DrpActivity.ClientID%>";
           if (document.getElementById(act1).value == -1 || document.getElementById(act1).value == -1) {
               alert("Please select Activity Type");
               document.getElementById(act1).focus();   
          
               return false;

           }


           var mnth1 = "<%=TxtMnt.ClientID%>";
           if (document.getElementById(mnth1).value == "" || document.getElementById(mnth1).value == null) {
               alert("Please Enter Duration of Activity (Month)");
               document.getElementById(mnth1).focus();
          
               return false;
           }
           var day1 = "<%=TxtDay.ClientID%>";
           if (document.getElementById(day1).value == "" || document.getElementById(day1).value == null) {
               alert("Please Enter Duration of Activity (day)");
               document.getElementById(day1).focus();
           //    document.getElementById("<%=HiddenField2.ClientID%>").value = 2;
               return false;
           }

           var stdte1 = "<%=txtstartdate.ClientID%>";
           if (document.getElementById(stdte1).value == "" || document.getElementById(stdte1).value == null) {
               alert("Please Select Start Date");
               document.getElementById(stdte1).focus();
           //    document.getElementById("<%=HiddenField2.ClientID%>").value = 2;
               return false;
           }
           var edte1 = "<%=txtenddate.ClientID%>";
           if (document.getElementById(edte1).value == "" || document.getElementById(edte1).value == null) {
               alert("Please select End Date");
               document.getElementById(edte1).focus();
            //   document.getElementById("<%=HiddenField2.ClientID%>").value = 2;
               return false;
           }

           var vndr = "<%=vendor_drp1.ClientID%>";
           var vndrt = "<%=vendr1_nme.ClientID%>";
           if (document.getElementById(vndr).value == "" || document.getElementById(vndr).value == null) {
               alert("Please Enter first few alphabets of Vendor name and click view");
               document.getElementById(vndrt).focus();
             
               return false;
           }
           if (document.getElementById(vndr).value == "no data found") {
               alert("Please Enter valid vendor name");
               document.getElementById(vndrt).focus();
                return false;
            }

           var amnt11 = "<%=Txt_amnt_vendr1.ClientID%>";
           if (document.getElementById(amnt11).value == "" || document.getElementById(amnt11).value == null) {
               alert("Please  Enter Quotation Proposed Amount -vendor1");
               document.getElementById(amnt11).focus();
              // document.getElementById("<%=HiddenField2.ClientID%>").value = 2;
               return false;
           }
           

           var just = "<%=Textjust.ClientID%>";
           if (document.getElementById(just).value == "" || document.getElementById(just).value == null) {
               alert("Please Enter justification");
               document.getElementById(just).focus();
              // document.getElementById("<%=HiddenField2.ClientID%>").value = 2;
               return false;
           }

       }

       function isNumber(evt) {
           evt = (evt) ? evt : window.event;
           var charCode = (evt.which) ? evt.which : evt.keyCode;
           if (charCode > 31 && (charCode < 48 || charCode > 57)) {
               return false;
           }

       }

       function onlyAlphabets(evt) {
           var charCode = (evt.which) ? evt.which : evt.keyCode;
           if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32) || charCode == 8)
               return true;
           else
               return false;
       }


       function checkValidDate() {
           alert("TO DATE should be grerater than FROM DATE ");
       }
 
       </script>
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
     <table align="center" style="border: thick groove #009900; width: 45%; height: 753px; text-align: center; empty-cells: show; ">
        <tr>
            <td bgcolor="#FFCCCC" colspan="2" style="height: 23px; color: #000000; font-size: large;"><strong>MARKETING ACTIVITY</strong></td>
        </tr>
        <tr>
            <td style="border: thin groove #000000; color: #0000FF; width: 423px;">Zone</td>
            <td dir="rtl" align="center" style="border: thin groove #000000; width: 257px;">
                <asp:Label ID="Label_zone" runat="server" Text="Label" style="color: #000000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin groove #000000; width: 423px;">
                                <asp:Label ID="Label2" runat="server" Text="Region " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #000000; width: 257px;">
                <asp:Label ID="Labelregn" runat="server" Text="Label" style="color: #000000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin groove #000000; width: 423px;">
                                <asp:Label ID="Label3" runat="server" Text="Area " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #000000; width: 257px;">
                <asp:Label ID="Labelarea" runat="server" Text="Label" style="color: #000000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin groove #000000; width: 423px;">
                                <asp:Label ID="Label4" runat="server" Text="Branch " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #000000; width: 257px;">
                <asp:Label ID="Labelbrnch" runat="server" Text="Label" style="color: #000000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label5" runat="server" Text="Date Of Opening Of The Branch  " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                <asp:Label ID="lblopng_brnch" runat="server" Text="Label" style="color: #000000"></asp:Label>
                <strong><span>
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                    </span></strong>
            </td>
        </tr>
        <tr>
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label6" runat="server" Text="GL Business O/S As On Date  " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                <asp:Label ID="Label_gl" runat="server" Text="Label" style="color: #000000"></asp:Label>
                <asp:HiddenField ID="HiddenField3" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label7" runat="server" Text="Details of Activity Proposed  " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                    
               
                                <asp:DropDownList ID="DrpActivity" runat="server" Height="24px" Width="175px" AutoPostBack="True">
                                </asp:DropDownList>
            &nbsp;<asp:Button ID="btn_vew" runat="server" Text="View" />
&nbsp;<br />
            </td>
        </tr>
        <tr id="hr" runat="server">
            <td style="border: thin groove #333333; width: 423px; color: #0000FF;">
                                Marketing Activity Name</td>
            <td style="border: thin groove #333333; width: 257px;">
                    
               
                                <asp:TextBox ID="txt_others" runat="server" Width="210px"  MaxLength="250"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label8" runat="server" Text="Duration Of Activity " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="TxtMnt" runat="server" Font-Names="Times New Roman" 
                                    Width="66px"  Height="16px" onkeypress="return isNumber(event)"  MaxLength="10"></asp:TextBox>
                                <asp:Label ID="Label9" runat="server" Text="Months" style="color: #000000"></asp:Label>
                                <asp:TextBox ID="TxtDay" runat="server" Font-Names="Times New Roman" 
                                    Width="56px" onkeypress="return isNumber(event)" MaxLength="10"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" Text="Days" style="color: #000000"></asp:Label></td>
        </tr>
          <tr id="e" runat="server">
            <td  style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label1" runat="server" Text="Count" style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; color: #000000; width: 257px;"><asp:TextBox ID="txt_count" runat="server" Width="210px" onkeypress="return isNumber(event)" MaxLength="10" AutoPostBack="True"></asp:TextBox>
                            </td>
        </tr>
        <tr id="a" runat="server">
            <td  style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label21" runat="server" Text="Unit" style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; color: #000000; width: 257px;"><asp:TextBox ID="txt_unit" runat="server" Width="210px" onkeypress="return isNumber(event)" MaxLength="10"></asp:TextBox>
                            </td>
        </tr>
        <tr id="b" runat="server">
            <td  style="border: thin groove #333333; width: 423px; height: 30px;">
                                <asp:Label ID="Label22" runat="server" Text="Sqft" style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; height: 30px; width: 257px;"><asp:TextBox ID="txt_sqft" runat="server" Width="210px" onkeypress="return isNumber(event)"></asp:TextBox>
                            </td>
        </tr>
        <tr id="c" runat="server">
            <td  style="border: thin groove #333333; color: #0000FF; width: 423px;">Duration(Seconds)</td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="txt_sec" runat="server" Width="210px" onkeypress="return isNumber(event)"></asp:TextBox>
                            </td>
        </tr>
      
        <tr id="i" runat="server">
            <td  style="border: thin groove #333333; color: #0000FF; width: 423px;">Locality</td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:DropDownList ID="Drp_lclty" runat="server" Height="32px" Width="210px" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
        </tr>
      
        <tr id="c1" runat="server">
            <td  style="border: thin groove #333333; color: #0000FF; width: 423px;">Unit cost</td>
            <td style="border: thin groove #333333; width: 257px;">
                    
               
                <asp:TextBox ID="txt_unt_prc" runat="server" Width="210px" ReadOnly="True"></asp:TextBox>
                            </td>
        </tr>
      
        <tr id="cd" runat="server">
            <td  style="border: thin groove #333333; color: #0000FF; width: 423px;">Total Amount</td>
            <td style="border: thin groove #333333; width: 257px;">
                    
               
                                <asp:Button ID="btn_calc" runat="server" Text="Calculate Amount" Width="210px" />
                                <br />
                    
               
                                <asp:TextBox ID="txt_amnt" runat="server" Width="210px" onkeypress="return isNumber(event)" ReadOnly="True"></asp:TextBox>
                            </td>
        </tr>
      
        <tr id="c33" runat="server">
            <td  style="border: thin groove #333333; color: #0000FF; width: 423px;">Marketing activity Start date</td>
            <td style="border: thin groove #333333; width: 257px;">
                 
                     <asp:TextBox ID="txtstartdate"  BorderStyle="Groove" runat="server" Width="210px" onkeydown="return false" onpaste="return false"
                                    ondrop="return false" ></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtstartdate" TargetControlID="txtstartdate" Format="dd-MMM-yyyy">
                        </cc1:CalendarExtender>
                       </td>
        </tr>
      
        <tr id="c12" runat="server">
            <td  style="border: thin groove #333333; color: #0000FF; width: 423px; height: 36px;">Marketing activity End date</td>
            <td style="border: thin groove #333333; width: 257px; height: 36px;">
                                <asp:TextBox ID="txtenddate"  BorderStyle="Groove" runat="server" Width="210px" onkeydown="return false" onpaste="return false"
                                    ondrop="return false" OnClientDateSelectionChanged="checkValidDate" ></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtenddate" TargetControlID="txtenddate" Format="dd-MMM-yyyy">
                        </cc1:CalendarExtender>
                        </td>
        </tr>
  
        <tr id="a1" runat="server">
            <td style="border: thin groove #333333; color: #0000FF; width: 423px; height: 55px;">Vendor1</td>
            <td style="border: thin groove #333333; width: 257px; height: 55px;">
                                                   <asp:TextBox ID="vendr1_nme" runat="server" Width="156px" style="margin-left:12px;" ToolTip="Type Vendor Name to Search" Onkeypress="return onlyAlphabets(event);"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="View" />
                 <asp:DropDownList ID="vendor_drp1" runat="server" Height="24px" Width="160px" style="margin-left:-55px;" AutoPostBack="True">
                                </asp:DropDownList>       
                         <%--<asp:TextBox ID="vendr1_nme" runat="server" Width="175px" ToolTip="Type Vendor Name to Search" Onkeypress="return onlyAlphabets(event);"></asp:TextBox>--%>
                <%--<asp:DropDownList ID="vendr1_nme" runat="server" Height="32px" Width="123px" AutoPostBack="True">
                                </asp:DropDownList>--%>
              </td>
        </tr>
         

               <tr id="a2" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label12" runat="server" Text="Quotation Proposed Amount -vendor1 " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="Txt_amnt_vendr1" runat="server" Font-Names="Times New Roman" Width="210px"
                                  onkeypress="return isNumber(event)"></asp:TextBox>
            </td>
        </tr>

          <tr id ="d" runat="server">
            <td style="border: thin groove #333333; color: #0000FF; height: 27px; width: 423px;">Justification</td>
            <td style="border: thin groove #333333; height: 27px; width: 257px;">
                                <asp:TextBox ID="Textjust" runat="server" Height="28px" TextMode="MultiLine" Width="210px"
                                     Font-Names="Times New Roman" style="color: #000000;"></asp:TextBox></td>
        </tr>
             
        <tr>
            <td style="border: thin groove #333333; color: #0000FF; width: 423px;">No Multiple Vendor</td>
            <td style="border: thin groove #333333; width: 257px;">
           <asp:CheckBox ID="CheckBox1" runat="server" style="color: #000000" AutoPostBack="True"/>
                            &nbsp;
                            </td>
        </tr>
         
        <tr id="aa" runat="server">
            <td style="border: thin groove #333333; color: #0000FF; width: 423px;">Vendor2</td>
            <td style="border: thin groove #333333; width: 257px;">
                  <asp:TextBox ID="vendor2_name" runat="server" Width="156px" style="margin-left:12px;" ToolTip="Type Vendor Name to Search" Onkeypress="return onlyAlphabets(event);"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="View" />
                 <asp:DropDownList ID="vendor_drp2" runat="server" Height="24px" Width="160px" style="margin-left:-55px;" AutoPostBack="True" >
                                </asp:DropDownList>  
                                <%--<asp:TextBox ID="vendor2_name" runat="server" Width="210px" style="text-align: left" Onkeypress="return onlyAlphabets(event);" ToolTip="Type Vendor Name to Search"></asp:TextBox>--%>
                <%--<asp:DropDownList ID="vendor2_name" runat="server" Height="32px" Width="123px" AutoPostBack="True">
                                </asp:DropDownList>--%>
               </td>
        </tr>
         
        <tr id="f" runat="server">
            <td style="border: thin groove #333333; color: #0000FF; width: 423px;">Vendor3</td>
            <td style="border: thin groove #333333; width: 257px;">
                <asp:TextBox ID="vendor3_name" runat="server" Width="156px" style="margin-left:12px;" ToolTip="Type Vendor Name to Search" Onkeypress="return onlyAlphabets(event);"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="View" />
                 <asp:DropDownList ID="vendor_drp3" runat="server" Height="24px" Width="160px" style="margin-left:-55px;" AutoPostBack="True">
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="vendor3_name" runat="server" Width="210px" Onkeypress="return onlyAlphabets(event);" ToolTip="Type Vendor Name to Search"></asp:TextBox>--%>
                <%--<asp:DropDownList ID="vendor3_name" runat="server" Height="32px" Width="123px" AutoPostBack="True">
                                </asp:DropDownList>--%>
                </td>
 </tr>
      
  
        <tr id ="ab" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label23" runat="server" Text="Quotation Proposed Amount -vendor2 " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="Txt_amnt_vendr2" runat="server" Font-Names="Times New Roman" Width="210px"
                                    onkeypress="return isNumber(event)"></asp:TextBox></td>
        </tr>
        <tr id="ac" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label24" runat="server" Text="Quotation Proposed Amount -vendor3 " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="Txt_amnt_vendr3" runat="server" Font-Names="Times New Roman" Width="210px"
                                    Height="17px" onkeypress="return isNumber(event)"></asp:TextBox></td>
        </tr>
        <tr id="a3" runat="server">
            <td style="border: thin groove #333333; width: 423px; color: #0000FF;">
                                Final Vendor Name</td>
            <td style="border: thin groove #333333; width: 257px;">
          
                                  <asp:DropDownList ID="vendor_drpf" runat="server" Height="24px" Width="160px" style="margin-left:-8px;" AutoPostBack="True">

                                </asp:DropDownList>
                <asp:Button ID="Button4" runat="server" Text="View" />
                                <%--<asp:TextBox ID="Txt_fnl_vndr" runat="server" Font-Names="Times New Roman" Width="210px"
                                    Height="17px" ToolTip="Type Vendor Name to Search" Onkeypress="return onlyAlphabets(event);"></asp:TextBox>--%>
                <%--<asp:DropDownList ID="Txt_fnl_vndr" runat="server" Height="32px" Width="123px" AutoPostBack="True">
                                </asp:DropDownList>--%>
                </td>
        </tr>
         
        <tr id="a4" runat ="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label13" runat="server" Text="Final Amount After Negotiation  " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                 
                                <asp:TextBox ID="TxtFAmt" runat="server" Width="210px" Font-Names="Times New Roman" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr id="c18" runat="server">
            <td style="border: thin groove #333333; height: 32px; width: 423px;">
                                <asp:Label ID="Label14" runat="server" Text="Payment Terms " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; height: 32px; width: 257px;">
                                <asp:DropDownList ID="DrpPay" runat="server" Font-Names="Times New Roman" Width="210px">
                                    <asp:ListItem Value="-1">-------- Select --------</asp:ListItem>
                                    <asp:ListItem Value="0">Advance Payment</asp:ListItem>
                                    <asp:ListItem Value="1">Payment After Completion</asp:ListItem>
                                </asp:DropDownList></td>
        </tr>
        <tr id="c2" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label15" runat="server" Text="Any Other Remarks " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="TextRem" runat="server" Height="28px" TextMode="MultiLine" Width="210px"
                                     Font-Names="Times New Roman" style="color: #000000"></asp:TextBox></td>
        </tr>
        <tr id="no_multivendor" runat="server">
              <td style="border: thin groove #333333; color: #0000FF; width: 423px;">Vendor1 attachment</td>
         <td style="border: thin groove #333333; width: 257px; height: 55px;">
              <asp:Label ID="Lblerr1" runat="server" ForeColor="Red"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="147px"
                                    Font-Names="Times New Roman" style="margin-left: 17px" />
             </td>
        
         </tr>
      <tr id="multivendor2" runat="server">
          <td style="border: thin groove #333333; color: #0000FF; width: 423px; height: 55px;">Vendor2 attachment</td>
            <td style="border: thin groove #333333; width: 257px; height: 55px;">
                <asp:Label ID="Lblerr2" runat="server" ForeColor="Red"></asp:Label>
                <asp:FileUpload ID="FileUpload2" runat="server" Width="133px"
                                    Font-Names="Times New Roman" style="margin-left: 17px" /></td>
         </tr>
         <tr id="multivendor3" runat="server">
             <td style="border: thin groove #333333; color: #0000FF; width: 423px; height: 59px;">Vendor3 attachment</td>
            <td style="border: thin groove #333333; width: 257px; height: 59px;">
                <asp:Label ID="Lblerr3" runat="server" ForeColor="Red"></asp:Label>
                                <asp:FileUpload ID="FileUpload3" runat="server" Width="139px"  Font-Names="Times New Roman" style="margin-left: 17px" /></td>
      
         </tr>
        <tr id="aa21" runat="server">
            <td style="border: thin groove #333333; width: 423px; height: 29px;">
                                <asp:Label ID="Label17" runat="server" Text="Villages Within 10km " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; height: 29px; width: 257px;">
                                <asp:TextBox ID="Txt_vilge_10" runat="server" Width="105px"  Font-Names="Times New Roman" onkeypress="return isNumber(event)"></asp:TextBox></td>
        </tr>
        <tr id="aa23" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label18" runat="server" Text="10 – 20 km" style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="Txt_vilge_20" runat="server" Width="105px"  Font-Names="Times New Roman" onkeypress="return isNumber(event)"></asp:TextBox></td>
        </tr>
        <tr id="aa24" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label19" runat="server" Text="20 – 30 km" style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="Txt_vilge_30" runat="server" Width="105px"  Font-Names="Times New Roman" onkeypress="return isNumber(event)"></asp:TextBox></td>
        </tr>
        <tr id="aa25" runat="server">
            <td style="border: thin groove #333333; width: 423px;">
                                <asp:Label ID="Label20" runat="server" Text="Total Num Of Branch Covered  " style="color: #0000FF"></asp:Label></td>
            <td style="border: thin groove #333333; width: 257px;">
                                <asp:TextBox ID="TxtCovered" runat="server" Width="105px"  Font-Names="Times New Roman" onkeypress="return isNumber(event)"></asp:TextBox>
  <asp:HiddenField ID="hidImg" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 423px">
            <asp:Button ID="btn_ext" runat="server" style="background-color: #CCCCCC; font-weight: 700;" Text="Exit" Width="78px" Height="26px" />

            </td>
            <td id= "x1"  runat = "server" style="width: 257px">
                <asp:Button ID="Confirm" runat="server" Text="Confirm" style="background-color: #C0C0C0" Width="74px" OnClientClick="return validation();" />
            </td>
            <td id= "x2"  runat = "server" style="width: 257px">
<asp:Button ID="btn_vendr" runat="server" Height="25px" Text="Confirm" Width="60px" OnClientClick="return validation1();" /> </td>
        </tr>
    </table>
   
    <asp:HiddenField ID="hdnvendor" runat="server" />
</asp:Content>

