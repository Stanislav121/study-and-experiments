using System;
using System.Collections.Generic;
using System.Text;

namespace MPC.Core
{
    public class GoalGenerator
    {
        private static long _counter;

        public Goal GenerateGoal()
        {
            return new Goal(_counter++);
        }
    }
}
