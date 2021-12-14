using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.IRepository;
using System.Threading.Tasks;

namespace Shopping.Areas.Admin.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _context;

        public ProductController(IProductRepository context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _context.GetByIdAsync(productId.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}
