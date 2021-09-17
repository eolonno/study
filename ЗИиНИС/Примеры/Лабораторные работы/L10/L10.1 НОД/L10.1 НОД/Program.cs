using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10._1_НОД
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 17;
            int b = 3;

            int nod = NOD(a,b);


        }

        static int NOD (int a, int b)
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
            nod = a+b;

            Console.WriteLine(nod);

            return nod;
        }
    }
}
