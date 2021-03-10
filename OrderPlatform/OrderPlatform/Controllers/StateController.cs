using OrderPlatform.Models;
using OrderPlatform.Services;
using System.Web.Mvc;

namespace OrderPlatform.Controllers
{
    public class StateController : Controller
    {
        public StateService service = new StateService();

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
        public ActionResult Edit(StateModel model)
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