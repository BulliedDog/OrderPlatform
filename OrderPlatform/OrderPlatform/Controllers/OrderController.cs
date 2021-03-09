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
        // GET: Order
        public ActionResult Index()
        {
            return View(service.Get());
        }

        public ActionResult Edit(int id) //this edit shows the page but doesn't do any post
        {
            ViewBag.userList = userService.GetList(); //passes the list of names corresponding to the userId field//
            return View(new OrderEditModel());
        }

        public ActionResult Edit(OrderEditModel model) //this edit shows nothing but does the post
        {

        }
    }
}