using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

//imports
using webpageClash.Models;

namespace webpageClash
{

  //CLASH REPORT CLASH3 (CODE BEHIND)
  //  DEAN JONES
  //  APR.20, 2018

    public partial class Clash3 : System.Web.UI.Page
    {       
        //*****************************************************
        //PAGE LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            //set current project 
            FileManager.SetCurrentProject(DropDownListProjName);

            //add image to gridview 
            AddImageToGridView();

            //do once only
            if (!IsPostBack)
            {
                //NOTIFICATION (set default value once)
                NotificationLabel.Text = "Please choose a project...";

                //LOAD DROPDOWNLIST(S) (COMBOBOX)
                //load only on Home page?          
                FileManager.loadPullDowns(DropDownListProjName, DropDownListXML, NotificationLabel);
                //FileManager.LoadDropDownListProjName(DropDownListProjName);     //project names (folders)
                //FileManager.LoadDropDownList(DropDownListXML);                  //*.xml files               

                //set dropdownlist (to default project)
                //*** NOTE, need to run this after (FileManager.LoadDropDownListProjName) runs... ***
                FileManager.SetCurrentProject(DropDownListProjName, "defaultProject");

            }
        }
        //*****************************************************

        //*****************************************************
        //*****************************************************
        //IMAGE (GRIDVIEW)

        //test if (image directory) exists 
        private bool ImageFolderExists(string path)
        {
            return Directory.Exists(path);
        }

        //get column index (gridview image)
        private int GetColumn(string columnName)
        {
            int index = -1;

            var grid = gvClashResult.Columns;
            foreach (DataControlField column in grid)
            {
                if (column.HeaderText == columnName)
                {
                    index = grid.IndexOf(column);
                }
            }

            return index;
        }

        //test (to see if image column exists)
        private bool TestColumn(string columnName)
        {
            bool result = false;

            var grid = gvClashResult.Columns;
            foreach (DataControlField column in grid)
            {
                if(column.HeaderText == columnName)
                {
                    result = true;
                }
            }

            return result;
        }

        //ADDS IMAGE (TO GRIDVIEW)(or hides depending)
        public void AddImageToGridView()
        {
            //current project
            string currentProject = ProjectFolder.GetCurrentProject();

            //test (image folder exists)
            string imagePath = ProjectFolder.GetAspFolder() + "images\\" + currentProject;
            bool testIfImageFolderExists = ImageFolderExists(imagePath);

            //test (image column exists)
            bool testIfColumnExists = TestColumn("Thumbnail");

            //get button column (image toggle)
            //int imageBtnIndex = GetColumn("Image Toggle");
            int imageBtnIndex = GetColumn("Toggle");

            //get column index
            int columnIndex = GetColumn("Thumbnail");
            //DataControlField cntl;
            ImageField img;

            //image path "/images/defaultProject/{0}"
            string imageAttrPath = "/images/" + currentProject + "/{0}";    //the {0} binds to Image column 'Piping/cd00001.jpg' (DataImageUrlField)

            //only do this if image folder exists (user needs to upload images)
            if (testIfImageFolderExists)
            {
                if (!testIfColumnExists)
                {
                    //(add) image column field
                    //ImageField img = new ImageField();
                    img = new ImageField();
                    img.DataImageUrlField = "Image";

                    //img.DataImageUrlFormatString = "/images/defaultProject/{0}";
                    img.DataImageUrlFormatString = imageAttrPath;
                    //img.DataImageUrlFormatString = imageAttrPath;

                    img.ControlStyle.Width = 80;
                    img.ControlStyle.Height = 50;

                    img.AlternateText = "Clash Image";                   
                    img.HeaderText = "Thumbnail";

                    //img.NullDisplayText = "Image not found, please load images from the settings menu.";
                    //img.NullImageUrl = "/images/404ImageNotFound.png";
                    
                    img.Visible = true;                                             //show image 
                    gvClashResult.Columns[imageBtnIndex].Visible = true;            //show button 

                    gvClashResult.Columns.Add(img);

                }
                else
                {
                    //cntl = gvClashResult.Columns[columnIndex];
                    //ImageField img = (ImageField)gvClashResult.Columns[columnIndex];
                    img = (ImageField)gvClashResult.Columns[columnIndex];

                    //img.DataImageUrlFormatString = "/images/defaultProject/{0}";
                    img.DataImageUrlFormatString = imageAttrPath;

                    //need to push the WIDTH and HEIGHT (seems to be stripping out the attributes when dropdown changes)
                    img.ControlStyle.Width = 80;
                    img.ControlStyle.Height = 50;

                    img.Visible = true;                                             //show image 
                    gvClashResult.Columns[imageBtnIndex].Visible = true;            //show button 
                }
            }
            //do this if there are (no image folder)
            else
            {
                //(remove) any image columns from previous project
                if (testIfColumnExists)
                {
                    //(hide) image column and button
                    img = (ImageField)gvClashResult.Columns[columnIndex];

                    //need to push the WIDTH and HEIGHT (seems to be stripping out the attributes when dropdown changes)
                    img.ControlStyle.Width = 80;
                    img.ControlStyle.Height = 50;

                    img.Visible = false;                                             //hide image 
                    gvClashResult.Columns[imageBtnIndex].Visible = false;            //hide button 
                }

            }

        }

