using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MPC.Core
{
    public class Producer
    {
        private readonly ITransmitter _transmitter;
        private readonly GoalGenerator _goalGenerator;
        private bool _stop;

        public Producer(GoalGenerator generator, ITransmitter transmitter)
        {
            _goalGenerator = generator;
            _transmitter = transmitter;
        }

        public void Start()
        {
            while (!Volatile.Read(ref _stop))
            {
                _transmitter.PutGoal(_goalGenerator.GenerateGoal());
            }
        }

        public void Stop() 
        {
            Volatile.Write(ref _stop, true);
        }
    }
}
