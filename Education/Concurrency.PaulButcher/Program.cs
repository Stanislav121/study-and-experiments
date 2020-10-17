using Concurrency.PaulButcher.Chapter2.Day1.DiningPhilosophers;
using System;
using System.Threading;

namespace Concurrency.PaulButcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Dinner(2);
            var thread = new Thread(a.StartDinner);
            thread.Start();
            Console.WriteLine("Dinner is started!");
            Console.ReadLine();
            
            a.StopDinner();
        }
    }
}
