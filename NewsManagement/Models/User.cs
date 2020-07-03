using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsManagement.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nickname { get; set; }
        public int type { get; set; }
    }
}