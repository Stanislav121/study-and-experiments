using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn
{
    class DeadLock
    {
        private int _resource;

        private readonly object _lock1 = new object();
        private readonly object _lock2 = new object();

        public void GoToDeadLock()
        {
            var thread1 = new Thread(ProcessResource1);
            var thread2 = new Thread(ProcessResource2);

            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();
        }

        private void ProcessResource1()
        {
            lock (_lock1)
            {
                Thread.Sleep(500);
                lock (_lock2)
                {
                    Console.WriteLine("1 " + _resource);
                }
            }
        }

        private void ProcessResource2()
        {
            lock (_lock2)
            {
                Thread.Sleep(500);
                lock (_lock1)
                {
                    Console.WriteLine("2 " + _resource);
                }
            }
        }
    }
}
