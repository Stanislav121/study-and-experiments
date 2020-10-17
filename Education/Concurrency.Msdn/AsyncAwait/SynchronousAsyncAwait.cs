using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait
{
    class SynchronousAsyncAwait
    {
        public async void Start()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await LongСalculations();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        private async Task LongСalculations()
        {
            long accumulator = 0;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (long i = 0; i < 100000; i++)
            {
                accumulator = (i + 2) / (3 + i / 2) + i * i / 7;
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + accumulator);
        }
    }
}
