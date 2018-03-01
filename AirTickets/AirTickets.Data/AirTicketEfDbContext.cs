using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AirTickets.Data
{
    public class AirTicketEfDbContext : IdentityDbContext<User>, IAirTicketDbContextSaveChanges
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

        public IDbSet<Airport> Airports { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    this.OnFlightCreating(modelBuilder);
        //    this.OnAirlineCreating(modelBuilder);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(t => t.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        private void OnFlightCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(b => b.Title).IsRequired();

            modelBuilder.Entity<Flight>()
                .Property(x => x.Price).IsRequired();

            modelBuilder.Entity<Flight>()
                .Property(x => x.Duration).IsRequired();

            modelBuilder.Entity<Flight>()
                .HasRequired(x => x.Airline)
                .WithMany(y => y.Flights)
                .HasForeignKey(x => x.AirlineId);

            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
        }

        private void OnAirlineCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Airline>()
                .Property(x => x.Name).IsRequired();
        }

        private void OnAirportCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>()
               .Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Airport>()
              .Property(x => x.Name).IsOptional();
        }

        public static AirTicketEfDbContext Create()
        {
            return new AirTicketEfDbContext();
        }
    }
}