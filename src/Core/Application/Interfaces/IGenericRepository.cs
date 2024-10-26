using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IGenericRepository<T> where T :class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> DeleteById(int id);
    Task<T> Update(T entity);
    Task<T> Create(T entity);
    Task<List<T>> Filter(Expression<Func<T,bool>> where = null , 
        Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
        string Include = null);
}