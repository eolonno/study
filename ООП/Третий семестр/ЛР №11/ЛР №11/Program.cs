using System;
using System.Collections.Generic;
using System.Linq;

namespace ЛР__11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> months = new List<string>
            {
                "Январь",
                "Февраль",
                "Март",
                "Апрель",
                "Май",
                "Июнь",
                "Июль",
                "Август",
                "Сентрябрь",
                "Октябрь",
                "Ноябрь",
                "Декабрь"
            };

            Console.WriteLine("Строки из 7 символов:");
            var answer = months.Where(x => x.Count() == 7);
            foreach (var a in answer)
                Console.WriteLine(a);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Летние месяцы:");
            answer = months.SkipWhile(x => x != "Июнь").Reverse().SkipWhile(x => x != "Август").Reverse();
            foreach (var a in answer)
                Console.WriteLine(a);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Зимние месяцы:");
            List<string> ans = new List<string>(months);
            ans.RemoveRange(2, 9);
            foreach (var a in ans)
                Console.WriteLine(a);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Сортировка по алфавиту:");
            answer = months.OrderBy(x => x);
            foreach (var a in answer)
                Console.WriteLine(a);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Содержащие букву \"а\" и размером не менее 4-х символов:");
            answer = months.Where(x => x.Contains('а')).Where(x => x.Length >= 4);
            foreach (var a in answer)
                Console.WriteLine(a);
            Console.WriteLine("--------------------------------------");

            List<Airline> Airline = new List<Airline>();
            Airline.Add(new Airline("Пекин", "21:50", "Четверг"));
            Airline.Add(new Airline("Сочи", "8:45", "Пятница"));
            Airline.Add(new Airline("Москва", "8:15", "Вторник"));
            Airline.Add(new Airline("Минск", "9:10", "Среда"));
            Airline.Add(new Airline("Париж", "12:32", "Суббота"));
            Airline.Add(new Airline("Париж", "18:46", "Среда"));
            Airline.Add(new Airline("Мюнхен", "20:20", "Четверг"));
            Airline.Add(new Airline("Париж", "7:20", "Пятница"));

            var ParisRaces = Airline.Where(x => x.getPlace().Contains("Париж"));
            Console.WriteLine("Рейсы в Париж:");
            foreach (var race in ParisRaces)
                race.print();
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Количество рейсов в среду: {0}", Airline.Where(x => x.getDayOfWeek().Contains("Среда")).Count());
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Рейс, который вылетает раньше всех в среду:");
            var MinTime = Airline.Where(x => x.getDayOfWeek().Contains("Среда")).Min(x => x.TimeIndex);
            var MinTimeObject = Airline.FirstOrDefault(a => a.TimeIndex == MinTime);
            MinTimeObject.print();
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Рейс, который вылетает в среду или пятницу раньше всех:");
            var MaxTime = Airline.Where(x => x.getDayOfWeek().Contains("Среда") || x.getDayOfWeek().Contains("Пятница")).Max(x => x.TimeIndex);
            var MaxTimeObject = Airline.FirstOrDefault(a => a.TimeIndex == MaxTime);
            MaxTimeObject.print();
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Список рейсов, упорядоченный по времени вылета: ");
            var OrderByTime = Airline.OrderBy(x => x.TimeIndex);
            foreach (var race in OrderByTime)
                race.print();
            Console.WriteLine("--------------------------------------");

            // Сложный запрос
            Console.WriteLine("Сложный запрос");
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 50, 100 };
            Console.WriteLine(Numbers.OrderByDescending(x => x).Skip(2).Append(55).Reverse().Aggregate((x, y) => x + y));
            Console.WriteLine("--------------------------------------");

            // Join
            Console.WriteLine("Join:");
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            var query = people.Join(pets, person => person, pet => pet.Owner, (person, pet) => new { OwnerName = person.Name, Pet = pet.Name });
            foreach (var obj in query)
            {
                Console.WriteLine("{0} - {1}", obj.OwnerName, obj.Pet);
            }
            Console.WriteLine("--------------------------------------");
        }
        class Person
        {
            public string Name { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }
    }
}
