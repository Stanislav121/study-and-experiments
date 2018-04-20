using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeExperiment
{
    struct PersonStruct
    {
        public string Name;

        public int Age;

        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Age);
        }
    }
}
