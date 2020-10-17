using System;
using System.Collections.Generic;
using System.Text;

namespace Concurrency.PaulButcher.Chapter2.Day1.DiningPhilosophers
{
    class Dinner
    {
        private readonly List<Philosopher> _philosophers;

        public Dinner(int countOfPhilo) 
        {
            _philosophers = new List<Philosopher>();
            var forks = new List<Object>();
            for (int i = 0; i < countOfPhilo; i++)
            {
                forks.Add(new object());
            }
            forks.Add(forks[0]);
                
            for (int i = 0; i < countOfPhilo; i++)
            {
                var p = new Philosopher(forks[i], forks[i+1], 2, 1, 10);
                _philosophers.Add(p);
            }
        }

        public void StartDinner()
        {
            foreach (var p in _philosophers)
            {
                p.StartDinner();
            }
        }

        public void StopDinner()
        {
            foreach (var p in _philosophers)
            {
                p.StopDinner();
            }
        }
    }
}
