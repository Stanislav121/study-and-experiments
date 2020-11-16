using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MPC.Core;

namespace MPC.Test
{
    class UnsafeTransmitter : ITransmitter
    {
        private readonly Queue<Goal> goals;

        public UnsafeTransmitter()
        {
            goals = new Queue<Goal>();
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
