using System.ComponentModel;

namespace OrderPlatform.Models
{
    public class ProductModel
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Price")]
        public decimal price { get; set; }
    }
}