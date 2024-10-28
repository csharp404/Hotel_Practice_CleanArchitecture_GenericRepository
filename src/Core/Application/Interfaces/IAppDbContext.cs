using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces;

public interface IAppDbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }

    Task Save();
    IDbContextTransaction getTransaction();
}