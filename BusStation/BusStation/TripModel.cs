using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class TripModel
    {
        public int Id { get; }
        public DateTime DepartureTime { get; }
        public string TripFrom { get; }

        public DateTime ArrivalTime { get; }
        public string TripTo { get; }

        public BusModel Bus { get; }
        public double TicketPrice { get; }

        public TripModel(int id, DateTime departureTime, string tripFrom, DateTime arrivalTime, string tripTo, BusModel bus, double ticketPrice)
        {
            Id = id;
            DepartureTime = departureTime;
            TripFrom = tripFrom;
            ArrivalTime = arrivalTime;
            TripTo = tripTo;
            Bus = bus;
            TicketPrice = ticketPrice;
        }
    }
}
