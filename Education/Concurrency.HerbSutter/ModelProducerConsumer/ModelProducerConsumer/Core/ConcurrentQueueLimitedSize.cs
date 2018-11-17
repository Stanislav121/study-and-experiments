using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ModelProducerConsumer.Core
{
    class ConcurrentQueueLimitedSize<T> : ConcurrentQueue<T>
    {
        //pattern Decorator

        //TODO Check is this code thread-safe
        public readonly int MaxSize;

        private readonly ConcurrentQueue<T> _queue;

        private readonly object _sync;

        public ConcurrentQueueLimitedSize(int maxSize)
        {
            MaxSize = maxSize;
            _queue = new ConcurrentQueue<T>();
        }

        public new bool Enqueue(T item)
        {
            //TODO Release it without Lock
            lock (_sync)
            {
                if (_queue.Count >= MaxSize)
                    return false;

                _queue.Enqueue(item);
                return true;
            }
        }

        public bool IsFull()
        {
            return _queue.Count >= MaxSize;
        }
    }
}
