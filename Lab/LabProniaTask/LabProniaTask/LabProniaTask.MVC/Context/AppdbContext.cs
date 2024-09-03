using LabProniaTask.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LabProniaTask.MVC.Context
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SliderItem> SliderItems { get; set; }
    }
}
