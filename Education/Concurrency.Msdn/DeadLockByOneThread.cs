using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn
{
    class DeadLockByOneThread
    {
        private readonly object _lock1 = new object();
        private readonly object _lock2 = new object();

        public void GoToDeadLock()
        {
            var thread = new Thread(SomeWork);

            thread.Start(Thread.CurrentThread);
            lock (_lock2)
            {
                thread.Join();
                Console.WriteLine("In Main");
            }
            
        }

        private void SomeWork(object thread) 
        {
            var thr = (Thread)thread;
            lock (_lock1)
            {
                thr.Join();
                Console.WriteLine("In SomeWork");
            }
        }
    }
}
