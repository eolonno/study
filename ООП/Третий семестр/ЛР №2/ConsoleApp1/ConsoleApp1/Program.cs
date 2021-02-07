using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ТИПЫ

            // Инициализация переменных
            bool var1       = true;
            byte var2       = 255;
            sbyte var3      = -128;
            short var4      = -2000;
            ushort var5     = 102;
            int var6        = 2147483643;
            uint var7       = 0xFF; // 255
            long var8       = 0b101; // 5
            ulong var9      = 10;
            float var10     = 55.3f;
            double var11    = 193842397423749.91824;
            decimal var12   = -1.2334234m;
            char var13      = 'H';
            string var14    = "Hello World!";

            // Ввод строковой переменной
            Console.Write("Введите переменую: ");
            var14 = Console.ReadLine();
            Console.WriteLine();

            // Вывод переменных в консоль
            Console.WriteLine($"bool: \t\t{var1}\n" +
                              $"byte: \t\t{var2}\n" +
                              $"sbyte: \t\t{var3}\n" +
                              $"short: \t\t{var4}\n" +
                              $"ushort: \t{var5}\n" +
                              $"int: \t\t{var6}\n" +
                              $"uint: \t\t{var7}\n" +
                              $"long: \t\t{var8}\n" +
                              $"ulong: \t\t{var9}\n" +
                              $"float: \t\t{var10}\n" +
                              $"double: \t{var11}\n" +
                              $"decimal: \t{var12}\n" +
                              $"char: \t\t{var13}\n" +
                              $"string: \t{var14}\n");

            // Явные преобразования
            var6 = (int)var10;
            var11 = Convert.ToDouble(var2);
            //var1 = Convert.ToBoolean(var13);
            var14 = Convert.ToString(var13);

            // Неявные преобразования
            double d = 11.2;
            int i = 92;
            float f = 45.2f;
            byte b = 72;
            short s = 29;
            long l = 12;

            f = i;
            i = b;
            d = f;
            i = s;
            l = i;

            // Упаковка и распаковка
            i = 34;
            object o = i;
            int j = (int)o;

            // Неявно типизированные переменные
            var v = 5; // int
            var str = "Hello World!"; // string
            var a = new[] { 1, 2, 3 }; // array of int

            // Nullable
            int? x = null;
            x = 14;

            // Ошибка с var
            var h = 5;
            //h = 5.5f; // Невозможно так как предыдущая строка определила переменную h, как переменную типа int

            // СТРОКИ

            // Сравнение строк
            string stringHello = "Hello",
                   stringWorld = "World!";

            Console.WriteLine("Сравниваемые строки: \"" + stringHello + "\" и \"" + stringWorld + "\nРезультат сравнения: " + String.Compare(stringHello, stringWorld));
            // Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля. В противном случае возвращается число больше нуля. 
            // И третий случай - если строки равны, то возвращается число 0.


            string string1 = "Lorem ",
                   string2 = "ipsum ",
                   string3 = "dolor";

            Console.WriteLine("Сцепление: " + string1 + string2 + string3);

            string Lorem = "Lorem ipsum dolor sit amet.";

            // Разделение строки на подстроки
            Console.WriteLine("Разделение строки на подстроки:");
            string[] words = Lorem.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string c in words)
                Console.WriteLine(c);

            // Копирование строк
            string copyOfString1 = string1;

            // Выделение подстроки
            Console.Write("Выделение подстроки: ");
            for (int m = 0; m < 18; m++)
                Console.Write(Lorem[m]);
            Console.WriteLine(Lorem.Substring(18).ToUpper());

            // Вставка подстроки в строку
            string aaa = "aaaaa",
                   bbb = "bbbbb";
            Console.WriteLine("Вставка подстроки в строку: " + aaa.Insert(2, bbb));

            // Удаление подстроки
            string num = "0123456789";
            Console.WriteLine("Удаление подстроки: " + num.Remove(0, 5));

            // Интерполирование строк
            int one = 1,
                two = 2;
            Console.WriteLine($"Интерполирование строк: один - {one}, два - {two}");

            // Пустые и null строки
            string? nullString = null;
            string emptyString = "";
            if (String.IsNullOrEmpty(nullString))
                Console.WriteLine("Строка пустая или заполнена null-значением");

            Console.WriteLine(nullString ?? Lorem);

            // StringBuilder
            StringBuilder sb = new StringBuilder("Hello World!");
            Console.WriteLine("\n---StringBuilder---\nНачальная строка: " + sb);
            sb.Remove(0, 5);
            sb.AppendFormat("!!");
            sb.Insert(0, "Привет");
            Console.WriteLine("Строка после форматирования: " + sb);

            // МАССИВЫ

            // Создание и вывод матрицы
            int[,] arr = {
                {1,10},
                {2,20},
                {3,30},
                {4,40}
            };

            Console.WriteLine("Матрица:");
            for(int k = 0; k < 4; k++)
            {
                for (int n = 0; n < 2; n++)
                    Console.Write(arr[k, n] + "\t");
                Console.WriteLine();
            }

            // Одномерный массив строк
            string[] arrOfStr = { "Hello ", "World!" };
            foreach (string smth in arrOfStr)
                Console.WriteLine(smth);
            Console.WriteLine("Длина массива строк: " + arrOfStr.Length);
            Console.Write("Выберете индекс строки: ");
            int index = Convert.ToInt32((Console.ReadLine()));
            if (index != 0 && index != 1)
                Console.WriteLine("Введены неверные данные!");
            else
            {
                Console.Write("Введите строку: ");
                arrOfStr[index] = Console.ReadLine();
                Console.Write("Полученная строка: ");
                foreach (string smth in arrOfStr)
                    Console.Write(smth);
                Console.WriteLine();
            }

            // Ступенчатый массив
            int[][] steppedArray = new int[3][];
            steppedArray[0] = new int[2];
            steppedArray[1] = new int[3];
            steppedArray[2] = new int[4];
            for (i = 0; i < steppedArray.Length; i++)
                for (j = 0; j < steppedArray[i].Length; j++)
                {
                    Console.Write($"Введите число с координатами ({i},{j}): ");
                    steppedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Полученный массив: ");
            for (i = 0; i < steppedArray.Length; i++)
            {
                for (j = 0; j < steppedArray[i].Length; j++)
                    Console.Write(steppedArray[i][j] + "\t");
                Console.WriteLine();
            }

            // Неявно типизированные строки и массивы
            var varStr = "Hello World!";
            var varArr = new[] { 1, 2, 3, 4, 5 };


            // КОРТЕЖИ

            (int, string, char, string, ulong) t = (2, "Lorem", 'h', "ipsum", 234);
            Console.WriteLine($"Кортеж: {t.Item1}, {t.Item2}, {t.Item3}, {t.Item4}, {t.Item5}");
            Console.WriteLine($"1, 3 и 4 элементы кортежа: {t.Item1}, {t.Item3}, {t.Item4}");

            // Распаковка кортежей
            (int q, string w, char e, string r, ulong y) = t;
            int cortInt;
            string cortStr1, cortStr2;
            char cortChar;
            ulong cortUlong;
            (cortInt, cortStr1, cortChar, cortStr2, cortUlong) = t;
            var (c1, c2, c3, c4, c5) = t;

            // Не понял задание про (_), возможно имелось в виду
            int million = 1_000_000;
            // ref???

            // Сравнение кортежей 
            if ((0, 2) == (-1, 1))
                Console.WriteLine("Сравниваемые кортежи равны");
            else
                Console.WriteLine("Сравниваемые кортежи не равны");

            // Локальная функция, которая возвращает кортеж
            static (int, int, int, char) func(int[] arr, string str)
            {
                int min = arr[0],
                    max = arr[0],
                    sum = 0;
                foreach(int i in arr)
                {
                    if (i > max)
                        max = i;
                    if (i < min)
                        min = i;
                    sum += i;
                }
                return (max, min, sum, str[0]);
            }

            var returnedCort = func(new int[]{1,2,3,4,5}, "Hello");

            // checked/unchecked
            static void checkedFunc()
            {
                int x = checked(int.MaxValue);
            }
            static void uncheckedFunc()
            {
                int x = unchecked(int.MaxValue);
            }
            checkedFunc();
            uncheckedFunc();
        }
    }
}
