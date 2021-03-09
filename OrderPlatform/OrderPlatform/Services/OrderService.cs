﻿using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderPlatform.Services
{
    public class OrderService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

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
            if(id != 0)
            {
                var dbrow = db.Order.Find(id);
                

                model.id = dbrow.Id;
                model.date = dbrow.date;
                model.userId = dbrow.userId;
                model.stateId = dbrow.stateId;
            }
            return model;
        }

        public void Post(OrderEditModel model)
        {
            var dbrow = new Order();
            if(model.id != 0 )
            {
                dbrow = db.Order.Find(model.id);
            }

            dbrow.date = model.date;
            dbrow.userId = model.userId;
            dbrow.stateId = model.stateId;

            if(model.id == 0)
            {
                db.Order.Add(dbrow);
            }

            db.SaveChanges();
        }
    }


}