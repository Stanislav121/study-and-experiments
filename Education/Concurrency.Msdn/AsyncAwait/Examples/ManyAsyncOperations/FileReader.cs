using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Concurrency.Msdn.AsyncAwait.Helpers;
using System.Threading;
using System.Diagnostics;

using System.Threading.Tasks.Schedulers;
using System.IO;

namespace Concurrency.Msdn.AsyncAwait.Examples.ManyAsyncOperations
{
    class FileReader
    {
        private static LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(1);
        public void Run()
        {
            LogHelper.Write("Run1");
            //LogHelper.Write("Run1 " + );
            //LogHelper.Write("Run1 " + (TaskScheduler.Current == TaskScheduler.Default));
            LogHelper.Write("SynchronizationContext " + SynchronizationContext.Current);
            var files = new List<string>();
            files.Add("D:\\For coding\\Files for read\\100MB.test");
            files.Add("D:\\For coding\\Files for read\\100MB2.test");
            files.Add("D:\\For coding\\Files for read\\100MB3.test");
            var cts = new CancellationTokenSource();
            var task = ReadFilesAsync(files, cts.Token);
            LogHelper.Write("Run2");
            cts.Cancel();
            task.Wait();
            LogHelper.Write("Run3");
        }

        private async Task ReadFilesAsync(List<string> files, CancellationToken ct)
        {
            var tasks = new List<Task>();
            foreach (var file in files)
            {
                var task = Task.Factory.StartNew(() => GetSumbolsCount(file, ct), ct);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }

        private long GetSumbolsCount(string fileName, CancellationToken ct)
        {
            long count = -1;
            LogHelper.Write(fileName + " " + count.ToString());
            using (FileStream fs = File.Open(fileName, FileMode.Open))
            {
                int b;
                do
                {
                    b = fs.ReadByte();
                    count++;
                }
                while (b != -1);
            }
            LogHelper.Write(fileName + " " + count.ToString());
            ct.ThrowIfCancellationRequested();
            return count;
        }
    }
}
