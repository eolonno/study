using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифр_перестановки
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "qwerty"; //eyrqtw
            int key = 3;

            Console.WriteLine(str);

            str = Permutation(str, key);
            Console.WriteLine(str);

            str = RePermutation(str, key);
            Console.WriteLine(str);


        }

        static string Permutation(string str, int key)
        {
            string temp = "";
            int[] mas = GettingIndexNumbers(str);

            int pos = key; //position

            for (int i = 0; i < str.Length; i++)
            {
                //если позиция больше длины строки, то уменьшаем её на длину строки
                if (pos > str.Length)
                {
                    pos -= str.Length;
                }

                //пока значение в ячейки массива равно длине строки, то сдвигаем вперед
                while (mas[pos-1] == str.Length)
                {
                    pos++;

                    //если позиция больше длины строки, то уменьшаем её на длину строки
                    if (pos > str.Length)
                    {
                        pos -= str.Length;
                    }
                }

                temp += str[pos - 1];
                mas[pos - 1] = str.Length;
                pos += key;
            }

            str = temp;

            return str;
        }

        static string RePermutation(string str, int key)
        {
            string[] temp = new string[str.Length];
            int[] mas = new int[str.Length];

            for(int i = 0; i < str.Length; i++)
            {
                mas[i] = str.Length;
            }

            int pos = key; //position

            for (int i = 0; i < str.Length; i++)
            {
                //если позиция больше длины строки, то уменьшаем её на длину строки
                if (pos > str.Length)
                {
                    pos -= str.Length;
                }

                //пока значение в ячейки массива равно длине строки, то сдвигаем вперед
                while (mas[pos - 1] != str.Length)
                {
                    pos++;

                    //если позиция больше длины строки, то уменьшаем её на длину строки
                    if (pos > str.Length)
                    {
                        pos -= str.Length;
                    }
                }

                temp[pos-1] += str[i];
                mas[pos - 1] = pos;
                pos += key;
            }

            for (int i = 1; i < str.Length; i++)
            {

                temp[0] += temp[i];
            }
            str = temp[0];

            return str;

        }

        static int[] GettingIndexNumbers (string str)
        {
            int[] mas = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                mas[i] = i;
            }

            return mas;
        }
    }
}
