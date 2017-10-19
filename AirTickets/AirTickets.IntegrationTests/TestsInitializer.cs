using AirTickets.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AirTickets.IntegrationTests
{
    [TestClass]
    public class TestsInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirTicketEfDbContext, TestDbConfiguration>());
        }
    }

    public sealed class TestDbConfiguration : DbMigrationsConfiguration<AirTicketEfDbContext>
    {
        public TestDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}