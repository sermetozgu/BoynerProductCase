using Azure.Core;
using BoynerCase.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CaseDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetCategoryProducts(int categoryId, int page)
        {
            int pageSize = 5;

            var totalProducts = await GetAll()
                .Where(u => u.KategoriId == categoryId)
                .CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;
            }

            var products = await GetAll()
                .Where(u => u.KategoriId == categoryId)
                .OrderBy(u => u.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products;
        }
    }
}
