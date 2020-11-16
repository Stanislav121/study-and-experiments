using MPC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPC.Test
{
    class EmptyUtilizer : IGoalUtilizer
    {
        public void Utilize(Goal goal)
        {
            // Empty method, no action
        }

        public bool? WasUtilizeSuccessful()
        {
            return null;
        }
    }
}
