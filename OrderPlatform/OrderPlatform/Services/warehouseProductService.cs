using OrderPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderPlatform.Services
{
    public class WarehouseProductService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<WarehouseProductModel> Gets(int warehouseId)
        {
            var dbrows = db.WarehouseProduct.OrderBy(x => x.warehouseId == warehouseId).OrderBy(x => x.Id);
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
    }
}