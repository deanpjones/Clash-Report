using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpageClash.Models
{
    public class _Case
    {
        private enum _case { Lower, Upper };
        
        public int testLower()
        {
            return (int)_case.Lower;
        }
    }
}