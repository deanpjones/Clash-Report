<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clash2.aspx.cs" Inherits="webpageClash.clash2" %>

<%--
CLASH REPORT PAGE2
  DEAN JONES
  APR.6, 2018
--%>

<%--SESSION--%>
<%
    //create UserInfo OBJECT from SESSION
    //webpageClash.Models.UserInfo user = (webpageClash.Models.UserInfo)Session["userInfo"];
    //update label
    //lblTesting.Text = user.filePath;
%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clash Report</title>

    <%--W3SCHOOLS STYLES--%>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
    <%--FONT AWESOME ICONS--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <%--STYLES--%><%--<link rel="stylesheet" type="text/css" href="~/css/styles2.css" />--%>
    <link rel="stylesheet" type="text/css" href="~/css/layout.css?'refresh_css'" />
    <link rel="stylesheet" type="text/css" href="~/css/gridview.css?'refresh_css'" />
    <%--JQUERY--%>
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
      

</head>
<body>
    <form id="form1" runat="server">
        <div id="page_layout" class="hatch_radial">

            <%--TESTING--%>
            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>

            <!-- Title -->
            <%--<div id="title">Title</div>--%>        
            <div id="title" class="w3-panel shadow offset">
                <%--<h3><b>Clash Report</b></h3>--%>
                Clash Report
                <%--<a href="#" class="w3-bar-item w3-button"><i class="fa fa-square"></i> Clash Report</a>       --%>
            </div>

            <!-- Menu Bar -->
            <%--<div id="menu">Menu</div>--%>
            <div id="menu" class="w3-panel shadow offset">
                <%--                <a href="#" class="w3-bar-item w3-button">Settings</a>
                <a href="#">Browse</a>
                <a href="#">Upload</a>--%>
                <a href="#" class="w3-bar-item w3-button"><i class="fa fa-cog"></i> Settings</a>
                <a href="#_BrowseInfo" class="w3-bar-item w3-button"><i class="fa fa-search"></i> Browse</a>
                <a href="#_UploadFile" class="w3-bar-item w3-button"><i class="fa fa-upload"></i> Upload</a>
            </div>

            <!-- Notification Info -->
            <asp:Panel ID="notification" CssClass="w3-panel shadow offset" runat="server">
                <i class="fa fa-info"></i><asp:Label id="NotificationLabel" runat="server" Text="..."></asp:Label>   
                <span id="notify_close" class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
            </asp:Panel>

            

            <!-- Notification Info -->
            <%--<div id="notification">Notification</div>--%>
            <%--<div id="notification" class="w3-panel shadow offset">
                   <i class="fa fa-info"></i><asp:Label id="NotificationLabel" runat="server" Text="..."></asp:Label>  
            </div>--%>

            <!-- ALERT POPUP -->         
