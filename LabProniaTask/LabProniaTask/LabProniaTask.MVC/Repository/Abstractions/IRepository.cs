using LabProniaTask.MVC.Context;
using Microsoft.EntityFrameworkCore;

namespace LabProniaTask.MVC.Repository.Abstractions;

public interface IRepository<T> where T : BaseEntity
{
    public DbSet<T> Table { get; }
}
public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool isTracking);
    Task<T?> GetById(int id);
}