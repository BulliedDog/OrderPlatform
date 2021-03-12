using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderPlatform.Models
{
    public class OrderEditModel
    {
        public IEnumerable<ProductOrderModel> orderProductList { get; set; }

        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Date")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] //this is the format that will be shown
        public DateTime date { get; set; }
        [Required]
        [DisplayName("User Name")]
        public int userId { get; set; }
        [Required]
        [DisplayName("State")]
        public int stateId { get; set; }

        public OrderEditModel()
        {
            date = DateTime.Now;
            orderProductList = new List<ProductOrderModel>();
        }

    }
}