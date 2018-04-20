using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main {0}", Thread.CurrentThread.ManagedThreadId);

            var bigObject = new BigClass();
            System.AppDomain otherDomain = System.AppDomain.CreateDomain("otherDomain");
            otherDomain.DoCallBack(new CrossAppDomainDelegate(bigObject.LongMethod));

            Console.WriteLine("End Main");
        }
    }
}
