using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadingExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            //var manualResetEventTest = new ManualResetEventWork();

            var a = new ThreadLikeLocalVariable();
            a.StartThreadLikeLocalVariable();

            //Console.ReadLine();
        }
    }
}
