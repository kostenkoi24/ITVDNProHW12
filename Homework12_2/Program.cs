using System;
using System.Text;
using System.Threading;

namespace Homework12_2
{
    class Program
    {
        // false - встановлення в несигнальний стан.
        static AutoResetEvent auto = new AutoResetEvent(false);
        static void Main(string[] args)
        {

            /*
             * Перетворіть приклад блокування подій таким чином, щоб замість ручної обробки використовувалася автоматична.
             */

            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function1).Start();

            Thread.Sleep(500);  // Дамо час запуститися вторинним потокам.

            Console.WriteLine("Натисніть будь-яку клавішу для переведення AutoResetEvent у сигнальний стан.\n");
            Console.ReadKey();
            auto.Set(); // Надсилає сигнал одному потоку.
            auto.Set(); // Надсилає сигнал іншому потоку.

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine($"Потік {Thread.CurrentThread.GetHashCode()} запущений та очікує сигналу.");
            auto.WaitOne(); // Зупинка виконання вторинного потоку 1.
            Console.WriteLine($"Потік {Thread.CurrentThread.GetHashCode()} завершується.");
        }

       
    }
}
