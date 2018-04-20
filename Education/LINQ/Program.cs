using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            persons.Add(new Person("Petr", "Ivanov"));
            persons.Add(new Person("Ivan", "Ivanov"));
            persons.Add(new Person("Alex", "Alexeev"));

            var results = Sort(persons);
        }

        private static List<Person> Sort(IEnumerable<Person> persons)
        {
            var sortedPresons = from p in persons orderby p.Surname, p.Name select p;
            return sortedPresons.ToList();
        }
    }
}
