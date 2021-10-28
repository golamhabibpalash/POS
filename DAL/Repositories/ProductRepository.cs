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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(POSDbContext context) : base(context)
        {

        }
        public override async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.UnitOfMeasure)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductType)
                .Include(p => p.ProductColor)
                .Include(p => p.ProductSize)
                .ToListAsync();
            return products;
        }
    }
}
