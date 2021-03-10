using OrderPlatform.Models;
using OrderPlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}