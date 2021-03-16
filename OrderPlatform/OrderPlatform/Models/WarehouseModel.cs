using System.Collections.Generic;
using System.ComponentModel;

namespace OrderPlatform.Models
{
    public class WarehouseModel
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Location")]
        public string location { get; set; }
        public IEnumerable<WarehouseProductModel> warehouseProductList { get; set; }
    }
}