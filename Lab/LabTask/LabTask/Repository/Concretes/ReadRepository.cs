﻿
namespace LabTask.MVC.Repository.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;

        public ReadRepository(AppDbContext db)
        {
            _db = db;
        }

        public DbSet<T> Table => _db.Set<T>();

        public IQueryable<T> GetAll(bool isTracking)
        {
            IQueryable<T> queryable =  Table.AsQueryable();

            if (!isTracking) queryable = queryable.AsNoTracking();
            return queryable;
        }

        public  async Task<T?> GetById(int id)
        {
            return await Table.Where(e=>e.Id == id).FirstOrDefaultAsync();
        }
    }
}