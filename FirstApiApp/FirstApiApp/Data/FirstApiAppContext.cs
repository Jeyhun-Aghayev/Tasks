using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstApiApp.Models;

namespace FirstApiApp.Data
{
    public class FirstApiAppContext : DbContext
    {
        public FirstApiAppContext (DbContextOptions<FirstApiAppContext> options)
            : base(options)
        {
        }

        public DbSet<FirstApiApp.Models.Category> Categories { get; set; } = default!;
    }
}
