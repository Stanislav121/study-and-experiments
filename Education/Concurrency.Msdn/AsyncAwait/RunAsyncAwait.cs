using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait
{
    class RunAsyncAwait
    {
        public void Run()
        {
            //RunSynchronousAsyncAwait();
            RunAsynchronousAsyncAwait();
            //RunExamples();
        }

        private void RunExamples()
        {
            Examples.Run();
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
