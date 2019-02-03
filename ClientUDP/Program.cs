using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1";
            const int PORT = 8082;
            //создание endPoint(подключения)
            var UDPEndpoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
            //создание сокета
            var UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UDPSocket.Bind(UDPEndpoint);

            while (true)
            {
                Console.WriteLine("Введите сообщение");
                var message = Console.ReadLine();
                var serverEndPoint = new IPEndPoint(IPAddress.Parse(IP), 8081);
                UDPSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);

                //получение ответа
                var buffer = new byte[256];
                //допю переменная для инфы, размером меньше указанной
                var size = 0;
                var data = new StringBuilder();
                //EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                do
                {
                    size = UDPSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (UDPSocket.Available > 0);
                Console.WriteLine(data);
            }
        }
    }
}
