using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;

public class ConfigurationRoom:IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasOne(x => x.Guest).WithMany(x => x.Rooms).HasForeignKey(x => x.GuestId);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
       
    }
}