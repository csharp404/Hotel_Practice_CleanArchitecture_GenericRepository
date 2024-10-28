using System.Linq.Expressions;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenericRepository<T>(AppDbContext context):IGenericRepository<T> where T :class
{
    public Task<List<T>> GetAll()
    {
       var data  = context.Set<T>().ToList();
       return Task.FromResult(data);
    }

    public async Task<T> GetById(int id)
    {
        var data = await context.Set<T>().FindAsync(id);
        return data;
    }

    public async Task<T> DeleteById(int id)
    {
        var trans = context.getTransaction();
        try
        {
            var data = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(data);
            await context.Save();
            trans.Commit();
            return data;
        }
        catch (Exception)
        {
            trans.Rollback();
            throw;
        }
    }

    public async Task<T> Update(T entity)
    {
        var trans = context.getTransaction();

        try
        {
            context.Set<T>().Update(entity);
            await context.Save();
            trans.Commit();
            return entity;
        }
        catch (Exception)
        {
            trans.Rollback();
            throw;
        }
    }

    public async Task<T> Create(T entity)
    {
        context.Set<T>().Add(entity);
        await context.Save();
        return entity;
    }

    public async Task<List<T>> Filter(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string Include = null)
    {
        IQueryable<T> query = context.Set<T>();
        if (Include != null)
        {
           query =  context.Set<T>().Include(Include);
        }
        if (where != null)
        {
            query = query.Where(where);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query.ToListAsync();
    }
}