using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Contracts
{
    public interface ISaveContext
    {
        void Commit();
    }
}
