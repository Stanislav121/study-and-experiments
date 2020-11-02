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
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            var task = DelayOperationAsync();
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            LogHelper.Write("Run2");
            task.Wait();
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
        }


        public static async Task DelayOperationAsync() // асинхронный метод
        {
            LogHelper.Write("BeforeCall");
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            Task task = Task.Delay(1000); //асинхронная операция
            LogHelper.Write("AfterCall");
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            //Thread.Sleep(200);
            await task.ConfigureAwait(false);
            LogHelper.Write("AfterAwait");
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
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




