using Shopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Domain.IRepository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetBestSellersAsync(CancellationToken cancellationToken = default);
        Task<bool> ProductExistsAsync(int? productId, CancellationToken cancellationToken = default);
        Task Update(Product product, CancellationToken cancellationToken = default);
        Task Remove(int? productId, CancellationToken cancellationToken = default);
        Task CommitChanges(CancellationToken cancellationToken = default);
    }
}
