<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clash3.aspx.cs" Inherits="webpageClash.Clash3" EnableEventValidation="false" %>

<!DOCTYPE html>

<%--
CLASH REPORT CLASH3
  DEAN JONES
  APR.20, 2018
--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crash Report</title>
    
    <!-- BOOTSTRAP -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <!-- FONT AWESOME ICONS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- STYLES -->
    <link rel="stylesheet" type="text/css" href="~/css/layout3.css?'refresh_css'" />
    <!-- JQUERY -->
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>


    <style>
        /* see layout3.css */
    </style>
    
    <script>
        //gridview (collapse)(for images)
        var pic = (function () {

            //(public) image toggle
            //***WARNING, the code below is dependant upon the (order of columns) 
            // COLUMNS ORDER (IMAGE | THUMBNAIL | +/-)
            var toggleImage = function (obj) {

                //toggle image (in gridview)  
                //get (row element of button)
                var img = obj.parentElement.nextElementSibling.firstElementChild;      //WARNING, this is dependent on image being beside the button

                //toggle size (one image)
                if (img.style.cssText == "width: 80px; height: 50px;") {
                    img.style.cssText = "width: 160px; height: 100px;"
                }
                else {
                    img.style.cssText = "width: 80px; height: 50px;"
                }
 
                //toggle (button text)
                var plus = 'Enlarge';
                var minus = 'Shrink';
                obj.innerHTML = obj.innerHTML === plus ? minus : plus;
                
            };

            return {
                toggleImage: toggleImage,
                //toggleImage2: toggleImage2,
            };
        })();
    </script>
    <script>
        //SETTINGS --> UPLOAD
        //disable upload button(or enable) 
        var btnDisable = function (obj, bool) {
            return obj[0].disabled = bool;
        }
        //btnDisable($('#UploadButtonImages'), true);

        //radio button test (rad_piping rad_struct rad_elect rad_piping_elect rad_piping_struct rad_struct_elect)
        var isRadioChecked = function () {
            return $('#rad_piping')[0].checked ||
                $('#rad_struct')[0].checked ||
                $('#rad_elect')[0].checked ||
                $('#rad_piping_elect')[0].checked ||
                $('#rad_piping_struct')[0].checked ||
                $('#rad_struct_elect')[0].checked;
        }

        //disable button (by default)
        $(document).ready(function () {   
            btnDisable($('#UploadButtonImages'), true);
        }); 
    </script>
    <script>      
        //menu buttons (to show view)
        //toggles view of all sections (rather than creating separate pages)
        var view = (function () {  
            var helper = function (_home, _settings, _upload, _newProj) {
                //sets (visibility) of each group (true/false)(.toggle changes css display:none value)
                $('#home').toggle(_home);
                $('#settings').toggle(_settings);
                $('#upload').toggle(_upload);
                $('#newProj').toggle(_newProj);
                
                //get (notification) text window element
                //var notify = document.getElementById('NotificationLabel');
                //notify.innerText = _notify;
            };
            var home = function () {
                helper(true, false, false, false);

                //update notification 
                var notify = document.getElementById('NotificationLabel');
                notify.textContent = "...";

            };
            var settings = function () {
                //helper(false, true, false);
                helper(false, true, true, true);

                //update notification 
                var notify = document.getElementById('NotificationLabel');
                notify.textContent = "You can upload (*.xml) files to current project, or create a new project below.";

                //blank textbox
                var txtProjFolder = document.getElementById('txtNewProjFolder');
                txtProjFolder.innerText = '';
            };
            var btn_upload = function () {
                helper(false, true, true, true);
            };
            var btn_uploadToggle = function () {
                //sets (visibility) of each group (true/false)(.toggle changes css display:none value)
                if ($('#uploadXml').is(':visible')) {       //if XML UPLOAD (is visible)
                    $('#uploadXml').toggle(false);
                    $('#uploadImages').toggle(true);

                    //update upload toggle button
                    //... title="Click here to upload IMAGES...">Upload Images...
                    $('#btnUploadToggle').attr("title", "Click here to upload XML...");
                    $('#btnUploadToggle')[0].innerText = "Click to Upload Xml...";
                }
                else if ($('#uploadImages').is(':visible')) {
                    $('#uploadXml').toggle(true);
                    $('#uploadImages').toggle(false);

                    //update upload toggle button
                    //... title="Click here to upload IMAGES...">Upload Images...
                    $('#btnUploadToggle').attr("title", "Click here to upload IMAGES...");
                    $('#btnUploadToggle')[0].innerText = "Click to Upload Images...";
                        
                }
            };
            var btn_new_proj = function () {
                helper(false, true, true, true);

                //blank textbox
                var txtProjFolder = document.getElementById('txtNewProjFolder');
                txtProjFolder.innerText = '';
            };
            var show_newFolderTextbox = function (){
                $('#new_project_folder').toggle();
            };
            var show_uploadXml = function () {
                $('#uploadXml').toggle();
            };
            var show_uploadImages = function () {
                $('#uploadImages').toggle();
            };

            return {         
                //menus
                home: home,
                settings: settings,
                //upload: upload,

                //buttons (settings menu)(see code behind to run)
                btn_upload: btn_upload,  
                btn_uploadToggle: btn_uploadToggle,  
                btn_new_proj: btn_new_proj,

                //expand (buttons on settings page)               
                newFolder: show_newFolderTextbox, //onclick="view.newFolder()"
                show_uploadXml: show_uploadXml,
                show_uploadImages: show_uploadImages,
            };
        })();       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page" class="page">
            
            <!-- MENU -->
            <nav id="menu" class="navbar navbar-inverse">
              <div class="container-fluid">
                <div class="navbar-header">
                  <a class="navbar-brand" href="#">Clash Report</a>
                </div>
                <ul class="nav navbar-nav">
                    <!-- ****************************************** -->
                    <%--<li class="active"><a href="#home"><i class="fa fa-home"></i>  Home</a></li>--%>
                    <li id="mnuHome" onclick="view.home()"><a href="#"><i class="fa fa-home"></i>  Home</a></li>
                    <li id="mnuSetting" onclick="view.settings()" runat="server"><a href="#"><i class="fa fa-cog"></i>  Settings</a></li>
                    <%--<li id="mnuUpload" onclick="view.upload()"><a href="#upload"><i class="fa fa-upload"></i>  Upload</a></li>--%>
                    <!-- ****************************************** -->
                </ul>
              </div>
            </nav>
            <!-- MENU (end) -->

            <!-- NOTIFICATION -->
            <div id="notification" class="panel panel-info" runat="server">
                <div class="panel-heading"><i class="fa fa-info"></i>  Info</div>
                <%--<div class="panel-body">...notification goes here...</div>--%>
                <div class="panel-body">
                    <%--Text="Please select a project to begin."--%>
                    <asp:Label id="NotificationLabel" runat="server" ></asp:Label> 
                    <%--<asp:Label id="NotificationLabel" runat="server" Text="<% Response.Write(ViewState["Notify"]); %>"></asp:Label> --%>
                </div>
            </div>
            <!-- NOTIFICATION (end) -->

            <!-- HOME -->
            <div id="home"> 
                <h3>Home</h3>    
                
                <!-- dropdownlists -->
                <div class="table">
                    <table>
                    <!-- dropdownlist (project name) -->
                    <tr id="dropdownProjName">
                        <td><asp:Label ID="lblDropDownProjName" runat="server" Text="Project:&nbsp;"></asp:Label></td>
                        <td><asp:DropDownList ID="DropDownListProjName" runat="server" OnSelectedIndexChanged="DropDownListProjName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <!-- dropdownlist (*.xml) -->
                    <tr id="dropdown">
                        <td><asp:Label ID="Label1" runat="server" Text="XML:&nbsp;"></asp:Label></td>
                        <td><asp:DropDownList ID="DropDownListXML" runat="server" OnSelectedIndexChanged="DropDownListXML_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    </table>                  
                </div>

                <!-- ********************************************************************************************************************* -->
                <!-- GridView -->
                <!-- COLUMNS: (RowID), (Clash Name), (Clash Model), (ResultStatus), (AssignedTo), (Comments) -->
                <!-- fix the visibility with (design view, Visible="false", update description on HEADERS) -->
                <!-- *********************************************************************************** -->
                <!-- *** NOTE, if the DEFAULT PATH changes, the columns will be reset, (all visible) *** -->
                <!-- *********************************************************************************** -->

                <%--<div id="grid" class="container">--%>
                <div id="grid" class="myTableFormat">
                <asp:GridView ID="gvClashResult" 
                    CssClass="table table-bordered table-hover" 
                    runat="server" 
                    DataSourceID="ClashReportingService" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    OnSorted="gvClashResult_Sorted"
                    AllowSorting="True" OnPreRender="gvClashResult_PreRender">
                    <Columns>
                        <%-- #, Clash Name, Clash Model, Result Status, Assigned To, --%>
                        <asp:BoundField DataField="RowID" HeaderText="#" ReadOnly="True" SortExpression="RowID" NullDisplayText="..." />
                        <asp:BoundField DataField="Name" HeaderText="Clash Name" SortExpression="Name" NullDisplayText="..." />
                        <asp:BoundField DataField="Models" HeaderText="Clash Model" SortExpression="Models" ReadOnly="True" NullDisplayText="..." />                      
                        <asp:BoundField DataField="ResultStatus" HeaderText="Result Status" SortExpression="ResultStatus" NullDisplayText="..." />
                        <asp:BoundField DataField="AssignedTo" HeaderText="Assigned To" SortExpression="AssignedTo" NullDisplayText="..." />
                        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" NullDisplayText="..." />
                        <asp:BoundField DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified" NullDisplayText="..." />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" NullDisplayText="..." />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" NullDisplayText="..." />
                        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" NullDisplayText="..." />
                                         
                        <%-- Response.Write(webpageClash.Models.FileManager.LoadGridImages()); --%>

                        <%-- THUMBNAIL (see clash3.AddImageToGridView)--%>
