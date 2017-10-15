using AirTickets.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly SqlDbContext context;

        public SaveContext(SqlDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
