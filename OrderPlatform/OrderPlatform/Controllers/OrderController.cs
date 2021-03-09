using OrderPlatform.Models;
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
        public UserService userService = new UserService();
        public StateService stateService = new StateService();
        // GET: Order

        public ActionResult Index()
        {
            return View(service.Gets());
        }
        
        [HttpGet]
        public ActionResult Edit(int id) //this edit shows the page but doesn't do any post//
        {
            ViewBag.userList = userService.GetList(); //passes the list of names corresponding to the userId field//
            ViewBag.stateList = stateService.GetList(); //passes the list of states corresponding to the stateId field//
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(OrderEditModel model) //this edit shows nothing but does the post//
        {
            service.Post(model);
            return RedirectToAction("Index"); //redirects to another action of the same controller in this case, you can also redirect to another controller set apart//
        }
    }
}