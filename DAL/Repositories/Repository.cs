using DAL.IRepositories;
using DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly POSDbContext _context;

        public Repository(POSDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table
        {
            get { return _context.Set<T>(); }
        }

        public virtual async Task<bool> AddAsync(T model)
        {
            Table.Add(model);
            int isSaved = await _context.SaveChangesAsync();
            if (isSaved>0)
            {
                return true;
            }
            return false;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(int id)
        {
            var result = await Table.FindAsync(id);
            if (result!=null)
            {
                _context.Remove(result);
            }
            int isDeleted = await _context.SaveChangesAsync();
            if (isDeleted > 0)
            {
                return true;
            }
            return false;
        }

        public virtual async Task<bool> UpdateAsync(T model)
        {
            Table.Update(model);
            int isUpdated = await _context.SaveChangesAsync();
            if (isUpdated > 0)
            {
                return true;
            }
            return false;
        }
    }
}
