using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Albahari.GettingStarted
{
    public static class SamplesRunner
    {
        public static void TestThreadTestStatic()
        {
            new Thread(ThreadTestStatic.Go).Start();
            ThreadTestStatic.Go();
        }

        public static void TestThreadTestObject()
        {
            ThreadTestObject tt = new ThreadTestObject();   // Create a common instance
            new Thread(tt.Go).Start();
            tt.Go();
        }
    }
}
