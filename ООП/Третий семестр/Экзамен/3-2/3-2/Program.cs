using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Park<Taxi> Uber = new Park<Taxi>();
            Uber.Add(new Taxi() { Number = 1, Position = new Location() { Lat = 12.3439493f, Long = 483.129849384f, Speed = 63.2f }, Status = Statuses.busy });
            Uber.Add(new Taxi() { Number = 2, Position = new Location() { Lat = 42.3439493f, Long = 452.129849384f, Speed = 0f }, Status = Statuses.free });
            Uber.Add(new Taxi() { Number = 3, Position = new Location() { Lat = 22.3439493f, Long = 495.129849384f, Speed = 44.2f }, Status = Statuses.free });
            Uber.Add(new Taxi() { Number = 4, Position = new Location() { Lat = 17.3439493f, Long = 457.129849384f, Speed = 68f }, Status = Statuses.busy });

            Console.WriteLine("---Введите свои координаты---");
            Location UserLocation = new Location();
            Console.Write("Широта: ");
            UserLocation.Lat = float.Parse(Console.ReadLine());
            Console.Write("Долгота: ");
            UserLocation.Long = float.Parse(Console.ReadLine());

            List<Taxi> taxis = new List<Taxi>(Uber.park);
            var TaxisToUser = taxis.OrderBy(x => Math.Sqrt(Math.Pow(x.Position.Lat - UserLocation.Lat, 2) + Math.Pow(x.Position.Long - UserLocation.Long, 2)));
            foreach (var taxi in TaxisToUser)
                Console.WriteLine(taxi.Number);

            using (FileStream sw = new FileStream("Taxi.bin", FileMode.Create))
            {
                //XmlSerializer xml = new XmlSerializer(TaxisToUser.First().GetType());
                //xml.Serialize(sw, TaxisToUser.First());
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(sw, TaxisToUser.First());
            }
        }
        [Serializable]
        public class Location
        {
            public float Lat { get; set; }
            public float Long { get; set; }
            public float Speed { get; set; }

        }
        [Serializable]
        public class Taxi
        {
            public int Number { get; set; }
            public Location Position { get; set; }
            public Statuses Status { get; set; }
        }
        [Serializable]
        public enum Statuses
        {
            busy,
            free
        }
        public class Park<T>
        {
            public List<T> park { get; } = new List<T>();
            public void Add(T obj)
            {
                park.Add(obj);
            }
            public void Remove(int index)
            {
                park.RemoveAt(index);
            }
            public void Clear()
            {
                park.Clear();
            }
            public T Find(Predicate<T> predicate)
            {
                foreach(var obj in park)
                {
                    if (predicate(obj))
                        return obj;
                }
                return default(T);
            }
        }
    }
}
