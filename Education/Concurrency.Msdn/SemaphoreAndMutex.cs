using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn
{
    class SemaphoreAndMutex
    {
        private static Mutex _mutex;
        private static Semaphore _semaphore;
        public static void Run()
        {
            ThreadPool.QueueUserWorkItem(ThreadProc);
            ThreadPool.QueueUserWorkItem(ThreadProc, "Abc");
            ThreadPool.QueueUserWorkItem((o) => Console.WriteLine("ThreadProc in thread pool, ob {0}", o), "delegate");

            _mutex = new Mutex();
            _semaphore = new Semaphore(1, 1);

            _mutex.WaitOne();
            _mutex.WaitOne();
            Console.WriteLine("In Mutex recursive");
            _mutex.ReleaseMutex();
            _mutex.ReleaseMutex();

            _semaphore.WaitOne();
            Console.WriteLine("In Semaphore");
            _semaphore.WaitOne();
            Console.WriteLine("In Semaphore recursive");
            _semaphore.Release();
            _semaphore.Release();
        }

        private static void ThreadProc(object state)
        {
            Console.WriteLine("ThreadProc in thread pool, ob {0}", state);
        }
    }
}
