namespace AirTickets.Data.Migrations
{
    using AirTickets.Data.Model;
    using AirTickets.Data.Model.Enum;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SqlDbContext>
    {
        private const string AdministratorUserName = "pesho@thebest.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            // to have control in what is happening in the database -> false
            // update database when we want manually
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedSimpleData(context);

            base.Seed(context);
        }

        private void SeedUsers(SqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSimpleData(SqlDbContext context)
        {
            if (!context.Flights.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var flight = new Flight()
                    {
                        Price = 200 + i,
                        TravelClass = TravelClass.Economy,
                        Duration = TimeSpan.FromHours(2 + i),
                        //User = context.Users.First(x => x.Email == "pesho@thebest.com"),
                        CreatedOn = DateTime.Now
                    };
                    context.Flights.Add(flight);

                    var airport = new DepartureAirport()
                    {
                        Name = "Bulgaria" + i,
                        AirportCode = "EBLN" + i
                    };
                    context.DepartureAirports.Add(airport);

                    var airline = new Airline()
                    {
                        Name = "BritishAir" + i,

                    };
                    context.Airlines.Add(airline);


                    var airportAr = new ArrivalAirport()
                    {
                        Name = "London" + i,
                        AirportCode = "EBLN" + i
                    };
                    context.ArrivalAirports.Add(airportAr);

                    var country = new Country()
                    {
                        Name = "Bulgaria",
                    };
                    context.Countries.Add(country);
                }
            }
        }
    }
}
