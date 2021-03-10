using OrderPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderPlatform.Services
{
    public class ProductService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<ProductModel> Gets()
        {
            var dbrows = db.Product.OrderBy(x => x.Id);
            foreach(var dbrow in dbrows)
            {
                yield return new ProductModel()
                {
                    id = dbrow.Id,
                    name = dbrow.name,
                    price = dbrow.price
                };
            }
        }
    }
}