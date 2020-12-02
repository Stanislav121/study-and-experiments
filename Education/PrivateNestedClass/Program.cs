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

            //var innerClass1 = new OpenClass.NestedPrivateClass();
            //var innerClass2 = new OpenClass.NestedClass();
            var innerClass3 = new OpenClass.NestedPublicClass();
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
