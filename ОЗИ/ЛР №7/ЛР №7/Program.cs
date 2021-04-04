using System;
using System.Collections.Generic;
using System.Linq;

namespace ЛР__7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //int p = (int)GetPrime(2, 30);
            //int q = (int)GetPrime(2, 30);
            //int e = rnd.Next(1, 10);
            //int msg = rnd.Next(1, 100);
            int p = 31;
            int q = 7;
            int e = 47;
            int msg = rnd.Next(5, 100);


            int n = p * q;

            int EulerFunction = (p - 1) * (q - 1);

            int d = modinv(e, EulerFunction);

            // Ключи из таблицы (2 вариант)
            e = 7;
            n = 533;
            d = 343;

            List<int> OpenKey = new List<int>();
            OpenKey.Add(e);
            OpenKey.Add(n);

            List<int> SecretKey = new List<int>();
            SecretKey.Add(d);
            SecretKey.Add(n);

            Console.WriteLine("Число p: " + p);
            Console.WriteLine("Число q: " + q);
            Console.WriteLine("Открытая экспонента: " + e);
            Console.WriteLine("Закрытая экспонента: " + d);
            Console.WriteLine("Сообщение: " + msg);
            Console.WriteLine("Зашифрованное сообщение: " + Encrypt(OpenKey, msg));
            Console.WriteLine("Расшифрованное сообщени: " + Decrypt(SecretKey, Encrypt(OpenKey, msg)));

            int encMsg = Encrypt(OpenKey, msg);

            // Алгоритм MD5
            //string hash;
            //using (var md5 = System.Security.Cryptography.MD5.Create())
            //{
            //    hash = String.Concat(md5.ComputeHash(BitConverter
            //      .GetBytes(encMsg))
            //      .Select(x => x.ToString("x2")));
            //}
            //Console.WriteLine(hash);

            // Этап 2
            int s = Modpow(encMsg, SecretKey[0], SecretKey[1]);

            // Этап 3
            int DecMsg = Modpow(s, OpenKey[0], OpenKey[1]);
            Console.WriteLine("Прообраз сообщения из ЭЦП: " + DecMsg);

            // Расшифровка
            DecMsg = Decrypt(SecretKey, DecMsg);

            Console.WriteLine("Подлинность ЭЦП: " + (msg == DecMsg ? "да" : "нет"));

        }
        public static int? GetPrime(int start, int end)
        {
            List<int> Primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                bool b = true;
                for (int j = 2; j < i / 2; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    Primes.Add(i);
                }
            }
            if (Primes.Count == 0)
                return null;
            else
            {
                Random rnd = new Random();
                return Primes[rnd.Next(0, Primes.Count)];
            }
        }
        public static int Encrypt(List<int> OpenKey, int msg)
        {
            return Modpow(msg, OpenKey[0], OpenKey[1]);
        }
        public static int Decrypt(List<int> SecretKey, int msg)
        {
            return Modpow(msg, SecretKey[0], SecretKey[1]);
        }
        public static int Modpow(int Base, int exp, int modulus)
        {
            Base %= modulus;
            int result = 1;
            while (exp > 0)
            {
                if ((exp & 1) != 0) result = (result * Base) % modulus;
                Base = (Base * Base) % modulus;
                exp >>= 1;
            }
            return result;
        }
        public static int modinv(int u, int v)
        {
            int inv, u1, u3, v1, v3, t1, t3, q;
            int iter;
            u1 = 1;
            u3 = u;
            v1 = 0;
            v3 = v;
            iter = 1;
            while (v3 != 0)
            {
                q = u3 / v3;
                t3 = u3 % v3;
                t1 = u1 + q * v1;
                u1 = v1;
                v1 = t1;
                u3 = v3;
                v3 = t3;
                iter = -iter;
            }
            if (u3 != 1)
                return 0;
            if (iter < 0)
                inv = v - u1;
            else
                inv = u1;
            return inv;
        }
    }
}
