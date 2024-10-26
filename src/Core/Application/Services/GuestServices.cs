using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class GuestServices(IGenericRepository<Guest> GuestRepo)
{
    public Task<List<Guest>> GetAll()
    {
        var data = GuestRepo.GetAll();
        return data;

    }

    public Task<List<Guest>> Fillter(Expression<Func<Guest,bool>> where = null,
        Func<IQueryable<Guest>,IOrderedQueryable<Guest>> orderBy=null,
        string include = null)
    {
        var data = GetAll();
        if (where != null)
        {
             data = GuestRepo.Filter(where: where);
        }

        if (include != null)
        {
             data = GuestRepo.Filter(Include: include);
        }

        if (orderBy != null)
        {
            data = GuestRepo.Filter(orderBy: orderBy);
        }

        return data;
    }
    public Task<Guest> GetById(int id)
    {
        var data = GuestRepo.GetById(id);
        return data;
    }

    public Task Delete(int id)
    {
        GuestRepo.DeleteById(id);
        return Task.CompletedTask;
    }

    public Task<Guest> Update(Guest usr)
    {
        var data = GuestRepo.Update(usr);
        return data;
    }

    public Task<Guest> Create(Guest usr)
    {
        var data = GuestRepo.Create(usr);
        return data;
    }
}