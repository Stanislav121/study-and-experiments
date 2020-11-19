using System.Collections.Concurrent;
using System.Collections.Generic;


namespace MPC.WikiProcessor
{
    class PageConsumer
    {
        private readonly BlockingCollection<string> _transmitter;
        private readonly Dictionary<string, long> _wordsCount = new Dictionary<string, long>();
        private readonly ConcurrentDictionary<string, long> _generalWordsCount;

        public PageConsumer(BlockingCollection<string> transmitter, ConcurrentDictionary<string, long> generalWordsCount)
        {
            _transmitter = transmitter;
            _generalWordsCount = generalWordsCount;
        }

        public void Run()
        {
            while (!_transmitter.IsCompleted)
            {
                var words = _transmitter.Take().Split(' ');
                foreach (var word in words)
                {
                    CountWordsInPage(word);
                }
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
                _generalWordsCount.TryAdd(word, 1);
            }
        }

        
    }
}
