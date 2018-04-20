using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Msdn
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new WorkWithCancellationToken();
            a.Run();
            Console.ReadLine();
        }
    }
}
