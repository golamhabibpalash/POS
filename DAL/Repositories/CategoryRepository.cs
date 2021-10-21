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
    public class CategoryRepository :  Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(POSDbContext context):base(context)
        {

        }
        public override async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Parent).ToListAsync();
        }
    }
}
