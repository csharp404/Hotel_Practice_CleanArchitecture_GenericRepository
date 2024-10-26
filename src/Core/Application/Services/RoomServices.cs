using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class RoomServices(IGenericRepository<Room> RoomRepo)
{
    public Task<List<Room>> GetAll()
    {
       var data =  RoomRepo.GetAll();
       return data;
    }

    public Task<Room> GetById(int id)
    {
        var data = RoomRepo.GetById(id);
        return data;
    }

    public Task Delete(int id)
    {
        RoomRepo.DeleteById(id);
        return Task.CompletedTask;
    }

    public Task<Room> Create(Room room)
    {
        var data = RoomRepo.Create(room);
        return data;
    }

    public Task<Room> Update(Room room)
    {
        var data = RoomRepo.Update(room);
        return data;
    }

}