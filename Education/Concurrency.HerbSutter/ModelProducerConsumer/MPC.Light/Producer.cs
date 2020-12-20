using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MPC.Core;

namespace MPC.Light
{
    class Producer
    {
        private readonly long _maxValue;
        private long _counter;
        private readonly ITransmitter _transmitter;
        private readonly Thread _thread;
        private readonly int _nConsumer;

        public Producer(ITransmitter transmitter, long maxValue, int nConsumer)
        {
            _transmitter = transmitter;
            _maxValue = maxValue;
            _nConsumer = nConsumer;
            _thread = new Thread(GenerateGoals);
        }     

        public void Start()
        {
            _thread.Start();
        }

        private void GenerateGoals()
        {
            while (_counter < _maxValue)
            {
                var goal = new Goal(_counter);
                _transmitter.PutGoal(goal);
                _counter++;
            }
            for(int i = 0; i < _nConsumer; i++)
                _transmitter.PutGoal(null);
        }
    }
}
