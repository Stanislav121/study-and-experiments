using System;
using System.Collections.Generic;
using System.Text;

namespace MPC.Core
{
    public interface IGoalUtilizer
    {
        void Utilize(Goal goal);

        bool? WasUtilizeSuccessful();
    }
}