        //IMAGE (GRIDVIEW)(end)
        //*****************************************************
        //*****************************************************

        //(EVENT) DROPDOWNLIST (project folder) selection changes 
        protected void DropDownListProjName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set current project (if changes)
            //ProjectFolder.SetCurrentProject()

            //reload files 
            FileManager.ReloadFiles(DropDownListProjName, DropDownListXML);      //reload (files) if (project name) changes

            //current project
            //current XML file 
            string file = Path.GetFileName(DropDownListXML.Text);
            if (file == "")
            {
                NotificationLabel.Text = String.Format("Go to the <b>Settings</b> menu to upload files.", file);
            }
            else
            {
                //NotificationLabel.Text = String.Format("Current XML file: <b>{0}</b>", file);
                NotificationLabel.Text = String.Format("Current project: <b>{0}</b>", ProjectFolder.GetCurrentProject());
            }
            
        }

        //(EVENT) DROPDOWNLIST  (*.xml files) selection changes
        protected void DropDownListXML_SelectedIndexChanged(object sender, EventArgs e)
        {
            //*** dropdownlist is connected to table dynamically ***
            //  see CONFIGURE DATA SOURCE (for setup)

            //current XML file 
            string file = Path.GetFileName(DropDownListXML.Text);
            NotificationLabel.Text = String.Format("Current XML file: <b>{0}</b>", file);

        }

        //(EVENT) UPLOAD IMAGES (button)
        protected void UploadButtonImages_Click(object sender, EventArgs e)
        {
            string radio = "";
            //which radio button was picked
            if(rad_piping.Checked)
            {
                radio = "Piping_files\\";
            }
            else if (rad_struct.Checked)
            {
                radio = "Struct_files\\";
            }
            else if (rad_elect.Checked)
            {
                radio = "Elect_files\\";
            }
            else if (rad_piping_elect.Checked)
            {
                radio = "PipingElect_files\\";
            }
            else if (rad_piping_struct.Checked)
            {
                radio = "PipingStruct_files\\";
            }
            else if (rad_struct_elect.Checked)
            {
                radio = "StructElect_files\\";
            }

            //upload files here
            string pathPutFiles = ProjectFolder.GetCurrentProjectImageFolder() + "\\" + radio;
            FileManager.UploadFiles(FileUploadImages, NotificationLabel, pathPutFiles);

            //call javascript (for view function)(stay on settings page)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnUpload", "view.btn_upload();", true);

        }

        //(EVENT) UPLOAD XML (button)
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //upload files here
            string pathPutFiles = ProjectFolder.GetCurrentProjectFolder() + "\\";
            FileManager.UploadFiles(FileUpload1, NotificationLabel, pathPutFiles);

            //call javascript (for view function)(stay on settings page)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnUpload", "view.btn_upload();", true);
            
        }

        //(EVENT) CREATE NEW PROJECT FOLDER (button)
        protected void btnNewProjFolder_Click(object sender, EventArgs e)
        {
            string projName = txtNewProjFolder.Text;
            //FileManager.CreateProjectFolder(projName, NotificationLabel);        
            FileManager.CreateProjectFolder(projName, NotificationLabel, DropDownListProjName, DropDownListXML);

            //call javascript (for view function)(stay on settings page)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnNewProject", "view.btn_new_proj();", true);
        }

        // UPDATE (Notification Label)
        protected void UpdateNotification(string toNotify)
        {
            this.NotificationLabel.Text = toNotify;
        }

        //(EVENT) SORTED (GridView)
        protected void gvClashResult_Sorted(object sender, EventArgs e)
        {
            //<asp:GridView ID = "gvClashResult" OnSorted = "gvClashResult_Sorted" ...
            UpdateNotification("The column you selected was just sorted.");
        }


        protected void gvClashResult_PreRender(object sender, EventArgs e)
        {
            //test to see if (image path is good)(dynamically generated)
            //gvClashResult.Rows[e.Row.].DataItem
            //gvClashResult.row.Rows(0).FindControl("Image1")
        }

    }
}