using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace MPC.WikiProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWikiWordsProcess();
            //RunAction();


            Console.ReadLine();
        }

        private static void RunWikiWordsProcess()
        {
            var filePath = @"D:\For coding\enwiki-20201020-pages-articles-multistream1.xml-p1p41242";
            var pagesToProcess = 3000;

            var a = new WikiProcessorSequential();
            var resultSequential = a.ProcessMostFrequentWord(filePath, pagesToProcess);
            Console.WriteLine($"    {resultSequential.Item1} {resultSequential.Item2} {resultSequential.Item3}");

            var results = new List<Tuple<string, long, TimeSpan>>();
            var b = new WikiProcessorParallel();
            var resultSequentialB = b.ProcessMostFrequentWord(filePath, pagesToProcess, true, 18);
            results.Add(resultSequentialB);
            Console.WriteLine($"S   {resultSequentialB.Item1} {resultSequentialB.Item2} {resultSequentialB.Item3}");

            var c = new WikiProcessorParallel();
            var resultSequentialC = c.ProcessMostFrequentWord(filePath, pagesToProcess, true, 6);
            results.Add(resultSequentialC);
            Console.WriteLine($"S   {resultSequentialC.Item1} {resultSequentialC.Item2} {resultSequentialC.Item3}");

            var d = new WikiProcessorParallel();
            var resultSequentialD = d.ProcessMostFrequentWordParallel(filePath, pagesToProcess, true, 6);
            results.Add(resultSequentialD);
            Console.WriteLine($"S   {resultSequentialD.Item1} {resultSequentialD.Item2} {resultSequentialD.Item3}");


            results.ForEach(p => Console.WriteLine($"{resultSequential.Item3 / p.Item3}"));

            Console.WriteLine((resultSequential.Item2 == resultSequentialD.Item2) );

            //Console.WriteLine((resultSequential.Item2 == resultSequentialB.Item2) && (resultSequential.Item2 == resultSequentialC.Item2));

        }

        private static bool IsEqueal(IList<string> a, ConcurrentBag<string> b)
        {
            var list1 = new SortedSet<string>(a);
            var list2 = new SortedSet<string>(b);
            var c = list1.IsSubsetOf(list2) && list2.IsSubsetOf(list1);
            return list1.SetEquals(list2);
        }

        private static void RunAction()
        {
            double n = 1.4;
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task.Factory.StartNew(Boo, n, token);
        }


        private static void Boo(object s)
        {
            new Class1().Foo((double)s);
        }
    }
}
