using System;
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace MPC.WikiProcessor
{
    class PageConsumer
    {
        private readonly BlockingCollection<string> _transmitter;
        private readonly Dictionary<string, long> _generalWordsCount;

        public PageConsumer(BlockingCollection<string> transmitter)
        {
            _transmitter = transmitter;
            _generalWordsCount = new Dictionary<string, long>();
        }

        public Dictionary<string, long> Run(bool runWithSpin)
        {
            if (runWithSpin)
            {
                Run();
                return _generalWordsCount;
            }
            RunSafely();
            return _generalWordsCount;
        }

        private void Run()
        {
            //Very long
            string line;
            while (!_transmitter.IsCompleted)
            {
                if (!_transmitter.TryTake(out line))
                    continue;
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    CountWordsInPage(word);
                }
            }
        }

        private void RunSafely()
        {
            try
            {
                while (!_transmitter.IsCompleted)
                {
                    var line = _transmitter.Take();
                    var words = line.Split(' ');
                    foreach (var word in words)
                    {
                        CountWordsInPage(word);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                //Console.WriteLine($"CollectionExtensions is empry and close {ex.Message}");
            }            
        }

        private void CountWordsInPage(string word)
        {
            if (_generalWordsCount.ContainsKey(word))
            {
                _generalWordsCount[word]++;
            }
            else
            {
                _generalWordsCount.Add(word, 1);
            }
        }

        
    }
}
