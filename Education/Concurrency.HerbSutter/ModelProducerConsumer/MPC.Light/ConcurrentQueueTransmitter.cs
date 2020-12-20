using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Light
{
    class ConcurrentQueueTransmitter : ITransmitter
    {
        private readonly ConcurrentQueue<Goal> _concurrentQueue;

        public ConcurrentQueueTransmitter(ConcurrentQueue<Goal> concurrentQueue)
        {
            _concurrentQueue = concurrentQueue;
        }

        public long Count()
        {
            return _concurrentQueue.Count;
        }

        public Goal GetGoal()
        {
            Goal goal = null;
            while (true)
            {
                if (_concurrentQueue.TryDequeue(out goal))
                    break;
            }
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            _concurrentQueue.Enqueue(goal);
        }
    }
}
