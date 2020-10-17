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
            var a = new SynchronousAsyncAwait();
            a.Start();
        }
    }
}
