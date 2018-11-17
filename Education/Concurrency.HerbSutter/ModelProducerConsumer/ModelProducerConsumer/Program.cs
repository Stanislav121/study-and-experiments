using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModelProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestYeild();
        }

        private static void TestYeild()
        {
            var isSwitched = Thread.Yield();
            Console.WriteLine(isSwitched);
            Console.ReadLine();
        }

        private static void TestInterlocked()
        {
            int b = 1;
            var a = Interlocked.Increment(ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.ReadLine();
        }
    }
}
