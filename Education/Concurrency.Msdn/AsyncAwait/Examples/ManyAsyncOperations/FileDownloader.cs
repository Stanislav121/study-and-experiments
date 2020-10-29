using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Concurrency.Msdn.AsyncAwait.Helpers;

namespace Concurrency.Msdn.AsyncAwait.Examples.ManyAsyncOperations
{
    class FileDownloader
    {
        public static void DownloadFiles(IList<string> urls, IList<string> fileNames)
        {
            var task = DownloadFilesAsync(urls, fileNames);
            LogHelper.Write("DownloadFiles. Start file downloading");

            try
            {
                task.Wait();
            }
            catch (Exception ex)
            {
                LogHelper.Write("Some problems " + ex.Message + " Inner " + ex.InnerException);
            }

            LogHelper.Write("DownloadFiles. Finish file downloading");
        }

        public static async Task DownloadFilesAsync(IList<string> urls, IList<string> fileNames)
        {
            //var webClient = new WebClient();
            var urlsInner = urls.Select(s => Tuple.Create(s, new WebClient())).ToList();
            var tasks = new List<Task>();
            for (int i = 0; i < urls.Count; i++)
            {
                var task = urlsInner[i].Item2.DownloadFileTaskAsync(urlsInner[i].Item1, fileNames[i]);
                task.ContinueWith((t, fileName) => { LogHelper.Write(fileName + " is downloaded"); }, fileNames[i],
                    TaskContinuationOptions.OnlyOnRanToCompletion);
                task.ContinueWith((t, fileName) => { LogHelper.Write("I can't download file " + fileName); }, fileNames[i],
                    TaskContinuationOptions.OnlyOnFaulted);
                tasks.Add(task);
            }
            LogHelper.Write("DownloadFilesAsync. Start file downloading");

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (WebException ex)
            {
                LogHelper.Write("I can't download file " + ex.Message + " " + ex.Response + " " + ex.Status + " Inner " + ex.InnerException);
            }

            //TODO
            urlsInner.ToList().ForEach(s => s.Item2.Dispose());
            //webClient.Dispose();

            return;
        }

        private static void Foo(Task task)
        {
            LogHelper.Write(" is downloaded");
        }
    }
}
