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
        public WarehouseProductService warehouseProductService = new WarehouseProductService();

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
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            warehouseService.Del(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult newWarehouseProduct(int warehouseId)
        {
            return PartialView("_WarehouseProduct", warehouseProductService.Get(warehouseId));
        }
    }
}