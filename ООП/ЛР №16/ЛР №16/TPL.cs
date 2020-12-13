using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace ЛР__16
{
    public static class TPL
    {
        public static void ParallelVectorByNumber()
        {
            Stopwatch stopwatch = new Stopwatch();
            const int SomeNumber = 182;
            List<Task> Tasks = new List<Task>();
            Random rnd = new Random();
            BlockingCollection<int> Vector = new BlockingCollection<int>();

            for (int i = 0; i < 10; i++)
            {
                Tasks.Add(new Task(() =>
                {
                    for (int i = 0; i < 100000; i++)
                        Vector.Add(rnd.Next(1, 10000) * SomeNumber);
                }));
                
            }
            Console.WriteLine(Tasks[0].Status);
            stopwatch.Start();
            foreach (var task in Tasks)
                task.Start();
            Task.WaitAll(Tasks.ToArray());
            stopwatch.Stop();
            Console.WriteLine(Tasks[0].Status);

            Console.WriteLine("Количество тактов при использовании Task: " + stopwatch.ElapsedTicks);
        }
        public static void VectorByNumber()
        {
            Stopwatch stopwatch = new Stopwatch();
            const int SomeNumber = 182;
            List<int> Vector = new List<int>();
            Random rnd = new Random();

            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                Vector.Add(rnd.Next(1, 10000) * SomeNumber);   
            }
            stopwatch.Stop();

            Console.WriteLine("Количество тактов без использования Task: " + stopwatch.ElapsedTicks);
        }
        public static void ParallelVectorByNumberWithTocken()
        {
            const int SomeNumber = 182;
            List<Task> Tasks = new List<Task>();
            Random rnd = new Random();
            List<int> Vector = new List<int>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            for (int i = 0; i < 10; i++)
            {
                Tasks.Add(new Task(() =>
                {
                    for (int i = 0; i < 1000000; i++)
                        Vector.Add(rnd.Next(1, 10000) * SomeNumber);
                }, tokenSource.Token));

            }


            foreach (var task in Tasks)
                task.Start();
            tokenSource.Cancel();
            Console.WriteLine("Status: " + Tasks[5].Status);
        }
        public static void Continuation()
        {
            Task<double> task1 = Task.Run(() => {  return Math.Pow(2, 64); });
            Task<double> task2 = task1.ContinueWith(x => { return Math.Pow(264, 5) * x.Result; });
            Task task3 = task2.ContinueWith(x => { Console.WriteLine("Ответ: " + x.Result * 12); });
            task3.GetAwaiter().GetResult();
        }
        public static void ParallelFor()
        {
            BlockingCollection<int> Arr = new BlockingCollection<int>();
            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.For(0, 1000000, i => { Arr.Add(rnd.Next(1, 1000)); });
            stopwatch.Stop();

            Console.WriteLine("Parallel.For: \t" + stopwatch.ElapsedTicks + " ticks");

            stopwatch.Reset();
            stopwatch.Start();
            List<int> Array = new List<int>();
            for (int i = 0; i < 1000000; i++)
                Array.Add(rnd.Next(1, 1000));
            stopwatch.Stop();

            Console.WriteLine("For:\t\t" + stopwatch.ElapsedTicks + " ticks");
        }
        public static void ParallelInvoke()
        {
            Parallel.Invoke(() => { Console.WriteLine("First function"); }, () => { Console.WriteLine("Second function"); }, () => { Console.WriteLine("Third function"); });
        }
        private static Mutex mutex = new Mutex();
        public static void Shop()
        {
            Dictionary<int?, string> Product = new Dictionary<int?, string>();
            Product.Add(0, "Sofa");
            Product.Add(1, "Armchair");
            Product.Add(2, "Table");
            Product.Add(3, "Poster");
            Product.Add(4, "Stool");
            Product.Add(5, "Linoleum");
            Product.Add(6, "Bed");
            Product.Add(7, "Wallpaper");
            Product.Add(8, "Extension");
            Product.Add(9, "Window");

            BlockingCollection<int> Warehouse = new BlockingCollection<int>();
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        Thread.Sleep(rnd.Next(1000, 5000));
                        mutex.WaitOne();

                        int Counter = 0;
                        Warehouse.Add(rnd.Next(0, 9));
                        Console.WriteLine("Warehouse: ");
                        foreach (var product in Warehouse)
                        {
                            Console.WriteLine(Product[product]);
                            Counter++;
                        }
                        if (Counter == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Nothing");
                            Console.ResetColor();
                        }

                        Console.WriteLine("-------------------");
                        mutex.ReleaseMutex();
                        Thread.Sleep(rnd.Next(1000, 5000));
                    }
                });
            }
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        Thread.Sleep(rnd.Next(1000, 5000));
                        foreach (var product in Warehouse)
                        {
                            mutex.WaitOne();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Product[product] + " bought");
                            Console.ResetColor();
                            Console.WriteLine("-------------------");

                            int i = product;
                            int Counter = 0;
                            Warehouse.TryTake(out i);
                            Console.WriteLine("Warehouse: ");
                            foreach (var productt in Warehouse)
                            {
                                Console.WriteLine(Product[productt]);
                                Counter++;
                            }
                            if (Counter == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Nothing");
                                Console.ResetColor();

                            }
                            else
                                Counter = 0;
                            Console.WriteLine("-------------------");
                            mutex.ReleaseMutex();
                            break;
                        }
                    }
                });
            }
            Thread.Sleep(5000);
        }
        public static async void AsyncDemonstration()
        {
            await Task.Run(Continuation);
        }
    }
}
