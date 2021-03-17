using OrderPlatform.Models;
using OrderPlatform.Services;
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
            return RedirectToAction("Edit", new { id = warehouseService.Set(model) });
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