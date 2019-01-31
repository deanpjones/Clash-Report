using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpageClash.Models
{
    //CLASS (USER INFO)
    //DEAN JONES
    //APR.8, 2018
    //  used to store USER info inside of SESSION object
    //  *** WARNING, created CONSTRUCTOR AND GETTER/SETTERS from RIGHTCLICK and CRASHED PROGRAM WEIRD? ***

    

    public static class _UserInfo
    {
        //PROPERTIES 
        public static int UserId { get; set; }
        public enum CurrentSessionState { NEW, EXISTING };
        private static string currentFolder = "not set";
        private static bool isSessionAlive;

        //CONSTRUCTOR 
        //public UserInfo()
        //{
        //    isSessionAlive = false;
        //    currentFolder = "not set";
        //}

        //GETTERS AND SETTERS 
        public static string CurrentFolder
        {
            get { return currentFolder; }
            set { currentFolder = value; }
        }
        public static bool IsSessionAlive
        {
            get { return isSessionAlive; }
            set
            {
                if(currentFolder == "not set")
                {
                    isSessionAlive = false;
                }
                else
                {
                    isSessionAlive = true;
                }
            }
        }
    
        //METHOD (CREATE SESSION FOLDER)
        //private string CreateSessionFolder()
        //{
            //switch (op)
            //{
            //    case CurrentSessionState.NEW:
            //        {

            //        }
            //}
        //}
        
        //METHOD (POINT TO CURRENT FOLDER)
        //private
    }
}