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

    public sealed class Configuration : DbMigrationsConfiguration<AirTickets.Data.MsSqlDbContext>
    {
        public Configuration()
        {
            // to have control in what is happening in the database -> false
            // update database when we want manually
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AirTickets.Data.MsSqlDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            const string AdministratorUserName = "pesho@thebest.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
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
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedSimpleData(MsSqlDbContext context)
        {
            if (!context.Tickets.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var ticket = new Ticket()
                    {
                        Price = 100 + i,
                        TravelClass = TravelClass.First,
                        Customer = context.Users.First(x => x.Email == "pesho@thebest.com"),
                        CreatedOn = DateTime.Now
                    };

                    context.Tickets.Add(ticket);
                }
            }
        }
    }
}
