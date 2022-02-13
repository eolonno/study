    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифр_Цезаря
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
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string newStr = "";
       
        for (int i = 0; i < str.Length; i++)
        {
            int j;

            for (j = 0; j < alphabet.Length; j++)
            {
                if (alphabet[j].Equals(str[i]))
                    break;
            }

            if (j == alphabet.Length)
            {
                newStr += str[i];
                continue;
            }

            j += key;
            if (j >= alphabet.Length)
                j -= alphabet.Length;

            newStr += alphabet[j];
        }

        return newStr;
    }

    static string Decryption(string str, int key)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string newStr = "";

        for (int i = 0; i < str.Length; i++)
        {
            int j;

            for (j = 0; j < alphabet.Length; j++)
            {
                if (alphabet[j].Equals(str[i]))
                    break;
            }

            if (j == alphabet.Length)
            {
                newStr += str[i];
                continue;
            }

            j -= key;
            if (j < 0)
                j += alphabet.Length;

            newStr += alphabet[j];
        }
        return newStr;
    }
}
}
