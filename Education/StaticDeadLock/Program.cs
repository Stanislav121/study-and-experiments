using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StaticDeadLock
{
    class Program
    {
        static Program()
        {
            var thread = new Thread(o => { Console.WriteLine("Static"); });
            thread.Start();
            thread.Join();
        }

        static void Main()
        {
            Console.WriteLine("Main");
            // Этот метод никогда не начнет выполняться,
            // поскольку дедлок произойдет в статическом
            // конструкторе класса Program
        }
    }
}
