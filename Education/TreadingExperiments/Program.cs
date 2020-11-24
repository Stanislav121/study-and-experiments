using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TreadingExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            //var manualResetEventTest = new ManualResetEventWork();
            //var a = new ThreadLikeLocalVariable();
            //a.StartThreadLikeLocalVariable();

            var list = new ArrayList { 1, 2, 3 };

            var x1 = new { Items = ((IEnumerable<int>)list).GetEnumerator() };
            while (x1.Items.MoveNext())
            {
                Console.WriteLine(x1.Items.Current);
            }

            Console.ReadLine();

            var x2 = new { Items = list.GetEnumerator() };
            while (x2.Items.MoveNext())
            {
                Console.WriteLine(x2.Items.Current);
            }

            Console.ReadLine();
        }
    }
}
