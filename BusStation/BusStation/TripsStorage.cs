using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class TripsStorage
    {
        public static List<TripModel> Trips = new List<TripModel>
        { 
            new TripModel(1, new DateTime(2022,1,1), "Jmerynka", new DateTime(2022,1,2), "Paris", new BusModel("Ikarus", 35), 1500),
            new TripModel(2, new DateTime(2022,1,6), "Kyiv", new DateTime(2022,1,7), "Bukovel", new BusModel("Bohdan", 20), 500),
            new TripModel(3, new DateTime(2022,1,13), "Kurvamat", new DateTime(2022,1,15), "Ternopil", new BusModel("Sprinter", 18), 1200)
        };
    }
}
