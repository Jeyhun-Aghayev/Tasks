﻿using CeyhunApplication.Abstractions.Repositories;
using CeyhunApplication.Data;
using CeyhunApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace CeyhunApplication.Concretes.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private readonly ApplicationDbContext _context;

    public ReadRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public T? GetById(int? id, bool asNoTracking = false, params string[] includes)
    {
        var queryable = Table.AsQueryable();

        if (asNoTracking)
        {
            queryable = queryable.AsNoTracking();
        }

        foreach (string include in includes)
        {
            queryable = queryable.Include(include);
        }

        T? entity = queryable.FirstOrDefault(e => e.Id == id);
        return entity;

    }
    public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes)
    {
        IQueryable<T> query = Table;
        foreach (string include in includes)
        {
            query = query.Include(include);
        }

        if (expression is not null)
        {
            query = query.Where(expression);
        }
        return query;
    }

}