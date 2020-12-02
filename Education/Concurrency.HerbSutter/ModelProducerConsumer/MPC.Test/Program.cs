using System;
using System.Collections.Generic;
using MPC.Core;
using System.Threading;
using MPC.Transmitters;
using System.Diagnostics;

namespace MPC.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var utilizer = new GoalCounter();
            var utilizer = new EmptyUtilizer();
            TestMPCs(utilizer);

            //TestConcurrentQueueDIY();
            Console.WriteLine("End");
            Console.ReadLine();
        }

        private static void TestConcurrentQueueDIY()
        {
            var queue = new ConcurrentQueueDIY<int>();

            int a;
            queue.Enqueue(1);
            queue.Enqueue(2);
            //queue.TryDequeue(out a);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);

            while (true)
            {
                int item;
                var isEmpty = !queue.TryDequeue(out item);
                if (isEmpty)
                    break;
                Console.WriteLine(item);
            }           
            
        }

        private static void TestMPCs(IGoalUtilizer utilizer)
        {
            //RunMPC(new UnsafeTransmitter());
            //RunMPC(new ConcurrentQueueDIYTransmitter(), utilizer);
            
            RunMPC(new ConcurrentQueueTransmitter(), utilizer);

            RunMPC(new MonitorTransmitter(), utilizer);
            using (var transmitter = new SemaphoreSlimTransmitter())
            {
                RunMPC(transmitter, utilizer);
            }
            using (var transmitter = new SemaphoreTransmitter(true))
            {
                RunMPC(transmitter, utilizer);
            }
            using (var transmitter = new SemaphoreTransmitter(false))
            {
                RunMPC(transmitter, utilizer);
            }
            RunMPC(new InterlockedTransmitter(), utilizer);
            using (var transmitter = new MutexTransmitter(true))
            {
                RunMPC(transmitter, utilizer);
            }
            using (var transmitter = new MutexTransmitter(false))
            {
                RunMPC(transmitter, utilizer);
            }
            using (var transmitter = new AutoResetEventTransmitter())
            {
                RunMPC(transmitter, utilizer);
            }
            using (var transmitter = new EventWaitHandleAutoTransmitter())
            {
                RunMPC(transmitter, utilizer);
            }
        }

        private static void RunMPC(ITransmitter transmitter, IGoalUtilizer utilizer)
        {
            var generator = new GoalGenerator();
            IList<Producer> producers = new List<Producer>() { new Producer(generator, transmitter) };
            IList<Consumer> consumers = new List<Consumer>();
            consumers.Add(new Consumer(utilizer, transmitter));
            consumers.Add(new Consumer(utilizer, transmitter));
            consumers.Add(new Consumer(utilizer, transmitter));
            GoalManager manager = new GoalManager(producers, consumers);

            Stopwatch stopWatchBody = new Stopwatch();
            stopWatchBody.Start();

            manager.Run();
            Thread.Sleep(5000);//22 000 000
            manager.Stop();
            
            stopWatchBody.Stop();            
            string elapsedTimeBody = ConvertTSToString(stopWatchBody.Elapsed);
            Stopwatch stopWatchFinish = new Stopwatch();
            stopWatchFinish.Start();
            var isOk = utilizer.WasUtilizeSuccessful();
            stopWatchFinish.Stop();
            string elapsedTimeFinish = ConvertTSToString(stopWatchFinish.Elapsed);
            Console.WriteLine($"{transmitter.GetType().Name.PadRight(30)} isOk {isOk} nGoals: {generator.Counter} BodyTime: {elapsedTimeBody} FinishTime: {elapsedTimeFinish}");

        }

        private static string ConvertTSToString(TimeSpan ts)
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }
    }
}
