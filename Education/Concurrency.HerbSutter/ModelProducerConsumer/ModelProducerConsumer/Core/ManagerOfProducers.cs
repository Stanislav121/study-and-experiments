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
        private List<ConsumerOfWork> consumers;
        private bool _stopping;

        private ConcurrentQueueLimitedSize<NumbersToSum> _producerConsumerQueue;
        private ManualResetEvent _producerEvent;

        public ManagerOfProducers()
        {
            producers = new List<ProducerOfWork>();
            _producerConsumerQueue = new ConcurrentQueueLimitedSize<NumbersToSum>(7);
            _producerEvent = new ManualResetEvent(true);

            consumers = new List<ConsumerOfWork>();
        }

        public void AddProducer(GeneratorOfNumbersToSum realProducer)
        {
            if (_stopping)
                return;
            var producer = new ProducerOfWork(realProducer, _producerConsumerQueue, _producerEvent);
            producers.Add(producer);
            var thread = new Thread(producer.StartProduceWork);
            thread.Start();
        }

        public void AddConsumer(SummatorOfNumbers realWorker)
        {
            var consumer = new ConsumerOfWork(new SummatorOfNumbers(), this, _producerConsumerQueue, _producerEvent);
            consumers.Add(consumer);
            var thread = new Thread(consumer.ProcessQueue);
            thread.Start();
        }

        public void Stop()
        {
            _stopping = true;            
            producers.ForEach(s => s.Stop());
        }

        public bool IsProducingStop()
        {
            // TODO Made it as varaibale -> public bool IsProducingStop;
            if (!_stopping)
                return false;
            return producers.All(s => s.IsStopped);
        }
    }
}
