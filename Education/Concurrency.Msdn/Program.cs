using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Concurrency.Msdn
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunWorkWithCancellationToken();
            RunLockInLock();

            Console.ReadLine();
        }

        private static void RunLockInLock()
        {
            var a = new LockInLock();
            var thread = new Thread(a.LongSyncOperation);
            thread.Start();
            Thread.Sleep(100);
            a.TestLockInLock();
        }

        private static void RunWorkWithCancellationToken()
        {
            var a = new WorkWithCancellationToken();
            a.Run();
        }
    }
}
