using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SleepSort
{
    public class RandomComarer<T> : Comparer<T>
    {
        private Random _random;

        public RandomComarer()
        {
            _random = new Random();
        }

        public override int Compare(T x, T y)
        {
            int result = 0;
            while (result == 0)
            {
                result = _random.Next(-1, 2);
            }

            return result;
        }
    }
}
