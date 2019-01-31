using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace webpageClash.Models
{
    //PROJECT FOLDER (CLASS)
    //DEAN JONES
    //APR.14, 2018
    //  project folder (to manage different projects)

    //PROJECT FOLDER (CLASS)
    //  (ONE PROJECT)
    //    READ (GET)        (done)
    //    SET               (done)
    //    CREATE (ADD)      (done)
    //    UPDATE            ??
    //    DELETE            ??
    //  (ALL PROJECTS)
    //    GET               (done)

    //PROJECT FOLDER (CLASS)
    //aspFolder
    //  "C:\Users\Pythagoras\Documents\000_work\00_Matt(ClashViewer)\cmswClashReportViewer\cmswClashReportViewer\webpageClash\"
    //AppDataFolder
    //  "...\App_Data\..."
    //clashProjectsFolder
    //  "...\XML\..."
    //clashProjectFolder
    //  "...\defaultProject\"


    public static class ProjectFolder
    {
 
        //TODO:
        //UI pagination formatting 
        //UI table (columns?)
        //UI set up menus (hide/collapse?)
        //UI settings (for files and project setup)
        //UI *** probably need a IMAGE VIEW (otherwise what's the point?) ***

        //TODO: HOW RE-ORGANIZE TO HANDLE (Dictionary for dropdownlists) properly?
        //UI: file upload (path to current project?)
        //UI: create SETTINGS PAGE 
        //UI: master page (for continuity?)
        //UI: remove IMAGE (comment out)
        //UI: visible (SETTINGS vs TABLE)
        //UI: menu (link to SETTINGS, toggles visibility)
        //UI: CREATE PROJECT (input box)(notification success or not)
        //UI: BROWSE FILES (file upload)(notification success or not)
        //UI: SETTINGS (see projects, set current, upload files?)

        //HOW IS MODEL-CONTROLLER-VIEW (organized)?
        //MODEL 
        //  CRUD 
        //  Add data (folders, files)
        //  Get data (folders, files)(this also can be Matt's (read XML))
        //  Edit data (folders(manual), files)  
        //  Delete data (folders(manual), files)
        //  Web.config(ASP)(.config)(DESKTOP APP)(file permissions, sql config, session timeout, project properties)
        //  Global.asax (session state, application state, etc)
        //CONTROLLER 
        //  how tie in UI?
        //  clash2.aspx.cs (CODE BEHIND)
        //  JavaScript (used to help view)?
        //VIEW
        //  layout html files (master file, etc)
        //  html
        //  css


        //PROPERTIES 
        private static string aspFolder;                                    //"C:\Users\Pythagoras\...\cmswClashReportViewer\cmswClashReportViewer\webpageClash\"
        private static string appDataFolder = "App_Data\\";                 //App_Data folder
        private static string clashProjects = "XML\\";                      //root folder for XML projects
        private static string currentProject = "defaultProject";            //set to default project (for testing)        
        private static string clashProjectsImages = "images\\";                //root folder for IMAGES (cannot put in App_Data, will not render images here)

        //list of (Folder) key value pairs  
        //private static Dictionary<string, string> folderNames = new Dictionary<string, string>();
        private static Dictionary<string, string> folderNames;


        //***********************************************
        //FOLDER METHODS
        //GET (ASP PROJECT) FOLDER              "C:\Users\Pythagoras\...\cmswClashReportViewer\cmswClashReportViewer\webpageClash\"
        public static string GetAspFolder()
        {
            return aspFolder = AppDomain.CurrentDomain.BaseDirectory;  //gets (asp project) folder
        }
        //GET (APP_DATA) FOLDER                 "...\App_Data\..."
        public static string GetAppDataFolder2()
        {
            return GetAspFolder() + appDataFolder;              //sets (asp) folder + concat
        }
        //GET (CLASH PROJECTS) FOLDER           "...\XML\..."
        public static string GetClashProjectsFolder()
        {
            return GetAppDataFolder2() + clashProjects;         //sets (App_Data) folder + concat
        }
        //GET (CURRENT PROJECT) FOLDER          "...\defaultProject\
        public static string GetCurrentProjectFolder()
        {
            return GetClashProjectsFolder() + currentProject;   //sets (clash projects) folder + concat
        }

        //GET (CURRENT PROJECT)(IMAGE) FOLDER          "...images\defaultProject\
        public static string GetProjectsImageFolder()
        {
            return GetAspFolder() + clashProjectsImages;        //sets IMAGES FOLDER
        }
        //GET (CURRENT PROJECT)(IMAGE) FOLDER          "...images\defaultProject\
        public static string GetCurrentProjectImageFolder()
        {
            return GetAspFolder() + clashProjectsImages + currentProject;        //sets IMAGES FOLDER
        }

        //***********************************************

        //***********************************************
        //GETTERS AND SETTERS 
        public static string GetNameAspFolder() { return aspFolder; }
        public static string GetNameAppDataFolder() { return appDataFolder; }
        public static string GetNameClashProjects() { return clashProjects; }

        //******
        //(ONE PROJECT)
        //GET (CURRENT PROJECT)
        public static string GetCurrentProject() { return currentProject; }

        //SET (CURRENT PROJECT)
        public static string SetCurrentProject(int index)
        {
            int test = index;
            currentProject = folderNames.ElementAt(index).Key;                  //get dictionary (by index)

            return currentProject;
        }

        //OLD... (use CreateNewProjectFolder)
        //CREATE (ADD) (NEW PROJECT)
        public static bool CreateNewProjectFolder2(string projectName)
        {          
            //string path = GetRootFolder() + projectName;
            //string path = GetCurrentProjectFolder();
            //xml path
            string path = GetClashProjectsFolder() + projectName;
            //image folder 
            string image_path = GetCurrentProjectImageFolder() + projectName;

            //xml
            //only create it if the path doesn't exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return true;
            }

            //return if successful
            //return Directory.Exists(path);

            //if folder (already exists)
            return false;
        }

        //CREATE (ADD) (NEW PROJECT)
        public static Valid CreateNewProjectFolder(string projectName)
        {
            Valid _isValid = new Valid();

            //string path = GetRootFolder() + projectName;
            //string path = GetCurrentProjectFolder();
            //xml path
            string path = GetClashProjectsFolder() + projectName;
            //image folder 
            string image_path = GetProjectsImageFolder() + projectName;

            //test (if folders exist)
            bool testXmlFolderExists = Directory.Exists(path);
            bool testImageFolderExists = Directory.Exists(image_path);

            //directory info
            DirectoryInfo xmlDir;
            DirectoryInfo imageDir;

            //TEST WHICH FOLDERS EXIST
            if ((testXmlFolderExists == false) && (testImageFolderExists == false))
            {
                //create both folders
                xmlDir = Directory.CreateDirectory(path);
                imageDir = Directory.CreateDirectory(image_path);

                //**********************
                //create (image subfolders)
                CreateImageSubFolders(projectName);
                //**********************

                //return message
                _isValid.Bool = true;
                _isValid.Message = "Both the xml or image folders were created successfully.";
            }
            else if ((testXmlFolderExists == false) && (testImageFolderExists == true))
            {
                //create (xml folder only)
                xmlDir = Directory.CreateDirectory(path);

                //**********************
                //create (image subfolders)
                CreateImageSubFolders(projectName);
                //**********************

                _isValid.Bool = true;
                _isValid.Message = "Only the xml folder was created.";
            }
            else if ((testXmlFolderExists == true) && (testImageFolderExists == false))
            {
                //create (image folder only)
                imageDir = Directory.CreateDirectory(image_path);

                //**********************
                //create (image subfolders)
                CreateImageSubFolders(projectName);
                //**********************

                _isValid.Bool = true;
                _isValid.Message = "Only the image folder was created.";
            }
            else if ((testXmlFolderExists == true) && (testImageFolderExists == true))
            {
                //create (no folders)

                //**********************
                //create (image subfolders)
                CreateImageSubFolders(projectName);
                //**********************

                _isValid.Bool = false;
                _isValid.Message = "Neither the xml or image folders were created, they already exist.";
            }

            //xml
            //only create it if the path doesn't exist
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //    return true;
            //}

            //images
            //only create it if the path doesn't exist
            //if (!Directory.Exists(image_path))
            //{
            //    Directory.CreateDirectory(image_path);
            //    result = true;
            //}

            //RETURN
            return _isValid;
        }   
        
        //create subfolders (images)
        private static void CreateImageSubFolders(string projectName)
        {
            //image (subfolders)
            string image_path_piping = GetProjectsImageFolder() + projectName + "\\Piping_files\\";
            string image_path_struct = GetProjectsImageFolder() + projectName + "\\Struct_files\\";
            string image_path_elect = GetProjectsImageFolder() + projectName + "\\Elect_files\\";
            string image_path_piping_elect = GetProjectsImageFolder() + projectName + "\\PipingElect_files\\";
            string image_path_piping_struct = GetProjectsImageFolder() + projectName + "\\PipingStruct_files\\";
            string image_path_struct_elect = GetProjectsImageFolder() + projectName + "\\StructElect_files\\";

            //test (image subfolders)
            bool testImageFolderPipingExists = Directory.Exists(image_path_piping);
            bool testImageFolderStructExists = Directory.Exists(image_path_struct);
            bool testImageFolderElectExists = Directory.Exists(image_path_elect);
            bool testImageFolderPipingElectExists = Directory.Exists(image_path_piping_elect);
            bool testImageFolderPipingStructExists = Directory.Exists(image_path_piping_struct);
            bool testImageFolderStructElectExists = Directory.Exists(image_path_struct_elect);

            //directory info
            DirectoryInfo imageDirPiping, imageDirStruct, imageDirElect;
            DirectoryInfo imageDirPipingElect, imageDirPipingStruct, imageDirStructElect;

            //**********
            //SUBFOLDERS
            //create subfolders (by default)
            if (testImageFolderPipingExists == false)           //if folder doesn't exist
            {
                imageDirPiping = Directory.CreateDirectory(image_path_piping);
            }
            if (testImageFolderStructExists == false)      //if folder doesn't exist
            {
                imageDirStruct = Directory.CreateDirectory(image_path_struct);
            }
            if (testImageFolderElectExists == false)       //if folder doesn't exist
            {
                imageDirElect = Directory.CreateDirectory(image_path_elect);
            }
            //***
            if (testImageFolderPipingElectExists == false)       //if folder doesn't exist
            {
                imageDirPipingElect = Directory.CreateDirectory(image_path_piping_elect);
            }
            if (testImageFolderPipingStructExists == false)       //if folder doesn't exist
            {
                imageDirPipingStruct = Directory.CreateDirectory(image_path_piping_struct);
            }
            if (testImageFolderStructElectExists == false)       //if folder doesn't exist
            {
                imageDirStructElect = Directory.CreateDirectory(image_path_struct_elect);
            }
            //**********
        }

        //UPDATE (CURRENT PROJECT)(RENAME)
        public static void UpdateProjectFolder(string newProjectName)
        {
            //TODO
        }
        //DELETE (DELETE PROJECT)
        public static void DeleteProjectFolder(string ProjectName)
        {
            //TODO
        }

        //***********************************************

        //***********************************************
        //GETTERS AND SETTERS 
        //(ALL PROJECTS)
        //GET (ALL PROJECTS)
        public static Dictionary<string, string> GetFolderNames()
        {
            //get the files (with paths) from the folder
            //List<string> list = Directory.GetDirectories(GetRootFolder()).ToList();
            List<string> list = Directory.GetDirectories(GetClashProjectsFolder()).ToList();

            //need to reset (foldername)(otherwise error for DUPLICATE KEY)
            folderNames = new Dictionary<string, string>();

            try
            {
                //add to dictionary
                foreach (string folder in list)
                {
                    string key = Path.GetFileName(folder);    //get name of folder (for dropdownlist)
                                                              //string key = Path.GetFileName(folder);    //get name of folder (for dropdownlist)
                    string value = folder;
                    folderNames.Add(key, value);              //add to dictionary
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.GetType().ToString() + ": " + ex.Message);
            }

            return folderNames;
        
        }

        //***********************************************

    }
}