using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифр_Виженера
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            string key;

            str = "PKMSDK";
            key = "PKM";

            str = Encryption(str, key);

            Console.WriteLine(str);

            str = Decryption(str, key);

            Console.WriteLine(str);


        }

        static string Encryption (string str, string key)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string newStr = "";
            for (int i = 0; i <= str.Length / key.Length; i++)
                key += key;

            for( int i= 0; i < str.Length; i++)
            {
                int j;
                int k;

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

                for (k = 0; k < alphabet.Length; k++)
                {
                    if (alphabet[k].Equals(key[i]))
                        break;
                }

                if (k == alphabet.Length)
                {
                    newStr += str[i];
                    continue;
                }

                j += k;
                if (j >= alphabet.Length)
                    j -= alphabet.Length;

                newStr += alphabet[j];
            }

            return newStr;
        }

        static string Decryption(string str, string key)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string newStr = "";
            for (int i = 0; i <= str.Length / key.Length; i++)
                key += key;

            for (int i = 0; i < str.Length; i++)
            {
                int j;
                int k;

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

                for (k = 0; k < alphabet.Length; k++)
                {
                    if (alphabet[k].Equals(key[i]))
                        break;
                }

                if (k == alphabet.Length)
                {
                    newStr += str[i];
                    continue;
                }

                j -= k;
                if (j < 0)
                    j += alphabet.Length;

                newStr += alphabet[j];
            }
            return newStr;
        }
    }
}
