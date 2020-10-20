using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait
{
    class AsynchronousAsyncAwait
    {

        public async void Start()
        {
            Console.WriteLine("1 " + Thread.CurrentThread.ManagedThreadId);
            var task = LongСalculations();
            long accumulator = 0;
            
            Console.WriteLine("3 " + Thread.CurrentThread.ManagedThreadId + " " + accumulator);
            for (long i = 0; i < 100000; i++)
            {
                accumulator = (i + 2) / (3 + i / 2) + i * i / 7;
            }
            Console.WriteLine("4 " + Thread.CurrentThread.ManagedThreadId + " " + accumulator);
            await task;
            Console.WriteLine("7 " + Thread.CurrentThread.ManagedThreadId);
        }

        private async Task LongСalculations()
        {
            Console.WriteLine("2 " + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() =>
                 {
                     var threads = new List<Thread>();
                     for (long i = 0; i < 300000; i++)
                     {
                         threads.Add(new Thread(() => Console.WriteLine()));
                     }

                     Console.WriteLine("5 " + Thread.CurrentThread.ManagedThreadId);
                 }
            );
            
            Console.WriteLine("6 " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
