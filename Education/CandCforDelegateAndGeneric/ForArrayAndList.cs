using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandCforDelegateAndGeneric
{
    class ForArrayAndList
    {
        public void RunArrays()
        {
            var cars = new Car[5];
            var fords = new Ford[5];

            cars[0] = new Ford();
            //fords[0] = new Car();

            FooA(cars);
            FooA(fords);

            //BooA(cars);
            BooA(fords);


        }

        private void FooA(Car[] cars) { }
        private void BooA(Ford[] fords) { }

        public void RunLists()
        {
            var cars = new List<Car>();
            var fords = new List<Ford>();

            cars.Add(new Ford());
            //fords.Add(new Car());

            //cars.AddRange(fords);

            FooL(cars);
            //FooL(fords);

            //BooL(cars);
            BooL(fords);


        }

        private void FooL(List<Car> cars) { }
        private void BooL(List<Ford> fords) { }
    }
}
