using AirTickets.Data.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model.Abstracts
{
    public abstract class DataModel : IAuditable, IDeletable
    {
        public DateTime? CreateOn { get; set ; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
