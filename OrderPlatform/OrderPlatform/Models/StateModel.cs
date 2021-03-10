using System.ComponentModel;

namespace OrderPlatform.Models
{
    public class StateModel
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
    }
}