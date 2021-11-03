using System;

namespace BusStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var mainController = new MainController();
            while (true)
            {
                mainController.Run();
            }

            //Console.WriteLine(TripController.Eq(2,2));
            //Console.ReadLine();
        }
    }
}
