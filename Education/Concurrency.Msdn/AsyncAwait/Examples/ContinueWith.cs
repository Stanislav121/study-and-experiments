using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait.Examples
{
    class ContinueWith
    {
        public static void Run()
        {
            var task0 = new Task(Foo1);
            var task = task0.ContinueWith((t) => Foo2());
            task.ContinueWith((t) => Foo3());
            task.ContinueWith((t) => Foo4());

            task0.Start();
            task0.Wait();
        }

        private static void Foo1()
        {
            Thread.Sleep(3000);
            Console.WriteLine(nameof(Foo1));
        }

        private static void Foo2()
        {
            Thread.Sleep(3000);
            Console.WriteLine(nameof(Foo2));
        }

        private static void Foo3()
        {
            Thread.Sleep(3000);
            Console.WriteLine(nameof(Foo3));
        }

        private static void Foo4()
        {
            Thread.Sleep(3000);
            Console.WriteLine(nameof(Foo4));
        }
    }
}
