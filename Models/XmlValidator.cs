using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace webpageClash.Models
{
    //XML VALIDATION
    //  DEAN JONES
    //  MAY 02, 2018

    public static class XmlValidator
    {
        //test for valid (xml file) for (dropdownlists)
        public static bool IsXmlValid(string pathToFile)
        {
            bool result = false;        //default to (false)

            try
            {
                //string pathToFile = @"C:\Users\Pythagoras\Documents\000_work\00_Matt(ClashViewer)\cmswClashReportViewer\cmswClashReportViewer\webpageClash\App_Data\Piping.xml";
                XDocument mydoc = XDocument.Load(pathToFile);
                var clashes = mydoc.Descendants("clashresults");
                var clashList = mydoc.Descendants("clashresult");

                //LINQ (test to see if any elements exist)
                bool clashesExist = clashes.Any();
                bool clashListExist = clashList.Any();

                //LINQ (count elements)
                //var clashesCount = clashes.Count();
                //var clashListCount = clashList.Count();

                //TEST (return true if good only)
                if (clashesExist && clashListExist)
                {
                    result = true;
                }
            }
            catch (System.Xml.XmlException ex1)
            {
                ErrorMessageToConsole(ex1);
                //throw ex1;
            }
            catch (Exception ex)
            {
                ErrorMessageToConsole(ex);
                //throw ex;
            }
            
            return result;
        }

        //error message (to OUTPUT (Debug) window in Visual Studio)
        private static void ErrorMessageToConsole(Exception ex)
        {
            string info = String.Format("**************************************" +
            "\n(XmlValidator.cs)" +
            "\nXML ERROR: " +
            "\nMessage: {0}" +
            "\nStack: {1}" +
            "\n**************************************",
            ex.Message, ex.StackTrace);

            System.Diagnostics.Debug.WriteLine(info);
        }

    }
}