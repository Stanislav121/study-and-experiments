using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn.LittleThings
{
    class InsideThread
    {
        private Thread _thread;

        public InsideThread()
        {
            _thread = new Thread(SomeMethod);
        }
        public void StartThread()
        {
            _thread.Start();
        }

        public void RestartThread()
        {
            _thread.Start();
        }

        private void SomeMethod()
        {
            Console.WriteLine("SomeMethod");
        }
    }
}
