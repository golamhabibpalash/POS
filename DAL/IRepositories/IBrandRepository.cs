﻿using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand> GetByNameAsync(string brandName);
    }
}
