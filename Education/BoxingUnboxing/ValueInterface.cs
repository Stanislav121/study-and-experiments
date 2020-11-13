using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingUnboxing
{
    class ValueInterface
    {
        public static void Run()
        {
            int a = 21;
            Foo(a);
            Boo(a);
            Poo(a);
        }

        private static void Foo(IComparable a)
        {
            Console.WriteLine(a);
        }

        private static void Boo(IComparable<int> a)
        {
            Console.WriteLine(a);
        }

        private static void Poo<T>(T value) where T : IComparable<T>
        {
            Console.WriteLine(value);
        }
    }
}
