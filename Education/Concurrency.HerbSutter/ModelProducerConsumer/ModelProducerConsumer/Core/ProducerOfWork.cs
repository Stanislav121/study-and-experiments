using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using log4net;

namespace ModelProducerConsumer.Core
{
    class ProducerOfWork
    {
        public bool IsStopped;
        private ConcurrentQueueLimitedSize<NumbersToSum> _producerConsumerQueue;
        private ManualResetEvent _producerEvent;
        private bool _stop;

        private GeneratorOfNumbersToSum _realProduce;
        private ManualResetEvent _consumerEvent;
        private ILog _log;

        public ProducerOfWork(GeneratorOfNumbersToSum realProducer, ConcurrentQueueLimitedSize<NumbersToSum> producerConsumerQueue, ManualResetEvent producerEvent, ManualResetEvent consumerEvent)
        {
            _producerConsumerQueue = producerConsumerQueue;
            _producerEvent = producerEvent;
            _realProduce = realProducer;
            _consumerEvent = consumerEvent;
            _log = LogManager.GetLogger(typeof(ProducerOfWork));
        }

        // TODO Convert to Generic
        public void StartProduceWork()
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
                {
                    _consumerEvent.Set();
                    break;
                }                
                _producerEvent.WaitOne();
            }      
        }

        private NumbersToSum GetWork()
        {
            return _realProduce.Generate();
        }

        private void WriteLog(NumbersToSum work)
        {
            var message = string.Format("{0} {1}", work.A, work.B);
            Console.WriteLine(message);
            //_log.Info(message);
        }
    }
}
