using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class MainController
    {
        private readonly InputComponent _input;
        private readonly MainMenuController _menuController;

        public MainController()
        {
            _input = new InputComponent();
            _menuController = new MainMenuController();
        }

        public void Run()
        {
            _menuController.ShowMainMenu();
            var result = _input.GetInputInt();
            switch (result)
            {
                case 1:
                    _menuController.ShowTripsTable();
                    break;
                case 2:
                    //todo for example only
                    Console.Write("SHOW FIND BY ID: ");
                    var id = _input.GetInputInt2();

                    {
                        //список всіх маршрутів
                        List<TripModel> tripsAll = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        newTripController.Filter(tripsAll, ref tripsFind, id: id);

                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }

                    break;
                case 3:     //Знайти рейс по місцю кінцевого призначення(по місцю 'Дніпро')"

                    Console.Write("SHOW FIND BY TRIP TO: ");
                    var tripTo = _input.GetInputString();

                    { 
                        //список всіх маршрутів
                        List<TripModel> tripsAll = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        newTripController.Filter(tripsAll, ref tripsFind, tripTo: tripTo);

                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }
                    
                    break;

                case 4: //"4 - Показати рейси на сьогодні. (1 січня 22р)"
                    Console.Write("SHOW FIND BY DEPARTURE date: ");
                    //var departure = _input.GetInputDate();
                    DateTime departureTime = new DateTime(2022, 01, 01);
                        Console.WriteLine(departureTime.ToShortDateString());
                    {
                        //список всіх маршрутів
                        List<TripModel> tripsAll = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        //TripController.Filter(tripsBase, ref tripsFin_4, departureTime: departureTime);

                        // звісно роблячи пошук рейсів за день не корректно робити пошук по "==", правильніше пошук по діапазону, але для приклада піде
                        newTripController.Filter(tripsAll, ref tripsFind, departureTime: new MyDateTimeComparator("==", departureTime) );


                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }
                    break;

                case 5: //"5 - Показати рейси на найближчих 7 днів"
                    Console.Write("SHOW FIND BY DEPARTURE next 7 days: ");
                    //var departure = _input.GetInputDate();
                    DateTime depTime_Begin = new DateTime(2022, 01, 01);
                    DateTime depTime_End = depTime_Begin.AddDays(7);
                    Console.WriteLine($"{depTime_Begin.ToShortDateString()} - {depTime_End.ToShortDateString()}");
                    {
                        //список всіх маршрутів
                        List<TripModel> tripsAll = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        //TripController.Filter(tripsBase, ref tripsFin_4, departureTime: depTime_Begin);
                        newTripController.Filter(tripsAll, ref tripsFind, departureTime: new MyDateTimeComparator(">=", depTime_Begin,"<", depTime_End) );

                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }
                    break;

                case 6: //"6 - Показати рейси дешевші за 400 грн"
                    Console.Write("SHOW FIND BY Less Tisked Price <: ");
                    double price = 600f;
                    //price = _input.GetInputDate();

                    Console.WriteLine($" {price}grn");
                    {
                        //список всіх маршрутів
                        List<TripModel> tripsAll = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        //TripController.Filter(tripsBase, ref tripsFin_4, departureTime: depTime_Begin);
                        newTripController.Filter(tripsAll, ref tripsFind, ticketPrice: new MyDoubleComparator("<", price) );

                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }
                    break;


                case 7: //"7 - Показати рейси на які є вільні місця");
                    Console.Write("SHOW FIND BY Capasity is >: ");
                    int capacity = 0;
                    //capacity = _input.GetInputInt2();

                    Console.WriteLine($" {capacity}");
                    {
                        //список всіх маршрутів
                        List<TripModel> tripsAll = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        //TripController.Filter(tripsBase, ref tripsFin_4, departureTime: depTime_Begin);
                        newTripController.Filter(tripsAll, ref tripsFind, busCapacity: new MyIntComparator(">", capacity));

                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }
                    break;



                case 8: //"8 - Показати всі рейси що по маршруту Kurvamat-Ternopil, на 13.01.2022-15.01.2022, мають вільні місця і дешевші 1500");
                    Console.Write("SHOW FIND всі рейси що по маршруту Kurvamat-Ternopil, на 13.01.2022-15.01.2022, мають вільні місця і дешевші 1500 ");
                    Console.WriteLine();
                    {
                        //список всіх маршрутів
                        List<TripModel> tripsBase = TripsStorage.Trips;

                        //список відібраних маршрутів (заданним критеріям пошуку)
                        List<TripModel> tripsFind = new List<TripModel>();

                        //запуск ф-ї відбору
                        newTripController.Filter(tripsBase, ref tripsFind, 
                                            tripFrom: "Kurvamat", tripTo : "Ternopil",
                                            departureTime: new MyDateTimeComparator(">=",new DateTime(2022,01,13)),
                                            arrivalTime:   new MyDateTimeComparator("<=", new DateTime(2022,01,15)),
                                            ticketPrice:   new MyDoubleComparator("<",1500),
                                            busCapacity:   new MyIntComparator(">", 0));

                        //відображаємо на екрані табличку відібраних маршрутів
                        _menuController.ShowTripsTable(tripsFind);
                    }
                    break;


            }




            MainMenuView.PrintTextWaitAnyKey();
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
