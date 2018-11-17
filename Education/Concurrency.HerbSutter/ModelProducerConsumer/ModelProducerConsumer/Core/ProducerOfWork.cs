using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace ModelProducerConsumer.Core
{
    class ProducerOfWork
    {
        public bool IsStopped;
        private ConcurrentQueueLimitedSize<NumbersToSum> _producerConsumerQueue;
        private ManualResetEvent _producerEvent;
        private bool _stop;

        public ProducerOfWork(GeneratorOfNumbersToSum realProducer, ConcurrentQueueLimitedSize<NumbersToSum> producerConsumerQueue, ManualResetEvent producerEvent)
        {
            _producerConsumerQueue = producerConsumerQueue;
            _producerEvent = producerEvent;
        }

        // TODO Convert to Generic
        public void ProduceWork()
        {
            while (!_stop)
            {
                var work = GetWork();
                WriteLog(work);
                GiveToProcess(work);
                WaitFreeQueue();
            }
            IsStopped = true;
        }

        public void Stop()
        {
            _stop = true;
        }

        private void WaitFreeQueue()
        {
            if (!_producerConsumerQueue.IsFull())
                return;

            _producerEvent.Reset();
            if (!_producerConsumerQueue.IsFull())
            {
                _producerEvent.Set();
            }
            else
            {
                _producerEvent.WaitOne();
            }
        }

        private void GiveToProcess(NumbersToSum work)
        {
            // Put to Queue            
            while (true)
            {
                var isPlaced = _producerConsumerQueue.Enqueue(work);
                if (isPlaced)
                    break;
                _producerEvent.WaitOne();
            }      
        }

        private NumbersToSum GetWork()
        {
            return new NumbersToSum();
        }

        private void WriteLog(NumbersToSum work)
        {
            throw new NotImplementedException();
        }
    }
}
