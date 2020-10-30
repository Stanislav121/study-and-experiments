using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concurrency.Msdn.AsyncAwait.Examples;
using Concurrency.Msdn.AsyncAwait.Examples.JonSkeet;
using Concurrency.Msdn.AsyncAwait.Examples.ManyAsyncOperations;

namespace Concurrency.Msdn.AsyncAwait
{
    class RunAsyncAwait
    {
        public void Run()
        {
            //RunSynchronousAsyncAwait();
            //RunAsynchronousAsyncAwait();
            //RunTeplakov();
            //RunExamplesNetFiddle();
            //RunMyFirstStep();
            //RunProcessingErrors();
            //RunManyAsyncOperations();
            //RunOverview();
            RunFileReader();
        }

        private void RunFileReader()
        {
            var a = new FileReader();
            a.Run();
        }

        private void RunOverview()
        {
            Overview.Run();
        }

        private void RunManyAsyncOperations()
        {
            Directory.GetFiles("D:\\For coding\\Downloads\\").ToList().ForEach(f => File.Delete(f));

            var urls = new List<string>();
            urls.Add("http://lg.hosterby.com/1MB.test");
            urls.Add("http://lg.hosterby.com/10MB.test");
            urls.Add("http://lg.hosterby.com/100MB.test");

            var files = new List<string>();
            files.Add("D:\\For coding\\Downloads\\1MB.test");
            files.Add("D:\\For coding\\Downloads\\10MB.test");
            files.Add("D:\\For coding\\Downloads\\100MB.test");

            FileDownloader.DownloadFiles(urls, files);
        }

        private void RunProcessingErrors()
        {
            ProcessingErrors.Foo();
        }

        private void RunCascade()
        {
            Cascade.PrintPageLenghtAsync( );
        }

        private void RunMyFirstStep()
        {
            var a = new MyFirstStep();
            a.Run();
        }

        private void RunExamplesNetFiddle()
        {
            NetFiddle.Run();
        }

        private void RunTeplakov()
        {
            Teplakov.Run();
        }

        private void RunAsynchronousAsyncAwait()
        {
            var a = new AsynchronousAsyncAwait();
            a.Start();
        }

        private void RunSynchronousAsyncAwait()
        {
            var a = new SynchronousAsyncAwait();
            a.Start();
        }
    }
}
