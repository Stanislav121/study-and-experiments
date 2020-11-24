using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MPC.Core;

namespace MPC.Transmitters
{
    public class InterlockedTransmitter : ITransmitter
    {
        private readonly Queue<Goal> goals;
        private readonly InterlockedLock _lock = new InterlockedLock();

        public InterlockedTransmitter()
        {
            goals = new Queue<Goal>();
        }

        public long Count()
        {
            long count;
            _lock.Take();
            count = goals.Count;
            _lock.Release();
            return count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            _lock.Take();
            goals.TryDequeue(out goal);
            _lock.Release();
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            _lock.Take();
            goals.Enqueue(goal);
            _lock.Release();
        }
    }
}
