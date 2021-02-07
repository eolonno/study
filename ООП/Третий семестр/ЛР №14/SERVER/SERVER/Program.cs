using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SERVER
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            // Инициализация
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 8888;
            TcpListener server = new TcpListener(localAddr, port);
            // Запуск в работу
            server.Start();
            // Бесконечный цикл
            while (true)
            {
                try
                {
                    // Подключение клиента
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    // Обмен данными
                    try
                    {
                        if (stream.CanRead)
                        {
                            byte[] myReadBuffer = new byte[1024];
                            StringBuilder myCompleteMessage = new StringBuilder();
                            int numberOfBytesRead = 0;
                            do
                            {
                                numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                myCompleteMessage.AppendFormat("{0}", Encoding.UTF8.GetString(myReadBuffer, 0, numberOfBytesRead));
                            }
                            while (stream.DataAvailable);
                            List<int> Numbers = JsonSerializer.Deserialize<List<int>>(myCompleteMessage.ToString());
                            foreach (var number in Numbers)
                            {

                                Console.WriteLine($"Число №{i++}: {number}");
                            }
                        }
                    }
                    finally
                    {
                        stream.Close();
                        client.Close();
                    }
                }
                catch
                {
                    server.Stop();
                    break;
                }
            }
        }
    }
}
