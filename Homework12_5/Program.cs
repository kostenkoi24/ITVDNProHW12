using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Homework12_5
{
    class Program
    {
        static Semaphore pool;

        public static string fileLog = "File.log";

        static void Function(object number)
        {
            pool.WaitOne();

            Console.WriteLine("Потік {0} зайняв {1} семафору.", number, fileLog);
            FileWrite(fileLog);
            Thread.Sleep(4000);
            Console.WriteLine("Потік {0} -----> звільнив {1}.", number, fileLog);

            pool.Release();
        }

        static void Main(string[] args)
        {
            /*Створіть Semaphore, що контролює доступу до ресурсу з кількох потоків. 
             * Організуйте впорядкований висновок інформації про 
             * отримання доступу до спеціального файлу *.log.*/

            FileCreator(fileLog);


            Console.OutputEncoding = Encoding.Unicode;

            pool = new Semaphore(1, 1, "MySemafore");

            //pool.Release(2); // Скидання семафору.

            for (int i = 1; i <= 2; i++)
            {
                new Thread(Function).Start(i);
                //Thread.Sleep(500);  // Потоки з різних процесів встигнуть стати в чергу упереміш.
            }

            // Delay
            Console.ReadKey();

            
        }


        static void FileCreator(string fileName)
        {
            var file = new FileInfo(fileName);
            
        }

        static void FileWrite(object fileName)
        {
            var writer = new StreamWriter((string)fileName, append: true);
            writer.WriteLine($"{Thread.CurrentThread.GetHashCode()}");
            writer.Close();
        }

    }
}
