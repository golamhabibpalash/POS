using BLL.IManagers;
using DAL.IRepositories;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class SaleManager : Manager<Sale>, ISaleManager
    {
        public SaleManager(ISaleRepository repository) : base(repository)
        {

        }
    }
}
