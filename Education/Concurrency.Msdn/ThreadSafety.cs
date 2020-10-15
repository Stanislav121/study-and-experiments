using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Concurrency.Msdn
{
    public class ThreadSafety
    {
        private int _flag;

        private const int _free = 0;
        private const int _busy = 1;
        public void Take()
        {
            while (Interlocked.CompareExchange(ref _flag, _busy, _free) == _busy)
            {
                ;
            }
        }

        public void Release()
        {
            Interlocked.Exchange(ref _flag, _free);
        }
    }
}
