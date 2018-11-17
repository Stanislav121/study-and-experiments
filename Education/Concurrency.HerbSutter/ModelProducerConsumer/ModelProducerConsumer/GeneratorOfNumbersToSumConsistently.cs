using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProducerConsumer
{
    class GeneratorOfNumbersToSumConsistently : GeneratorOfNumbersToSum
    {
        public long Number { get; private set; }

        public NumbersToSum Generate()
        {
            var numbers = new NumbersToSum();
            numbers.A = Number;
            numbers.B = Number;
            Number++;
            return numbers;
        }
    }
}
