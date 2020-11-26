using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclePerfMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            long total = 0;
            while (true)
            {
                var a = new object();
                total += a.GetHashCode();
                if (total < 0)
                    break;
            }
            Console.WriteLine(total);
        }
    }
}
