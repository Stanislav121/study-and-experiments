using System;
using System.Collections.Generic;
using MPC.Core;
using System.Threading;
using MPC.Transmitters;

namespace MPC.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var transmitter = new UnsafeTransmitter();
            var transmitter = new ConcurrentQueueTransmitter();

            var utilizer = new GoalCounter();
            IList<Producer> producers = new List<Producer>() { new Producer(new GoalGenerator(), transmitter) };
            IList<Consumer> consumers = new List<Consumer>();
            consumers.Add(new Consumer(utilizer, transmitter));
            consumers.Add(new Consumer(utilizer, transmitter));
            consumers.Add(new Consumer(utilizer, transmitter));


            GoalManager manager = new GoalManager(producers, consumers);
            manager.Run();
            Thread.Sleep(500);
            manager.Stop();
            Console.WriteLine(utilizer.IsAllGoalsProcessed());
            Console.ReadLine();
        }
    }
}
