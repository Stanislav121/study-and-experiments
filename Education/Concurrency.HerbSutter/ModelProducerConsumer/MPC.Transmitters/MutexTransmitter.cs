using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Transmitters
{
    public class MutexTransmitter : ITransmitter, IDisposable
    {
        private readonly Queue<Goal> goals;
        private readonly Mutex _mutex;

        public MutexTransmitter(bool localMutex)
        {
            _mutex = localMutex ? new Mutex() : new Mutex(false, "Mutex_abrvalk");
            goals = new Queue<Goal>();
        }

        public long Count()
        {
            long count;
            _mutex.WaitOne();
            count = goals.Count;
            _mutex.ReleaseMutex();
            return count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            _mutex.WaitOne();
            goals.TryDequeue(out goal);
            _mutex.ReleaseMutex();
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            _mutex.WaitOne();
            goals.Enqueue(goal);
            _mutex.ReleaseMutex();
        }

        public void Dispose()
        {
            _mutex.Dispose();
        }
    }
}
