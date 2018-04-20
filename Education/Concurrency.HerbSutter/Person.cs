using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.HerbSutter
{
    class Person
    {
        public string Name;
        public string Surname;
        public int Age;

        public override string ToString()
        {
            return string.Concat(Name, " ", Surname, " ", Age);
        }
    }
}