<%--                        <asp:ImageField   
                            runat="server"
                            DataImageUrlField="Image"
                            DataImageUrlFormatString="/images/defaultProject/{0}"
                            ControlStyle-Width="80"
                            ControlStyle-Height="50"                       

                            AlternateText="Clash Image" 
                            HeaderText="Thumbnail" 
                            NullDisplayText="No image"  
                            
                        />--%>

                        <%-- BUTTON (didn't work) (see code behind) --%>
<%--                        <asp:TemplateField HeaderText="Image Toggle">
                            <ItemTemplate>                  
                                <asp:Button ID="BtnImageClick" Text="Enlarge" OnClick="BtnImageClick_Click" CssClass="btn btn-default" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <%-- COLLAPSE BUTTON --%>
                        <asp:TemplateField HeaderText="Toggle">
                        <ItemTemplate>
                            <button type="button" class="imgToggle btn btn-primary" onclick="pic.toggleImage(this)">Enlarge</button>
                        </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="&plusmn;">--%>
                        <%--<ItemTemplate>--%>
                            <%--<img class="imgToggle" alt="+" style="cursor: pointer" src="images/plus.png" onclick="pic.toggleImage(this)"/>--%>
                            <%--<button type="button" class="imgToggle btn btn-primary circle" onclick="pic.toggleImage(this)" title="Click to enlarge.">+</button>--%>
                            <%--<button type="button" class="imgToggle btn btn-primary circle" onclick="pic.toggleImage(this)" title="Click to enlarge thumbnail."><i class="fa fa-plus-circle"></i></button>--%>
                            <%--<button type="button" class="imgToggle btn btn-primary" onclick="pic.toggleImage2(this)">Enlarge</button>--%>
                            <%--<img class="imgDisplay" style="display:none" width="160" height="100" alt="Clash Image" 
                                src="\images\<% Response.Write(webpageClash.Models.ProjectFolder.GetCurrentProject()); %>">--%>
                        <%--</ItemTemplate>--%>
                        <%--</asp:TemplateField>--%>
                        
                        <%--onerror="this.src='/images/404ImageNotFound.png'" width="160" height="100"--%>
                        <%-- Console.WriteLine("  Comments: {0}", clash.Comments); --%>
                        <%--    Console.WriteLine("  DateModified: {0}", clash.DateModified);
                                Console.WriteLine("  DateCreated: {0}", clash.DateCreated);
                                Console.WriteLine("  Description: {0}", clash.Description);

                                Console.WriteLine("  Image: {0}", clash.Image);
                                Console.WriteLine("  ImagePath: {0}", clash.ImagePath);     ?????????

                            <% Response.Write(webpageClash.Models.ProjectFolder.GetCurrentProjectFolder()); %>
                            DataImageUrlField="Image"
                            DataImageUrlFormatString="~/App_Data/XML/defaultProject/{0}"
                            DataImageUrlFormatString="/images/defaultProject/{0}"
                        --%>

                         <%--visible (false)--%>
                        <asp:BoundField DataField="Model01FileName" HeaderText="Model01FileName" SortExpression="Model01FileName" ReadOnly="True" Visible="false" NullDisplayText="..." />
                        <asp:BoundField DataField="Model02FileName" HeaderText="Model02FileName" SortExpression="Model02FileName" ReadOnly="True" Visible="false" NullDisplayText="..." />   
                        <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" SortExpression="ImagePath" ReadOnly="True" Visible="false" NullDisplayText="..." />
                        <asp:BoundField DataField="ActiveModel" HeaderText="ActiveModel" SortExpression="ActiveModel" Visible="false" NullDisplayText="..." />
                        <asp:BoundField DataField="GUID" HeaderText="GUID" SortExpression="GUID" Visible="false" NullDisplayText="..." /> 
                        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" Visible="false" NullDisplayText="..." />                       
                        <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" Visible="false" NullDisplayText="..." />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" Visible="false" NullDisplayText="..." />
                        <asp:CheckBoxField DataField="HasXrefs" HeaderText="HasXrefs" ReadOnly="True" SortExpression="HasXrefs" Visible="false" />
                        <asp:BoundField DataField="DateModified" HeaderText="DateModified" ReadOnly="True" SortExpression="DateModified" Visible="false" NullDisplayText="..." />

                        <%--<asp:BoundField DataField="RowID" HeaderText="#" ReadOnly="True" SortExpression="RowID" />
                        <asp:BoundField DataField="Model01FileName" HeaderText="Model01FileName" SortExpression="Model01FileName" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="Model02FileName" HeaderText="Model02FileName" ReadOnly="True" SortExpression="Model02FileName" Visible="False" />
                        <asp:BoundField DataField="Models" HeaderText="Models" ReadOnly="True" SortExpression="Models" />
                        <asp:BoundField DataField="Name" HeaderText="Clash Name" SortExpression="Name" />
                        <asp:BoundField DataField="ResultStatus" HeaderText="ResultStatus" SortExpression="ResultStatus" />
                        <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" SortExpression="ImagePath" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="ActiveModel" HeaderText="ActiveModel" SortExpression="ActiveModel" />
                        <asp:BoundField DataField="GUID" HeaderText="GUID" SortExpression="GUID" Visible="False" />
                        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" Visible="False" />
                        <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" Visible="False" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                        <asp:CheckBoxField DataField="HasXrefs" HeaderText="HasXrefs" ReadOnly="True" SortExpression="HasXrefs" Visible="False" />
                        <asp:BoundField DataField="DateModified" HeaderText="DateModified" ReadOnly="True" SortExpression="DateModified" />--%>
                        
                    </Columns>
        
                    <%-- PAGINATION --%>
                    <PagerStyle CssClass="pager" />

                    <%-- STYLES (GRIDVIEW), Dean Jones, Mar.26, 2018 --%>
                    <%--                
                    <HeaderStyle BackColor="LightGray" ForeColor="White" Font-Bold="true" />
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <SelectedRowStyle BackColor="Gray" ForeColor="White" Font-Bold="true" />
                    <FooterStyle BackColor="LightGray" ForeColor="Blue" />
                    <PagerStyle BackColor="LightGray" ForeColor="Blue" HorizontalAlign="Center" />
                    --%>

                    <%--using (gridview.css)...--%>
                    <%--<RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <PagerStyle CssClass="PagerStyle" />              
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />--%>
                
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

                <!-- data source -->
                <asp:ObjectDataSource ID="ClashReportingService" runat="server" SelectMethod="GetClashReports2" TypeName="Camansol.Camansys.CMSGlobal.ClashReports.DataModel.ClashReportingService">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownListXML" DefaultValue="C:\Users\Pythagoras\Documents\000_work\00_Matt(ClashViewer)\cmswClashReportViewer\cmswClashReportViewer\webpageClash\App_Data\XML\defaultProject\default.xml" Name="sClashReportFile" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <!-- ********************************************************************************************************************* -->
              
            </div>
            <!-- HOME (end) -->

            <!-- SETTINGS -->
            <div id="settings" style="display:none;">
            <h3>Settings</h3>
                <div class="table">
                    <table>
                    <!-- current project -->
                    <tr id="dropdownProjName2">
                        <td><asp:Label ID="Label2" runat="server" Text="Current Project:&nbsp;"></asp:Label></td>
                        <td><span class="proj" title="To change the current project, go the the 'Home' menu."><b><% Response.Write(webpageClash.Models.ProjectFolder.GetCurrentProject()); %></b></span></td>
                        <%--<td><asp:Label ID="Label3" runat="server" Text="...current project"></asp:Label></td>--%>
                    </tr>
                    </table>                  
                </div>
            </div>
            <!-- SETTINGS (end) -->

            <!-- UPLOAD -->
            <div id="upload" class="uploadFormat" style="display:none;">
            <h3>Upload Files</h3>
                <%-- button to toggle between XML upload and IMAGES upload --%>
                <button id="btnUploadToggle" 
                    type="button" 
                    class="btn btn-primary" 
                    onclick="view.btn_uploadToggle()" 
                    title="Click here to upload IMAGES...">
                    Click to Upload Images...</button>
                <div id="uploadXml">   
                    <h3>Xml</h3>
                       <%--accept=".xml, .jpg"--%><%--btn btn-file--%> 
                       <%--<asp:Label ID="lblUploadXml2" for="FileUpload1" Text="Browse..." CssClass="btn btn-default" runat="server"></asp:Label>--%>
                       <!-- FileUpload (is hidden), the <label for="..."> redirects it to the same browse files control -->                      
                        <label id="lblUploadXml" for="FileUpload1" class="btn btn-default" title="Click here to browse for (*.xml) files to upload.">Browse...</label>
                        <br />
                            <label id="file_name" style="padding-top: 6px; padding-bottom: 6px;">No XML files selected.</label>
                       <%-- see CSS (to hide this control) --%>
                       <asp:FileUpload id="FileUpload1" AllowMultiple="true" accept=".xml" CssClass="btn btn-default" style="width:50%;" runat="server">             
                       </asp:FileUpload>
                       <br />
                       <asp:Button id="UploadButton" CssClass="btn btn-default"
                           title="Click here to upload your selected (*.xml) files."
                           Text="Upload Xml"
                           OnClick="UploadButton_Click"
                           runat="server">
                       </asp:Button>   
                </div>
                <div id="uploadImages" style="display:none;">
                    <h3>Images</h3>
                        <!-- FileUpload (is hidden), the <label for="..."> redirects it to the same browse files control --> 
                        <label id="lblUploadImages" for="FileUploadImages" class="btn btn-default btn-image" title="Click here to browse for (*.jpg) files to upload.">Browse...</label>
                        <br />
                            <label id="file_name_image" style="padding-top: 6px; padding-bottom: 6px;">No image files selected.</label>
                        <%-- see CSS (to hide this control) --%>
                        <asp:FileUpload id="FileUploadImages" AllowMultiple="true" accept=".jpg" CssClass="btn btn-default" style="width:50%;" runat="server">             
                        </asp:FileUpload>
                        <br />
                        <%-- RADIO BUTTONS (Piping, Struct) --%>
                        <form id="discipline_folder">
                            <br />
                            <label>Select which (discipline) folder for the images to go into.</label>
                            <div class="radio">
                              <label><input id="rad_piping" type="radio" name="optradio" runat="server" />Piping</label>
                            </div>
                            <div class="radio">
                              <label><input id="rad_struct" type="radio" name="optradio" runat="server" />Struct</label>
                            </div>
                            <div class="radio">
                              <label><input id="rad_elect" type="radio" name="optradio" runat="server" />Elect</label>
                            </div>
                            <div class="radio">
                              <label><input id="rad_piping_elect" type="radio" name="optradio" runat="server" />PipingElect</label>
                            </div>
                            <div class="radio">
                              <label><input id="rad_piping_struct" type="radio" name="optradio" runat="server" />PipingStruct</label>
                            </div>
                            <div class="radio">
                              <label><input id="rad_struct_elect" type="radio" name="optradio" runat="server" />StructElect</label>
                            </div>
                            <br />
                        </form>
                        <%-- UPLOAD BUTTON --%>
                        <asp:Button id="UploadButtonImages" CssClass="btn btn-default btn-image"
                           title="Click here to upload your selected (*.jpg) image files."
                           Text="Upload Images"
                           OnClick="UploadButtonImages_Click"
                           runat="server">
                        </asp:Button>   
                </div>

            </div>
            <!-- UPLOAD (end) -->
            <!-- NEW FOLDER -->
            <div id="newProj" style="display:none;">
            <h3>New Project</h3>
                <div class="table">
                    <table>
                    <tr>
                        <td><button type="button" class="btn btn-primary" onclick="view.newFolder()" title="Click here to add a new project folder.">Create New Project...</button></td>
                       <%-- <td><asp:Button ID="btnNewProj" CssClass="btn btn-primary" runat="server" Text="Create New Project" onclick="view.newFolder()" /></td>--%>
                    </tr>
                    <!-- create new (add) project folder -->
                    <tr id="new_project_folder" style="display:none;">
                        <td><asp:Label ID="Label4" runat="server" Text="Create new project folder:&nbsp;"></asp:Label></td>
                        <td><asp:TextBox ID="txtNewProjFolder" runat="server" AutoPostBack="False" title="Type in a new project name here."></asp:TextBox></td> 
                        <td><asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Add" OnClick="btnNewProjFolder_Click" title="Click to add new project."/></td>
                    </tr>
                    </table>                  
                </div>
            </div>
            <!-- NEW FOLDER (end) -->

            <!-- FOOTER -->
            <%--<footer id="footer" class="text-center text-info">
                <span>Dean Jones 2018</span>
            </footer>--%>
        </div>
    </form>
    <script>
        //file upload (label event)
        //upload files (xml) (show all files selected)
        $("#FileUpload1").change(function () {
            var str = "<span style='font-weight:normal;'>";
            for (var i = 0; i < this.files.length; i++) {
                str += this.files[i].name + "<br />";           //create string of files              
            }
            //$("#file_name").text(str);                        //doesn't work on html
            str += "</span>Click upload to add xml files to this project.";
            $("#file_name").html(str);
            //$("#file_name").text(this.files[0].name);         //works on one file only
        });
        //upload files (images) (show all files selected)
        $("#FileUploadImages").change(function () {
            var str = "<span style='font-weight:normal;'>";
            for (var i = 0; i < this.files.length; i++) {
                str += this.files[i].name + "<br />";           //create string of files              
            }
            //$("#file_name").text(str);                        //doesn't work on html
            str += "</span>Click upload to add images files to this project.";
            $("#file_name_image").html(str);
            //$("#file_name").text(this.files[0].name);         //works on one file only
        });
    </script>
    <script>
        //gridview sort (add tooltips)
        $('a').attr('title', 'Click to sort this column');
    </script>
    <script>
        //enable button (if folder picked)(rad_piping rad_struct rad_elect rad_piping_elect rad_piping_struct rad_struct_elect)
        $("#rad_piping, #rad_struct, #rad_elect, #rad_piping_elect, #rad_piping_struct, #rad_struct_elect").click(function () {
            if (isRadioChecked) {
                btnDisable($('#UploadButtonImages'), false);
            }
        });
    </script>

</body>
</html>
