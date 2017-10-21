namespace AirTickets.Data.Migrations
{
    using Models;
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AirTicketEfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AirTicketEfDbContext context)
        {
            if (context.Flights.Any())
            {
                return;
            }

            IList<Airline> airlines = new List<Airline>()
            {
                new Airline() { Id = Guid.NewGuid(), Name = "BulgariaAir" },
                new Airline() { Id = Guid.NewGuid(), Name = "WizzAir" },
                new Airline() { Id = Guid.NewGuid(), Name = "RyanAir" },
                new Airline() { Id = Guid.NewGuid(), Name = "BritishAir" }
            };

            IList<Airport> airports = new List<Airport>()
            {
                new Airport() {Id = Guid.NewGuid(), Name = "Sofia", AirportCode = "LBSF" },
                new Airport() {Id = Guid.NewGuid(), Name = "Rome", AirportCode = "LIRF" },
                new Airport() {Id = Guid.NewGuid(), Name = "Plovdiv", AirportCode = "LBPD" },
                new Airport() {Id = Guid.NewGuid(), Name = "London", AirportCode = "EGLL" }
            };

            List<Flight> flights = new List<Flight>()
            {
                new Flight() {
                    Id = Guid.NewGuid(),
                    Title = "FB0123",
                   Price = 50,
                   Duration = TimeSpan.Parse("01:20:00"),
                   TravelClass = TravelClass.Business,
                   Airline = airlines[0],
                   DepartureAirport = airports[0],
                   ArrivalAirport = airports[1]
                },
                new Flight() {
                    Id = Guid.NewGuid(),
                     Title = "RA324",
                   Price = 150,
                   Duration = TimeSpan.Parse("01:45:00"),
                   TravelClass = TravelClass.First,
                   Airline = airlines[1],
                    DepartureAirport = airports[1],
                   ArrivalAirport = airports[0]
                },
                new Flight() {
                    Id = Guid.NewGuid(),
                     Title = "WB563",
                   Price = 40,
                   Duration = TimeSpan.Parse("01:05:00"),
                   TravelClass = TravelClass.Economy,
                   Airline = airlines[2],
                    DepartureAirport = airports[2],
                   ArrivalAirport = airports[3]
                },
                new Flight() {
                    Id = Guid.NewGuid(),
                     Title = "BA4123",
                   Price = 250,
                   Duration = TimeSpan.Parse("02:20:00"),
                   TravelClass = TravelClass.Business,
                   Airline = airlines[3],
                    DepartureAirport = airports[3],
                   ArrivalAirport = airports[2]
                },
                new Flight() {
                    Id = Guid.NewGuid(),
                     Title = "BA8963",
                   Price = 220,
                   Duration = TimeSpan.Parse("01:55:00"),
                   TravelClass = TravelClass.First,
                   Airline = airlines[3],
                    DepartureAirport = airports[2],
                   ArrivalAirport = airports[3]
                },
                new Flight() {
                    Id = Guid.NewGuid(),
                     Title = "RA9876",
                   Price = 110,
                   Duration = TimeSpan.Parse("02:20:00"),
                   TravelClass = TravelClass.Economy,
                   Airline = airlines[1],
                    DepartureAirport = airports[0],
                   ArrivalAirport = airports[1]
                },
                new Flight() {
                    Id = Guid.NewGuid(),
                     Title = "FB0783",
                   Price = 175,
                   Duration = TimeSpan.Parse("02:25:00"),
                   TravelClass = TravelClass.Business,
                   Airline = airlines[0],
                    DepartureAirport = airports[1],
                   ArrivalAirport = airports[0]
                },
            };

            context.Flights.AddOrUpdate(flights.ToArray());
        }
    }
}
