using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Transmitters
{
    public class SemaphoreSlimTransmitter : ITransmitter, IDisposable
    {
        private readonly Queue<Goal> goals;
        private readonly SemaphoreSlim _semaphore;

        public SemaphoreSlimTransmitter()
        {
            _semaphore = new SemaphoreSlim(1, 1);
            goals = new Queue<Goal>();
        }

        public long Count()
        {
            long count;
            _semaphore.Wait();
            count = goals.Count;
            _semaphore.Release();
            return count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            _semaphore.Wait();
            goals.TryDequeue(out goal);
            _semaphore.Release();
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            _semaphore.Wait();
            goals.Enqueue(goal);
            _semaphore.Release();
        }

        public void Dispose()
        {
            _semaphore.Dispose();
        }
    }
}
