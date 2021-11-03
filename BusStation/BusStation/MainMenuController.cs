using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class MainMenuController
    {
        private MainMenuView _menuView;

        public MainMenuController()
        {
            _menuView = new MainMenuView();
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            //табл.маршр для (зручносты і наглядності)
            ShowTripsTable();
            Console.WriteLine();

            _menuView.ShowHeader();
            _menuView.ShowMenu();
        }

        public void ShowTripsTable()
        {
            _menuView.ShowTripsTable(TripsStorage.Trips);
        }

        //мій метод що буде виводити переданий список маршрутів через параметер
        //(передбачається що список буде вже відфільтрований по заданик критеріям)
        public void ShowTripsTable(List<TripModel> trips)
        {
            _menuView.ShowTripsTable(trips);
        }


    }
}
