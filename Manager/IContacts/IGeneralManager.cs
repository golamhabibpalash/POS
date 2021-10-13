using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.IContacts
{
    public interface IGeneralManager<T> where T:class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> Add(T product);
        Task<bool> Update(T product);
        Task<bool> Remove(int id);
    }
}
