using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderPlatform.Models
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool able { get; set; }
    }
}