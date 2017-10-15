using AirTickets.Data.Contracts;
using AirTickets.Data.Model;
using AirTickets.Data.Model.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data
{
    public class SqlDbContext : IdentityDbContext<User>, ISqlDbContext
    {
        public SqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Flight> Flights { get; set; }

        public virtual IDbSet<Airline> Airlines { get; set; }

        public virtual IDbSet<DepartureAirport> DepartureAirports { get; set; }

        public virtual IDbSet<ArrivalAirport> ArrivalAirports { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static SqlDbContext Create()
        {
            return new SqlDbContext();
        }
    }
}
