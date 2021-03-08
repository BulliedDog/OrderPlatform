using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderPlatform.Services
{
    public class OrderService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<OrderIndexModel> Get()
        {
            var dbrows = db.Order.OrderBy(x => x.Id);
            foreach (var dbrow in dbrows)
            {
                yield return new OrderIndexModel()
                {
                    id = dbrow.Id,
                    username = dbrow.User.username,
                    state = dbrow.State.name,
                    date = dbrow.date.ToShortDateString(),
                };
            }
        }
    }


}