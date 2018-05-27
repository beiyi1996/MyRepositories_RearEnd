using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPrice.Models;

namespace TicketPrice
{
    class StartStationIEquityComparer : IEqualityComparer<TicTable>
    {
        public bool Equals(TicTable x, TicTable y)
        {
            return x.Startstation == y.Startstation;
        }

        public int GetHashCode(TicTable obj)
        {
            return obj.Startstation.GetHashCode();
        }
    }

    class EndStationIEquityComparer : IEqualityComparer<TicTable>
    {
        public bool Equals(TicTable x, TicTable y)
        {
            return x.Endstation == y.Endstation;
        }

        public int GetHashCode(TicTable obj)
        {
            return obj.Endstation.GetHashCode();
        }
    }
}
