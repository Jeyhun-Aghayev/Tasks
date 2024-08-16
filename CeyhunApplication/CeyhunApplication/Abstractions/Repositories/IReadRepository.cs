using CeyhunApplication.Models;
using System.Linq.Expressions;

namespace CeyhunApplication.Abstractions.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()   //Marker Pattern
{
    T? GetById(int? id, bool asNoTracking = false, params string[] includes);
    IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes);

}


