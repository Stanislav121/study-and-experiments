using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProducerConsumer
{
    class GeneratorOfNumbersToSum
    {        
        private Random _randomGenerator;

        public GeneratorOfNumbersToSum(int baseForRandom)
        {
            _randomGenerator = new Random(baseForRandom);
        }
        
        public NumbersToSum Generate()
        {
            var numbers = new NumbersToSum();
            numbers.A = _randomGenerator.Next(500);
            numbers.B = _randomGenerator.Next(500);
            return numbers;
        }
    }
}
