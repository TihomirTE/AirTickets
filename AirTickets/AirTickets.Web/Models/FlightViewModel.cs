using AirTickets.Data.Model;
using AirTickets.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AirTickets.Data.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace AirTickets.Web.Models
{
    public class FlightViewModel: IMap<Flight> //ICustomMappings
    {
        [Display(Name ="Total sum = ")]
        public decimal Price { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
            
        //}

        public TravelClass TravelClass { get; set; }

    }
}