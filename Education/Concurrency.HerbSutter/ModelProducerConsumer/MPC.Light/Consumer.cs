using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MPC.Core;

namespace MPC.Light
{
    class Consumer
    {
        private readonly ITransmitter _transmitter;
        public readonly List<long> Goals;
        public bool IsFinished { get; private set; }
        private readonly Thread _thread;
        private readonly AutoResetEvent _waitHandle;

        public Consumer(ITransmitter transmitter, AutoResetEvent waitHandle)
        {
            Goals = new List<long>();
            _transmitter = transmitter;
            _waitHandle = waitHandle;
            _thread = new Thread(ProcessGoals);
        }        

        public void Start()
        {
            _thread.Start();
        }

        private void ProcessGoals()
        {
            Goal goal;
            while (true) 
            {
                goal = _transmitter.GetGoal();
                if (goal == null)
                    break;
                Goals.Add(goal.Id);
            }            
            IsFinished = true;
            _waitHandle.Set();
        }
    }
}
