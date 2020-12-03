using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait.Examples
{
    class WrapSyncInAsync
    {
        
        public static void Run()
        {
            Directory.GetFiles("D:\\For coding\\Downloads\\").ToList().ForEach(f => File.Delete(f));
            Console.WriteLine("Start Run");
            var task = DownLoadString();
            Console.WriteLine("Middle Run");
            Console.WriteLine(task.Result.Length);
            //task.Wait();
            Console.WriteLine("End Run");
        }

        private async static Task<string> DownLoadString()
        {
            var webClient = new WebClient();
            Console.WriteLine("Start DownLoadFile");
            //var task = webClient.DownloadStringTaskAsync("http://csharpindepth.com");
            var task = DownloadFileTaskAsync();
            Console.WriteLine("Middle DownLoadFile");
            Console.WriteLine((await task).Length);
            //string text = await task; 
            Console.WriteLine("End DownLoadFile");
            return "";
        }

        private async static Task DownLoadFile()
        {
            var webClient = new WebClient();
            Console.WriteLine("Start DownLoadFile");
            var task = webClient.DownloadFileTaskAsync("http://lg.hosterby.com/100MB.test", "D:\\For coding\\Downloads\\100MB.test");
            //var task = DownloadFileTaskAsync();
            Console.WriteLine("Middle DownLoadFile");
            
            await task;
            Console.WriteLine("End DownLoadFile");
            task.Wait();
            return;
        }

        private static Task<string> DownloadFileTaskAsync()
        {
            var webClient = new WebClient();
            var task = Task.Run(() => webClient.DownloadString("http://csharpindepth.com"));
            //task.Start();
            return task;
        }


    }
}
