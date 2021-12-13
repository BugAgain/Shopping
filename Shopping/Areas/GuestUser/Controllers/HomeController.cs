using Microsoft.AspNetCore.Mvc;

namespace Shopping.Areas.GuestUser.Controllers
{
    [Area("GuestUser")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
