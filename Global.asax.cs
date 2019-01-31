using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

//GLOBAL.ASAX.CS
//DEAN JONES
//APR.8, 2018
// add SESSION STATES and APPLICATION STATES

//add imports 
using webpageClash.Models;

namespace webpageClash
{
    public class Global : System.Web.HttpApplication
    {
        
        //SESSION STATE
        protected void Session_Start(object sender, EventArgs e)
        {
            
        }
        protected void Session_End(object sender, EventArgs e)
        {
            
        }

        //APPLICATION STATE
        protected void Application_Start(object sender, EventArgs e)
        {
          
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}