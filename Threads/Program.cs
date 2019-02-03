using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Старт основного потока");
            #region with delegate
            //var myThread = new Thread(new ThreadStart(MyMethod));
            //myThread.Priority = ThreadPriority.AboveNormal;
            //myThread.Start();
            //var myThread2 = new Thread(new ParameterizedThreadStart(MyMethod2));
            //myThread2.Start(int.MaxValue);

            //int a = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    a++;
            //    if (i % 10000 == 0)
            //    {
            //        Console.WriteLine("десятитысячный! из основного потока");
            //    }
            //}
            #endregion
            MethodAsync();
            Method2Async(15);
            Console.WriteLine("Конец основноо потока");
            Console.ReadKey();
        }
        static async Task MethodAsync()
        {
            await Task.Run(()=>MyMethod());
            Console.WriteLine("ASYNC");
        }
        static async Task Method2Async(int a)
        {
            await Task.Run(()=>MyMethod2((int)a));
            Console.WriteLine("ASYNC с аргументами");
        }
        static void MyMethod()
        {
            Console.WriteLine("Старт метода без аргументов");
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("чётный! из безарументного асинк метода");
                }
            }
            Console.WriteLine("Конец метода без аргументов");
        }
        static void MyMethod2(object max)
        {
            Console.WriteLine("Старт метода с аргументами");
            for (int i = 0; i < (int)max; i++)
            {
                if (i % 2 == 0)
                    {
                        Console.WriteLine("чётный! из  асинк метода с аргументами");
                    }
            }
            Console.WriteLine("Конец метода с аргументами");
        }
    }
}
