using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ExperimentsWithHashSet();
            a.UpdateItemsInHashSet();
            Console.WriteLine("");
            a.UpdateItemsInIEmunerable();

            Console.ReadLine();
        }
    }
}
