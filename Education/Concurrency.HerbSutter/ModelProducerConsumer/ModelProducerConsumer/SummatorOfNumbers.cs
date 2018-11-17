using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProducerConsumer
{
    class SummatorOfNumbers
    {
        public void ProcessNumbers(NumbersToSum numbers)
        {
            numbers.Sum = numbers.A + numbers.B;
        }
    }
}
