using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace webpageClash.Models
{
    //FILES (CLASS)
    //DEAN JONES
    //APR.10, 2018
    //  project folder and list of (*.xml) files

    //FILES (CLASS)
    //  (ALL FILES)
    //    READ (GET)        (done)
    //    SET               (done)
    //    CREATE (ADD)      (done) (see FileManager UploadFiles METHOD)
    //    UPDATE            ??
    //    DELETE            ??

    //  (ONE FILE)
    //    CREATE (ADD)      ??
    //    GET               ??
    //    SET               ??

    //List<Files> listOfFiles
    //FILES (CLASS)
    //files
    //  "Piping.xml"
    //  "Struct.xml"
    //  "Elect.xml"


    public class Files
    {
        //PROPERTIES 
        //list of files (for each project)
        private Dictionary<string, string> fileNames;               

        //CONSTRUCTOR
        public Files()
        {
            SetFileNames();                     //set default filesnames
        }

        //GETTERS AND SETTERS 
        //**********************************
        //(ALL FILES)
        //GET (ALL FILES) LIST OF FILE NAMES
        public Dictionary<string, string> GetFileNames()
        {
            return this.fileNames;
        }
        //SET (ALL FILES) LIST OF FILE NAMES (PROJECT FOLDER)
        public void SetFileNames()
        {
            //clear dictionary (files)
            fileNames = new Dictionary<string, string>();

            //get the files (with paths) from the folder
            List<string> list = Directory.GetFiles(ProjectFolder.GetCurrentProjectFolder()).ToList();

            //add to dictionary
            foreach (string file in list)
            {
                //only add to dropdownlist (if good XML file)
                if (XmlValidator.IsXmlValid(file))
                {
                    string key = Path.GetFileName(file);    //get name of file (for dropdownlist)
                    string value = file;                    //get full path (to file)
                    this.fileNames.Add(key, value);              //add to dictionary
                }
                
            }
        }
        //**********************************

        //**********************************
        //(ONE FILE)
        //ADD (ONE FILE)
        //public void AddFile(string fileName)
        //{
        //    this.fileNames.Add(fileName, fileName);
        //}

        //**********************************
    }
}