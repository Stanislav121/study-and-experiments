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


namespace Concurrency.Msdn.AsyncAwait.Examples.ManyAsyncOperations
{
    class FileDownloader
    {
        private static Stopwatch _stopwatch = new Stopwatch();
        private static LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(1);


        public static void DownloadFiles(IList<string> urls, IList<string> fileNames)
        {
            //todo вЫПОЛНИТЬ ВСЕ В ОДНОМ ПОТОКЕ

            _stopwatch.Start();
            var task = DownloadFilesAsync(urls, fileNames);
            LogHelper.Write("DownloadFiles. Start file downloading");

            try
            {
                LogHelper.Write(task.Result + " files are downloaded");
            }
            catch (Exception ex)
            {
                LogHelper.Write("Some problems " + ex.Message + " Inner " + ex.InnerException);
            }

            _stopwatch.Stop();
            TimeSpan ts = _stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            LogHelper.Write("DownloadFiles. Finish file downloading " + elapsedTime);
        }

        public static async Task<int> DownloadFilesAsync(IList<string> urls, IList<string> fileNames)
        {
            //var webClient = new WebClient();
            var downloadedFiles = 0;
            var urlsInner = urls.Select(s => Tuple.Create(s, new WebClient())).ToList();
            var tasks = new List<Task>();
            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            for (int i = 0; i < urls.Count; i++)
            {
                //Task task = new Task(Foo);
                var task =  urlsInner[i].Item2.DownloadFileTaskAsync(urlsInner[i].Item1, fileNames[i]);
                task.ContinueWith((t, fileName) => { LogHelper.Write(fileName + " is downloaded"); Interlocked.Increment(ref downloadedFiles); }, fileNames[i],
                    ct, TaskContinuationOptions.OnlyOnRanToCompletion, lcts);
                task.ContinueWith((t, fileName) => { LogHelper.Write("I can't download file " + fileName); }, fileNames[i],
                    ct, TaskContinuationOptions.OnlyOnFaulted, lcts);
                tasks.Add(task);
            }
            LogHelper.Write("DownloadFilesAsync. Start file downloading");

            try
            {
                await Task.WhenAll(tasks);                
                LogHelper.Write("DownloadFilesAsync. End file downloading");
            }
            catch (WebException ex)
            {
                LogHelper.Write("Catched. I can't download file " + ex.Message + " " + ex.Response + " " + ex.Status + " Inner " + ex.InnerException);
            }
            downloadedFiles = tasks.Count(t => t.IsCompleted);

            //TODO
            urlsInner.ToList().ForEach(s => s.Item2.Dispose());
            //webClient.Dispose();

            return downloadedFiles;
        }

        private static void Foo()
        {
            Console.WriteLine("Start task");
        }
    }
}
