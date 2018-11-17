using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModelProducerConsumer.Core
{
    class ConsumerOfWork
    {
        private ConcurrentQueueLimitedSize<NumbersToSum> _producerConsumerQueue;
        private ManualResetEvent _producerEvent;
        private ManagerOfProducers _managerOfProducers;
        private SummatorOfNumbers _realWorker;

        public ConsumerOfWork(SummatorOfNumbers realWorker, ManagerOfProducers managerOfProducers, ConcurrentQueueLimitedSize<NumbersToSum> producerConsumerQueue, ManualResetEvent producerEvent)
        {
            _producerConsumerQueue = producerConsumerQueue;
            _producerEvent = producerEvent;
            _managerOfProducers = managerOfProducers;
            _realWorker = realWorker;
        }

        public void ProcessWork()
        {
            while (!_managerOfProducers.IsProducingStop())
            {
                NumbersToSum work;
                var isGetted = _producerConsumerQueue.TryDequeue(out work);
                if (!isGetted)
                {                    
                    // TODO Wait of filling
                }

                // TODO May by it is get bad perfomance, to send Set signal for all Dequeue?
                _producerEvent.Set();
                _realWorker.ProcessNumbers(work);
                WriteLog();
            }
        }

        private void WriteLog()
        {
            throw new NotImplementedException();
        }
    }
}
