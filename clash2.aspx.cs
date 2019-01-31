using System;
using System.Web.UI;

//add imports
using webpageClash.Models;

//CLASH REPORT PAGE2
//  DEAN JONES
//  APR.6, 2018

//DONE:
//CREATE A FOLDER (PROJECT)
//UPLOAD FILES (TO PROJECT)
//UPLOAD (control) filter for (*.xml) files only? (using ASP?)

//TODO:
//NOTIFICATION LABEL (maybe have visible only after a message, then fade-out after 10 seconds)
//UPLOAD (overwrite existing files, or delete from project folder?)
//FIX DROPDOWN TO POPULATE FILES IN PROJECT
//FIX GRID TO PATH TO (PROJECT FOLDER, FILE THAT IS PICKED)(see console project)
//UI: HOW SHOW USER SETTINGS 
//UI: CREATE FOLDER
//UI: UPLOAD FILES
//UI: LOAD DROPDOWNLIST METHOD

//UI: ALERT (OR MODAL POPUP?)
// server side, or using javascript?



namespace webpageClash
{
    public partial class clash2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             //do once only
            if (!IsPostBack)
            {
                //SET THE PROJECT (defaultProject to start)(set dropdownlist?)
                // get from SESSION or APPLICATION STATE?

                //LOAD DROPDOWNLIST(S) (COMBOBOX)
                FileManager.LoadDropDownListProjName(DropDownList2);    //project names (folders)
                FileManager.LoadDropDownList(DropDownList1);            //*.xml files

                //NOTIFICATION
                NotificationLabel.Text = "Wassup Matt";

                //**************************************
                //TESTING...
                //test set folder 
                //ProjectFolder.SetCurrentProject(1); 

                //test create folder
                //FileManager.CreateProjectFolder();

                //test create project folder 
                //ProjectFolder.CreateNewProjectFolder("test1");


                //load combobox (dropdownlist)
                //FileManager.LoadComboBox(DropDownList1);

                //default settings for page
                //FileManager.SettingsInit(txtFilePath1, txtFileName1);
                //**************************************

            }

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //upload files here
            //FileManager.UploadFiles(FileUpload1, NotificationLabel);
            //FileManager.UploadFiles(FileUpload1, NotificationLabel);
        }

        
        //TESTING...
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if(notification.Visible == false)
        //    {
        //        notification.Attributes.Add("class", "w3-panel shadow offset fadeout");          
        //        //notification.Visible = true;
        //    }
        //    else
        //    {
        //        notification.Attributes.Add("class", "w3-panel shadow offset");
        //        //notification.Attributes.Remove("visible")
        //        //notification.Visible = false;
        //    }
            
        //}

        //DROPDOWNLIST (PROJECT FOLDER) SELECTION CHANGES 
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reload files 
            FileManager.ReloadFiles(DropDownList2, DropDownList1);      //reload (files) if (project name) changes

        }

        //DROPDOWNLIST (*.XML FILES) SELECTION CHANGES
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //*** dropdownlist is connected to table dynamically ***
            //  see CONFIGURE DATA SOURCE (for setup)

        }
    }
}