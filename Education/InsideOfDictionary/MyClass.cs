using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideOfDictionary
{
    class MyClass
    {
        public string Value;

        public MyClass(string val)
        {
            Value = val;
        }

        public override int GetHashCode()
        {
            if (Value == "aaa")
                return 10000;
            if (Value == "bbb")
                return 10000;
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ((MyClass)obj).Value == this.Value;
        }
    }
}
