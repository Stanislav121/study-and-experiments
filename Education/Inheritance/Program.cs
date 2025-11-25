using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Inheritor();

            //CallMethodA(a);
            CallMethodI(a);
            //CallMethodI1(a);
            //CallMethodI2(a);            

            Console.ReadLine();
        }

        private static void CallMethodA(AbstractClass a)
        {
            a.Foo();
        }

        private static void CallMethodI(Inheritor a)
        {
            a.Foo();
        }

        private static void CallMethodI1(IInterface1 a)
        {
            a.Foo();
        }

        private static void CallMethodI2(IInterface2 a)
        {
            a.Foo();
        }
    }
}
