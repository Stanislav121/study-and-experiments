using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProducerConsumer
{
    class GeneratorOfNumbersToSumConsistently : GeneratorOfNumbersToSum
    {
        private long number;

        public NumbersToSum Generate()
        {
            var numbers = new NumbersToSum();
            numbers.A = number;
            numbers.B = number;
            number++;
            return numbers;
        }
    }
}
