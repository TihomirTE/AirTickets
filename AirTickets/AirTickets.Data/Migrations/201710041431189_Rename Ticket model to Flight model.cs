namespace AirTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTicketmodeltoFlightmodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tickets", newName: "Flights");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Flights", newName: "Tickets");
        }
    }
}
