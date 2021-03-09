using OrderPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlatform.Services
{
    public class StateService
    {
        public OrderPlatformDBEntities db = new OrderPlatformDBEntities();
        public IEnumerable<SelectListItem> GetList()
        {
            var dbrows = db.State.OrderBy(x => x.name);
            foreach(var dbrow in dbrows)
            {
                yield return new SelectListItem()
                {
                    Text = dbrow.name,
                    Value = dbrow.Id.ToString(),
                };
            }
        }
    }
}