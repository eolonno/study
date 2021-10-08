using System;

namespace ЛР__4
{
    class Program
    {
        static void Main(string[] args)
        {

            string str;
            do
            {
                Console.Clear();
                Console.Write("Введите строку (не менее трех символов) = ");
                str = Console.ReadLine();
            }
            while (str.Length < 3);


            int k = str.Length;
            int r = HemmingLenght(k);
            int n = k + r;

            int[] mas = new int[str.Length + r];
            int[,] checkMatrix = new int[n, r];

            int error;

            //Преобразование строки в массив
            mas = StrInMas(str, k);
            Console.Write("\nВходная строка = ");
            OutMass(mas, k);

            //Получение проверочной матрицы
            checkMatrix = CheckMatrix(k);



            Console.WriteLine("\nПроверочная матрица");
            OutMass(checkMatrix, k);

            //Добавление проверочных битов
            Sindrom(checkMatrix, mas, k);


            Console.WriteLine("\nПолная строка");
            OutMass(mas, k);

            try
            {
                Console.WriteLine("Введите место ошибки");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (mas[error] == 1) mas[error] = 0;
                    else mas[error] = 1;
            }
            catch { }

            Console.WriteLine("\nСтрока с ошибкой");
            OutMass(mas, k);


            mas = SearchError(mas, checkMatrix, k);
            Console.WriteLine("\nСтрока без ошибки");
            OutMass(mas, k);


        }

        //Считаем r (кол-во пров. симв.)
        public static int HemmingLenght(int k)
        {
            int r = (int)(Math.Log(k, 2) + 1.99f);
            return r;
        }

        //Создание пров. матрицы
        public static int[,] CheckMatrix(int k)
        {
            int r = HemmingLenght(k);
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

                for (int segmentPosition = 1; segmentPosition < r; segmentPosition++)
                {
                    for (int i = 0; i < r - 1; i++)
                    {
                        combinations[segmentLenght * r + segmentPosition, i + 1] = combinations[segmentLenght * r + segmentPosition - 1, i];
                    }
                    combinations[segmentLenght * r + segmentPosition, 0] = combinations[segmentLenght * r + segmentPosition - 1, r - 1];
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
        public static int[] Sindrom(int[,] CheckMatrix, int[] mas, int k)
        {

            int r = HemmingLenght(k);
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

        //Нахождение ошибок
        public static int[] SearchError(int[] mas, int[,] checkMatrix, int k)
        {

            int r = HemmingLenght(k);
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
            mas = Sindrom(checkMatrix, mas, k);

            return mas;
        }

        //Преобразование строки в массив
        public static int[] StrInMas(string str, int k)
        {
            int r = HemmingLenght(k);
            int[] mas = new int[str.Length + r];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 49)
                    mas[i] = 1;
                else mas[i] = 0;
            }
            return mas;
        }

        //вывод матрицы
        public static void OutMass(int[,] mas, int k)
        {
            int r = HemmingLenght(k);
            int n = r + k;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[j, i]);
                    if (j + 1 == k) Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        //вывод одномерного массива
        public static void OutMass(int[] mas, int k)
        {
            int n = HemmingLenght(k) + k;

            for (int i = 0; i < n; i++)
            {
                if (i == k) Console.Write("|");
                Console.Write(mas[i]);
            }
            Console.WriteLine("\n");
        }
    }

}
