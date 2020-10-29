using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Concurrency.Msdn.AsyncAwait.Helpers
{
    class LogHelper
    {
        public static void Write(string text)
        {
            string message = Thread.CurrentThread.ManagedThreadId + " " + text;
            Console.WriteLine(message);
        }
    }
}
