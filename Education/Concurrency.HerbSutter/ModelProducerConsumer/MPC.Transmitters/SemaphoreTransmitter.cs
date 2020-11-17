using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Transmitters
{
    public class SemaphoreTransmitter : ITransmitter, IDisposable
    {
        private readonly Queue<Goal> goals;
        private readonly Semaphore _semaphore;

        public SemaphoreTransmitter(bool localSemaphore)
        {
            _semaphore = localSemaphore ? new Semaphore(1, 1) : new Semaphore(1, 1, "Semaphore_abrvalk");
            goals = new Queue<Goal>();
        }

        public long Count()
        {
            long count;
            _semaphore.WaitOne();
            count = goals.Count;
            _semaphore.Release();
            return count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            _semaphore.WaitOne();
            goals.TryDequeue(out goal);
            _semaphore.Release();
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            _semaphore.WaitOne();
            goals.Enqueue(goal);
            _semaphore.Release();
        }

        public void Dispose()
        {
            _semaphore.Dispose();
        }
    }
}
