using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ModelProducerConsumer.Core;
using System.Diagnostics;

namespace ModelProducerConsumer
{
    class Program
    {
        private static Timer _timer;

        static void Main(string[] args)
        {            
            //var watch = new Stopwatch();
            //watch.Start();
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

            
            
            //watch.Stop();
            
            var generators = new List<GeneratorOfNumbersToSumConsistently>();
            generators.Add(generator1);
            generators.Add(generator2);
            generators.Add(generator3);

            //Console.WriteLine("Elapsed time {0}, Processed items {1}", watch.Elapsed, generators.Sum(s => s.Number));
            

            _timer = new Timer(OnStop, Tuple.Create(manager, generators), 6000, Timeout.Infinite);
        }

        private static void OnStop(object obj)
        {
            var manager = ((Tuple<ManagerOfProducers, List<GeneratorOfNumbersToSumConsistently>>)obj).Item1;
            var generators = ((Tuple< ManagerOfProducers,List<GeneratorOfNumbersToSumConsistently>>)obj).Item2;
            manager.Stop();
            Console.Write("Generator values ");
            generators.ForEach(g => Console.Write(g.Number + " "));            
            Console.WriteLine(string.Format("Sum is {0}", generators.Sum(g => g.Number)));
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
