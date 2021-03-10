using OrderPlatform.Models;
using OrderPlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class StateController : Controller
    {
        public StateService service = new StateService();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(service.GetList());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(StateModel model)
        {
            service.Set(model);
            return RedirectToAction("Index");
        }
    }
}