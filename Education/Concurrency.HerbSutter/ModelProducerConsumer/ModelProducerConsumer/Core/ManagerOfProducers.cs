using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModelProducerConsumer.Core
{
    class ManagerOfProducers
    {
        private List<ProducerOfWork> producers;
        private bool _stop;

        private ConcurrentQueueLimitedSize<NumbersToSum> _producerConsumerQueue;
        private ManualResetEvent _producerEvent;

        public ManagerOfProducers()
        {
            producers = new List<ProducerOfWork>();
            _producerConsumerQueue = new ConcurrentQueueLimitedSize<NumbersToSum>(25);
            _producerEvent = new ManualResetEvent(true);
        }

        public void AddProducer(GeneratorOfNumbersToSum realProducer)
        {
            if (_stop)
                return;
            producers.Add(new ProducerOfWork(realProducer, _producerConsumerQueue, _producerEvent));
        }

        public void Stop()
        {
            _stop = true;
            producers.ForEach(s => s.Stop());
        }

        public bool IsProducingStop()
        {
            // TODO Made it as varaibale -> public bool IsProducingStop;
            return producers.All(s => s.IsStopped);
        }
    }
}
