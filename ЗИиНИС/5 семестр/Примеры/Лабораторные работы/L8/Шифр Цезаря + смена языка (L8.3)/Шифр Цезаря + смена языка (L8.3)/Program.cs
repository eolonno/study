using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифр_Цезаря___смена_языка__L8._3_
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            int key;

            str = "BSTU";
            key = 10;


            str = Encryption(str, key);

            Console.WriteLine(str);

            str = Decryption(str, key);

            Console.WriteLine(str);


        }

        static string Encryption(string str, int key)
        {
            string alphabetEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
            string alphabetRus = "АБВГДЕЖЗИКЛМПРСТУФХЦЧШЫЭЮЯ";
            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                int j;

                //Нахождение номера позииции буквы в алфавите
                for (j = 0; j < alphabetEng.Length; j++)
                {
                    if (alphabetEng[j].Equals(str[i]))
                        break;
                }

                if (j == alphabetEng.Length)
                {
                    newStr += str[i];
                    continue;
                }

                j += key;
                if (j >= alphabetEng.Length)
                    j -= alphabetEng.Length;

                newStr += alphabetRus[j];
            }

            return newStr;
        }

        static string Decryption(string str, int key)
        {
            string alphabetEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabetRus = "АБВГДЕЖЗИКЛМПРСТУФХЦЧШЫЭЮЯ";
            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                int j;

                for (j = 0; j < alphabetRus.Length; j++)
                {
                    if (alphabetRus[j].Equals(str[i]))
                        break;
                }

                if (j == alphabetRus.Length)
                {
                    newStr += str[i];
                    continue;
                }

                j -= key;
                if (j < 0)
                    j += alphabetRus.Length;

                newStr += alphabetEng[j];
            }
            return newStr;
        }
    }
}

