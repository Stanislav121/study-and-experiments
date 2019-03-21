using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogTry
{
    class Car
    {
        public string Model; 

        public int number{get;}

        public string Name{get;set;}

        public Car(int number, string name, string model)
        {
            this.number = number;
            Name = name;
            Model = model;
        }
    }
}
