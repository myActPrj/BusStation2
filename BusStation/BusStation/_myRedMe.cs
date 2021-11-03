//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusStation
//{
//    class _myRedMe
//    {
//    }

//}


//список класів та їх призначення
//спробував описати класи та їх призначення для чіткого розуміння програмних блоків
/*
    

    BusModel.cs     -  модель автобуса та кількість місць для даної моделі
    TripModel.cs    -  модель містить опис маршруту (id, дата-час місце відправлення та прибуття та назви мість, модель автобуса (BusModel.cs) , вартість квитка)
    TripsStorage.cs -  містить в собі набір всіх маршрутів, автостанції (маршрути у вигляді List<TripModel>)

    InputComponent.cs       - клас забезпечення вводу користувачем значень, та команд (набір ф-й команд та обробка некорректного вводу)

    MainMenuView.cs         -   безпосерередньо реалізація всії ф-й, що виконують виведення на екран (всі тексти надписів,..) 
    MainMenuController.cs   -   тільки виклик описаних ф-й в  MainMenuView.cs

    MainController.cs

    Program.cs
*/