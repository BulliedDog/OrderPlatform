using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OrderPlatform.Services
{
    public class ProductService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<ProductModel> Gets()
        {
            var dbrows = db.Product.OrderBy(x => x.Id);
            foreach (var dbrow in dbrows)
            {
                yield return new ProductModel()
                {
                    id = dbrow.Id,
                    name = dbrow.name,
                    price = dbrow.price
                };
            }
        }

        public ProductModel Get(int id)
        {
            var model = new ProductModel();
            if (id != 0)
            {
                var dbrow = db.Product.Find(id);
                model.id = dbrow.Id;
                model.name = dbrow.name;
                model.price = dbrow.price;
            }
            return model;
        }

        public void Set(ProductModel model)
        {
            var dbrow = new Product();
            if (model.id != 0)
            {
                dbrow = db.Product.Find(model.id);
            }
            dbrow.name = model.name;
            dbrow.price = model.price;
            if (model.id == 0)
            {
                db.Product.Add(dbrow);
            }

            db.SaveChanges();
        }

        public void del(int id)
        {
            db.Product.Remove(db.Product.Find(id));

            db.SaveChanges();
        }

        public SelectList GetList()
        {
            var dbrows = db.Product.OrderBy(x => x.Id);
            var list = new List<SelectListItem>();
            foreach (var dbrow in dbrows)
            {
                list.Add(new SelectListItem()
                {
                    Value = dbrow.Id.ToString(),
                    Text = dbrow.name
                });
            }
            return new SelectList(list, "Value", "Text");
        }
    }
}