using System;
using System.Collections.Generic;
using System.IO;

namespace ЛР__8
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<int> arr1 = new CollectionType<int>(3);
            CollectionType<int> arr2 = new CollectionType<int>(3);
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr2[0] = 1;
            arr2[1] = 2;
            arr2[2] = 3;
            arr1.SaveAsFile();
            arr2.SaveAsFile();
        }
        interface IMain<T> where T : struct
        {
            public void Add(T index);
            public void Delete(T index);
            public void Print(T index);
        }
        class Owner
        {
            public string name;
            public string organization;
            public uint id;
        }
        class CollectionType<T> : IMain<int>
        {
            private Owner person = new Owner { name = "Yegor", organization = "BELSTU", id = 0 };
            private Date date = new Date { date = (DateTime.Now).ToString() };
            private T[] array;
            private uint size;
            public T this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    array[index] = value;
                }
            }
            public CollectionType(uint Size)
            {
                array = new T[Size];
                size = Size;
            }

            public static double operator -(CollectionType<T> arr1, CollectionType<T> arr2)
            {
                T diff;
                double sum1 = 0, sum2 = 0;
                for (int i = 0; i < arr1.size; i++)
                    sum1 += Convert.ToDouble(arr1[i]);
                for (int i = 0; i < arr2.size; i++)
                    sum2 += Convert.ToDouble(arr2[i]);
                return sum1 - sum2;
            }

            public static bool operator >(T e, CollectionType<T> arr)
            {
                for (int i = 0; i < arr.size; i++)
                    if (Convert.ToDouble(e) == Convert.ToDouble(arr[i]))
                        return true;
                return false;
            }
            public static bool operator <(T e, CollectionType<T> arr2)
            { return false; }

            public static bool operator !=(CollectionType<T> arr1, CollectionType<T> arr2)
            {
                if (arr1.size != arr2.size)
                    return true;
                for (int i = 0; i < arr1.size; i++)
                    if (Convert.ToDouble(arr1[i]) != Convert.ToDouble(arr2[i]))
                        return true;
                return false;
            }
            public static bool operator ==(CollectionType<T> arr1, CollectionType<T> arr2)
            {
                if (arr1.size != arr2.size)
                    return false;
                for (int i = 0; i < arr1.size; i++)
                    if (Convert.ToDouble(arr1[i]) != Convert.ToDouble(arr2[i]))
                        return false;
                return true;
            }

            public static CollectionType<T> operator +(CollectionType<T> arr1, CollectionType<T> arr2)
            {
                CollectionType<T> arr = new CollectionType<T>(arr1.size + arr2.size);
                int i = 0;
                for (; i < arr1.size; i++)
                    arr[i] = arr1[i];
                for (; i < arr2.size + arr1.size; i++)
                    arr[i] = arr2[i - Convert.ToInt32(arr1.size)];
                return arr;
            }

            public void Delete(int index)
            {
                for (int i = index, j = i + 1; i < size - 1; i++, j = i + 1)
                    this[i] = this[j];
                //this[Convert.ToInt32(size) - 1] = null;
                size--;
            }
            public void Add(int index)
            {
                return;
            }
            public void Print(int index)
            {
                return;
            }
            class Date
            {
                public string date;
            }
            public void SaveAsFile()
            {
                string Message = $"Владелец: {person.name}\nID владельца: {person.id}\nОрганизация: {person.organization}\nМассив: " ;
                foreach (T a in array)
                    Message += a + " ";
                Message += "\n---------------------------------------------------------\n";
                File.AppendAllText("D:\\Учеба\\ООП\\ЛР №8\\INFO.txt", Message);
            }
        }

        class Figure
        {
            public int size { get; set; }
            public string color { get; set; }
        }
        class FiguresControl<T> where T : Figure
        {
            public virtual void show()
            {
                Console.Write("Фигура: ");
            }
            public void resize(T Figure)
            {
                Console.Write("Введите размер: ");
                Figure.size = Convert.ToInt32(Console.ReadLine());
            }
            public void input(T Figure)
            {
                Figure.color = Console.ReadLine();
            }
            public void printSize(T Figure)
            {
                Console.WriteLine($"Размер: {Figure.size}");
            }

            public override string ToString()
            {
                return "Использован метод ToString()";
            }
        }
    }
}
