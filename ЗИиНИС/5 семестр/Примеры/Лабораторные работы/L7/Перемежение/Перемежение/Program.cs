using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Перемежение
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtK = 16; //Должна быть равна 2^n
            int k = (int)(Math.Sqrt(lenghtK));
            int r = LenghtHemminga(k);
            int n = k + r;
            int lenghtN = lenghtK + (r * k);

            int[] masK = new int[lenghtK];
            int[] masK2 = new int[lenghtK]; //сюда запишиться итоговая строка после всех манипуляций 
            int[] masN = new int[lenghtK + (r * k)];
            int[,] checkMatrix = new int[n, r];

            int error;
            int errorLenght;

            GenerationRandMasMod2(masK);
            Console.WriteLine("Входная строка: ");
            OutMas(masK);

            Console.WriteLine("\n\nПроверочная матрица: ");
            checkMatrix = CheckMatrix(k);
            OutMatrixInv(checkMatrix, n, r);

            AddCheckBits(masK, masN, checkMatrix);
            Console.WriteLine("\n\nСтрока с доб. проверочными битами: ");
            OutMas(masN);

            Alternation(masN, k);
            Console.WriteLine("\nСтрока после перемежения: ");
            OutMas(masN);

            try
            {
                Console.WriteLine("\n\nВведите место ошибки");
                error = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите длину ошибки");
                errorLenght = Convert.ToInt32(Console.ReadLine());
                for (int i = error; i <  (error + errorLenght); i++)
                {
                    masN[i] = (masN[i] + 1) % 2;
                }
            }
            catch { }

            Console.WriteLine("\nСтрока с ошибками: ");
            OutMas(masN);

            ReAlternation(masN, k);
            Console.WriteLine("\nСтрока после re:перемежения: ");
            OutMas(masN);

            SearchErrorLong(masN, checkMatrix, k);
            Console.WriteLine("\n\nСтрока после исправления ошибок: ");
            OutMas(masN);

            RemoveCheckBits(masK2, masN, checkMatrix);
            Console.WriteLine("\n\nСтрока после удаления проверочных бит: ");
            OutMas(masK2);
            Console.WriteLine("");
            OutMas(masK);
            Console.WriteLine("\nИсходная строка: ");

        }

        static int[] SearchErrorLong(int[] masN, int [,] checkMatrix, int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    temp[j] = masN[(n * i) + j];
                }
                //Получение проверочных битов каждой строки
                //Console.WriteLine("\nTemp");
                SearchError(temp, checkMatrix, k);
                //OutMas(temp);

                //Запись строки в массив, для получения одной большой строки
                for (int j = 0; j < n; j++)
                {
                    masN[i * n + j] = temp[j];
                }

            }

            return masN;
        }

        static int[] RemoveCheckBits(int[] masK, int[] masN, int[,] checkMatrix)
        {
            int lenghtK = masK.Length; //Должна быть равна 2^n
            int lenghtN = masN.Length;
            int k = (int)(Math.Sqrt(lenghtK));
            int r = LenghtHemminga(k);
            int n = k + r;

            int[,] matrix = new int[k, n];

            //Разбиение массива на отдельные строки
            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    temp[j] = masN[(n * i) + j];
                }

                //Запись строки в массив, для получения одной большой строки
                for (int j = 0; j < k; j++)
                {
                    masK[i * k + j] = temp[j];
                }

            }
            return masK;
        }

        static int[] AddCheckBits(int [] masK,int[] masN, int [,] checkMatrix)
        {
            int lenghtK = masK.Length; //Должна быть равна 2^n
            int lenghtN = masN.Length;
            int k = (int)(Math.Sqrt(lenghtK));
            int r = LenghtHemminga(k);
            int n = k + r;

            int[,] matrix = new int[k, n];

            //Разбиение массива на отдельные строки
            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < k; j++)
                {
                    temp[j] = masK[(k * i) + j];
                }
                //Получение проверочных битов каждой строки
                Sindrom(checkMatrix, temp, k);
                // Console.WriteLine("");
                //OutMas(temp);

                //Запись строки в массив, для получения одной большой строки
                for (int j = 0; j < n; j++)
                {
                    masN[i * n + j] = temp[j];
                }

            }
            return masN;
        }

        static int[] Alternation(int[] masN, int k)
        {
            int r = LenghtHemminga(k);
            int n = k + r;

            int[,] matrix = new int[k, n];
            //Получение матрицы
            for (int i = 0, m = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++, m++)
                {
                    matrix[i, j] = masN[m];
                }
            }
            Console.WriteLine("\n\nПолученая матрица");
            OutMatrix(matrix, k,n);

            //Перемежение
            for (int i = 0, m = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++, m++)
                {
                    masN[m] = matrix[j, i];
                }
            }

            return masN;
        }

        static int[] ReAlternation(int[] masN, int k)
        {
            int r = LenghtHemminga(k);
            int n = k + r;

            int[,] matrix = new int[k, n];
            //Получение матрицы
            for (int j = 0, m = 0; j < n; j++)
            {
                for (int i = 0; i < k; i++, m++)
                {
                    matrix[i, j] = masN[m];
                }
            }
            Console.WriteLine("\n\nПолученая матрица");
            OutMatrix(matrix, k, n);

            //RE:Перемежение
            for (int j = 0, m = 0; j < k; j++)
            {
                for (int i = 0; i < n; i++, m++)
                {
                    masN[m] = matrix[j, i];
                }
            }

            return masN;
        }

        static int[] GenerationRandMasMod2(int[] mas)
        {
            Random rnd = new Random();

            for(int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(2);
            }
            return mas;
        }
        

        //Создание пров. матрицы
        static int[,] CheckMatrix(int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;
            double rDouble = r - 1;
            int rPow = (int)(Math.Pow(2, rDouble));

            int[,] mas = new int[n, r];

            int[,] combinations = new int[rPow, r];

            for (int i = 0; i < rPow; i++)
                for (int j = 0; j < r; j++)
                    combinations[i, j] = 0;

            //генератор бит.мн.
            for (int segmentLenght = 0; segmentLenght < r - 2; segmentLenght++)
            {
                if (segmentLenght * r > k) break;

                for (int i = 0; i < segmentLenght + 2; i++)
                {
                    combinations[segmentLenght * r, i] = 1;
                }

                for (int segmentPositin = 1; segmentPositin < r; segmentPositin++)
                {
                    for (int i = 0; i < r - 1; i++)
                    {
                        combinations[segmentLenght * r + segmentPositin, i + 1] = combinations[segmentLenght * r + segmentPositin - 1, i];
                    }
                    combinations[segmentLenght * r + segmentPositin, 0] = combinations[segmentLenght * r + segmentPositin - 1, r - 1];
                }

                if (segmentLenght == r - 3)
                {
                    for (int i = 0; i < r; i++)
                    {
                        combinations[rPow - 1, i] = 1;
                    }
                }
            }



            for (int i = 0; i < k; i++)
                for (int j = 0; j < r; j++)
                    mas[i, j] = combinations[i, j];

            for (int i = 0; i < r; i++)
                mas[i + k, i] = 1;

            return mas;
        }

        //Поиск синдрома
        static int[] Sindrom(int[,] CheckMatrix, int[] mas, int k)
        {

            int r = LenghtHemminga(k);
            int n = r + k;
            int[] sindrom = new int[r];



            for (int i = 0, l = 0; i < r; i++, l = 0)
            {
                for (int j = 0; j < k; j++)
                {
                    if (CheckMatrix[j, i] == 1 && mas[j] == 1) l++;
                    else sindrom[i] = 0;
                }
                if (l % 2 == 1) sindrom[i] = 1;
                else sindrom[i] = 0;
            }

            for (int i = 0; i < r; i++)
            {
                mas[i + k] = sindrom[i];
            }

            return mas;
        }

        //Считаем r (кол-во пров. симв.)
        static int LenghtHemminga(int k)
        {
            int r = (int)(Math.Log(k, 2) + 1.99f);
            return r;
        }

        //Нахождение ошибок
        static int[] SearchError(int[] mas, int[,] checkMatrix, int k)
        {

            int r = LenghtHemminga(k);
            int n = r + k;

            int[] beforeSindrom = new int[r];

            //запоминаем проверочные биты
            for (int i = k; i < n; i++)
            {
                beforeSindrom[i - k] = mas[i];
            }

            mas = Sindrom(checkMatrix, mas, k);

            //Складываем синдром по модулю два
            for (int i = k, j = 0; i < n; i++)
            {
                if (beforeSindrom[i - k].Equals(mas[i]))
                {
                    mas[i] = 0;

                    j++;
                    //если сумма по модулю два все пров. бит равна нулю
                    if (j == r)
                    {
                        for (int l = k; l < n; l++)
                        {
                            mas[l] = beforeSindrom[l - k];
                        }
                        return mas;
                    }
                }
                else
                {
                    mas[i] = 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int l = 0;
                for (int j = 0; j < r; j++)
                {
                    if (checkMatrix[i, j].Equals(mas[j + k])) l++;
                }
                if (l == r)
                {
                    mas[i] = (mas[i] + 1) % 2;
                }
            }
            //OutMas(mas);
            mas = Sindrom(checkMatrix, mas, k);

            return mas;
        }

        static void OutMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i]);
            }
        }
        //вывод матрицы
        static void OutMatrix(int[,] matrix, int k, int n)
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                    //if (j + 1 == k) Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        static void OutMatrixInv(int[,] matrix, int k, int n)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
