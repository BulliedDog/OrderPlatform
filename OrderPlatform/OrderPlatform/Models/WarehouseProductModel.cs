using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrderPlatform.Models
{
    public class WarehouseProductModel
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Quantity")]
        public int quantity { get; set; }
        [DisplayName("Warehouse")]
        public int warehouseId { get; set; }
        [DisplayName("Product")]
        public int productId { get; set; }
    }
}