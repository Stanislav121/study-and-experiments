using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeExperiment
{
    class ChangeValue
    {
        public void ChageValueOfValueType()
        {
            int val = 5;
            object obj = val;
            var newVal = (int)obj + 2;
            Console.WriteLine("{0} {1} {2}", val, obj, newVal);
        }

        public void ChangeStruct()
        {
            var person = new PersonStruct
            {
                Name = "Alex",
                Age = 32
            };
            var person2 = ChangeStruct(person);
            Console.WriteLine(String.Concat(person, " ", person2));
        }

        private PersonStruct ChangeStruct(PersonStruct person)
        {
            person.Name = "Bob";
            person.Age = 44;
            return person;
        }
    }
}
