using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}