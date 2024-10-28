using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<IdentityUser>(options), IAppDbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(builder);
    }

    public async Task Save()
    {
        await SaveChangesAsync();
    }

    public IDbContextTransaction getTransaction()
    {
         return Database.BeginTransaction();
    }
}

   
