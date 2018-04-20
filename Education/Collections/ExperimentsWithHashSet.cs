using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class ExperimentsWithHashSet
    {
        public void UpdateItemsInHashSet()
        {
            var hashset = new HashSet<Person>();
            var a = new Person("A");
            hashset.Add(a);
            var b = new Person("B");
            hashset.Add(b);

            var exclude = new List<Person> {a};
            hashset.ExceptWith(exclude);
            b.Name = "C";

            foreach (var person in hashset)
            {
                Console.WriteLine(person.Name);
            }
        }

        public void UpdateItemsInIEmunerable()
        {
            var list = new List<Person>();
            var a = new Person("A");
            list.Add(a);
            var b = new Person("B");
            list.Add(b);

            var exclude = new List<Person> { a };
            var newList = list.Except(exclude);
            b.Name = "C";

            foreach (var person in list)
            {
                Console.WriteLine(person.Name);
            }
        }
    }
}
