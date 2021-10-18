using BLL.IManagers;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class Manager<T> : IManager<T> where T : class
    {
        public readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> AddAsync(T model)
        {
            bool isAdded = await _repository.AddAsync(model);
            if (isAdded)
            {
                return true;
            }
            return false;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(int id)
        {
            return await _repository.RemoveAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(T model)
        {
            bool isUpdated = await _repository.AddAsync(model);
            if (isUpdated)
            {
                return true;
            }
            return false;
        }
    }
}
