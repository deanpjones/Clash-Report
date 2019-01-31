using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

//add imports 
using props = webpageClash.Properties;

//FILE MANAGER 
//  handles the browse button (decouple from the view)
//  DEAN JONES
//  APR.6, 2018

namespace webpageClash.Models
{
    public static class _FileManager
    {
        //create (Files) object
        static Files f = new Files();

        //METHOD (GET SESSION FOLDER)
        public static void GetSessionFolder()
        {
            //IF SESSION IS EXISTING
            if (_UserInfo.IsSessionAlive)
            {
                //TODO: point to correct folder
            }
            //IF SESSION IS NEW
            else
            {
                //TODO: create new folder (point to it...)
            }          
            
        }

        //METHOD (UPLOAD FILES FROM UPLOAD CONTROL)
        public static void UploadFiles(FileUpload _fileUpLoadControl, Label lblToNotify)
        {
            //get project directory
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            //add folder for sessions
            string projAppData = "App_Data\\";
            //add session folder
            string sessionFolder = "session1\\";
            //full path
            string fullPath = string.Format("{0}{1}{2}", appPath, projAppData, sessionFolder);

            //verify user has picked a file
            if (_fileUpLoadControl.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = _fileUpLoadControl.FileName;

                // Append the name of the file to upload to the path.
                fullPath += fileName;

                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                _fileUpLoadControl.SaveAs(fullPath);

                // Notify the user of the name of the file
                // was saved under.
                //UploadStatusLabel.Text = "Your file was saved as " + fileName;
                lblToNotify.Text = String.Format("Your file {0} was uploaded successfully", fileName);

                //lblTesting.Text = fullPath;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                //UploadStatusLabel.Text = "You did not specify a file to upload.";
                lblToNotify.Text = "You did not specify a file to upload.";
            }
        }

        //METHOD SET DATA
        public static void SetFileData()
        {
            //create (Files) object
            //Files f = new Files();
 //?           f.folderPath = @"~/App_Data/";              //folder path
 //?           f.fileNames.Add("_Piping.xml");             //test dropdown...
 //?           f.fileNames.Add("_Struct.xml");
 //?           f.fileNames.Add("_Elect.xml");
        }

        //METHOD LOAD COMBOBOX (DROPDOWNLIST)
        public static void LoadComboBox(DropDownList ddl)
        {
            //set file data
            SetFileData();

            //sort list
 //?           f.fileNames.Sort();

            //bind LIST to DROPDOWNLIST
 //?           ddl.DataSource = f.fileNames;
            ddl.DataBind();

            //DropDownList ddl = new DropDownList();
            //ddl.DataSource = f.fileNames;
            //ddl.DataTextField = "blah";
            //ddl.DataValueField = "asdfa";
            //ddl.DataBind();
            //DropDownList.DataSource = f.fileNames;



            //object to hold the (path, and list of files)
            //read folder, get all files (*.xml)
            //put names in the in combobox


            //GETS METHOD FROM (WEB SERVICE)
            //CategoryServiceReference.Category[] cats = my_proxy.GetCategories();  //create array (Category objects)  
            //ddlCategories.DataSource = cats;
            //ddlCategories.DataTextField = "LongName";       //Display for combobox
            //ddlCategories.DataValueField = "CategoryID";    //Value
            //ddlCategories.DataBind();                       //binds DATA to CONTROL
        }

        //DEFAULT SETTINGS FOR LABELS (File name and path)
        public static void SettingsInit(Label lblPath, Label lblName)
        {
            //create properties object (to access properties)
            props.Settings mySavedProperties = new props.Settings();
            props.Settings.Default.Save();

            //mySavedProperties.DefaultFilePath = "zzzzzzzz";
            //props.Settings.Default.DefaultFileName = "yyyyyyyyyy";
            //props.Settings.Default.DefaultFilePath = "azzzzzzzzzzzzzPath";
            //props.Settings.Default.DefaultFileName = "yyyyyyyyyyFileName";
            //mySavedProperties.Save();

            //update labels
            lblPath.Text = mySavedProperties.testFilePath2;
            lblName.Text = mySavedProperties.testFileName2;

            
            //SetFolderPath("DefaultFilePath", "zzzzzz");
        }

        public static void SetFolderPath()
        {
            //create properties object (to access properties)
            props.Settings mySavedProperties = new props.Settings();
            //props.Settings.Default.Save();
            //props.Settings.Default.Reload();
            //props.Settings.Default.Reset();
            //mySavedProperties.Properties.
        }
        //public static void SetFolderPath(String key, String value)
        //{
        //    //var config = WebConfigurationManager.OpenWebConfiguration("~");
 
        //    //Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            
        //    //config.AppSettings.Settings["DefaultFilePath"].Value = "Dean is awesome";
        //    ////config.AppSettings.Settings[key].Value = value;
        //    //config.Save();

        //}

        //?????????????????
        //GET DEFAULT PROJECT PATH 
        public static void GetDefaultPath()
        {
            //String projFolder = AppDomain.CurrentDomain.BaseDirectory;
            //return projFolder;
        }
        //?????????????????
        //SET DEFAULT PROJECT PATH 
        public static void SetProjectPath()
        {
            //create properties object (to access properties)
            //props.Settings mySavedProperties = new props.Settings();
            //mySavedProperties.DefaultFilePath = AppDomain.CurrentDomain.BaseDirectory;
        }

    //    //SETTINGS INIT (load setttings from properties to settings tab)
    //    private void SettingsInit()
    //    {
    //        //connect to settings (project, properties, settings tab)
    //        WpfApp1.Properties.Settings settings = new Settings();

    //        txtUsername.Text = settings.Username;
    //        txtPassword.Text = settings.Password;
    //    }
				//--------------
				////SETTINGS (SAVE)(update settings in (project, properties, settings))
				//private void btnSettingsSave_Click(object sender, RoutedEventArgs e)
    //    {
    //        //connect to settings (project, properties, settings tab)
    //        WpfApp1.Properties.Settings settings = new Settings();
    //        //PROPERTIES (set to APPLICATION, read-only)
    //        //PROERTIES (set to USER, read-write)

    //        //update settings (to be saved in application)
    //        settings.Username = txtUsername.Text;
    //        settings.Password = txtPassword.Text;
    //        //SAVE SETTINGS
    //        settings.Save();

    //        //messagebox 
    //        System.Windows.MessageBox.Show("Your settings have been saved.", "Settings");
    //    }
    }
}