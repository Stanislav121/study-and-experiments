using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TryCatchFinally
{
    class ExceptionsInConcurrency
    {
        public static void Run()
        {
            //ExceptionsInMainThreadNotCatched();
            //ExceptionsInMainThreadCatched();
            //ExceptionsInBackgroundThreadNotCatched();
            ExceptionsInThreadPoolThreadNotCatched();
            //ExceptionsInTaskNotCached();
            //ExceptionsInTaskCached();
            //Sample();
            //ExceptionsInTaskNotCachedAndThrow();
            Console.WriteLine("Aaa");           
        }

        private static void ExceptionsInTaskNotCachedAndThrow()
        {
            var t = StartTaskWithExceptionAsync();
            t.Wait();
        }

        private async static Task StartTaskWithExceptionAsync()
        {
            var task = Task.Run(ThrowException);

            await task;
        }

        private static void ThrowException()
        {
            //Thread.Sleep(100); 
            throw new Exception("Aaaaa");
        }

        private static void Sample()
        {
            try
            {
                Task t1 = Task.Run(ThrowException);
                Task t2 = Task.Run(ThrowException);
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Sample()"); 
            }
        }

        private static void Try(string[] args)
        {
            Task someTask;
            try
            {
                someTask = Task.Factory.StartNew(() => throw new Exception());
            }
            catch (Exception ex)
            {
                Console.WriteLine("1. Bam");
                return;
            }

            try
            {
                AggregateException someTaskException = someTask.Exception;
            }
            catch (Exception ex)
            {
                Console.WriteLine("2. Bam-bam");
                return;
            }

            try
            {
                someTask.GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine("3. Bam-bam-bam");
                return;
            }

            Console.WriteLine("4. No bam");
        }


        private static void ExceptionsInTaskNotCached()
        {
            var t = Task.Run(ThrowException);
            Console.WriteLine("111");
            Thread.Sleep(3000);
            var ex = t.Exception;
            Console.WriteLine("Exep");
        }


        private static void ExceptionsInTaskCached()
        {
            var task = Task.Run(() => throw new Exception("Taaaaaaaaaaaaask"));
            task.Wait();
            Console.WriteLine("Newer printed");
        }

        private static void ExceptionsInThreadPoolThreadNotCatched()
        {
            ThreadPool.QueueUserWorkItem(ThrowExceptionObject, new object());          
        }

        private static void ExceptionsInBackgroundThreadNotCatched()
        {
            var thread = new Thread(ThrowException);
            thread.IsBackground = true;
            thread.Start();
        }

        private static void ExceptionsInMainThreadNotCatched()
        {
            var thread = new Thread(ThrowException);
            thread.Start();
        }

        private static void ExceptionsInMainThreadCatched()
        {
            try
            {
                var thread = new Thread(ThrowException);
                thread.Start();
            }
            catch
            {
                Console.WriteLine("ExceptionsInMainThreadCatched");
            }
        }

        private static void ThrowExceptionObject(Object obj)
        {
            throw new Exception("Aaaaa");
        }

        
    }
}
