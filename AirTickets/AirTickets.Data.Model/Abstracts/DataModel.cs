﻿using AirTickets.Data.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model.Abstracts
{
    public abstract class DataModel : IAuditable, IDeletable
    {
        public DataModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreateOn { get; set ; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
