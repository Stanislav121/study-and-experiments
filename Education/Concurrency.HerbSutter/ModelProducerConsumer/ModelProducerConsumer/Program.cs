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
            var generator1 = new GeneratorOfNumbersToSumConsistently();
            var generator2 = new GeneratorOfNumbersToSumConsistently();
            var generator3 = new GeneratorOfNumbersToSumConsistently();
            manager.AddProducer(generator1);
            manager.AddProducer(generator2);
            manager.AddProducer(generator3);
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());
            manager.AddConsumer(new SummatorOfNumbers());

            Console.ReadLine();
            manager.Stop();
            Console.ReadLine();
            var generators = new List<GeneratorOfNumbersToSum>();
            Console.WriteLine("Generator values {0} {1} {2}", generator1.Number-1, generator2.Number-1, generator3.Number-1);
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
