using LabProniaTask.MVC.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LabProniaTask.MVC.Repository.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppdbContext _db;

        public WriteRepository(AppdbContext db)
        {
            _db = db;
        }
        public DbSet<T> Table => _db.Set<T>();

        public async Task Add(T entity)
        {
            await Table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Table.Where(e => e.Id == id).FirstOrDefaultAsync();
            if(entity is null) return;
            Table.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            var oldEntity = await Table.Where(e=>e.Id == entity.Id).FirstOrDefaultAsync();
            await _db.SaveChangesAsync();
        }
    }
}
