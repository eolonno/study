using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class Program
    {
        class Calc{
            public string ChangeSub(string b, string c, string a)
        {
            return a.Replace(b, c);
        }

        public string DelSub(string b, string a)
        {
            int n = a.IndexOf(b);
            return a.Remove(n, b.Length);
        }

        public char FindInd(int b, string a)
        {
            char s = '?';
                for (int i = 0; i < a.Length; i++)
                    if (i == b) { s = a[i]; break; };
            return s;
        }

        public int Length(string a)
        {
            return a.Length;
        }

        public void VovelAm(string a)
        {
            int n = 0;
            string b = a.ToLower();
            char[] vovels = new char[5] { 'a', 'e', 'o', 'i', 'u'};
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (b[i] == vovels[j])
                            n++;
                    }
                    Console.WriteLine($"There are {n} vovels");
                }
        }

        public int SentAm(string a)
        {
            int i = 0;
            if (a[a.Length - 1] != '.' || a[a.Length - 1] != '!' || a[a.Length - 1] != '?')
                a.Insert(a.Length - 1, ".");
            if (a[0] == '.')
                a.Remove(0, 1);
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] == '.' || a[j] == '!' || a[j] == '?') i++;
            }
                return i;
         }
            

        public int WordAm(string a)
        {
            int i = 1;
            if (a[0] == ' ')
                a.Remove(0, 1);
            if (a[a.Length - 1] != ' ')
                a.Remove(0, 1);
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] == ' ') i++;
            }
            return i;
        }

    }

    static void Main(string[] args)
        {
            string a = "Input string";
            Calc calc = new Calc();
            
            calc.VovelAm(a);
            Console.WriteLine(calc.WordAm(a));
            Console.WriteLine(calc.SentAm(a));
            Console.ReadLine();
        }
    }
}
