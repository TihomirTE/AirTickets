namespace AirTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "TravelClass", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Tickets", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Tickets", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Tickets", "Customer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            CreateIndex("dbo.Tickets", "IsDeleted");
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.AspNetUsers", "IsDeleted");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Tickets", new[] { "IsDeleted" });
            DropColumn("dbo.AspNetUsers", "DeletedOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "ModifiedOn");
            DropColumn("dbo.Tickets", "Customer_Id");
            DropColumn("dbo.Tickets", "DeletedOn");
            DropColumn("dbo.Tickets", "ModifiedOn");
            DropColumn("dbo.Tickets", "CreatedOn");
            DropColumn("dbo.Tickets", "IsDeleted");
            DropColumn("dbo.Tickets", "TravelClass");
            DropColumn("dbo.Tickets", "Price");
        }
    }
}
