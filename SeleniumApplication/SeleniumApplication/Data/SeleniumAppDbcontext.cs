using Microsoft.EntityFrameworkCore;
using SeleniumSelenium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSelenium.Data
{
    public class SeleniumAppDbcontext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SATURN12\\SQLEXPRESS;database=SeleniumDb;Trusted_Connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
