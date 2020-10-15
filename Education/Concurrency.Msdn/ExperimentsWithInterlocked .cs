using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Concurrency.Msdn
{
    class ExperimentsWithInterlocked
    {
        public int Accum;
        public double TrueResult;

        public int Accum2;
        private ThreadSafety _locking = new ThreadSafety();

        public void IncrementAccumulatorUnsafe(Object stateInfo)
        {
            //Accum++;
            Console.WriteLine("On start " + Volatile.Read(ref Accum));
            for (int i = 0; i < 300000; i++)
            {
                Accum += 1;
                //Console.WriteLine(" " + Accum);
            }
            Console.WriteLine("End " + Accum);
        }

        public void IncrementAccumulatorSafe(Object stateInfo)
        {
            Console.WriteLine("On start " + Volatile.Read(ref Accum));
            var temp = 0;
            int i;
            for (i = 0; i < 300000; i++)
            {
                temp = Accum;
                while (temp != Interlocked.CompareExchange(ref Accum, temp + 1, temp))
                {
                    temp = Accum;
                }
                
                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + i + " " + Accum);
            }
            Console.WriteLine("End II " + i);
            Console.WriteLine("End " + Accum);
        }

        public void IncrementUnsafe()
        {
            for (int i = 0; i < 300000; i++)
            {
                _locking.Take();
                Accum2++;
                _locking.Release();
            }
        }
    }
}
