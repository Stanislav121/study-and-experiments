using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MPC.Core;

namespace MPC.Transmitters
{
    public class ConcurrentQueueTransmitter : ITransmitter
    {
        private readonly ConcurrentQueue<Goal> goals;

        public ConcurrentQueueTransmitter()
        {
            goals = new ConcurrentQueue<Goal>();
        }

        public long Count()
        {
            return goals.Count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            goals.TryDequeue(out goal);
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            goals.Enqueue(goal);
        }
    }
}
