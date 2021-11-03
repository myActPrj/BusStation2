using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    //клас що буде мати набір всіх ф-й для маніпулювання данними маршрутів Trip
    public class newTripController
    {
        //List<TripModel> 
        //ф-я універсальний фільтр данних Trips
        //при виклику може немати параметрів взагалі
        //або за допомогою явної передачі (з вказаням назви параметрів) Filter(Bus:="Bohdan")  Filter(id:= 3, Bus:="Bohdan") 
        public static int Filter(
            List<TripModel> trips,
            ref List<TripModel> resultTrips,

            int id = -1,
            //DateTime departureTime = default(DateTime),
            MyDateTimeComparator departureTime = null,

            string tripFrom = null,

            //DateTime arrivalTime = default(DateTime),
            MyDateTimeComparator arrivalTime = null,

            string tripTo = null,

            BusModel bus = null,
            MyIntComparator busCapacity = null,
            
            //double ticketPrice = -1
            MyDoubleComparator ticketPrice=null

            )
        {
            //private List<TripModel> resultTrip;

            //один великий цикл з всіма умаовами для полів TripModel на співпадіння
            foreach (var trip in trips)
            {
                //признак співпадіння однієї з ознак добавлення, для виконання самої кінцевої умови добавлення в список, після ряду перевірок
                bool _addTrip = true;   // по замовчуванню true-тобто елемент списка добавляєм, реалізуєм логіку AND при комбінації декількох умов


                if (id != -1)      //1-ша умова на перевірку дефолтного значення (чи данне поле взагалі приймає учатся в)
                {
                    if (trip.Id == id)  //2-га умова перевірка ітератора на співпадіння з переданим параметром в супер ф-ю фільтрації Filter
                    {
                        _addTrip &= true; //реалізуєм логіку AND при комбінації декількох умов записом "_addTrip &= true"
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }

                //if (trip.DepartureTime == departureTime)
                //{
                //    addTrip = true;
                //}
                if (departureTime != null)
                {
                    if (departureTime.Compare(trip.DepartureTime, trip.DepartureTime))
                    {
                        _addTrip &= true;
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }

                if(tripFrom != null)
                { 
                    if (trip.TripFrom == tripFrom)
                    {
                        _addTrip &= true;
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }
                //if (trip.ArrivalTime == arrivalTime)
                //{
                //    addTrip = true;
                //}
                if (arrivalTime != null)
                {
                    if (arrivalTime.Compare(trip.ArrivalTime,trip.ArrivalTime))
                    {
                        _addTrip &= true;
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }

                if (tripTo != null)
                {
                    if (trip.TripTo == tripTo)
                    {
                        _addTrip &= true;
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }

                //if (trip.Bus == bus)
                //{
                //    addTrip = true;

                //}
                if (busCapacity != null)
                {
                    if (busCapacity.Compare(trip.Bus.Capacity)) 
                    {
                        _addTrip &= true;
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }


                //if (trip.TicketPrice == ticketPrice)
                //{
                //    addTrip = true;
                //}
                if (ticketPrice != null)
                { 
                    if (ticketPrice.Compare(trip.TicketPrice))
                    {
                        _addTrip &= true;
                    }
                    else
                    {
                        _addTrip = false;
                    }
                }



                // маршрут відповіжає всіс критеріям пошуку, добавляэм маршрут в список знайдених маршрутів
                if (_addTrip)
                {
                    resultTrips.Add(trip);
                }

            }

            return 0;
        }

        ////EqualityComparer()
        //private void EQ<T>(T tripField, T CompareVal) where T : TripModel, int //DateTime
        //{
        //    if ((int)tripField > (int)CompareVal)
        //    {

        //    }

        //    if ((T)tripField > (T)CompareVal)
        //    {

        //    }

        //    if (tripField == CompareVal)
        //    {

        //    }

        //}


        //основні операції
        //==
        //>
        //>=
        //<
        //<=



        public static string Eq(object a, object b)
        {
            if ((int)a == (int)b)
            {
                return "==";
            }

            // погано ресурсоемкая операция упаковка (boxing) и распаковка (unboxing).
            if ((int) a > (int)b)
            {
                return ">";
            }

            if ((int)a < (int)b)
            {
                return "<";
            }

            return "";
        }

        //public void Comparer<T>(T a, T b) where T : int
        //{
        //    T c = a;
        //    a = b;
        //    b = c;

        //    //if (a.Bus.Capacity > b.Bus.Capacity)
        //    //{

        //    //}
        //}



    }
    

}
