using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Albahari.GettingStarted
{
    public class ThreadTestObject
    {
        bool done;

        // Note that Go is now an instance method
        public void Go()
        {
            Console.WriteLine("First {0}", Thread.CurrentThread.ManagedThreadId);
            if (!done)
            {
                Console.WriteLine("In if {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                done = true; Console.WriteLine("Done");
            }
        }
    }
}
