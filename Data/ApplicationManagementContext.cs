using crm_minimal.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_minimal.Data
{
    public class ApplicationManagementContext : DbContext
    {
        public ApplicationManagementContext(DbContextOptions<ApplicationManagementContext> options)
            : base(options)
        {
        }

        public ApplicationManagementContext()
        {}

    public virtual DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventHasType> EventHasTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventHasVenue> EventHasVenuse { get; set; }
        public DbSet<Customer> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventHasType>()
                .HasKey(eht => new { eht.EventId, eht.TypeId });

            modelBuilder.Entity<EventHasType>()
                .HasOne(eht => eht.Event)
                .WithMany(e => e.EventHasTypes)
                .HasForeignKey(eht => eht.EventId);

            modelBuilder.Entity<EventHasType>()
                .HasOne(eht => eht.EventType)
                .WithMany(et => et.EventHasTypes)
                .HasForeignKey(eht => eht.TypeId);
            
            modelBuilder.Entity<Customer>()
                .HasDiscriminator<string>("CustomerType")
                .HasValue<Customer>("Customer")
                .HasValue<RegisteredCustomer>("RegisteredCustomer");
           ;
        }
    }
}
