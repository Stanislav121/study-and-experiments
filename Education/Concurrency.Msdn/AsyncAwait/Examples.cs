using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait
{
    class Examples
    {
        public static void Run()
        {

            try
            {
                Console.WriteLine("Main thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                var task = AsyncVersion();
                Console.WriteLine("Right after AsyncVersion() method call");
                //Ожидаем завершения асинхронной операции
                task.Wait();
                Console.WriteLine("Asyncronous task finished!");

            }
            catch (System.AggregateException e)
            {
                //Все исключения в TPL пробрасываются обернутые в AggregateException
                Console.WriteLine("AggregateException: {0}", e.InnerException.Message);
            }
            Console.ReadLine();
        }
        static async Task AsyncVersion()
        {
            Stopwatch sw = Stopwatch.StartNew();
            string url1 = "http://rsdn.ru";
            string url2 = "http://gotdotnet.ru";
            string url3 = "http://blogs.msdn.com";

            var webRequest1 = WebRequest.Create(url1);
            Console.WriteLine("Before webRequest1.GetResponseAsync(). Thread Id: {0}",
                Thread.CurrentThread.ManagedThreadId);

            var webResponse1 = await webRequest1.GetResponseAsync();
            Console.WriteLine("{0} : {1}, elapsed {2}ms. Thread Id: {3}", url1,
                webResponse1.ContentLength, sw.ElapsedMilliseconds,
                Thread.CurrentThread.ManagedThreadId);

            var webRequest2 = WebRequest.Create(url2);
            Console.WriteLine("Before webRequest2.GetResponseAsync(). Thread Id: {0}",
                Thread.CurrentThread.ManagedThreadId);

            var webResponse2 = await webRequest2.GetResponseAsync();
            Console.WriteLine("{0} : {1}, elapsed {2}ms. Thread Id: {3}", url2,
                webResponse2.ContentLength, sw.ElapsedMilliseconds,
                Thread.CurrentThread.ManagedThreadId);

            //var webRequest3 = WebRequest.Create(url3);
            //Console.WriteLine("Before webRequest3.GetResponseAsync(). Thread Id: {0}",
            //    Thread.CurrentThread.ManagedThreadId);
            //var webResponse3 = await webRequest3.GetResponseAsync();
            //Console.WriteLine("{0} : {1}, elapsed {2}ms. Thread Id: {3}", url3,
            //    webResponse3.ContentLength, sw.ElapsedMilliseconds,
            //    Thread.CurrentThread.ManagedThreadId);
        }
    }

    
}
