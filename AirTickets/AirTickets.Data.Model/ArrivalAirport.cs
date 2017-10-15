﻿using AirTickets.Data.Model.Abstracts;
using AirTickets.Data.Model.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class ArrivalAirport : DataModel
    {
        private IEnumerable<Airline> airlines;

        public ArrivalAirport()
        {
            this.airlines = new HashSet<Airline>();
        }

        [MinLength(ModelConstants.MinNameLenght)]
        [MaxLength(ModelConstants.MaxNameLenght)]
        public string Name { get; set; }

        public string AirportCode { get; set; }

        public Guid? DepartureAirportId { get; set; }

        public virtual DepartureAirport DepartureAirport { get; set; }

        public virtual IEnumerable<Airline> Airlines
        {
            get
            {
                return this.airlines;
            }
            set
            {
                this.airlines = value;
            }
        }
    }
}
