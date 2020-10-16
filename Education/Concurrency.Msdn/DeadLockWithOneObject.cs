using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn
{
    class DeadLockWithOneObject
    {
        private readonly object _lock1 = new object();

        public void GoToDeadLock()
        {
            var thread1 = new Thread(ProcessResource1);
            var thread2 = new Thread(ProcessResource2);

            thread2.Start(thread1);
            thread1.Start(thread2);

            thread1.Join();
            thread2.Join();
        }

        private void ProcessResource1(object anotherThread)
        {
            var thr = (Thread)anotherThread;
            lock (_lock1)
            {
                Console.WriteLine("ProcessResource1");
                thr.Join();
                Console.WriteLine("ProcessResource1");
            }
        }

        private void ProcessResource2(object anotherThread)
        {
            var thr = (Thread)anotherThread;
            lock (_lock1)
            {
                Console.WriteLine("ProcessResource2");
                thr.Join();
                Console.WriteLine("ProcessResource2");
            }
        }
    }
}
