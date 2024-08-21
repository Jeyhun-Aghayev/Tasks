using LabProniaTask.MVC.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LabProniaTask.MVC.Repository.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => throw new NotImplementedException();
    }
}
