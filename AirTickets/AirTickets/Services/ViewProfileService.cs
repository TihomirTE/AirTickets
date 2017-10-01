using AirTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Services
{
    public class ViewProfileService
    {
        private ApplicationDbContext db;

        public ViewProfileService(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }

        public void CreateViewProfile(string firstName, string lastName, string userId, 
            int numberOfTickets)
        {
            var viewProfile = new ViewProfile
            {
                FirstName = firstName,
                LastName = lastName,
                NumberOfTickets = numberOfTickets,
                ApplicationUserId = userId
            };
            db.ViewProfile.Add(viewProfile);
            db.SaveChanges();
        }
    }
}