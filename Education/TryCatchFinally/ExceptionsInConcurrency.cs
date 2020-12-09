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
            //ExceptionsInThreadPoolThreadNotCatched();
            //ExceptionsInTaskNotCached();
            ExceptionsInTaskCached();
        }

        private static void ExceptionsInTaskNotCached()
        {
            Task.Run(() => throw new Exception("Taaaaaaaaaaaaask")); ;
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

        private static void ThrowException()
        {
            throw new Exception("Aaaaa");
        }
    }
}
