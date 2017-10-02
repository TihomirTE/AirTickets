namespace AirTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateticketmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tickets", name: "Customer_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Tickets", name: "IX_Customer_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tickets", name: "IX_User_Id", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Tickets", name: "User_Id", newName: "Customer_Id");
        }
    }
}
