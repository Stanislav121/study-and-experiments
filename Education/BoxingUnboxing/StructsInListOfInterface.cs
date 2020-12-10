using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingUnboxing
{
    class StructsInListOfInterface
    {
        struct MyStruck : ICloneable
        {
            public int Id;
            public object Clone()
            {
                throw new NotImplementedException();
            }
        }

        public static void Run()
        {
            var list = new List<ICloneable>();
            var a = new MyStruck() { Id = 1 };
            list.Add(a);
            MyStruck b = (MyStruck)list[0];
            Console.WriteLine(b.Id);
        }
    }
}
