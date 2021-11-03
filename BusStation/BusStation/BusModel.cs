using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class BusModel
    {
        public string Name { get; }
        public int Capacity { get; }
        private int _numOfPassengers = 0;

        public BusModel(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}
