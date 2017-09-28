using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirTickets.Models
{
    public class ViewProfile
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage ="FirstName must contain only letters")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "LastName must contain only letters")]

        public string LastName { get; set; }

        public int? NumberOfTickets { get; set; }

        public int? NumberOfPassengers { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}