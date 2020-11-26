using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandCforDelegateAndGeneric
{
    class Generics
    {
        interface IGenericInterface<out T> { }

        class ConcreteO<T> : IGenericInterface<T>
        {
        }
        class ConcreteS<T> : IGenericInterface<T>
        {
        }

        

        public static void Run()
        {
            IGenericInterface<Car> igio = new ConcreteO<Car>();
            //Foo(igio);
            IGenericInterface<Ford> igis = new ConcreteS<Ford>();
            Foo(igis);
            IGenericInterface<SuperFord> igisF = new ConcreteS<SuperFord>();
            Foo(igisF);

            //Boo(new List<Car>());
            Boo(new List<Ford>());
            //Boo(new List<SuperFord>());

            TakeComparer(new ComparatorCar());
            TakeComparer(new ComparatorFord());
            //TakeComparer(new ComparatorSuperFord());
        }

        private static void TakeComparer(IComparer<Ford> comparer)
        {
            var a = comparer.Compare(new Ford(), new Ford());
        
        }
        class ComparatorCar : IComparer<Car>
        {
            public int Compare(Car x, Car y)
            {
                return x == y ? 1 : 0;
            }
        }

        class ComparatorFord : IComparer<Ford>
        {
            public int Compare(Ford x, Ford y)
            {
                return x == y ? 1 : 0;
            }
        }

        class ComparatorSuperFord : IComparer<SuperFord>
        {
            public int Compare(SuperFord x, SuperFord y)
            {
                return x == y ? 1 : 0;
            }
        }

        private static void Foo(IGenericInterface<Ford> o) { }
        private static void Boo(IList<Ford> objects) { }
    }
}
