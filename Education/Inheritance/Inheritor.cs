using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Inheritor : AbstractClass, IInterface1, IInterface2
    {
        //public new void Foo()
        //{
        //    Console.WriteLine("Inheritor new");
        //}

        public void Foo()
        {
            Console.WriteLine("Inheritor");
            base.Foo();
        }

        void IInterface1.Foo()
        {
            Console.WriteLine("IInterface1");
        }

        void IInterface2.Foo()
        {
            Console.WriteLine("IInterface2");
        }
    }
}
