// Учитывая то, что на второй строке генерации ФИО, меня уже это все за#####, я решил произвести на свет эту штуку, довольствуемся...
using System;
using System.IO;
using System.Text;

namespace DBGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //FullNameInSqlFormat("names.txt", "namesSQL.txt");
        }
        public static void FullNameInSqlFormat(string InPath, string OutPath)
        {
            string Input = "";
            using(StreamReader sr = new StreamReader(InPath))
            {
                Input = sr.ReadToEnd();
            }
            Input = Input.Insert(0, "\'");
            for(int i = 0; i < Input.Length; i++)
            {
                if (Input[i] == ' ')
                {
                    Input = Input.Insert(i, "\',");
                    Input = Input.Insert(i + 3, "\'");
                    i += 4;
                }
                else if(Input[i] == '\n')
                {
                    Input = Input.Insert(i - 1, "\',");
                    Input = Input.Insert(i + 3, "\'");
                    i += 4;
                }
            }
            using(StreamWriter sw = new StreamWriter(OutPath, false, Encoding.Default))
            {
                sw.Write(Input);
            }
        }
    }
}
