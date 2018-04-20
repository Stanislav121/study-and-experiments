using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SinpleSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeOut();
            SerializeFrom();
        }

        private static void SerializeFrom()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            Employee man1;
            using (Stream fStream = File.OpenRead("user.dat"))
            {
                man1 = (Employee)binFormat.Deserialize(fStream);
            }
            var name = man1.Company;
        }

        private static void SerializeOut()
        {
            var man1 = new Person("Mark", 21);
            var employee = new Employee{person = man1, Company = "IBM"};
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, employee);
            }
        }
    }
}
