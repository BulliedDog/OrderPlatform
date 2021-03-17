using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderPlatform.Services
{
    public class WarehouseService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();
        public WarehouseProductService warehouseProductService = new WarehouseProductService();

        public IEnumerable<WarehouseModel> Gets()
        {
            var dbrows = db.Warehouse.OrderBy(x => x.Id);
            foreach (var dbrow in dbrows)
            {
                yield return new WarehouseModel()
                {
                    id = dbrow.Id,
                    name = dbrow.name,
                    location = dbrow.location,
                };
            }
        }

        public WarehouseModel Get(int id)
        {
            var model = new WarehouseModel();
            if (id != 0)
            {
                var dbrow = db.Warehouse.Find(id);
                model.id = dbrow.Id;
                model.name = dbrow.name;
                model.location = dbrow.location;
                model.warehouseProductList = warehouseProductService.Gets(model.id).ToList();
            }
            return model;
        }

        public int Set(WarehouseModel model)
        {
            var dbrow = new Warehouse();
            if (model.id != 0)
            {
                dbrow = db.Warehouse.Find(model.id);
            }
            dbrow.Id = model.id;
            dbrow.name = model.name;
            dbrow.location = model.location;
            if (model.id == 0)
            {
                db.Warehouse.Add(dbrow);
            }
            db.SaveChanges();
            warehouseProductService.Sets(model.warehouseProductList.ToList());
            db.SaveChanges();
            return dbrow.Id;
        }

        public void Del(int id)
        {
            var dbrow = db.Warehouse.Find(id);
            db.Warehouse.Remove(dbrow);
            db.SaveChanges();
        }
    }
}