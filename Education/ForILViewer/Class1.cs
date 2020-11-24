using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForILViewer
{
    public class Class1
    {
        private static void Foo()
        {
            var manyLines = "aaaaaaaaaaaaaaaaaa";
            string item;
            using (var reader = new StringReader(manyLines))
            {
                item = reader.ReadLine();
                Console.WriteLine(item);
            }
        }
    }
}
