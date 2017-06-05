using System.Web.Mvc;

namespace PrivateHospital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}