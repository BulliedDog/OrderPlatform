using OrderPlatform.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OrderPlatform.Services
{
    public class StateService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();

        public IEnumerable<StateModel> Gets()
        {
            var dbrows = db.State.OrderBy(x => x.Id);
            foreach (var dbrow in dbrows)
            {
                yield return new StateModel()
                {
                    id = dbrow.Id,
                    name = dbrow.name,
                };
            }
        }

        public StateModel Get(int id)
        {
            var model = new StateModel();
            if (id != 0)
            {
                var dbrow = db.State.Find(id);
                model.id = dbrow.Id;
                model.name = dbrow.name;
            }
            return model;
        }

        public void Set(StateModel model)
        {
            var dbrow = new State();
            if (model.id != 0)
            {
                dbrow = db.State.Find();
            }
            dbrow.name = model.name;
            if (model.id == 0)
            {
                db.State.Add(dbrow);
            }
            db.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetList()
        {
            var dbrows = db.State.OrderBy(x => x.name);
            foreach (var dbrow in dbrows)
            {
                yield return new SelectListItem()
                {
                    Text = dbrow.name,
                    Value = dbrow.Id.ToString(),
                };
            }
        }

        public void del(int id)
        {
            db.State.Remove(db.State.Find(id));

            db.SaveChanges();
        }
    }
}