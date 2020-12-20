using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MPC.Core;

namespace MPC.Light
{
    class Program
    {
        


        static void Main(string[] args)
        {           
            TestMPC(new WaitPulseTransmitter(new Queue<Goal>()));
            TestMPC(new ConcurrentQueueTransmitter(new ConcurrentQueue<Goal>()));
            //var nGoals = 9000000000; TODO Разберись, почему не хватает памяти
            
            Console.Read();
        }

        private static void TestMPC(ITransmitter transmitter)
        {
            var sw = new Stopwatch();
            sw.Start();
            var nGoals = 90000000;
            int nConsumer = 3;
            var producer = new Producer(transmitter, nGoals, nConsumer);
            var consumers = new List<Consumer>(nConsumer);
            WaitHandle[] waitHandles = new WaitHandle[nConsumer];
            for (int i = 0; i < nConsumer; i++)
            {
                var waitHandle = new AutoResetEvent(false);
                waitHandles[i] = waitHandle;
                consumers.Add(new Consumer(transmitter, waitHandle));
            }
            producer.Start();
            consumers.ForEach(s => s.Start());

            var set = new HashSet<long>();
            for (long i = 0; i < nGoals; i++)
            {
                set.Add(i);
            }
            WaitHandle.WaitAll(waitHandles);
            foreach (var consumer in consumers)
            {
                foreach (var goal in consumer.Goals)
                {
                    if (set.Contains(goal))
                        set.Remove(goal);
                    else
                        Console.WriteLine($"Can't find goal id {goal}");
                }
            }

            sw.Stop();
            Console.WriteLine($"{transmitter.GetType().Name.PadRight(30)} {set.Count} {sw.Elapsed.ToString()}");
        }
    }
}
