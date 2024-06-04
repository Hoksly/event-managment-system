using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities;

public class EventLocationConfiguration : IEntityTypeConfiguration<EventLocation>
{
    public void Configure(EntityTypeBuilder<EventLocation> builder)
    {
        builder.ToTable("EventLocation");

        builder.Property(el => el.Id)
            .UseHiLo("event_location_hilo")
            .IsRequired();

        builder.Property(el => el.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(el => el.Address)
            .HasMaxLength(100);

        builder.Property(el => el.City)
            .HasMaxLength(50);

        builder.Property(el => el.State)
            .HasMaxLength(50);

        builder.Property(el => el.ZipCode)
            .HasMaxLength(20);

        builder.Property(el => el.PictureUri)
            .HasMaxLength(255);

        builder.Property(el => el.Link)
            .HasMaxLength(255);

        builder.Property(el => el.Capacity);

        builder.Property(el => el.HasOnline)
            .IsRequired();

    }
}