<%--            <div id="popup" class="alert" style="display:none" runat="server">
              <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
              <strong>Danger!</strong> Indicates a dangerous or potentially negative action.
            </div>--%>

            <!-- DROPDOWN PROJECT NAME -->
            <div id="dropdownProjName" class="w3-panel">
                <asp:Label ID="lblDropDownProjName" runat="server" Text="Project: "></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">   
                </asp:DropDownList>

            <!-- DROPDOWN FILES (*.XML) -->
            <div id="dropdown" class="w3-panel">
                <asp:Label ID="lblDropDown" runat="server" Text="XML: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">   
                </asp:DropDownList>
              <%--  <asp:Label ID="lblSelectedXML" runat="server" Text=""><b>...selected...</b></asp:Label>--%>

                

            </div>
            <!-- LABELS FOR PROPERTY INFO -->
            <table id="_CurrentInfo">
                <tr>
                    <td><h4>Current Info</h4></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblFilePath" runat="server" Text="File Path:"></asp:Label></td>
                    <td><asp:Label ID="lblFilePathValue" runat="server" Text="_file_path"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblFileName" runat="server" Text="File Name:"></asp:Label></td>
                    <td><asp:Label ID="lblFileNameValue" runat="server" Text="_file_name"></asp:Label></td>
                </tr>
            </table>
       
            <!-- IMAGE -->
            <%--<div id="image">Image</div>--%>

            <!-- GridView -->
            <%--<div id="grid">Grid</div>--%>
            <div id="grid" class="w3-container shadow">
            <asp:GridView ID="gvClashResult" runat="server" DataSourceID="ClashReportingService" AutoGenerateColumns="False" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="RowID" HeaderText="RowID" ReadOnly="True" SortExpression="RowID" />
                    <asp:BoundField DataField="Model01FileName" HeaderText="Model01FileName" SortExpression="Model01FileName" ReadOnly="True" />
                    <asp:BoundField DataField="Model02FileName" HeaderText="Model02FileName" ReadOnly="True" SortExpression="Model02FileName" />
                    <asp:BoundField DataField="Models" HeaderText="Models" ReadOnly="True" SortExpression="Models" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="ResultStatus" HeaderText="ResultStatus" SortExpression="ResultStatus" />
                    <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" SortExpression="ImagePath" ReadOnly="True" />
                    <asp:BoundField DataField="ActiveModel" HeaderText="ActiveModel" SortExpression="ActiveModel" />
                    <asp:BoundField DataField="GUID" HeaderText="GUID" SortExpression="GUID" />
                    <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
                    <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                    <asp:CheckBoxField DataField="HasXrefs" HeaderText="HasXrefs" ReadOnly="True" SortExpression="HasXrefs" />
                    <asp:BoundField DataField="DateModified" HeaderText="DateModified" ReadOnly="True" SortExpression="DateModified" />
                </Columns>
        
                <%-- STYLES (GRIDVIEW), Dean Jones, Mar.26, 2018 --%>
                <%--                
                <HeaderStyle BackColor="LightGray" ForeColor="White" Font-Bold="true" />
                <RowStyle BackColor="White" ForeColor="Black" />
                <SelectedRowStyle BackColor="Gray" ForeColor="White" Font-Bold="true" />
                <FooterStyle BackColor="LightGray" ForeColor="Blue" />
                <PagerStyle BackColor="LightGray" ForeColor="Blue" HorizontalAlign="Center" />
                --%>

                <%--using (gridview.css)...--%>
                <RowStyle CssClass="RowStyle" />
                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                <PagerStyle CssClass="PagerStyle" />              
                <SelectedRowStyle CssClass="SelectedRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <AlternatingRowStyle CssClass="AltRowStyle" />
                
                <%-- STYLES --%>

            </asp:GridView>
            </div>
            <%-- STYLES (GRIDVIEW), Dean Jones, Mar.26, 2018 --%><%--                
                <HeaderStyle BackColor="LightGray" ForeColor="White" Font-Bold="true" />
                <RowStyle BackColor="White" ForeColor="Black" />
                <SelectedRowStyle BackColor="Gray" ForeColor="White" Font-Bold="true" />
                <FooterStyle BackColor="LightGray" ForeColor="Blue" />
                <PagerStyle BackColor="LightGray" ForeColor="Blue" HorizontalAlign="Center" />
                --%>
            <asp:ObjectDataSource ID="ClashReportingService" runat="server" SelectMethod="GetClashReports" TypeName="Camansol.Camansys.CMSGlobal.ClashReports.DataModel.ClashReportingService">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="C:\Users\Pythagoras\Documents\000_work\00_Matt(ClashViewer)\cmswClashReportViewer\cmswClashReportViewer\webpageClash\App_Data\XML\test1\Piping.xml" Name="sClashReportFile" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <!-- Footer -->
            <!--using (gridview.css)...-->
            <footer id="footer">Page created by: Dean Jones</footer>
 
        <!-- FILE UPLOAD -->
        <div id="_UploadFile">
           <h4>Select file(s) to upload:</h4>

           <asp:FileUpload id="FileUpload1" runat="server" AllowMultiple="true" accept=".xml"></asp:FileUpload>

           <br /><br />

           <asp:Button id="UploadButton" 
               Text="Upload file(s)"
               OnClick="UploadButton_Click"
               runat="server">
           </asp:Button>    

           <hr />

           <asp:Label id="UploadStatusLabel"
               runat="server">
           </asp:Label>        
        </div>
        <!-- ************************************** -->
        <asp:label runat="server" text="Label" ID="lblTesting"></asp:label><br />
        <!-- LABELS FOR PROPERTY INFO -->
        <table id="_BrowseInfo">
            <tr>
                <td><h4>BROWSE INFO</h4></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblFilePath1" runat="server" Text="File Path:"></asp:Label></td>
                <td><asp:Label ID="txtFilePath1" runat="server" Text="_xxxfile_path"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblFileName1" runat="server" Text="File Name:"></asp:Label></td>
                <td><asp:Label ID="txtFileName1" runat="server" Text="_xxxfile_name"></asp:Label></td>
            </tr>
        </table>
    
        <%--PAGE LAYOUT--%>
        </div> 
    </form>
    <script type="text/javascript"> 
        //$(document).ready(function () {     
        //    $("#notification").fadeIn("slow");
        //    $("#notify_close").click(function () {
        //        $("#notification").fadeOut("slow");
        //        return false;
        //    });
        //});
        //var prm = Sys.WebForms.PageRequestManager.getInstance();
        //prm.add_endRequest(function () {
        //    $(document).ready(function () {
        //        $("span[id$='lblStatus']").delay(3000).fadeOut(4000, function () {
        //            $(this).innerHTML("");
        //        });
        //    });
        //});
        //$(function () {
        //    $(".showDate").live('click', function () {
        //        $(".status").fadeOut("slow");
        //    });
        //});
    </script>
</body>
</html>


