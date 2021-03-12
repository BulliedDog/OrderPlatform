using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class WarehouseController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}