using Microsoft.AspNetCore.Mvc;

namespace SMS.Web.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
