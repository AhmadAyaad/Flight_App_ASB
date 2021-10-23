using Flight.Entities.Entities;
using Flight.Infrastructre.ConfigruationClasses;

using Microsoft.EntityFrameworkCore;

namespace Flight.Infrastructre.Data
{
    public class FlightDbContext : DbContext
    {

        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration<Country>(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration<CreditCard>(new CreditCardEntityConfiguration());

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }
}
