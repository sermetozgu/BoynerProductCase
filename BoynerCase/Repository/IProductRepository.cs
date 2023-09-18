using BoynerCase.Models;

namespace BoynerCase.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetCategoryProducts(int categoryId, int page);
    }
}
