using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace L10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1026;
            int n = 18;


            

            int c = Inverse(a,n);

            Console.WriteLine(NOD(a, n));
        }

        static int NOD(int a, int b)
        {
            int nod;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);

            Console.Write("НОД(" + a + "," + b + ") = ");
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            nod = a + b;

            Console.WriteLine(nod);

            return nod;
        }

        public static int Inverse(int a, int n)
        {
            int b = n, x = 0, d = 1;
            while (a != 0)
            {
                int q = b / a;
                int y = a;
                a = b % a;
                b = y;
                y = d;
                d = x - (q * d);
                x = y;
            }
            x = x % n;
            if (x < 0)
            {
                x = (x + n) % n;
                return x;
            }
            else
            {
                return x;
            }
        }
    }
}
