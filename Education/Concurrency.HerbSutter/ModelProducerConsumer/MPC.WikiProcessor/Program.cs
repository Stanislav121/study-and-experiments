

using System;

namespace MPC.WikiProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"D:\For coding\enwiki-20201020-pages-articles-multistream1.xml-p1p41242";
            var pagesToProcess = 300;

            var a = new WikiProcessorSequential();
            var resultSequentialA = a.ProcessMostFrequentWord(filePath, pagesToProcess);
            Console.WriteLine($"{resultSequentialA.Item1} {resultSequentialA.Item2} {resultSequentialA.Item3}");

            var b = new WikiProcessorParallel();
            var resultSequentialB = b.ProcessMostFrequentWord(filePath, pagesToProcess);
            Console.WriteLine($"{resultSequentialB.Item1} {resultSequentialB.Item2} {resultSequentialB.Item3}");

            if (resultSequentialA.Item2 != resultSequentialB.Item2)
                throw new Exception("Different count");
            
        }
    }
}
