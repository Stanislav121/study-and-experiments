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

            CreateStruct();

            CompareStruct();

            Console.ReadLine();
        }

        private static void CreateStruct()
        {
            PersonStruct person;
            int age1 = 0;
            // Error age1 = person.Age;

            PersonStruct person2 = new PersonStruct();
            var age2 = person2.Age;
            Console.WriteLine($"{age1} {age2}");
        }

        private static void CompareStruct()
        {
            PersonStruct person1 = new PersonStruct("Alex", 21);
            PersonStruct person2 = new PersonStruct("Alex", 21);

            PersonClass personC1 = new PersonClass("Alex", 21);
            PersonClass personC2 = new PersonClass("Alex", 21);

            Console.WriteLine($"Struct equals {person1.Equals(person2)}");
            //Console.WriteLine($"Struct = {person1 == person2}");
            Console.WriteLine($"Class equals {personC1.Equals(personC2)}");
            Console.WriteLine($"Class = {personC1 == (personC2)}");
            Console.WriteLine($"struct and Class equals {person1.Equals(personC1)}");
            Console.WriteLine($"Class and struct equals {personC1.Equals(person1)}");
            Console.WriteLine($"Class ReferenceEquals {Object.ReferenceEquals(personC1, personC2)}");
            Console.WriteLine($"struct ReferenceEquals {Object.ReferenceEquals(person1, person2)}");
        }
    }
}
