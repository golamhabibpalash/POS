using DAL.IRepositories;
using DB;
using Microsoft.EntityFrameworkCore;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(POSDbContext context):base(context)
        {

        }
        public override async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.Include(b => b.Category).ToListAsync();
        }
        public override async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands.Include(b => b.Category).FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
