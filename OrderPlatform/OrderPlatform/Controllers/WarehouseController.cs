using OrderPlatform.Models;
using OrderPlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class WarehouseController : Controller
    {
        public WarehouseService warehouseService = new WarehouseService();

        [HttpGet]
        public ActionResult Index()
        {
            return View(warehouseService.Gets());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(warehouseService.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(WarehouseModel model)
        {
            warehouseService.Set(model);
            return RedirectToAction("Index");
        }
    }
}