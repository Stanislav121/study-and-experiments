using System;

namespace MPC.Core
{
    public interface ITransmitter
    {
        void PutGoal(Goal goal);

        Goal GetGoal();

        long Count();
    }
}
