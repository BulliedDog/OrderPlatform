using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OrderPlatform.Services
{
    public class WarehouseProductService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<WarehouseProductModel> Gets(int warehouseId)
        {
            var dbrows = db.WarehouseProduct.Where(x => x.warehouseId == warehouseId).OrderBy(x => x.Id);
            foreach (var dbrow in dbrows)
            {
                yield return new WarehouseProductModel()
                {
                    id = dbrow.Id,
                    quantity = dbrow.quantity,
                    warehouseId = dbrow.warehouseId,
                    productId = dbrow.productId
                };
            }
        }

        public WarehouseProductModel Get(int warehouseId)
        {
            return new WarehouseProductModel()
            {
                quantity = 1,
                warehouseId = warehouseId
            };
        }

        public void Sets(List<WarehouseProductModel> list)
        {
            foreach (var model in list)
            {
                var dbrow = new WarehouseProduct();
                if (model.id != 0)
                {
                    dbrow = db.WarehouseProduct.Find(model.id);
                }

                dbrow.quantity = model.quantity;
                dbrow.warehouseId = model.warehouseId;
                dbrow.productId = model.productId;

                if (model.id == 0)
                {
                    db.WarehouseProduct.Add(dbrow);
                }
                db.SaveChanges();
            }
        }

        public SelectList GetList()
        {
            var dbrows = db.Product.OrderBy(x => x.Id);
            var list = new List<SelectListItem>();
            foreach(var dbrow in dbrows)
            {
                list.Add(new SelectListItem()
                {
                    Value = dbrow.Id.ToString(),
                    Text = dbrow.name
                });
            }
            return new SelectList(list, "Value", "Text");
        }

        public int Del(int id)
        {
            db.WarehouseProduct.Remove(db.WarehouseProduct.Find(id));
            db.SaveChanges();
            return id;
        }
    }
}