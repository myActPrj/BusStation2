using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{

    // клас набір довлільних умов порівннянн над більшістю типами
    public class MyComparators
    {
        // основні операції порівняння 
        public enum OperationCompare
        {
            Err,
            NEQ,    // "!="
            EQ,     // "=="
            More,   // ">"
            Less,   // "<"
            EQMore, // ">="
            EQLess  // "<="
        };

        // основні операції порівняння з string в Типы перечислений OperationCompare (що буде крутитись в умові що в циклі перебору записів - int швидше)
        public OperationCompare getOperatorCompare(string oper)
        {
            OperationCompare result = OperationCompare.Err;
            switch (oper)
            {
                case "!=":
                    result = OperationCompare.NEQ;
                    break;
                case "==":
                    result = OperationCompare.EQ;
                    break;
                case ">":
                    result = OperationCompare.More;
                    break;
                case "<":
                    result = OperationCompare.Less;
                    break;
                case ">=":
                    result = OperationCompare.EQMore;
                    break;
                case "<=":
                    result = OperationCompare.EQLess;
                    break;

                default:
                    Console.WriteLine($"Error Uncnovn compare operator {oper}");
                    //корректна обработка Error ненеделана
                    break;
            }
            return (result);
        }
    }



    //  клас що буде виконувати порівняння дати з по вказаній умові, так і брати діапазон двох дат
    public class MyDateTimeComparator : MyComparators
    {
        private OperationCompare _operation1; // !=, ==, >, <, >=, <=
        private DateTime _dateTime1;

        // дата та умов для представлення діапазону дат
        private OperationCompare _operation2; // !=, ==, >, <, >=, <=
        private DateTime _dateTime2;

        private bool _compareMode2Diapazone = false;

        //-----------------
        //конструктори
        //-----------------
        //конструктор на одну дату
        //приймає 2-ва параметра: 
        //     1 параметер умови порівняння (!=, ==, >, <, >=, <=)
        //     2 параметер поле дати для порівняння
        public MyDateTimeComparator(string operation1, DateTime dateTime1)
        {
            _operation1 = getOperatorCompare(operation1);
            _dateTime1 = dateTime1;
        }

        //конструктор на діапазан дат ("з такогото числа по таке")
        //приймає 4-ри параметра: 
        //     1 параметер умови порівняння 1 (!=, ==, >, <, >=, <=)
        //     2 параметер поле дати для порівняння 1
        //     3 параметер умови порівняння 2 (!=, ==, >, <, >=, <=)
        //     4 параметер поле дати для порівняння 2
        public MyDateTimeComparator(string operation1, DateTime dateTime1, string operation2, DateTime dateTime2)
        {
            _operation1 = getOperatorCompare(operation1);
            _dateTime1 = dateTime1;
            _operation2 = getOperatorCompare(operation2);
            _dateTime2 = dateTime2;

            _compareMode2Diapazone = true;   // диапазон дат между двумя значениями
        }
        ///-----------------


        // публична ф-я перевірки на виконання умови
        // цей метод буде викликатись в циклі іншого класу беручи кожне значення, переданого через параметер
        // і виконувати перевірку по параметрам що вказані в конструкторі (опереція порівняння >, <... та значення дати з якою порівнювати)
        //
        // це дозволить зробити крутий запис перевірки умови в іншому місці ( наприклад перевірка часового діапазону за 7-м днів)
        // (..., departureTime: new MyDateTimeComparator(">=", DateTime(2021, 01, 01), "<=", DateTime(2021, 01, 01) ), ...) ;

        // 1-й параметер: значення дати в циклі порівняння
        // 2-й параметер може бути не обовязковим, залежно від конструктора: значення дати в циклі порівняння
        public bool Compare(DateTime compRecord, DateTime compRecord2 = default(DateTime))
        {
            bool result;

            //перевірка відповідності умови для 1-ї межі
            result = compare(_operation1, compRecord, _dateTime1);

            // виконуэмо перевірку на 2-гу межу обмеження дати, якщо попередній результат  перевірки був true
            if (_compareMode2Diapazone && result)
            {
                result = compare(_operation2, compRecord2, _dateTime2);
            }

            return result;
        }

        private bool compare(OperationCompare oper, DateTime dateTime1, DateTime dateTime2)
        {
            switch (oper)
            {
                case OperationCompare.NEQ:
                    return (dateTime1 != dateTime2 ? true : false);
                    break;
                case OperationCompare.EQ:
                    return (dateTime1 == dateTime2 ? true : false);
                    break;
                case OperationCompare.More:
                    return (dateTime1 > dateTime2 ? true : false);
                    break;
                case OperationCompare.Less:
                    return (dateTime1 < dateTime2 ? true : false);
                    break;
                case OperationCompare.EQMore:
                    return (dateTime1 >= dateTime2 ? true : false);
                    break;
                case OperationCompare.EQLess:
                    return (dateTime1 <= dateTime2 ? true : false);
                    break;
            }
            return false;
        }

    }


    //  клас що буде виконувати порівняння дати з по вказаній умові, так і брати діапазон двох дат

    //public class MyAnyNumberComparator<T> : MyComparators  - НЕПОЛУЧАЭТСЯ над типом <T> робити операції !=, ==, >, <, >=, <=

    public class MyDoubleComparator : MyComparators
    {
        private OperationCompare _operation1; // !=, ==, >, <, >=, <=
        private double _doubleVal1;

        // дата та умов для представлення діапазону дат
        private OperationCompare _operation2; // !=, ==, >, <, >=, <=
        private double _doubleVal2;

        private bool _compareMode2Diapazone = false;

        //-----------------
        //конструктори
        //-----------------
        //конструктор на одну дату
        //приймає 2-ва параметра: 
        //     1 параметер умови порівняння (!=, ==, >, <, >=, <=)
        //     2 параметер поле дати для порівняння
        public MyDoubleComparator(string operation1, double doubleVal1)
        {
            _operation1 = getOperatorCompare(operation1);
            _doubleVal1 = doubleVal1;
        }

        //конструктор на діапазан дат ("з такогото числа по таке")
        //приймає 4-ри параметра: 
        //     1 параметер умови порівняння 1 (!=, ==, >, <, >=, <=)
        //     2 параметер поле дати для порівняння 1
        //     3 параметер умови порівняння 2 (!=, ==, >, <, >=, <=)
        //     4 параметер поле дати для порівняння 2
        public MyDoubleComparator(string operation1, double doubleVal1, string operation2, double doubleVal2)
        {
            _operation1 = getOperatorCompare(operation1);
            _doubleVal1 = doubleVal1;
            _operation2 = getOperatorCompare(operation2);
            _doubleVal2 = doubleVal2;

            _compareMode2Diapazone = true;   // диапазон дат между двумя значениями
        }
        ///-----------------


        // публична ф-я перевірки на виконання умови
        // цей метод буде викликатись в циклі іншого класу беручи кожне значення, переданого через параметер
        // і виконувати перевірку по параметрам що вказані в конструкторі (опереція порівняння >, <... та значення дати з якою порівнювати)
        //
        // 
        //
        // 
        //
        public bool Compare(double compRecord, double compRecord2 = -1)
        {
            bool result;

            //перевірка відповідності умови для 1-ї межі
            result = compare(_operation1, compRecord, _doubleVal1);

            // виконуэмо перевірку на 2-гу межу обмеження дати, якщо попередній результат  перевірки був true
            if (_compareMode2Diapazone && result)
            {
                result = compare(_operation2, compRecord2, _doubleVal2);
            }

            return result;
        }

        private bool compare(OperationCompare oper, double doubleVal1, double doubleVal2)
        {
            switch (oper)
            {
                case OperationCompare.NEQ:
                    return (doubleVal1 != doubleVal2 ? true : false);
                    break;
                case OperationCompare.EQ:
                    return (doubleVal1 == doubleVal2 ? true : false);
                    break;
                case OperationCompare.More:
                    return (doubleVal1 > doubleVal2 ? true : false);
                    break;
                case OperationCompare.Less:
                    return (doubleVal1 < doubleVal2 ? true : false);
                    break;
                case OperationCompare.EQMore:
                    return (doubleVal1 >= doubleVal2 ? true : false);
                    break;
                case OperationCompare.EQLess:
                    return (doubleVal1 <= doubleVal2 ? true : false);
                    break;
            }
            return false;
        }

    }




    //departureTime: depTime_Begin);
    //(..., departureTime: new dateTimeComparator(">=",depTime_Begin,"and" ,"<=", depTime_End ), ...) ;
    //(..., departureTime: new dateTimeComparator(">=", depTime_Begin), ...) ;

    //(..., departureTime: new IntComparator(">=", intVal1,"and" ,"<=", intVal2 ), ...) ;
    //(..., departureTime: new IntComparator(">=", intVal1), ...) ;


    //(..., departureTime: new StrComparator("==", intVal1,"and" ,"<=", intVal2 ), ...) ;
    //(..., departureTime: new StrComparator("==", intVal1), ...) ;



    //MyDateTimeComparator cmp = new MyDateTimeComparator("<=", new DateTime(2021, 01, 01));

    //DateTime dt = new DateTime(2021, 01, 02);
    //Console.WriteLine(   cmp.Compare(dt) );


    //MyIntComparator cmp = new MyIntComparator("<=", 400);
    //Console.WriteLine(cmp.Compare(400) );

    //        int[] aInt = { 300, 400, 500 };

    //        foreach (var item in aInt)
    //        {
    //            Console.WriteLine( $" item={item} : compare={cmp.Compare(item)}");
    //        }





    public class MyIntComparator : MyComparators
    {
        private OperationCompare _operation1; // !=, ==, >, <, >=, <=
        private int _intVal1;

        // дата та умов для представлення діапазону дат
        private OperationCompare _operation2; // !=, ==, >, <, >=, <=
        private int _intVal2;

        private bool _compareMode2Diapazone = false;

        //-----------------
        //конструктори
        //-----------------
        //конструктор на одну дату
        //приймає 2-ва параметра: 
        //     1 параметер умови порівняння (!=, ==, >, <, >=, <=)
        //     2 параметер поле дати для порівняння
        public MyIntComparator(string operation1, int intVal1)
        {
            _operation1 = getOperatorCompare(operation1);
            _intVal1 = intVal1;
        }

        //конструктор на діапазан дат ("з такогото числа по таке")
        //приймає 4-ри параметра: 
        //     1 параметер умови порівняння 1 (!=, ==, >, <, >=, <=)
        //     2 параметер поле дати для порівняння 1
        //     3 параметер умови порівняння 2 (!=, ==, >, <, >=, <=)
        //     4 параметер поле дати для порівняння 2
        public MyIntComparator(string operation1, int intVal1, string operation2, int intVal2)
        {
            _operation1 = getOperatorCompare(operation1);
            _intVal1 = intVal1;
            _operation2 = getOperatorCompare(operation2);
            _intVal2 = intVal2;

            _compareMode2Diapazone = true;   // диапазон дат между двумя значениями
        }
        ///-----------------


        // публична ф-я перевірки на виконання умови
        // цей метод буде викликатись в циклі іншого класу беручи кожне значення, переданого через параметер
        // і виконувати перевірку по параметрам що вказані в конструкторі (опереція порівняння >, <... та значення дати з якою порівнювати)
        //
        // 
        //
        // 
        //
        public bool Compare(int compRecord, int compRecord2 = -1)
        {
            bool result;

            //перевірка відповідності умови для 1-ї межі
            result = compare(_operation1, compRecord, _intVal1);

            // виконуэмо перевірку на 2-гу межу обмеження дати, якщо попередній результат  перевірки був true
            if (_compareMode2Diapazone && result)
            {
                result = compare(_operation2, compRecord2, _intVal2);
            }

            return result;
        }

        private bool compare(OperationCompare oper, int intVal1, int intVal2)
        {
            switch (oper)
            {
                case OperationCompare.NEQ:
                    return (intVal1 != intVal2 ? true : false);
                    break;
                case OperationCompare.EQ:
                    return (intVal1 == intVal2 ? true : false);
                    break;
                case OperationCompare.More:
                    return (intVal1 > intVal2 ? true : false);
                    break;
                case OperationCompare.Less:
                    return (intVal1 < intVal2 ? true : false);
                    break;
                case OperationCompare.EQMore:
                    return (intVal1 >= intVal2 ? true : false);
                    break;
                case OperationCompare.EQLess:
                    return (intVal1 <= intVal2 ? true : false);
                    break;
            }
            return false;
        }




    }

}