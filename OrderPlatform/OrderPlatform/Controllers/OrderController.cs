using OrderPlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class OrderController : Controller
    {
        public OrderService service = new OrderService();
        // GET: Order
        public ActionResult Index()
        {
            return View(service.Get());
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}