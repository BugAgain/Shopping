using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            var cart = Extensions.SessionExtensions
                .GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            return View(cart ?? new List<Product>());
        }

        [HttpPost]
        public async Task<JsonResult> AddToCart(int productId)
        {
            var prod = await _context.Products.FindAsync(productId);

            var cart = Extensions.SessionExtensions
                .GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<Product>() { prod };
                Extensions.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = ProductExists(productId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(prod);
                }
                Extensions.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return Json(default);
        }

        [HttpDelete]
        public JsonResult Remove(int productId)
        {
            var cart = Extensions.SessionExtensions
                .GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            int index = ProductExists(productId);
            if (index != -1)
            {
                cart.RemoveAt(index);
            }

            Extensions.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return Json(default);
        }

        private int ProductExists(int productId)
        {
            var cart = Extensions.SessionExtensions
                .GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == productId)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
