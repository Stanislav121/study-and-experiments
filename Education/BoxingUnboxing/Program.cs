using System;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Overview();
            //ValueInterface.Run();
            var a = new Teplakov();
            //a.Run1();
            a.Run2();
            Console.Read();
        }

        private static void Overview()
        {
            int nonnullable = 3;
            int? nullableValue = 5;
            int? nullableNull = null;

            object nonnullableObj = nonnullable;
            object nullableValueObj = nullableValue;
            object nullableNullObj = nullableNull;

            Console.WriteLine(nonnullableObj.GetType());
            Console.WriteLine(nullableValueObj.GetType());
            //Console.WriteLine(nullableNullObj.GetType());

            int nonnullable1 = (int)nonnullableObj;
            Console.WriteLine(nonnullable1);
            int? nullableValue1 = (int?)nullableValueObj;
            Console.WriteLine(nullableValue1);

            int? nullableNullObj1 = (int?)nullableNullObj;
            Console.WriteLine(nullableNullObj1);

            int[] ints = new int[1];
            object i = 1;
            ints[0] = (int)i;
            Console.WriteLine(ints[0]);

            byte a = 15;
            object oa = a;
            int b = (int)(byte)oa;
            Console.WriteLine(b);
            Console.WriteLine("End of Overview");
        }
    }
}
