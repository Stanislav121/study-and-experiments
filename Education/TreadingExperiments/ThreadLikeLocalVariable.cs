using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TreadingExperiments
{
    class ThreadLikeLocalVariable
    {
        public void StartThreadLikeLocalVariable()
        {
            var thread = new Thread(StartDoingSomething);
            //thread.IsBackground = true;
            thread.Start();
        }

        private void StartDoingSomething()
        {
            var count = 0;
            while (count < 10)
            {
                //Console.WriteLine("I am alive");
                //Console.Beep(350, 250);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
