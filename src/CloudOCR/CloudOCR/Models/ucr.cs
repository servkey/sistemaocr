using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudOCR.Models
{
    public class ucr
    {
        [Key]
        public int userID { get; set; }
        public string nUsuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }

   
}