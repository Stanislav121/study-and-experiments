using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogTry
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessForLog pfl = new ProcessForLog();
            pfl.Run();
            Console.ReadLine();
        }
    }
}
