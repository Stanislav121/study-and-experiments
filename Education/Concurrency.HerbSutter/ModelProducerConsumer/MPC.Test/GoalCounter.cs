﻿using MPC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPC.Test
{
    class GoalCounter : IGoalUtilizer
    {
        private readonly SortedSet<long> _processedIds;
        public GoalCounter()
        {
            _processedIds = new SortedSet<long>();
        }
        public void Utilize(Goal goal)
        {
            _processedIds.Add(goal.Id);
        }

        public bool IsAllGoalsProcessed()
        {
            var lastId = _processedIds.Max;
            var createdIds = new SortedSet<long>();
            for (long i = 0; i <= lastId; i++)
            {
                createdIds.Add(i);
            }
            return _processedIds.IsSubsetOf(createdIds) && createdIds.IsSubsetOf(_processedIds);
        }
    }
}
