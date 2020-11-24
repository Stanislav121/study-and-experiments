using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MPC.Transmitters
{
    class InterlockedLock
    {
        // 1 - free
        // 0 - busy
        private int _free = 1;

        public void Take()
        {            
            while (Interlocked.CompareExchange(ref _free, 0, 1) == 0)
            {
                //Empty
            }
        }

        public void Release()
        {
            Interlocked.Exchange(ref _free, 1);
        }


    }
}
