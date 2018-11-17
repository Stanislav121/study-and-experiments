using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using log4net;

namespace ModelProducerConsumer.Core
{
    class ConsumerOfWork
    {
        private ConcurrentQueueLimitedSize<NumbersToSum> _producerConsumerQueue;
        private ManualResetEvent _producerEvent;
        private ManagerOfProducers _managerOfProducers;
        private SummatorOfNumbers _realWorker;

        private ILog _log;

        public ConsumerOfWork(SummatorOfNumbers realWorker, ManagerOfProducers managerOfProducers, ConcurrentQueueLimitedSize<NumbersToSum> producerConsumerQueue, ManualResetEvent producerEvent)
        {
            _producerConsumerQueue = producerConsumerQueue;
            _producerEvent = producerEvent;
            _managerOfProducers = managerOfProducers;
            _realWorker = realWorker;
            _log = LogManager.GetLogger(typeof(ConsumerOfWork));
        }

        public void ProcessQueue()
        {
            while (!_managerOfProducers.IsProducingStop())
            {
                NumbersToSum work;
                var isGetted = _producerConsumerQueue.TryDequeue(out work);
                if (!isGetted)
                {
                    // TODO Wait of filling
                    _producerEvent.Set();
                    Thread.Sleep(50);
                    // TODO Very bad, use ManualResetEvent
                    continue;
                }

                // TODO May by it is get bad perfomance, to send Set signal for all Dequeue?
                _producerEvent.Set();
                _realWorker.ProcessNumbers(work);
                WriteLog(work);
            }
        }

        private void WriteLog(NumbersToSum work)
        {
            var message = string.Format("{0} {1} {2}", work.A, work.B, work.Sum);
            Console.WriteLine(message);
            //_log.Info(message);
        }
    }
}
