using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Entities;
using UnluOnlineAkademi.Domain.Interfaces;
using UnluOnlineAkademi.Persistence.Context;

namespace UnluOnlineAkademi.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var data = await _context.Set<T>().FirstOrDefaultAsync(x => x.ID == id && !x.IsDeleted);
            data.IsDeleted = true;
             _context.Set<T>().Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
             return await _context.Set<T>().Where(x=>!x.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.ID == id && !x.IsDeleted);
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
