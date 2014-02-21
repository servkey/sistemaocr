using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudOCR.Models
{
    public class AplicationModel
    {
        
        
    }

    public class Picture
    {
        public IEnumerable<HttpPostedFile> Files { get; set; }
    }
}