using MPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.Test
{
    class GoalCounter : IGoalUtilizer
    {
        private List<long> _processedIds;
        private readonly object _sync = new object();
        public GoalCounter()
        {
            _processedIds = new List<long>();
        }

        public void Reset()
        {
            _processedIds = new List<long>();
        }
        public void Utilize(Goal goal)
        {
            lock (_sync)
            {
                _processedIds.Add(goal.Id);
            }            
        }

        public bool? WasUtilizeSuccessful()
        {
            return IsAllGoalsProcessed();
        }

        private bool IsAllGoalsProcessed()
        {
            var lastId = _processedIds.Max();
            var createdIds = new List<long>();
            for (long i = 0; i <= lastId; i++)
            {
                createdIds.Add(i);
            }
            return createdIds.Intersect(_processedIds).LongCount() == _processedIds.Count && createdIds.Count == _processedIds.Count;
        }
    }
}
