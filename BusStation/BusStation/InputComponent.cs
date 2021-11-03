using System;


namespace BusStation
{
    public class InputComponent
    {
        public int GetInputInt()
        {
            bool isParsed;
            int result;
            do
            {
                Console.WriteLine("Enter integer, and press Enter");
                var userChoice = Console.ReadLine();
                isParsed = int.TryParse(userChoice, out result);
            } while (!isParsed);
            return result;
        }

        //введення даних так як в "GetInputInt()" але без повідомлення "Enter integer, and press Enter"
        public int GetInputInt2()
        {
            bool isParsed;
            int result;
            do
            {
                //Console.WriteLine("Enter integer, and press Enter");
                var userChoice = Console.ReadLine();
                isParsed = int.TryParse(userChoice, out result);
            } while (!isParsed);
            return result;
        }

        public String GetInputString()
        {
            //bool isParsed;
            //int result;
            //do
            //{
                //Console.WriteLine("Enter integer, and press Enter");
                var userChoice = Console.ReadLine();
                //isParsed = int.TryParse(userChoice, out result);
            //} while (!isParsed);
            //return result;
            return userChoice;

        }


    }
}
