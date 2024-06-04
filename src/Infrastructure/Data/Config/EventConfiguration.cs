using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Event");

        builder.Property(e => e.Id)
            .UseHiLo("event_hilo")
            .IsRequired();

        builder.Property(e => e.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(e => e.Price)
            .IsRequired(true)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.PictureUri)
            .IsRequired(false);

        builder.HasMany(e => e.EventTypes)
            .WithMany(et => et.Events);

        builder.HasMany(e => e.EventLocations)
            .WithMany(et => et.Events);
           
        
        builder.HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId);

    }
}
