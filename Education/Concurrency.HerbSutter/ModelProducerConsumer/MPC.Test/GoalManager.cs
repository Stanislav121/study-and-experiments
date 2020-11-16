using System;
using System.Collections.Generic;
using System.Text;
using MPC.Core;
using System.Threading.Tasks;
using System.Threading;

namespace MPC.Test
{
    class GoalManager
    {
        private readonly IList<Producer> _producers;
        private readonly IList<Consumer> _consumers;
        private Task[] _tasks;

        public GoalManager(IList<Producer> producers, IList<Consumer> consumers)
        {
            _producers = producers;
            _consumers = consumers;
        }
        
        public void Run()
        {
            _tasks = new Task[_producers.Count + _consumers.Count];
            for(int i = 0; i < _producers.Count; i++)
            {
                _tasks[i] = Task.Run(_producers[i].Start);
            }
            for (int i = _producers.Count; i < _producers.Count + _consumers.Count; i++)
            {
                _tasks[i] = Task.Run(_consumers[i - _producers.Count].StartProvessingGoals);
            }            
        }

        public void Stop()
        {
            Parallel.ForEach(_producers, item => item.Stop());
            Parallel.ForEach(_consumers, item => item.Stop());
            Task.WaitAll(_tasks);
        }
    }
}
