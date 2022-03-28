using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Riner.Models;

namespace Riner.Data
{
    public class RinerContext : DbContext
    {
        public RinerContext (DbContextOptions<RinerContext> options)
            : base(options)
        {
        }

        public DbSet<Riner.Models.Customers> Customers { get; set; }

        public DbSet<Riner.Models.Department> Department { get; set; }

        public DbSet<Riner.Models.Employees> Employees { get; set; }
    }
}
