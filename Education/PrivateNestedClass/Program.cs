using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateNestedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new OpenClass();
            a.UpdateInnerClass();
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
