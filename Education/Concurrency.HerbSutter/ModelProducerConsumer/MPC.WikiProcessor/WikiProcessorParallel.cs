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
        public Tuple<string, long, TimeSpan> ProcessMostFrequentWord(string filePath, long pagesToProcess, bool runSafely, bool runWithSpin, int nConsumers, bool byTasks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var transmitter = new BlockingCollection<string>();
            var producer = new PageProducer(filePath, pagesToProcess, transmitter);

            var results = byTasks ? WorkByTasks(transmitter, producer, runSafely, runWithSpin, nConsumers) : WorkByParallel(transmitter, producer, runSafely, runWithSpin, nConsumers);

            var generalWordsCount = new Dictionary<string, long>(results[0]);
            for(int i = 1; i < nConsumers; i++ )
            foreach (var word in results[i])
            {
                if (generalWordsCount.ContainsKey(word.Key))
                    generalWordsCount[word.Key] += word.Value;
                else
                    generalWordsCount.Add(word.Key, word.Value);
            }

            var biggestCount = generalWordsCount.Values.Max();
            string mostFrequentWord = string.Empty;
            foreach (var wordCount in generalWordsCount)
            {
                if (wordCount.Value == biggestCount)
                    mostFrequentWord = wordCount.Key;
            }

            return Tuple.Create(mostFrequentWord, biggestCount, watch.Elapsed);
        }

        private Dictionary<string, long>[] WorkByTasks(BlockingCollection<string> transmitter, PageProducer producer, bool runSafely, bool runWithSpin, int nConsumers)
        {
            var tasks = new Task<Dictionary<string, long>>[nConsumers];
            for (int i = 0; i < nConsumers; i++)
                tasks[i] = Task.Factory.StartNew((b) => { return new PageConsumer(transmitter).Run(runSafely, runWithSpin); }, runSafely);

            Task.Run(producer.Run);

            Task.WaitAll(tasks);

            var results = new Dictionary<string, long>[nConsumers];
            for (int i = 0; i < nConsumers; i++)
                results[i] = tasks[i].Result;
            return results;
        }

        private Dictionary<string, long>[] WorkByParallel(BlockingCollection<string> transmitter, PageProducer producer, bool runSafely, bool runWithSpin, int nConsumers)
        {
            Task.Run(producer.Run);

            var results = new Dictionary<string, long>[nConsumers];
            Parallel.For(0, results.Length,
              i => results[i] = new PageConsumer(transmitter).Run(runSafely, runWithSpin));

            return results;
        }
    }
}
