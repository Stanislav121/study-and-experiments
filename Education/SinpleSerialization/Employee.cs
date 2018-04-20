using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinpleSerialization
{
    [Serializable]
    class Employee
    {
        public Person person;

        public string Company;
    }
}
