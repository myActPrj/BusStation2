using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class MainMenuView
    {
        public void ShowHeader()
        {
            Console.WriteLine("Hello brodyaga, how can I help you?");
        }

        public void ShowTripsTable(List<TripModel> trips)
        {
            ShowTripsHeader();
            foreach (var oneTrip in trips)
            {
                //Console.WriteLine($"{oneTrip.Id} : {oneTrip.DepartureTime.ToShortDateString()} : {oneTrip.TripFrom} .....");
                Console.WriteLine($"{oneTrip.Id,3} | {oneTrip.DepartureTime.ToShortDateString(),12} | {oneTrip.TripFrom,8}" +
                    $" | {oneTrip.ArrivalTime.ToShortDateString(),12} | {oneTrip.TripTo,8} | {oneTrip.Bus.Name,8} | {oneTrip.Bus.Capacity,13} | {oneTrip.TicketPrice,4}");
                    
            }
        }

        public void ShowMenu()
        {
            //Console.WriteLine("1 - Show all");
            //Console.WriteLine("2 - Find by Id");
            //Console.WriteLine("3 - Find by destination");

            //Хочу свою російськомовну менюшку
            Console.WriteLine("1 - Показати всі рейси");
            Console.WriteLine("2 - Знайти рейс по вказаному номеру");               //(по номеру 1)
            Console.WriteLine("3 - Знайти рейс по місцю кінцевого призначення");    //(по місцю 'Дніпро')
            Console.WriteLine("4 - Показати рейси на сьогодні. (1 січня 22р)");
            Console.WriteLine("5 - Показати рейси на найближчих 7 днів");
            Console.WriteLine("6 - Показати рейси дешевші за 600 грн");
            Console.WriteLine("7 - Показати рейси на які є вільні місця");
            Console.WriteLine("8 - Показати всі рейси що по маршруту Kurvamat-Ternopil, на 13.01.2022-15.01.2022, мають вільні місця і дешевші 1500");
            
            Console.WriteLine("9 - Exit application");
        }

        private void ShowTripsHeader()
        {
            //Console.WriteLine("N     DEPARTURE      FROM     .....");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"N",3} | {"DEPARTURE",12} | {"FROM", 8} | {"ArrivalTime",12} | {"TripTo",8} | {"Bus.Name",8} | {"Bus.Capacity",13} | {"PRICE",4}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // виведення напису з проханням натиснути любу клавішу
        public static void PrintTextWaitAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Please press any key to countinue...");
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
