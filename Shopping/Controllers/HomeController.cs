using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Domain.IRepository;
using Shopping.Models;
using Shopping.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _context;

        public HomeController(ILogger<HomeController> logger,
            IProductRepository context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            model.BestSellers = await _context.GetBestSellersAsync();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
