//Написать программу, которая получит общий секретный ключ из доступных публичных ключей с помощью алгоритма Диффи-Хеллмана.
//Генерируйте секретный ключ Алисы и Боба, и высчитайте секретный ключ, удостоверьтесь что его одинаково смогут получить и Алиса и Боб.

using System;
using System.Collections.Generic;

namespace ЛР__6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Keys = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
                Keys.Add(rand.Next(1, 30));
            for (int i = 0; i < 2; i++)
                Keys.Add(rand.Next(1, 10));

            GetSecretKey(Keys[0], Keys[1], Keys[2], Keys[3]);
            //GetSecretKey(5, 23, 4, 3);

        }
        public static void GetSecretKey(int g, int p, int a, int b)
        {

            int A = Power(g, a, p);
            int B = Power(g, b, p);

            int K1 = Power(B, a, p);
            int K2 = Power(A, b, p);

            int SecretKey = Power(g, a * b, p);

            if (K1 == K2 && SecretKey == K1)
                Console.WriteLine($"Ключи равны!\nSecretKey = {SecretKey}\nK1 = {K1}\nK2 = {K2}");
            else
                Console.WriteLine($"Ключи не равны!\nSecretKey = {SecretKey}\nK1 = {K1}\nK2 = {K2}");

        }
        public static int Power(int a, int b, int n)
        {
            int tmp = a;
            int sum = tmp;
            for (int i = 1; i < b; i++)
            {
                for (int j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                    {
                        sum -= n;
                    }
                }
                tmp = sum;
            }
            return tmp;

        }
    }
}
