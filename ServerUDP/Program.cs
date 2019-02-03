using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1";
            const int PORT = 8081;
            //создание endPoint(подключения)
            var UDPEndpoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
            //создание сокета
            var UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UDPSocket.Bind(UDPEndpoint);

            while (true)
            {
                //получение ответа
                var buffer = new byte[256];
                //доп. переменная для инфы, размером меньше указанной
                var size = 0;
                var data = new StringBuilder();
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    size = UDPSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (UDPSocket.Available > 0);

                Console.WriteLine(data);
                //отправка ответа
                UDPSocket.SendTo(Encoding.UTF8.GetBytes("Сообщение получено."),senderEndPoint);
            }
        }
    }
}
