using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Concurrency.Msdn.AsyncAwait.Examples
{
    class MyFirstStep
    {
        public void Run()
        {
            WriteLog("Run 1");
            var task = WorkAsync();
            WriteLog("Run 2");
            task.Wait();
            WriteLog("Run 3");
        }

        private async Task WorkAsync()
        {
            WriteLog("WorkAsync1");
            var task = Task.Run(SomeWork);
            Thread.Sleep(100);
            WriteLog("WorkAsync2");
            await task;
        }

        private void SomeWork()
        {
            WriteLog("SomeWork Start");
            //Thread.Sleep(100);
            for (int i = 0; i < 3; i++)
            {
                WriteLog("SomeWork " + i);
            }
            WriteLog("SomeWork End");
        }

        public static void WriteLog(string text)
        {
            string message = Thread.CurrentThread.ManagedThreadId + " " + text;
            Console.WriteLine(message);
        }
    }
}
