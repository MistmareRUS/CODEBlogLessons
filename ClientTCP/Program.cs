using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1";
            const int PORT = 8080;
            //создание endPoint(подключения)
            var TCPEndpoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
            //создание сокета
            var TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообщение для отправки:");
            var message = Console.ReadLine();
            var data = Encoding.UTF8.GetBytes(message);

            //подключаемся
            TCPSocket.Connect(TCPEndpoint);
            //передаем подготовленные данные
            TCPSocket.Send(data);

            //получение ответа
            var buffer = new byte[256];
            //допю переменная для инфы, размером меньше указанной
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                //взяли кусок данных указанного размера, перекодировали, добавили к строке и так по кругу
                size = TCPSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            //пока есть данные-будем получать
            while (TCPSocket.Available > 0);

            Console.WriteLine(answer.ToString());

            TCPSocket.Shutdown(SocketShutdown.Both);
            TCPSocket.Close();

            Console.ReadKey();
        }
    }
}
