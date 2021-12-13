using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Shopping.Data;
using Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Filters;

using SessionEx = Shopping.Extensions.SessionExtensions;

namespace Shopping.Controllers
{
    public class CartController : Controller
    {
        private const string SessionKeyCart = "_cart";
        private const string SessionKeyCartItemsCount = "_cart_items_count";

        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Throttle(Name = "ThrottleDemo",
            Message = "You must wait {n} seconds before accessing this url again.", Seconds = 15)]
        public IActionResult Checkout()
        {
            var cart = SessionEx.GetObjectFromJson<List<Product>>(
                HttpContext.Session, SessionKeyCart);

            return View(cart ?? new List<Product>());
        }

        [HttpPost]
        public async Task<JsonResult> AddToCart(int productId)
        {
            var prod = await _context.Products.FindAsync(productId);

            var cart = SessionEx.GetObjectFromJson<List<Product>>(
                HttpContext.Session, SessionKeyCart);

            if (cart == null)
            {
                prod.Quantity = 1;
                cart = new List<Product>() { prod };
                SessionEx.SetObjectAsJson(HttpContext.Session, SessionKeyCart, cart);
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
                    prod.Quantity = 1;
                    cart.Add(prod);
                }
                SessionEx.SetObjectAsJson(HttpContext.Session, SessionKeyCart, cart);
            }

            HttpContext.Session.SetInt32(SessionKeyCartItemsCount, cart.Count);

            return Json(cart.Count);
        }

        [HttpDelete]
        public JsonResult Remove(int productId)
        {
            var cart = SessionEx.GetObjectFromJson<List<Product>>(
                HttpContext.Session, SessionKeyCart);

            int index = ProductExists(productId);
            if (index != -1)
            {
                cart.RemoveAt(index);
            }

            SessionEx.SetObjectAsJson(HttpContext.Session, SessionKeyCart, cart);

            return Json(cart.Count);
        }

        private int ProductExists(int productId)
        {
            var cart = SessionEx.GetObjectFromJson<List<Product>>(
                HttpContext.Session, SessionKeyCart);

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
