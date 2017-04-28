using System;
using System.Web.Mvc;

namespace GradeSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Student")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Add(string x, string y)
        {
            //var abc = Convert.ToInt32(x) + 1;
            var add_result = Convert.ToInt32(x) + Convert.ToInt32(y);
            return Json(add_result, JsonRequestBehavior.AllowGet);
        }
    }
}