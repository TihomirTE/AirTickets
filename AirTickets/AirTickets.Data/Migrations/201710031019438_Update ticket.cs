namespace AirTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateticket : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "UserId", c => c.Guid());
        }
    }
}
