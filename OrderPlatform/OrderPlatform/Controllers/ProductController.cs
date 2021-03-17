using OrderPlatform.Models;
using OrderPlatform.Services;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class ProductController : Controller
    {
        public ProductService service = new ProductService();

        [HttpGet]
        public ActionResult Index()
        {
            return View(service.Gets());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            service.Set(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            service.del(id);
            return RedirectToAction("Index");
        }
    }
}