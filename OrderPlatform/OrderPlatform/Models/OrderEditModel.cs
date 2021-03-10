using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderPlatform.Models
{
    public class OrderEditModel
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] //this is the format that will be shown
        public DateTime date { get; set; }

        [DisplayName("User Name")]
        public int userId { get; set; }

        [DisplayName("State")]
        public int stateId { get; set; }

        public OrderEditModel()
        {
            date = DateTime.Now;
        }
    }
}