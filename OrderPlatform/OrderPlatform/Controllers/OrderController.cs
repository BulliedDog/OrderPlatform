using OrderPlatform.Models;
using OrderPlatform.Services;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class OrderController : Controller
    {
        public OrderService service = new OrderService();
        public UserService userService = new UserService();
        public StateService stateService = new StateService();
        public ProductOrderService productOrderService = new ProductOrderService();
        // GET: Order

        public ActionResult Index()
        {
            return View(service.Gets());
        }

        [HttpGet]
        public ActionResult Edit(int id, string message) //this edit shows the page but doesn't do any post//
        {
            ViewBag.message = message;
            ViewBag.userList = userService.GetList(); //passes the list of names corresponding to the userId field//
            ViewBag.stateList = stateService.GetList(); //passes the list of states corresponding to the stateId field//
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(OrderEditModel model) //this edit shows nothing but does the post//
        {
            ViewBag.userList = userService.GetList(); //passes the list of names corresponding to the userId field//
            ViewBag.stateList = stateService.GetList(); //passes the list of states corresponding to the stateId field//
            if (ModelState.IsValid)
            {
                var orderId = service.Set(model);
                //The RedirerectToAction() below directs to another action of the same controller in this case, though you can redirect to another controller set apart//
                //It is also passing an anonymous object with the parameters needed for Edit()//
                return RedirectToAction("Edit", new { id = orderId, message = "Order saved succesfully!!!" });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            service.del(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult newProduct(int orderId)
        {
            return PartialView("_ProductOrder", productOrderService.Get(orderId));
        }
    }
}