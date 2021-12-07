using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Checkout
        public async Task<IActionResult> Checkout(int cartId)
        {
            var cart = await _context.Cart
                .Include(c => c.Items)
                .AsNoTracking()
                .Where(c => c.CartId == cartId)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        [HttpPost]
        public async Task<JsonResult> AddProduct(int productId, string userId)
        {
            var cart = await _context.Cart
                .Include(p => p.Items)
                .Where(c => c.UserId == userId)
                .FirstOrDefaultAsync();

            var prod = await _context.Products
                    .Include(c => c.Cart)
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefaultAsync();

            if (cart == null)
            {
                var newCart = new Cart() { UserId = userId };

                prod.Cart.Add(newCart);

                newCart.AddProduct(prod);

                cart = newCart;
            }
            else
            {
                var prodExists = cart.Items
                    .Any(p => p.ProductId == productId);

                if (!prodExists)
                {
                    cart.AddProduct(prod);
                }

                return Json("Nothing changed!");
            }


            if (cart.CartId < 1)
            {
                await _context.Cart.AddAsync(cart);
            }
            else
            {
                _context.Cart.Update(cart);
            }

            await _context.SaveChangesAsync();

            return Json($"Saved! - {productId}");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
