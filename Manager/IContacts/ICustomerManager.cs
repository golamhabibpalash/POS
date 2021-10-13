using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.IContacts
{
    public interface ICustomerManager
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<bool> Add(Customer product);
        Task<bool> Update(Customer product);
        Task<bool> Remove(int id);
    }
}
