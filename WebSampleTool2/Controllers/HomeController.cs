using System.Web.Mvc;

namespace WebSampleTool2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return PartialView();
        }
    }
}