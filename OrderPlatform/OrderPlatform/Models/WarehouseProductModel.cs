using System.ComponentModel;

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