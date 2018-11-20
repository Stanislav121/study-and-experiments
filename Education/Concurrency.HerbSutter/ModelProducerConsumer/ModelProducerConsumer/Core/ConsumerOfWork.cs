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
        private ManualResetEvent _consumerEvent;
        private ManagerOfProducers _managerOfProducers;
        private SummatorOfNumbers _realWorker;

        private ILog _log;

        public ConsumerOfWork(SummatorOfNumbers realWorker, ManagerOfProducers managerOfProducers, ConcurrentQueueLimitedSize<NumbersToSum> producerConsumerQueue, ManualResetEvent producerEvent, ManualResetEvent consumerEvent)
        {
            _producerConsumerQueue = producerConsumerQueue;
            _producerEvent = producerEvent;
            _consumerEvent = consumerEvent;
            _managerOfProducers = managerOfProducers;
            _realWorker = realWorker;
            _log = LogManager.GetLogger(typeof(ConsumerOfWork));
        }

        public void ProcessQueue()
        {
            while (true)
            {
                var stop = _managerOfProducers.IsProducingStop() && _producerConsumerQueue.Count == 0;
                if (stop)
                    break;

                NumbersToSum work;
                var isGetted = _producerConsumerQueue.TryDequeue(out work);
                if (!isGetted)
                {
                    // Wait of filling
                    _producerEvent.Set();

                    // TODO Very bad, use ManualResetEvent
                    //Thread.Yield();
                    Thread.Sleep(0);
                    //_consumerEvent.WaitOne();
                    //Thread.SpinWait(1);
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
