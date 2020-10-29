using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concurrency.Msdn.AsyncAwait.Examples;
using Concurrency.Msdn.AsyncAwait.Examples.JonSkeet;

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
            RunProcessingErrors();
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
