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

        private readonly object _sync = new object();

        public ConcurrentQueueLimitedSize(int maxSize)
        {
            MaxSize = maxSize;
        }

        public new bool Enqueue(T item)
        {
            //TODO Release it without Lock
            lock (_sync)
            {
                if (Count >= MaxSize)
                    return false;

                base.Enqueue(item);
                return true;
            }
        }

        public bool IsFull()
        {
            return Count >= MaxSize;
        }
    }
}
