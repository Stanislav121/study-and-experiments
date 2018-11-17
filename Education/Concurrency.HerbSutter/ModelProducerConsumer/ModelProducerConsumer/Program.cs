using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ModelProducerConsumer.Core;

namespace ModelProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new ManagerOfProducers();
            manager.AddProducer(new GeneratorOfNumbersToSumConsistently());
            manager.AddProducer(new GeneratorOfNumbersToSumConsistently());
            manager.AddProducer(new GeneratorOfNumbersToSumConsistently());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());

            Console.ReadLine();
            manager.Stop();
            Console.ReadLine();
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
