namespace AirTickets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        AirportCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        City_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Tickets", "Airline_Id", c => c.Guid());
            AddColumn("dbo.Tickets", "Airport_Id", c => c.Guid());
            AddColumn("dbo.Tickets", "ArrivalAirport_Id", c => c.Guid());
            AddColumn("dbo.Tickets", "DepartureAirport_Id", c => c.Guid());
            CreateIndex("dbo.Tickets", "Airline_Id");
            CreateIndex("dbo.Tickets", "Airport_Id");
            CreateIndex("dbo.Tickets", "ArrivalAirport_Id");
            CreateIndex("dbo.Tickets", "DepartureAirport_Id");
            AddForeignKey("dbo.Tickets", "Airline_Id", "dbo.Airlines", "Id");
            AddForeignKey("dbo.Tickets", "Airport_Id", "dbo.Airports", "Id");
            AddForeignKey("dbo.Tickets", "ArrivalAirport_Id", "dbo.Airports", "Id");
            AddForeignKey("dbo.Tickets", "DepartureAirport_Id", "dbo.Airports", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "DepartureAirport_Id", "dbo.Airports");
            DropForeignKey("dbo.Tickets", "ArrivalAirport_Id", "dbo.Airports");
            DropForeignKey("dbo.Tickets", "Airport_Id", "dbo.Airports");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Airports", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Tickets", "Airline_Id", "dbo.Airlines");
            DropIndex("dbo.Countries", new[] { "IsDeleted" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "IsDeleted" });
            DropIndex("dbo.Airports", new[] { "City_Id" });
            DropIndex("dbo.Airports", new[] { "IsDeleted" });
            DropIndex("dbo.Airlines", new[] { "IsDeleted" });
            DropIndex("dbo.Tickets", new[] { "DepartureAirport_Id" });
            DropIndex("dbo.Tickets", new[] { "ArrivalAirport_Id" });
            DropIndex("dbo.Tickets", new[] { "Airport_Id" });
            DropIndex("dbo.Tickets", new[] { "Airline_Id" });
            DropColumn("dbo.Tickets", "DepartureAirport_Id");
            DropColumn("dbo.Tickets", "ArrivalAirport_Id");
            DropColumn("dbo.Tickets", "Airport_Id");
            DropColumn("dbo.Tickets", "Airline_Id");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Airports");
            DropTable("dbo.Airlines");
        }
    }
}
