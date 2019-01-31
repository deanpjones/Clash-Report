using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace webpageClash.Models
{
    //FILE MANAGER (CLASS)
    //DEAN JONES
    //APR.16, 2018
    //  load/reload dropdownlists (project and files)
    //  upload files

    //TODO
    //  SET CURRENT PROJECT 
    //  LIST PATH 
    //  LIST FILES (HAVE DELETE TABLE?)

    public static class FileManager
    {
        //current project 
        static string currentProj = ProjectFolder.GetCurrentProject();
        //create (Files) object
        static Files f = new Files();
        //create (Valid) object (for bool, and message)
        static Valid _isValid = new Valid();
        
        //SET CURRENT PROJECT (based on dropdownlist)
        public static void SetCurrentProject(DropDownList ddlProj)
        {
            //test before (project wasn't updating in correct order)
            //string test = ProjectFolder.GetCurrentProject();

            int index = ddlProj.SelectedIndex;
            if(index != -1)
            {
                currentProj = ProjectFolder.SetCurrentProject(ddlProj.SelectedIndex);
            }

            //test after (project wasn't updating in correct order)
            //test = ProjectFolder.GetCurrentProject();
        }

        //(DIDN'T WORK)(see clash3.AddImageToGridView)
        //LOAD THUMBNAILS (build string for asp:ImageField)(gets the project path here)
        //public static string LoadGridImages()
        //{
        //    //write here (if images are loaded into correct folder)
        //    StringBuilder asp_imageField = new StringBuilder();
        //    asp_imageField.Append("<asp:ImageField");

        //    asp_imageField.Append("\n\tDataImageUrlField = \"Image\"");

        //    asp_imageField.Append("\n\tDataImageUrlFormatString = \"/images/defaultProject/{0}\"");
        //    asp_imageField.Append("\n\tControlStyle-Width = \"80\"");
        //    asp_imageField.Append("\n\tControlStyle-Height = \"50\"");

        //    asp_imageField.Append("\n\tAlternateText = \"Clash Image\"");
        //    asp_imageField.Append("\n\tHeaderText = \"Thumbnail\"");
        //    asp_imageField.Append("\n\tNullDisplayText = \"No image\"");

        //    asp_imageField.Append("\n/>");

        //    return asp_imageField.ToString();

        //    //< asp:ImageField
        //    //                 DataImageUrlField = "Image"
        //    //                DataImageUrlFormatString = "/images/defaultProject/{0}"
        //    //                ControlStyle - Width = "80"
        //    //                ControlStyle - Height = "50"

        //    //                AlternateText = "Clash Image"
        //    //                HeaderText = "Thumbnail"
        //    //                NullDisplayText = "No image"

        //    //            />



        //    //<% --COLLAPSE BUTTON-- %>
        //    //            < asp:TemplateField HeaderText = "&plusmn;" >

        //    //             < ItemTemplate >

        //    //                 <% --< img class="imgToggle" alt="+" style="cursor: pointer" src="images/plus.png" onclick="pic.toggleImage(this)"/>--%>
        //    //                <%--<button type = "button" class="imgToggle btn btn-primary circle" onclick="pic.toggleImage(this)" title="Click to enlarge.">+</button>--%>
        //    //                <%--<button type = "button" class="imgToggle btn btn-primary circle" onclick="pic.toggleImage(this)" title="Click to enlarge thumbnail."><i class="fa fa-plus-circle"></i></button>--%>
        //    //                <button type = "button" class="imgToggle btn btn-primary circle" onclick="pic.toggleImage(this)">Enlarge</button>
        //    //                <img class="imgDisplay" style="display:none" width="160" height="100" alt="Clash Image" 
        //    //                    src="\images\<% Response.Write(webpageClash.Models.ProjectFolder.GetCurrentProject()); %>">
        //    //            </ItemTemplate>
        //    //            </asp:TemplateField>


        //}

        //UI: LOAD PULLDOWNS
        public static void loadPullDowns(DropDownList ddlProj, DropDownList ddlXML, Label notify)
        {
            try
            {
                FileManager.LoadDropDownListProjName(ddlProj);      //project names (folders)
                FileManager.LoadDropDownList(ddlXML);               //*.xml files
            }
            catch (Exception ex)
            {
                //NotificationLabel.Text = "The files did not load correctly, please contact your administrator";
                notify.Text = String.Format("ERROR: " +
                    "<br />Message: {0}" +
                    "<br />Stack: {1}"
                    , ex.Message, ex.StackTrace);
            }

        }

        //UI: CREATE (ADD) FOLDER (PROJECT)
        public static void CreateProjectFolder(string projectName, Label notifyText, DropDownList ddlProj, DropDownList ddlXML)
        {
            Valid folder = ProjectFolder.CreateNewProjectFolder(projectName);

            if (folder.Bool)
            {
                //reload pulldown 
                //rehash folders 
                loadPullDowns(ddlProj, ddlXML, notifyText);
                //FileManager.LoadDropDownListProjName(ddlProj);      //project names (folders)
                //FileManager.LoadDropDownList(ddlXML);               //*.xml files

                //notifyText.Text = String.Format("Your new project folder <b>{0}</b> was created", projectName);
                notifyText.Text = folder.Message;
            }
            else
            {
                notifyText.Text = folder.Message;
            }
        }

        ////UI: CREATE (ADD) FOLDER (PROJECT)
        //public static void CreateProjectFolder(string projectName, Label notifyText, DropDownList ddlProj, DropDownList ddlXML)
        //{
        //    if (ProjectFolder.CreateNewProjectFolder(projectName))
        //    {
        //        //reload pulldown 
        //        //rehash folders 
        //        loadPullDowns(ddlProj, ddlXML, notifyText);       
        //        //FileManager.LoadDropDownListProjName(ddlProj);      //project names (folders)
        //        //FileManager.LoadDropDownList(ddlXML);               //*.xml files

        //        notifyText.Text = String.Format("Your new project folder <b>{0}</b> was created", projectName);
        //    }
        //    else
        //    {
        //        notifyText.Text = "Your folder was <b>not created</b> (it may already exist), please try again";
        //    }           
        //}

        //UI: SET CURRENT DROPDOWNLIST (PROJECT)
        public static void SetCurrentProject(DropDownList ddl, string projName)
        {
            //DropDownListProjName.Items.FindByValue("defaultProject").Selected = true;
            //< option selected = "selected" value = "C:\Users\Pythagoras\Documents\000_work\00_Matt(ClashViewer)\cmswClashReportViewer\cmswClashReportViewer\webpageClash\App_Data\XML\defaultProject" > defaultProject </ option >
            //ddl.Items.FindByText("defaultProject").Selected = true;
            ddl.Items.FindByText(projName).Selected = true;
        }

        //UI: LOAD DROPDOWNLIST (PROJECT)
        public static void LoadDropDownListProjName(DropDownList ddl)
        {
            //int selected_index = ddl.SelectedIndex;             //save value (so it doesn't reset to zero)

            ddl.DataSource = ProjectFolder.GetFolderNames();
            ddl.DataTextField = "Key";                          //maps to KEY (private Dictionary<string, string> folderNames;)
            ddl.DataValueField = "Value";                       //maps to VALUE (private Dictionary<string, string> folderNames;)
            ddl.DataBind();

            //selected index (reverts back to zero)(after reload?)
            //ddl.SelectedIndex = selected_index;                 //selected index (back to user selected)
        }

        //UI: LOAD DROPDOWNLIST (FILES)
        public static void LoadDropDownList(DropDownList ddl)
        {
            //int selected_index = ddl.SelectedIndex;             //save value (so it doesn't reset to zero)

            try
            {
                //map datasource to (list of file names)
                ddl.DataSource = f.GetFileNames();
                ddl.DataTextField = "Key";                          //maps to KEY (private Dictionary<string, string> fileNames;)
                ddl.DataValueField = "Value";                       //maps to VALUE (private Dictionary<string, string> fileNames;)
                ddl.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;                
            }


            //selected index (reverts back to zero)(after reload?)
            //ddl.SelectedIndex = selected_index;                 //selected index (back to user selected)

        }

        //RELOAD (FILES)(reloads both dropdown lists)
        public static void ReloadFiles(DropDownList ddlProj, DropDownList ddlFiles)
        {
            //update project name
            ProjectFolder.SetCurrentProject(ddlProj.SelectedIndex);     //from current index
                                                                        //update files 
            f.SetFileNames();                                           //reload (if project name changes)
            LoadDropDownList(ddlFiles);                                 //reload (dropdownlist) for (*.xml) files
            
        }

        //UI: GET PROJECT FOLDER (FROM USER)
        //public static void SetProjectFolder(string name)
        //{
        //    name = "txtBoxUserProjectFolderName.Text";
        //    //get input from input box from user
        //    //save
        //    //edit 
        //    //cancel
        //    //f.SetProjectName(name);
        //}

        //UI: UPLOAD FILES (XML OR IMAGES)
        public static Valid UploadFiles(FileUpload _fileUpLoadControl, Label lblFileUpload, string pathPutFiles)
        {
            //see (string pathPutFiles) argument
            //string path = ProjectFolder.GetCurrentProjectFolder() + "\\";      //get project folder (current)

            //string fullPath, fileName;
            string tempFile, tempPath, tempExtension;
            int fileCount = 0;
            bool validExtension;

            //file size 
            bool isFilesLimitAllowed;
            int fileSizeLimit = 0;

            if (_fileUpLoadControl.HasFile)                             //make sure there is a file selected
            {
                //fileName = _fileUpLoadControl.FileName;                   //get filename (Piping.xml)
                //fullPath = path + fileName;                               //get full path
                _isValid.Message = "The user has picked a file";

                try
                {
                    //FILE UPLOAD (MAXIMUM = 16MB)
                    //  WEB.CONFIG <httpRuntime targetFramework="4.5.2" maxRequestLength="16777216"/>
                    //_fileUpLoadControl.FileBytes
                    foreach (HttpPostedFile file in _fileUpLoadControl.PostedFiles)
                    {
                        fileSizeLimit += file.ContentLength;
                    }
                    isFilesLimitAllowed = fileSizeLimit < 16777216;

                    if (isFilesLimitAllowed)       //(limit < 16777216)
                    {
                        //save file to path
                        //TODO: validate (*.XML) file
                        //_fileUpLoadControl.SaveAs(fullPath);                      //works for (one file only)
                        foreach (HttpPostedFile file in _fileUpLoadControl.PostedFiles)
                        {
                            //gets file name (and patches it with the project folder path)(*** not the path from the upload folder ***)
                            tempFile = Path.GetFileName(file.FileName);

                            tempPath = pathPutFiles + tempFile;
                            tempExtension = Path.GetExtension(tempFile);

                            //valid (*.xml) file
                            //validExtension = tempExtension.ToLower() == ".xml";
                            if (tempExtension == ".xml")
                            {
                                validExtension = Validator.IsXmlFile(tempPath).Bool;            //using validation file
                            }
                            else if (tempExtension == ".jpg")
                            {
                                validExtension = Validator.IsImageFile(tempPath).Bool;          //using validation file
                            }
                            else
                            {
                                validExtension = false;                                         //something went wrong
                            }


                            //*****************************************************
                            //file upload
                            if (!File.Exists(tempPath) && validExtension)  //if the file doesn't already exist (and *.xml file)
                            {
                                file.SaveAs(tempPath);
                                //!!!WARNING, (use SAVEAS from FILE, not UPLOAD CONTROL)(if you do it from the CONTROL it will rename the FIRST file multiple times)
                                //_fileUpLoadControl.SaveAs(tempPath);       //save each file here...

                                //_fileUpLoadControl.SaveAs(file.FileName);       //save each file here...
                                //TODO: what if user wants to OVERWRITE FILE?

                                //tick up file count;
                                fileCount++;
                            }
                            //if (FileUploadMaps.HasFiles)
                            //{
                            //    foreach (HttpPostedFile uploadedfile in FileUploadMaps.PostedFiles)
                            //    {
                            //        var fileName = Path.GetFileName(uploadedfile.FileName);
                            //        uploadedfile.SaveAs(Server.MapPath("~/SiteImages/") + fileName);
                            //        mngUploadedMaterialMaps.InsertUploadedMaterialMaps(fileName, "", PropertyDetailsID);
                            //    }
                            //}

                            //*****************************************************

                        }
                    }

                }
                catch (HttpException e)
                {
                    //_isValid.Message = "HttpException ERROR";
                    throw e;
                }
                catch(Exception e)
                {
                    //_isValid.Message = "Exception ERROR";
                    throw e;
                }

                //message handler(picked files vs uploaded)
                if (isFilesLimitAllowed == false)
                {
                    _isValid.Bool = false;
                    _isValid.ErrorName = "NO FILES UPLOADED";
                    _isValid.Message = "The files exceeded the maximum allowed (16MB), please try uploading again in chunks.";
                }
                else if (fileCount == _fileUpLoadControl.PostedFiles.Count)                       //all files (uploaded)
                {
                    _isValid.Bool = true;
                    _isValid.ErrorName = "ALL FILES UPLOADED";
                    _isValid.Message = "The file(s) uploaded successfully";
                }
                else if (fileCount > 0 && fileCount < _fileUpLoadControl.PostedFiles.Count)  //some files (uploaded only)
                {
                    _isValid.Bool = true;
                    _isValid.ErrorName = "SOME FILES UPLOADED";
                    _isValid.Message = "Only some of the file(s) uploaded successfully";     //...possibly to not overwrite an existing file (or differenct extension)
                }
                else if (fileCount == 0)                                                     //zero files (uploaded)
                {
                    _isValid.Bool = false;
                    _isValid.ErrorName = "NO FILES UPLOADED";
                    _isValid.Message = "No files uploaded, please try again";
                }
                else
                {
                    _isValid.Bool = false;
                    _isValid.ErrorName = "ERROR: File Upload";
                    _isValid.Message = "Something went wrong with the file upload?";
                }

            }
            else
            {
                _isValid.Message = "NO FILES have been selected, please click on the <b>browse</b> button.";
            }

            lblFileUpload.Text = _isValid.Message;      //update label
            return _isValid;
        }


    }
}