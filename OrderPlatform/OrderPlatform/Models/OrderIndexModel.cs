using System.ComponentModel;

namespace OrderPlatform.Models
{
    public class OrderIndexModel
    {
        [DisplayName("Order number")]
        public int id { get; set; }

        [DisplayName("Date")]
        public string date { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [DisplayName("State")]
        public string state { get; set; }
    }
}