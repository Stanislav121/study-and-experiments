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
            //RunLockInLock();

            //RunExperimentsWithInterlocked();
            //RunIncrementAccumulatorSafe();

            RunIncrementSafe();

            Console.ReadLine();
        }

        private static void RunIncrementSafe()
        {
            var a = new ExperimentsWithInterlocked();
            var thread1 = new Thread(a.IncrementUnsafe);
            var thread2 = new Thread(a.IncrementUnsafe);
            var thread3 = new Thread(a.IncrementUnsafe);
            var thread4 = new Thread(a.IncrementUnsafe);

            thread3.Start();
            thread4.Start();
            thread2.Start();
            thread1.Start();
            thread1.Join();
            Console.WriteLine("   " + a.Accum2);
            thread2.Join();
            thread3.Join();
            thread4.Join();
            Console.WriteLine("Result " + a.Accum2);
        }

        

        private static void RunIncrementAccumulatorSafe()
        {
            var a = new ExperimentsWithInterlocked();
            var thread1 = new Thread(a.IncrementAccumulatorSafe);
            var thread2 = new Thread(a.IncrementAccumulatorSafe);
            
            thread2.Start();
            thread1.Start();
            thread1.Join();
            Console.WriteLine("   " + a.Accum);
            thread2.Join();
            Console.WriteLine("Result " + a.Accum + " " + (a.TrueResult == a.Accum));
        }

        private static void RunExperimentsWithInterlocked()
        {
            var a = new ExperimentsWithInterlocked();
            a.IncrementAccumulatorUnsafe(null);
            Console.WriteLine("Accum " + a.Accum + " *2 " + (a.Accum*2));
            a.TrueResult = a.Accum * 2;
            a.Accum = 0;

            var thread1 = new Thread(a.IncrementAccumulatorUnsafe);
            var thread2 = new Thread(a.IncrementAccumulatorUnsafe);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            Console.WriteLine("   " + a.Accum);
            thread2.Join();
            Console.WriteLine("Result " + a.Accum + " " + (a.TrueResult == a.Accum));
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
