using System;
using System.Text;
using System.Threading;

namespace Homework12_3
{
    class Program
    {
        


        /*
         Створіть програму, яка може бути запущена лише в одному екземплярі (використовуючи іменований Mutex).
         */


        static Mutex mutex = new Mutex(false, "MyMutex");

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            mutex.WaitOne();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Потік {0} зайшов у захищену область.", Thread.CurrentThread.Name);
                Thread.Sleep(5000);
                Console.WriteLine("Потік {0} покинув захищену область.\n", Thread.CurrentThread.Name);
            }
            

            mutex.ReleaseMutex();


            Console.ReadKey();
        }

       
    }
}
