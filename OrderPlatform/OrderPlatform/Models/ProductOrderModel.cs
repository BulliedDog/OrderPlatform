namespace OrderPlatform.Models
{
    public class ProductOrderModel
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
    }
}