using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using System.Data.Entity;

namespace AirTickets.Data
{
    public class AirTicketEfDbContext : DbContext, IAirTicketDbContextSaveChanges
    {
        public AirTicketEfDbContext()
            : base("DefaultConnection")
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Flight> Flights { get; set; }

        public IDbSet<Airline> Airlines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnFlightCreating(modelBuilder);
            this.OnAirlineCreating(modelBuilder);
        }

        private void OnFlightCreating(DbModelBuilder modelBuilder)
        {
            // TO DO
            //modelBuilder.Entity<Book>()
            //    .HasKey(b => b.Id)
            //    .Property(b => b.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            modelBuilder.Entity<Flight>()
                .Property(b => b.Title).IsRequired();

            modelBuilder.Entity<Flight>()
                .Property(x => x.Price).IsRequired();

            modelBuilder.Entity<Flight>()
                .Property(x => x.Duration).IsRequired();

            //modelBuilder.Entity<Book>()
            //    .Property(b => b.CategoryId).IsOptional();

            modelBuilder.Entity<Flight>()
                .HasRequired(x => x.Airline)
                .WithMany(y => y.Flights)
                .HasForeignKey(x => x.AirlineId);
        }

        private void OnAirlineCreating(DbModelBuilder modelBuilder)
        {
            // TO DO
            //modelBuilder.Entity<Category>()
            //    .HasKey(b => b.Id)
            //    .Property(b => b.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

            modelBuilder.Entity<Airline>()
                .Property(x => x.Name).IsRequired();

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Books)
            //    .WithOptional(b => b.Category);
                //.HasForeignKey(b => b.CategoryId);
        }
    }
}