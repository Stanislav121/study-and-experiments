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
            Console.ReadLine();
        }

        private static void TestMPCs(IGoalUtilizer utilizer)
        {
            //RunMPC(new UnsafeTransmitter());
            RunMPC(new ConcurrentQueueTransmitter(), utilizer);
            RunMPC(new MonitorTransmitter(), utilizer);
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
            Thread.Sleep(500);
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
