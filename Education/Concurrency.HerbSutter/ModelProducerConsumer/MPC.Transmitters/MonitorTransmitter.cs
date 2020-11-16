using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MPC.Core;

namespace MPC.Transmitters
{
    public class MonitorTransmitter : ITransmitter
    {
        private readonly Queue<Goal> goals;
        private readonly object _sync = new object();

        public MonitorTransmitter()
        {
            goals = new Queue<Goal>();
        }

        public long Count()
        {
            long count;
            lock (_sync) 
                count = goals.Count;
            return count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            lock (_sync)
            {
                goals.TryDequeue(out goal);
            }                
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            lock (_sync)
            {
                goals.Enqueue(goal);
            }            
        }
    }
}
