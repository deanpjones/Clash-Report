<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clash.aspx.cs" Inherits="webpageClash.clash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clash Report</title>

    <%--W3SCHOOLS STYLES--%>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
    <%--FONT AWESOME ICONS--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <%--STYLES--%>
    <link href="~/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <!-- Group (title, menubar, notification) -->
        <div id="group" class="w3-container shadow">
            <!-- Title -->
            <div id="title" class="w3-panel shadow offset">
                <a href="#" class="w3-bar-item w3-button"><i class="fa fa-square"></i> Clash Report</a>       
            </div>
        
            <!-- Menu Bar -->
            <div id="menubar" class="w3-panel shadow offset">
                <a href="#" class="w3-bar-item w3-button"><i class="fa fa-cog"></i> Settings</a>
                <%--<a href="#" class="w3-bar-item w3-button"><i class="fa fa-home"></i> Home</a>--%>
                <a href="#" class="w3-bar-item w3-button"><i class="fa fa-search"></i> Browse</a>
                <a href="#" class="w3-bar-item w3-button"><i class="fa fa-upload"></i> Upload</a>
            </div>

            <!-- Notification Info -->
            <div id="notificationbar" class="w3-panel shadow offset">
                <p>Notification Info...</p>
            </div>
        </div>
        
        <!-- GridView -->
        <div id="content" class="w3-container shadow stripe-4">
            <h5>Clash Results</h5>
        <asp:Label ID="lblFileUpload" runat="server" Text="Browse (*.xml)"></asp:Label>
        <asp:FileUpload ID="fileUpload" runat="server" />
        <asp:GridView ID="gvClashResult" runat="server" DataSourceID="ClashReportingService" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="RowID" HeaderText="#" ReadOnly="True" SortExpression="RowID" />
                <asp:BoundField DataField="Name" HeaderText="Clash Name" SortExpression="Name" />
                <asp:BoundField DataField="Models" HeaderText="Clash Model" ReadOnly="True" SortExpression="Models" />
                <asp:BoundField DataField="Model01FileName" HeaderText="Model#1" ReadOnly="True" SortExpression="Model01FileName" />
                <asp:BoundField DataField="Model02FileName" HeaderText="Model#2" ReadOnly="True" SortExpression="Model02FileName" />
                <asp:BoundField DataField="ResultStatus" HeaderText="ResultStatus" SortExpression="ResultStatus" />
                <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                <asp:BoundField DataField="ActiveModel" HeaderText="ActiveModel" SortExpression="ActiveModel" Visible="False" />
                <asp:BoundField DataField="GUID" HeaderText="GUID" SortExpression="GUID" Visible="False" />
                <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" Visible="False" />
                <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" Visible="False" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" Visible="False" />
                <asp:CheckBoxField DataField="HasXrefs" HeaderText="HasXrefs" ReadOnly="True" SortExpression="HasXrefs" Visible="False" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" ReadOnly="True" SortExpression="DateModified" Visible="False" />
            </Columns>
        
            <%-- STYLES (GRIDVIEW), Dean Jones, Mar.26, 2018 --%>
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
        <%--</div>--%>
        <%--DATASOURCE--%>
        <asp:ObjectDataSource ID="ClashReportingService" runat="server" SelectMethod="GetClashReports" TypeName="Camansol.Camansys.CMSGlobal.ClashReports.DataModel.ClashReportingService">
            <SelectParameters>
                <asp:Parameter DefaultValue="C:\Users\Pythagoras\Documents\000_work\00_Matt(ClashViewer)\cmswClashReportViewer\cmswClashReportViewer\webpageClash\App_Data\Piping.xml" Name="sClashReportFile" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <%--FILE UPLOAD--%>

        <%--FOOTER--%>
        <footer>Page created by: Dean Jones</footer>
    </form>
</body>
</html>
