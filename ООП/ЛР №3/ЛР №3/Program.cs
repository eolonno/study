using System;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ЛР__3
{
    class Program
    {
        public partial class Airline
        {
            // Объявление свойств
            static int counter;
            private string place;
            private int num;
            private string time;
            private string dayOfWeek;
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
            public  Airline(string Place, string Time, string DayOfWeek, int Num = 5)
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
                    num = Num;
                    time = Time;
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
        }
        public partial class Airline
        {
            public void Write()
            {
                Console.WriteLine("Hello World!");
            }
        }

        // Вывод экземпляра класса
        static void print(Airline airline)
        { Console.WriteLine($"{airline.getNum()}\t{airline.getDayOfWeek()}\t{airline.getTime()}\t{airline.getPlace()}"); }

        // Поиск рейсов по заданному параметру
        // type - код параметра, по которому идет сортировка
        // 0 - по назначению
        // 1 - по дню недели
        static void find(Airline[] airlines, string condition, byte type)
        {
            if (type == 0)
                Console.WriteLine($"---Список рейсов для назначения: {condition}---");
            else if (type == 1)
                Console.WriteLine($"---Список рейсов для дня недели: {condition}---");
            foreach (Airline airline in airlines)
            {
                if (type == 0 && airline.getPlace() == condition)
                    print(airline);
                else if (type == 1 && airline.getDayOfWeek() == condition)
                    print(airline);

            }
            Console.WriteLine();
        }

        

        static void Main(string[] args)
        {
            Airline[] airlines = new Airline[5];
            airlines[0] = new Airline(1, "Минск");
            airlines[1] = new Airline();
            airlines[2] = new Airline("Пекин", "21:50", "Четверг", 3);
            airlines[3] = new Airline("Сочи", "8:45", "Пятница", 4);
            airlines[4] = new Airline("Минск", "22:10", "Суббота");

            find(airlines, "Суббота", 1);
            find(airlines, "Минск", 0);

            Console.WriteLine(airlines[0].getForStatic());
            airlines[0].Number = 9;
            Console.WriteLine(airlines[0].Number);
            Console.WriteLine(airlines[0].ID);
            airlines[0].forSet = 12;
            //Console.WriteLine(airlines[0].forSet); - нет прав
            int a = 10,
                b = 3;
            airlines[0].Func(ref a, out b);
            airlines[0].Write();
        }
    }
}
