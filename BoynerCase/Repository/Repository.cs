using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using BoynerCase.Models;
using Azure.Core;

namespace BoynerCase.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CaseDbContext _context;

        public Repository(CaseDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public async Task<IEnumerable<T>> GetPage(int page)
        {
            int pageSize = 5;
            var totalProducts = await _context.Set<T>().CountAsync();//await _context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;
            }

            var products = await _context.Set<T>()
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<T> Update(int id, T entity)
        {
            _context.Set<T>().Update(entity);
    
            await _context.SaveChangesAsync();
            return await GetById(id);
        }
        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
