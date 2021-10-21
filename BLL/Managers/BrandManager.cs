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
    public class BrandManager : Manager<Brand>, IBrandManager
    {
        private readonly IBrandRepository _brnadRepository;
        public BrandManager(IBrandRepository Repository):base(Repository)
        {
            _brnadRepository = Repository;
        }
        public override async Task<bool> AddAsync(Brand model)
        {
            Brand brand = await _brnadRepository.GetByNameAsync(model.BrandName);
            if (brand!=null)
            {
                return false;
            }
            return await base.AddAsync(model);
        }

        public async Task<Brand> GetByNameAsync(string brandName)
        {
            return await _brnadRepository.GetByNameAsync(brandName);
        }
    }
}
