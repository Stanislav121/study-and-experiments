using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Light
{
    class WaitPulseTransmitter : ITransmitter
    {
        private readonly Queue<Goal> _queue;
        private readonly Object _sync = new object();

        public WaitPulseTransmitter(Queue<Goal> queue)
        {
            _queue = queue;
        }

        public long Count()
        {
            lock (_sync)
                return _queue.Count;
        }

        public Goal GetGoal()
        {
            Goal goal = null;
            lock (_sync)
            {
                while(!_queue.TryDequeue(out goal))
                {
                    Monitor.Wait(_sync);                    
                }
            }
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            lock (_sync)
            {
                _queue.Enqueue(goal);
                Monitor.Pulse(_sync);
            }
        }
    }
}
