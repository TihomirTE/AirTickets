﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model.Contracts
{
    // tracking modification on the entity
    public interface IAuditable
    {
        DateTime? ModifiedOn { get; set; }
        DateTime? CreatedOn { get; set; }
    }
}
