using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppDomain
{
    [Serializable]
    class BigClass
    {
        public void LongMethod()
        {
            Console.WriteLine("Start LongMethod {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);
            Console.WriteLine("End LongMethod");
        }
    }
}
