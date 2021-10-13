using Entity;
using Manager.IContacts;
using Repository.IDepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Contacts
{
    public class ProductManager : IProductManager
    {
        public IProductRepository productRepository;

        public async Task<bool> Add(Product product)
        {
            return await productRepository.Add(product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
           return await productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await productRepository.GetByIdAsync(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await productRepository.Remove(id);
        }

        public async Task<bool> Update(Product product)
        {
            return await productRepository.Update(product);
        }
    }
}
