using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Concurrency.PaulButcher.Chapter2.Day1.DiningPhilosophers
{
    class Philosopher
    {
        private static int _counter;
        private readonly int _number;

        private readonly Object _leftHand;
        private readonly Object _rightHand;

        private readonly Thread _thread;
        private readonly int _delayForTakeSecondFork;

        private readonly int _timeToThink;
        private readonly long _cycleIteration;

        private bool _stop;


        public Philosopher(Object leftHand, Object rightHand, int delayForTakeSecondFork, int timeToThink, long cycleIteration)
        {
            _number = _counter;
            _counter++;
            _leftHand = leftHand;
            _rightHand = rightHand;

            _timeToThink = timeToThink;
            _cycleIteration = cycleIteration;

            _delayForTakeSecondFork = delayForTakeSecondFork;

            _thread = new Thread(HaveDinner);
        }

        public void StartDinner()
        {
            _thread.Start();
        }

        public void StopDinner()
        {
            _stop = true;
        }

        private void HaveDinner()
        {
            while (!_stop)
            {
                Think();
                Eat();
            }
            Console.WriteLine("Philo " + _number + " stop dinning");
        }

        private void Think()
        {
            Console.WriteLine("Philo " + _number + " start thinking");
            Thread.Sleep(_timeToThink);
            Console.WriteLine("Philo " + _number + " end thinking");
        }

        private void Eat()
        {
            lock (_leftHand)
            {
                Thread.Sleep(_delayForTakeSecondFork);
                lock (_rightHand)
                {
                    Console.WriteLine("Philo " + _number + " start eating");
                    var sum = 0;
                    for (int i = 0; i < _cycleIteration; i++)
                    {
                        sum += i;
                    }
                    Console.WriteLine(sum);
                    Console.WriteLine("Philo " + _number + " end eating");
                }
            }
                
        }

    }
}
