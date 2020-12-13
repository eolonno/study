using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                Numbers.Add(rnd.Next(1, 100));

            string address = "127.0.0.1";
            int port = 8888;
            // Инициализация
            TcpClient client = new TcpClient(address, port);
            Byte[] data = Encoding.Default.GetBytes(JsonSerializer.Serialize(Numbers));
            NetworkStream stream = client.GetStream();
            try
            {
                // Отправка сообщения
                stream.Write(data, 0, data.Length);
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
