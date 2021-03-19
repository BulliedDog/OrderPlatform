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
        public ProductService productService = new ProductService();
        public ProductOrderService productOrderService = new ProductOrderService();
        // GET: Order

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.quantitiesList = service.GetQuantities();
            return View(service.Gets());
        }

        [HttpGet]
        public ActionResult Edit(int id, string message) //this edit shows the page but doesn't do any post//
        {
            ViewBag.message = message;
            ViewBag.userList = userService.GetList(); //passes the list of names corresponding to the userId field//
            ViewBag.stateList = stateService.GetList(); //passes the list of states corresponding to the stateId field//
            ViewBag.productList = productService.GetList();
            return View(service.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(OrderEditModel model) //this edit shows nothing but does the post//
        {
            ViewBag.userList = userService.GetList(); //passes the list of names corresponding to the userId field//
            ViewBag.stateList = stateService.GetList(); //passes the list of states corresponding to the stateId field//
            ViewBag.productList = productService.GetList();
            if (ModelState.IsValid) //this if is for the validation//
            {
                var orderId = service.Set(model); //service.Set saves the order model but it returns an int value that is model.orderId(go to definition of Set to check it out)//
                //The RedirerectToAction() below directs to another action of the same controller in this case, though you can redirect to another controller set apart//
                //It is also passing an anonymous object with the parameters needed for Edit()//
                return RedirectToAction("Edit", new { id = orderId, message = "Order saved succesfully!!!" });
            }
            return View(model); //returning the model with the same view trigers the validation messages//
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
            ViewBag.productList = productService.GetList();
            return PartialView("_ProductOrder", productOrderService.Get(orderId));
        }

        [HttpGet]
        public ActionResult deleteProductOrder(int id)
        {
            var orderId = productOrderService.Del(id);
            return RedirectToAction("Edit", new { id = orderId });
        }
    }
}