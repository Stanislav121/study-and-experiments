using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn
{
    class LockInLock
    {
        private readonly object _sync1 = new object();

        private readonly object _sync2 = new object();

        public void TestLockInLock()
        {
            lock(_sync1)
                lock(_sync1)
                {
                    Console.WriteLine("Double lock on one sync object are through");
                }
        }

        public void LongSyncOperation()
        {
            lock(_sync2)
            {
                Thread.Sleep(100000);
            }
        }

    }
}
