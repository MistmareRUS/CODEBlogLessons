using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1";
            const int PORT = 8080;
            //создание endPoint(подключения)
            var TCPEndpoint = new IPEndPoint(IPAddress.Parse(IP),PORT);
            //создание сокета
            var TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Указываем сокету какой порт слушать
            TCPSocket.Bind(TCPEndpoint);
            //запуск
            TCPSocket.Listen(5);
            while (true)
            {
                //подключение конкретного клиента( из настроенного кол-ва для очереди)
                var listener = TCPSocket.Accept();
                //место для сохранения полученной информации
                var buffer = new byte[256];
                //допю переменная для инфы, размером меньше указанной
                var size = 0;
                var data = new StringBuilder();
                do
                {
                    //взяли кусок данных указанного размера, перекодировали, добавили к строке и так по кругу
                    size=listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                //пока есть данные-будем получать
                while (listener.Available > 0);
                //отображение результата
                Console.WriteLine(data);

                //ответ обратно
                listener.Send(Encoding.UTF8.GetBytes("Succesfully"));
                //закрытие соединения слушателя 
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}
