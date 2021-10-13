using Database;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository.IDepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Depo
{
    public class ProductRepository : IProductRepository
    {
        public POSDbContext context;

        public async Task<bool> Add(Product product)
        {
            context.Products.Add(product);
            int isSaved = await context.SaveChangesAsync();
            if (isSaved>0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            var item = await context.Products.FindAsync(id);
            context.Products.Remove(item);
            int isDeleted = await context.SaveChangesAsync();
            if (isDeleted>0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Product product)
        {
            context.Products.Update(product);
            int isUpdated = await context.SaveChangesAsync();
            if (isUpdated>0)
            {
                return true;
            }
            return false;
        }
    }
}
