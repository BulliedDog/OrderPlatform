using OrderPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlatform.Services
{
    public class UserService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public UserModel Get(int id)
        {
            var model = new UserModel();
            var dbrow = db.User.Find(id);
            model.id = dbrow.Id;
            model.username = dbrow.username;
            model.password = dbrow.password;
            model.able = dbrow.able;
            return model;
        }

        public void Set(UserModel model)
        {
              //////////////////////////////////////////////
             //creates a new EMPTY record in the database//
            //////////////////////////////////////////////
            
            var dbrow = new User();

            //////////////////////////////////////////////
            
            if (model.id != 0)
            {
                dbrow = db.User.Find(model.id);
            }

            dbrow.username = model.username;
            dbrow.password = model.password;
            dbrow.able = model.able;

            if (model.id == 0)
            {
                db.User.Add(dbrow);
            }

            db.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetList()
        {
            var dbrows = db.User.OrderBy(x => x.username);
            foreach (var dbrow in dbrows)
            {
                yield return new SelectListItem()
                {
                    Text = dbrow.username,
                    Value = dbrow.Id.ToString(),
                };
            }
        }
    }
}