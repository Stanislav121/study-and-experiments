using System;
using System.Collections.Generic;
using System.Text;

namespace MPC.Core
{
    public class GoalGenerator
    {
        public long Counter { get; private set; }

        public Goal GenerateGoal()
        {
            return new Goal(Counter++);
        }
    }
}
