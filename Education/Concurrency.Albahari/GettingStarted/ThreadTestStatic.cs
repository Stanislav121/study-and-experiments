using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Albahari.GettingStarted
{
    public class ThreadTestStatic
    {
        public static bool done;    // Static fields are shared between all threads

        public static void Go()
        {
            if (!done)
            {
                Console.WriteLine("Done");
                done = true; 
            }
        }
    }
}
