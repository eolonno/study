using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ЛР__12
{
    public class Airline
    {
        // Объявление свойств
        static int counter;
        private string place;
        private int num;
        private string time;
        private string dayOfWeek;
        public int[] TimeArr = new int[2];
        public int TimeIndex { get; private set; }
        private int _ID { get; }
        public int ID
        {
            get { return _ID; }
        }
        private int _Number { get; set; }
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        private int _forSet { get; set; }
        public int forSet
        {
            set { _forSet = value; }
        }

        const double PI = Math.PI;

        static int forStatic;

        // Конуструктор с проверкой данных
        public Airline(string Place, string Time, string DayOfWeek)
        {
            Regex TimeRegex = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
            if (TimeRegex.Matches(Time).Count > 0)
            {
                switch (DayOfWeek)
                {
                    case "Понедельник": dayOfWeek = DayOfWeek; break;
                    case "Вторник": dayOfWeek = DayOfWeek; break;
                    case "Среда": dayOfWeek = DayOfWeek; break;
                    case "Четверг": dayOfWeek = DayOfWeek; break;
                    case "Пятница": dayOfWeek = DayOfWeek; break;
                    case "Суббота": dayOfWeek = DayOfWeek; break;
                    case "Воскресенье": dayOfWeek = DayOfWeek; break;
                    default: return;
                }
                place = Place;
                time = Time;

                if (time.Length == 5)
                    TimeIndex = 1000 * (time[0] - 48) + 100 * (time[1] - 48) + 10 * (time[3] - 48) + time[4] - 48;
                else
                    TimeIndex = 100 * (time[0] - 48) + 10 * (time[2] - 48) + time[3] - 48;
            }
            else return;
            counter++;
        }

        // Конструктор с двуми параметрами
        public Airline(int Num, string Place)
        {
            num = Num;
            place = Place;
            time = "10:00";
            dayOfWeek = "Вторник";
        }

        // Конструктор без параметров
        public Airline()
        {
            place = "Тбилиси";
            num = 2;
            time = "13:25";
            dayOfWeek = "Суббота";
            counter++;
        }

        // Статический конструктор
        static Airline()
        {
            forStatic = 12;
            counter++;
        }

        // Закрытый конструктор
        private Airline(int Num)
        {
            _ID = GetHashCode();
        }

        // Интерфейс
        public string getPlace() { return place; }
        public string getTime() { return time; }
        public string getDayOfWeek() { return dayOfWeek; }
        public int getNum() { return num; }
        public int getForStatic() { return forStatic; }

        public void Func(ref int val1, out int val2)
        {
            //val1 = 5;
            Console.WriteLine(val1);
            val2 = 10; // Обязательно
            Console.WriteLine(val2);
        }
        public static void printCounter()
        {
            Console.WriteLine("Количество экземплятров класса: " + counter);
        }
        public void print()
        { Console.WriteLine($"{getDayOfWeek()}\t{getTime()}\t{getPlace()}"); }
    }

}
