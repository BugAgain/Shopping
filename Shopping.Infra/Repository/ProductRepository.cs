using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Domain.Entities;
using Shopping.Domain.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Infra.Repository
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(p =>
                p.ProductId == productId, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetBestSellersAsync(CancellationToken cancellationToken = default)
        {
            //TODO: Best Sellers business logic
            return await _context.Products.AsNoTracking().Take(8).ToListAsync(cancellationToken);
        }

        public async Task<bool> ProductExistsAsync(int? productId, CancellationToken cancellationToken = default)
        {
            if (!productId.HasValue || productId <= 0)
            {
                return false;
            }

            return await _context.Products.AnyAsync(p => p.ProductId == productId, cancellationToken);
        }

        public async Task Update(Product product, CancellationToken cancellationToken = default)
        {
            if (!await ProductExistsAsync(product.ProductId, cancellationToken))
            {
                return;
            }

            _context.Update(product);
        }

        public async Task Remove(int? productId, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return;
            }

            //TODO: Soft delete?
            _context.Remove(product);
        }

        public async Task CommitChanges(CancellationToken cancellationToken = default)
        {
            //TODO: try catch
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
