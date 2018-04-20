using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ChangeValue();
            a.ChageValueOfValueType();

            a.ChangeStruct();

            Console.ReadLine();
        }
    }
}
