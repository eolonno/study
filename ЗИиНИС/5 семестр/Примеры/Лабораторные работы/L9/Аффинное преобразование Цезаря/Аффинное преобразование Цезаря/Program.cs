using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Аффинное_преобразование_Цезаря
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "BSTU";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int a = 11;
            int b = 2;
            int n = alphabet.Length;

            OutMas(GettingIndexLetters(str, alphabet));

            str = Encryption(str, alphabet, a, b);
            Console.WriteLine(str);
        }

        static string Encryption(string str, string alphabet, int a, int b)
        {
            int n = alphabet.Length;
            int[] mas = new int[str.Length];
            mas = GettingIndexLetters(str, alphabet);

            str = "";

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = (a * mas[i] + b) % n;

                str += alphabet[mas[i]];
            }

            Console.WriteLine(str);


            return str;
        }

        static int[] GettingIndexLetters(string str, string alphabet)
        {
            int[] mas = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j <= alphabet.Length; j++)
                {
                    if (str[i] == alphabet[j] || j == alphabet.Length)
                    {
                        mas[i] = j;
                        break;
                    }
                }
            }
            return mas;
        }

        static void OutMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
        }
    }
}
