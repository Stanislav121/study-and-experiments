using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForILViewer
{
    class LookInLock
    {
        private readonly object _lock = new object();
        public void Run()
        {
            lock (_lock) 
            {
                Console.WriteLine("In lock");
            }
        }
    }
}
