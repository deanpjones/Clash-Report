using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpageClash.Models
{
    //VALID (CLASS)
    //DEAN JONES
    //APR.14, 2018
    //  this object is used to make the (Validator) more generic and to decouple between UI and actual validation

    public class Valid
    {
        public bool Bool { get; set; }
        public string Message { get; set; }
        public string ErrorName { get; set; }
    }
}