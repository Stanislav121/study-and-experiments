using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MPC.Core
{
    public class Consumer
    {
        private readonly ITransmitter _transmitter;
        private readonly IGoalUtilizer _utilizer;
        private bool _stop;

        public Consumer(IGoalUtilizer utilizer, ITransmitter transmitter)
        {
            _utilizer = utilizer;
            _transmitter = transmitter;
        }

        public void StartProvessingGoals()
        {
            while (!(Volatile.Read(ref _stop)  && _transmitter.Count() == 0))
            {
                var goal = _transmitter.GetGoal();
                if (goal == null)
                    continue;
                _utilizer.Utilize(goal);
            }
        }

        public void Stop()
        {
            Volatile.Write(ref _stop, true);
        }
    }
}
