using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace webpageClash.Models
{
    //VALIDATOR (CLASS)
    //DEAN JONES
    //APR.14, 2018
    //  dependency (Valid CLASS)
    //  this is used to validate things in controller

    public static class Validator
    {
        //create (Valid) OBJECT
        static Valid isValid = new Valid();

        //FILE EXTENSIONS (any extension)
        public static Valid IsImageFile(this string fullPath)
        {
            //test (set true or false)
            isValid.Bool = Path.GetExtension(fullPath).ToLower() == ".jpg";

            //message
            if (isValid.Bool)
            {
                isValid.Message = "The file is an (*.jpg) file";
            }
            else
            {
                isValid.ErrorName = "INVALID FILE EXTENSION";
                isValid.Message = "The file is NOT a (*.jpg) file";
            }

            return isValid;
        }

        //FILE EXTENSIONS (is *.xml)
        public static Valid IsXmlFile(this string fullPath)
        {
            //test (set true or false)
            isValid.Bool = Path.GetExtension(fullPath).ToLower() == ".xml";

            //message
            if (isValid.Bool)
            {
                isValid.Message = "The file is an (*.xml) file";
            }
            else
            {
                isValid.ErrorName = "INVALID FILE EXTENSION";
                isValid.Message = "The file is NOT an (*.xml) file";
            }

            return isValid;
        }

        //STRING IS EMPTY
        public static Valid IsEmpty(this string str)
        {
            //test (set true or false)
            isValid.Bool = str == "";

            //message (if true or false)
            if (isValid.Bool)
            {
                isValid.Message = "The string is empty";          //message if true
                isValid.ErrorName = "String Error";
            }
            else
            {
                isValid.Message = "The string is NOT empty";      //message if false
                isValid.ErrorName = "NO ERROR";
            }
            
            return isValid;
        }

        //UI for MessageBox (messagebox, alert, label)
        //public static bool TestForAlert(string input, Func<string, Valid> testFunc)
        //{
        //    //test the function
        //    isValid = testFunc(input);

        //    //push to (MessageBox)
        //    if (isValid.Bool)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        //        //response.write("<script language=""javascript"">alert('Hello!');</script>")
        //        //MessageBox.Show(tb.Tag + isValid.Message, isValid.ErrorName);
        //        //tb.Focus();     //Put FOCUS back to where ERROR happened.
        //        return false;
        //    }
        //}

        //// Validate (is a decimal)
        //public static bool IsDecimal(TextBox tb)
        //{
        //    decimal num;    // test for trying parse
        //    if (Decimal.TryParse(tb.Text, out num))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show(tb.Tag + " has to be a decimal value", "Input Error");
        //        tb.Focus();     //Put FOCUS back to where ERROR happened.
        //        return false;
        //    }
        //}

        // Validate (is string (# of characters) within range)
        //public static bool IsStringWithinRange(TextBox tb, int min, int max)
        //{
        //    int value = tb.Text.Length;
        //    if (value >= min && value <= max)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show(tb.Tag + " must be within range from " + min + ".." + max, "String (# of characters) Input Range Error");
        //        tb.Focus();
        //        return false;
        //    }
        //}

    }
}