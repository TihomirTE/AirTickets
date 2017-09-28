using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Models
{
    public class ViewProfile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NumberOfTickets { get; set; }
    }
}