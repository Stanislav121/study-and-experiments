using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;
namespace MPC.Transmitters
{
    public class BlockingCollectionTransmitter : ITransmitter, IDisposable
    {
        private readonly BlockingCollection<Goal> goals;

        public BlockingCollectionTransmitter()
        {
            goals = new BlockingCollection<Goal>();
        }

        public long Count()
        {
            long count;
            count = goals.Count;
            return count;
        }

        public Goal GetGoal()
        {
            return goals.Take();
        }

        public void PutGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void Dispose()
        {
            goals.Dispose();
        }
    }
}
