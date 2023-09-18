using Azure.Core;
using BoynerCase.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CaseDbContext context) : base(context) { }
    }
}
