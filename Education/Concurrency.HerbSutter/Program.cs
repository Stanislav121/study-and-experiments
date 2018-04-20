using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Concurrency.HerbSutter.LockFree;

namespace Concurrency.HerbSutter
{
    class Program
    {
        static void Main(string[] args)
        {
            //var lockFreeConstruction1 = new LockFreeConstructions();
            //LockFreeStarter.Start(lockFreeConstruction1, lockFreeConstruction1.ConcurrencyUnsafe);

            //var lockFreeConstruction2 = new LockFreeConstructions();
            //LockFreeStarter.Start(lockFreeConstruction2, lockFreeConstruction2.BasedOnLock);

            var lockFreeConstruction3 = new LockFreeConstructions();
            LockFreeStarter.Start(lockFreeConstruction3, lockFreeConstruction3.BasedOnWhile);

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
