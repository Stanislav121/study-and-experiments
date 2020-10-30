using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Concurrency.Msdn.AsyncAwait.Helpers;

using TCO = System.Threading.Tasks.TaskCreationOptions;

namespace Concurrency.Msdn.AsyncAwait.Examples
{
    class Overview
    {
        public static void Run()
        {
            LogHelper.Write("Run1");
            var task = VoidAsyncMethod();
            LogHelper.Write("Run2");
            task.Wait();
        }


        public static async Task VoidAsyncMethod()
        {
            LogHelper.Write("VoidAsyncMethod1");
            var cancellationSource = new CancellationTokenSource();

            await Task.Factory.StartNew(
                // Code of action will be executed on other context
                () => Thread.Sleep(2000),
                cancellationSource.Token,
                TCO.LongRunning | TCO.AttachedToParent | TCO.PreferFairness,
                TaskScheduler.Current
            ).ConfigureAwait(true);
            LogHelper.Write("VoidAsyncMethod2");
            //  Code after await will be executed on captured context
            return;
        }
    }
}




