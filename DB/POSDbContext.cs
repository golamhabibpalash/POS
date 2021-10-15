﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class POSDbContext : IdentityDbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {

        }
    }
}
