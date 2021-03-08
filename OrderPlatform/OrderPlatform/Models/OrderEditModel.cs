using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderPlatform.Models
{
    public class OrderEditModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
        public int stateId { get; set; }
    }
}