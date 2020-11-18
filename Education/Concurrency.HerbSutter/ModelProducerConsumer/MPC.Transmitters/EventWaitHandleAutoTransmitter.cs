using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Transmitters
{
    public class EventWaitHandleAutoTransmitter : ITransmitter, IDisposable
    {
        private readonly Queue<Goal> goals;
        private readonly EventWaitHandle _event;

        public EventWaitHandleAutoTransmitter()
        {
            _event = new EventWaitHandle(true, EventResetMode.AutoReset);
            goals = new Queue<Goal>();
        }

        public long Count()
        {
            long count;
            _event.WaitOne();
            count = goals.Count;
            _event.Set();
            return count;
        }

        public Goal GetGoal()
        {
            Goal goal;
            _event.WaitOne();
            goals.TryDequeue(out goal);
            _event.Set();
            return goal;
        }

        public void PutGoal(Goal goal)
        {
            _event.WaitOne();
            goals.Enqueue(goal);
            _event.Set();
        }

        public void Dispose()
        {
            _event.Dispose();
        }
    }
}
