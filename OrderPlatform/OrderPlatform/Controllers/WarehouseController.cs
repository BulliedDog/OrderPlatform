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
            ViewBag.productList = warehouseProductService.GetList();
            return View(warehouseService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(WarehouseModel model)
        {
            ViewBag.productList = warehouseProductService.GetList();
            return RedirectToAction("Edit", new { id = warehouseService.Set(model) });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Edit", new { id = warehouseService.Del(id) });
        }

        [HttpGet]
        public PartialViewResult newWarehouseProduct(int warehouseId)
        {
            ViewBag.productList = warehouseProductService.GetList();
            return PartialView("_WarehouseProduct", warehouseProductService.Get(warehouseId));
        }

        [HttpGet]
        public ActionResult DeleteWarehouseProduct(int warehouseProductId)
        {
            return View("Edit", new { id = warehouseProductService.Del(warehouseProductId) });
        }
    }
}