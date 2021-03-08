using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrderPlatform.Models
{
    public class OrderIndexModel
    {
        [DisplayName("Numero ordine")]
        public int id { get; set; }
        public string date { get; set; }
        public string username { get; set; }
        public string state { get; set; }
    }
}