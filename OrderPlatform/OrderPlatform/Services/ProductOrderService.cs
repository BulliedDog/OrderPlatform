using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderPlatform.Services
{
    public class ProductOrderService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<ProductOrderModel> Gets(int orderid) ////////////////
        {
            var dbrows = db.ProductOrder.Where(x => x.orderId == orderid).OrderBy(x => x.Id);
            foreach (var dbrow in dbrows)
            {
                yield return new ProductOrderModel()
                {
                    id = dbrow.Id,
                    quantity = dbrow.quantity,
                    total_price = dbrow.total_price,
                    orderId = dbrow.orderId,
                    productId = dbrow.productId
                };
            }
        }

        public void Sets(List<ProductOrderModel> list)
        {
            foreach (var model in list)
            {
                var dbrow = new ProductOrder();
                if (model.id != 0)
                {
                    dbrow = db.ProductOrder.Find(model.id);
                }

                dbrow.quantity = model.quantity;
                dbrow.total_price = model.total_price;
                dbrow.orderId = model.orderId;
                dbrow.productId = model.productId;

                if (model.id == 0)
                {
                    db.ProductOrder.Add(dbrow);
                }
            }
        }

        public ProductOrderModel Get(int orderId)
        {
            return new ProductOrderModel()
            {
                quantity = 1,
                orderId = orderId
            };
        }

        public int Del(int id)
        {
            var dbrow = db.ProductOrder.Find(id);
            db.ProductOrder.Remove(dbrow);
            db.SaveChanges();
            return dbrow.orderId;
        }
    }
}