using OrderPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderPlatform.Services
{
    public class OrderService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();
        public ProductOrderService productOrderService = new ProductOrderService();

        public IEnumerable<OrderIndexModel> Gets()
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

        public OrderEditModel Get(int id)
        {
            var model = new OrderEditModel();
            if (id != 0)
            {
                var dbrow = db.Order.Find(id);

                model.id = dbrow.Id;
                model.date = dbrow.date;
                model.userId = dbrow.userId;
                model.stateId = dbrow.stateId;
                model.orderProductList = productOrderService.Gets(model.id).ToList(); //This tolist() method makes it so that the IEnumerable doesn't return a null value if the db is empty//
            }
            return model;
        }

        public int Set(OrderEditModel model)
        {
            var dbrow = new Order();
            if (model.id != 0)
            {
                dbrow = db.Order.Find(model.id);
            }

            dbrow.date = model.date;
            dbrow.userId = model.userId;
            dbrow.stateId = model.stateId;

            if (model.id == 0)
            {
                db.Order.Add(dbrow);
            }

            db.SaveChanges();
            productOrderService.Sets(model.orderProductList.ToList());
            db.SaveChanges();
            return dbrow.Id;
        }

        public void del(int id)
        {
            db.Order.Remove(db.Order.Find(id));

            db.SaveChanges();
        }

        public List<decimal> GetQuantities()
        {
            var total = db.Order.Count() + db.User.Count() + db.State.Count() + db.Product.Count() + db.Warehouse.Count();
            var list = new List<decimal>()
            {
                decimal.Round(Convert.ToDecimal(db.Order.Count()) / total * 100, 2),
                decimal.Round(Convert.ToDecimal(db.User.Count()) / total * 100, 2),
                decimal.Round(Convert.ToDecimal(db.State.Count()) / total * 100, 2),
                decimal.Round(Convert.ToDecimal(db.Product.Count()) / total * 100, 2),
                decimal.Round(Convert.ToDecimal(db.Warehouse.Count()) / total * 100, 2)
            };
            return list;
        }
    }
}