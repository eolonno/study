using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop Evroopt = new Shop("Евроопт");

            Evroopt.Add(new Item("Кока-кола 2л", 3.09f));
            Evroopt.Add(new Item("Спрайт 1л", 1.79f));
            Evroopt.Add(new Item("Фанта 0.5л", 1.19f));

            Console.WriteLine("Магазин: " + Evroopt);
            foreach(var item in Evroopt)
                Console.WriteLine(item.Name + ":\t" + item.Price + " BYN");

            var Enumerator = Evroopt.GetEnumerator();
            Enumerator.MoveNext();
            Manager.Sale += new Manager.SaleHandler(Enumerator.Current.OnSale);
            Enumerator.MoveNext();
            Manager.Sale += new Manager.SaleHandler(Enumerator.Current.OnSale);

            Console.WriteLine("---------------РАСПРОДАЖА---------------");
            Manager.CommandSale();
            Console.WriteLine("Магазин: " + Evroopt);
            foreach (var item in Evroopt)
                Console.WriteLine(item.Name + ":\t" + item.Price + " BYN");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Linq запрос: " + Evroopt.Where(x => x.Name == "Фанта 0.5л").Select(x => x.Price).First());
        }
        class Item
        {
            public Item(string name, float price)
            {
                ID = ++id;
                Name = name;
                Price = price;
            }
            private static int id = 0;
            public string Name { get; set; }
            public int ID { get; set; }
            public float Price { get; set; }

            public void OnSale()
            {
                Price = (float)Math.Round(Price / 2 , 2);
            }
        }
        class Shop : IEnumerable<Item>
        {
            public Shop(string name)
            {
                Name = name;
            }
            public string Name { get; }

            private Queue<Item> Items = new Queue<Item>();
            public void Add(Item item)
            {
                Items.Enqueue(item);
            }
            public Item Remove()
            {
                return Items.Dequeue();
            }
            public void Clear()
            {
                Items.Clear();
            }

            public IEnumerator<Item> GetEnumerator()
            {
                return Items.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Items.GetEnumerator();
            }
            public override string ToString()
            {
                return Name;
            }
            public override bool Equals(object obj)
            {
                return ((Shop)obj).Name == Name;
            }
            public static Shop operator +(Shop shop, Item item)
            {
                shop.Add(item);
                return shop;
            }
            public static Shop operator -(Shop shop, Item item)
            {
                shop.Remove();
                return shop;
            }

        }
        public static class Manager
        {
            public delegate void SaleHandler();
            public static event SaleHandler Sale;
            public static void CommandSale()
            {
                Sale();
            }
        }
    }
}
