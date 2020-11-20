using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace MPC.WikiProcessor
{
    class WikiProcessorSequential
    {
        private readonly Dictionary<string, long> _wordsCount = new Dictionary<string, long>();
        public readonly IList<string> Lines = new List<string>();

        private void CountWordsInPage(string word)
        {
            if (_wordsCount.ContainsKey(word))
            {
                _wordsCount[word]++;
            }
            else 
            {
                _wordsCount.Add(word, 1);
            }
        }

        public Tuple<string, long, TimeSpan> ProcessMostFrequentWord(string filePath, long pagesToProcess)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            long pageCount = 0;
            bool stop = false;
            using (XmlReader reader = XmlReader.Create(fs))
            {
                while (reader.Read() & !stop)
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Text:
                            var line = reader.Value;
                            Lines.Add(line);
                            var words = line.Split(' ');
                            foreach (var word in words)
                            {
                                CountWordsInPage(word);
                            }

                            pageCount++;
                            if (pageCount == pagesToProcess)
                                stop = true;
                            break;
                    }
                }

                var biggestCount = _wordsCount.Values.Max();
                string mostFrequentWord = string.Empty;
                foreach (var wordCount in _wordsCount)
                {
                    if (wordCount.Value == biggestCount)
                        mostFrequentWord = wordCount.Key;
                }

                watch.Stop();
                return Tuple.Create(mostFrequentWord, biggestCount, watch.Elapsed);
            }
        }
    }
}
