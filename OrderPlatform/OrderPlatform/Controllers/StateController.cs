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
        // GET: State
        public ActionResult Index()
        {
            return View(service.GetList());
        }
    }
}