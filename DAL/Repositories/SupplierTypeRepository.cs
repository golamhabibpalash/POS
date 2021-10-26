using DAL.IRepositories;
using DB;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SupplierTypeRepository : Repository<SupplierType>, ISupplierTypeRepository
    {
        public SupplierTypeRepository(POSDbContext context):base(context)
        {

        }
    }
}
