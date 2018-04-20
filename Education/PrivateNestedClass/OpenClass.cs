using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateNestedClass
{
    public class OpenClass
    {
        private NestedClass InnerClass;

        public OpenClass()
        {
            InnerClass = new NestedClass();
        }

        public void UpdateInnerClass()
        {
            //InnerClass._id = 11;
            InnerClass.id = 12;
            InnerClass.Id = 13;
        }

        public override string ToString()
        {
            return string.Concat(InnerClass.id, InnerClass.Id);
        }

        private class NestedClass
        {
            private int _id;
            internal int id;
            public int Id;

            public NestedClass()
            {
                _id = 1;
                id = 2;
                Id = 3;
            }
        }
    }
}
