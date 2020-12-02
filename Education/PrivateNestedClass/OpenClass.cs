using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateNestedClass
{
    public class OpenClass
    {
        private NestedPrivateClass InnerClass;

        public OpenClass()
        {
            InnerClass = new NestedPrivateClass();
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

        private class NestedPrivateClass
        {
            private int _id;
            internal int id;
            public int Id;

            public NestedPrivateClass()
            {
                _id = 1;
                id = 2;
                Id = 3;
            }
        }

        class NestedClass
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

        public class NestedPublicClass
        {
            private int _id;
            internal int id;
            public int Id;

            public NestedPublicClass()
            {
                _id = 1;
                id = 2;
                Id = 3;
            }
        }
    }
}
