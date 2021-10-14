using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IManagers
{
    public interface IManager<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> RemoveAsync(int id);
    }
}
