using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities.TicketAggregate;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config;

public class TicketConfiguration  : IEntityTypeConfiguration<TicketItem>
{
    public void Configure(EntityTypeBuilder<TicketItem> builder)
    {
        builder.ToTable("Ticket");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("ticket_hilo")
            .IsRequired();

        builder.Property(ci => ci.UserId)
            .IsRequired();

        builder.Property(ci => ci.EventId)
            .IsRequired();

    }
    
}
