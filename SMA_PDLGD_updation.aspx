<%@ Page Title="" Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeFile="SMA_PDLGD_updation.aspx.vb" Inherits="Pledge_SMA_classification_SMA_PDLGD_updation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <script language="javascript" type="text/javascript">

        function oncheck() {
            var pro = "<%=prdct_DropDownList.ClientID%>";
            if (document.getElementById(pro).value == -1 || document.getElementById(pro).value == -1) {
                alert("Please select product");
                document.getElementById(pro).focus();
                return false;
            }

            var stg = "<%=stage_DropDownList.ClientID%>";
            if (document.getElementById(stg).value == -1 || document.getElementById(stg).value == -1) {
                alert("Please select stage");
                document.getElementById(stg).focus();
                return false;
            }
            var sec = "<%=secured_DropDownList.ClientID%>";
            if (document.getElementById(sec).value == -1 || document.getElementById(sec).value == -1) {
                alert("Please select secured");
                document.getElementById(sec).focus();
                return false;
            }
            var pdval = "<%=p_d.ClientID%>";
                    if (document.getElementById(pdval).value == "" || document.getElementById(pdval).value == null) {
                        alert("Please Enter PD value");
                        document.getElementById(pdval).focus();
                        return false;
                    }
                    var lgdval = "<%=lgd.ClientID%>";
            if (document.getElementById(lgdval).value == "" || document.getElementById(lgdval).value == null) {
                alert("Please Enter LGD value");
                document.getElementById(lgdval).focus();
                return false;
            }
            var stdte = "<%=txt_fdate.ClientID%>";
            var now = new Date();
            if (document.getElementById(stdte).value < now) {
                alert("Previous Date not allowed");
                // document.getElementById(stdte).focus();
                return false;
            }

            var stdte = "<%=txt_fdate.ClientID%>";
            if (document.getElementById(stdte).value == "" || document.getElementById(stdte).value == null) {
                alert("Please Select Start Date");
                document.getElementById(stdte).focus();
                return false;
            }

            
           // var 
           // if (document.getElementById(edte).value == "" || document.getElementById(edte).value == null) {
          //      alert("Please select End Date");
          //      document.getElementById(edte).focus();
               // return false;
           // }
        }
        function checkValidDate() {
            alert("TO DATE should be grerater than FROM DATE ");
        }
        function exit() {
            window.open('./main.aspx', '_self');
        }

        //function mob_validation(evt, val1) {


        //    try {
        //        var txt = $("#" + val1).val();

        //        var l = txt.length;
        //        if (l < 10) {
        //            $("#" + val1).val("");

        //            alerts("Please enter a valid mobile number");

        //            return false;
        //        }

        //    }
        //    catch (err) {
        //        alert("5");
        //        alert(err.Description);
        //    }

        //}
        //function onlyNos(e, t) {




        //    try {
        //        if (window.event) {
        //            //To disable other button clicks
        //            if (window.event.keyCode == 13) {
        //                alert("1");
        //                e.preventDefault();

        //            }
        //            alert("2");
        //            var charCode = window.event.keyCode;

        //        }
        //        else if (e) {
        //            alert("3");
        //            var charCode = e.which;
        //        }
        //        else { return true; }
        //        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (err) {
        //        alert("4");
        //        alert(err.Description);
        //    }
        //}

        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <body >
<%--        style="background-image:url('./sma_img/sma.jpg.png');background-repeat:no-repeat;"--%>
   <form id="form1">
    <div style="margin-left:30%;">
    
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
   
        <br />
        
        <br />
<table class="auto-style6" style="background-color:burlywood"> <%--style="background-image:url('sma_img/sma2.jpg'); background-repeat:no-repeat; background-size: cover; background-position: center; width: 525px; margin-right: 14px;"--%>
    <%--<h1 style="margin-left:0px;">SMA PDLGD UPDATION</h1>--%>
    <marquee style="direction:rtl;font-weight:900;height:50px;width:50%;font-size:x-large;text-decoration-color:red;scrollbar-track-color:yellow;" >SMA PDLGD UPDATION</marquee>
            <tr>
                <td class="auto-style8" style="width: 500px;"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="width: 380px; height: 49px;">
        <asp:Label ID="product" runat="server" Text="Product" Font-Bold="True" Font-Size="Medium" ForeColor="black"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="prdct_DropDownList" runat="server" Height="34px" style="margin-left: 112px" Width="198px" AutoPostBack="True" ForeColor="black">
        </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>

     <tr>
                <td class="auto-style3" style="width: 380px; height: 49px;">
        <asp:Label ID="stage" runat="server" Text="Stage" Font-Bold="True" Font-Size="Medium" ForeColor="black"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="stage_DropDownList" runat="server" Height="34px" style="margin-left: 124px" Width="198px" AutoPostBack="True" ForeColor="black">
        </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>

     <tr>
                <td class="auto-style3" style="width: 380px">
        <asp:Label ID="secured" runat="server" Text="Secured" Font-Bold="True" Font-Size="Medium" ForeColor="black"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="secured_DropDownList" runat="server" Height="34px" style="margin-left: 105px" Width="198px" AutoPostBack="True" ForeColor="black">
        </asp:DropDownList>
                    <br />
                    <br />  
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="width: 380px"></td>
            </tr>
            <tr>
                <td class="auto-style4" style="width: 380px">
        <asp:Label ID="PD_labl" runat="server" Text="PD"  Font-Bold="True" ForeColor="black"></asp:Label>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:TextBox ID="p_d" runat="server"  MaxLength="10"  style="margin-left: 129px" Width="198px" Height="31px"  ></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
           
            <tr>
                <td class="auto-style4" style="width: 380px">
        <asp:Label ID="label_lgd" runat="server" Text="LGD" Font-Bold="True" ForeColor="black"></asp:Label>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:TextBox ID="lgd" runat="server" MaxLength="10" style="margin-left: 115px" Width="198px" Height="31px"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
           
            <tr>
                <td class="auto-style3" style="width: 380px">
                    <asp:Label ID="FROM" runat="server" Text="FROM"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="txt_fdate" runat="server" style="margin-left: 75px" Width="198px" Height="26px"></asp:TextBox>
  <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_fdate" Format="dd/MMM/yyyy"> </cc1:CalendarExtender>
                    <br />
                    <br />
              <%--      <asp:Label ID="TO" runat="server" Text="TO"></asp:Label>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="to_date" runat="server" Width="198px" Height="27px" style="margin-left: 19px; margin-bottom: 0px" ></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="to_date" Format="dd/MMM/yyyy"> </cc1:CalendarExtender>--%>

                     </td>
            </tr>
            <tr>
                <td class="auto-style3" style="width: 380px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="width: 380px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="width: 380px">&nbsp;</td>
            </tr>
   
        </table><br /><br />
         <div style="margin-left:15%;">
        <asp:Button ID="emp_confirm" runat="server" Text="confirm" Width="100px"  OnClientClick="return oncheck()" Font-Bold="True" ForeColor="black" BackColor="Green"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="button" id="Button1"  value="Exit" onclick="exit()"  style="background-color:red;width:100px;"/>
    </div>
       
         </div><br /><br /><br />
        </form>
    </body>
</asp:Content>

