using System;
using System.Buffers;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

namespace ЛР__4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<int> arr1 = new MyArray<int>(3);
            MyArray<int> arr2 = new MyArray<int>(3);
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr2[0] = 1;
            arr2[1] = 2;
            arr2[2] = 3;
            Console.WriteLine($"Включена ли 2 в первый массив: {2 > arr1}");
            Console.WriteLine($"Включена ли 5 во второй массив: {5 > arr2}");
            Console.WriteLine($"Не равны ли массивы: {arr1 != arr2}");

            MyArray<int> arr = new MyArray<int>((arr1 + arr2).Size());
            arr = arr1 + arr2;
            Console.Write("Объединение массивов: ");
            for (int i = 0; i < arr.Size(); i++)
                Console.Write(arr[i] + " ");
            arr.DeleteFirstFive();
            Console.Write("\nОбъединенный массив после удаления пяти первых элементов: ");
            for (int i = 0; i < arr.Size(); i++)
                Console.Write(arr[i] + " ");
        }
    }
    class Owner
    {
        public string name;
        public string organization;
        public uint id;
    }
 
    class MyArray<T>
    {
        private Owner person = new Owner { name = "Yegor", organization = "BELSTU", id = 0 };
        private Date date = new Date {date = (DateTime.Now).ToString() };
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
        public MyArray(uint Size)
        {
            this.array = new T[Size];
            size = Size;
        }

        public static double operator -(MyArray<T> arr1, MyArray<T> arr2)
        {
            T diff;
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < arr1.size; i++)
                sum1 += Convert.ToDouble(arr1[i]);
            for (int i = 0; i < arr2.size; i++)
                sum2 += Convert.ToDouble(arr2[i]);
            return sum1 - sum2;
        }

        public static bool operator >(T e, MyArray<T> arr)
        {
            for (int i = 0; i < arr.size; i++)
                if (Convert.ToDouble(e) == Convert.ToDouble(arr[i]))
                    return true;
            return false;
        }
        public static bool operator <(T e, MyArray<T> arr2)
        { return false; }

        public static bool operator !=(MyArray<T> arr1, MyArray<T> arr2)
        {
            if (arr1.size != arr2.size)
                return true;
            for (int i = 0; i < arr1.size; i++)
                if (Convert.ToDouble(arr1[i]) != Convert.ToDouble(arr2[i]))
                    return true;
            return false;
        }
        public static bool operator ==(MyArray<T> arr1, MyArray<T> arr2)
        {
            if (arr1.size != arr2.size)
                return false;
            for (int i = 0; i < arr1.size; i++)
                if (Convert.ToDouble(arr1[i]) != Convert.ToDouble(arr2[i]))
                    return false;
            return true;
        }

        public static MyArray<T> operator +(MyArray<T> arr1, MyArray<T> arr2)
        {
            MyArray<T> arr = new MyArray<T>(arr1.size + arr2.size);
            int i = 0;
            for (; i < arr1.size; i++)
                arr[i] = arr1[i];
            for (; i < arr2.size + arr1.size; i++)
                arr[i] = arr2[i-Convert.ToInt32(arr1.size)];
            return arr;
        }

        public void VowelsRemove()
        {
            string vowels = "уеыаоэяиюeyuioa";
            for(int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                    if (Convert.ToChar(this[i]) == vowels[j])
                        this.Delete(i);
            }

        }

        public void DeleteFirstFive()
        {
            uint count = this.size > 5 ? 5 : this.size;
            for (int i = 0; i < count; i++)
                this.Delete(i);
        }

        private void Delete(int index)
        {
            for (int i = index, j = i + 1; i < this.size - 1; i++, j = i + 1)
                this[i] = this[j];
            //this[Convert.ToInt32(size) - 1] = null;
            this.size--;
        }

        public uint Size() { return size; }

        class Date
        {
            public string date;
        }

    }
    static class StaticOperation
    {
        static public int Sum(this MyArray<int> arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Size(); i++)
                sum += arr[i];
            return sum;
        }

        static public int Diff(this MyArray<int> arr)
        {
            int max = arr[0], min = arr[0];
            for (int i = 0; i < arr.Size(); i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }
            return max - min;
        }

        static public int Size(this MyArray<int?> arr)
        {
            int counter = 0;

            while (arr[counter] != null)
                counter++;
            return --counter;
        }
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}
