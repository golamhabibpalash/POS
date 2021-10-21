﻿using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IManagers
{
    public interface IBrandManager : IManager<Brand>
    {
        Task<Brand> GetByNameAsync(string brandName);
    }
}
