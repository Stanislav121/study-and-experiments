using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Inheritor : IInterface1, IInterface2
    {
        public void Foo()
        {
            Console.WriteLine("AA");
        }
    }
}
