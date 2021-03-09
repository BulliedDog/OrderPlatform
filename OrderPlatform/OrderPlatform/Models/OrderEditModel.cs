using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrderPlatform.Models
{
    public class OrderEditModel
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Date")]
        public DateTime date { get; set; }
        [DisplayName("User Name")]
        public int userId { get; set; }
        [DisplayName("State")]
        public int stateId { get; set; }
    }
}