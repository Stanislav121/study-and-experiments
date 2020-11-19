using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MPC.WikiProcessor
{
    class WikiProcessorParallel
    {
        public Tuple<string, long, TimeSpan> ProcessMostFrequentWord(string filePath, long pagesToProcess)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var transmitter = new BlockingCollection<string>(1000);
            var producer = new PageProducer(filePath, pagesToProcess, transmitter);
            var generalWordsCount = new ConcurrentDictionary<string, long>();

            var nConsumers = 4;
            var tasks = new Task[nConsumers];
            for(int i = 0; i < nConsumers; i++)
                tasks[i] = (Task.Run((new PageConsumer(transmitter, generalWordsCount)).Run));

            Task.Run(producer.Run);

            Task.WaitAll(tasks);

            var biggestCount = generalWordsCount.Values.Max();
            string mostFrequentWord = string.Empty;
            foreach (var wordCount in generalWordsCount)
            {
                if (wordCount.Value == biggestCount)
                    mostFrequentWord = wordCount.Key;
            }

            return Tuple.Create(mostFrequentWord, biggestCount, watch.Elapsed);
        }
    }
}
