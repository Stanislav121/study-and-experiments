using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandCforDelegateAndGeneric
{
    class Delegates
    {
        public delegate TResult MyDelegateInOut<in T, out TResult>(T arg);
        public delegate TResult MyDelegate<T, TResult>(T arg);

        public delegate void MyDelegateArgIn<in T>(T arg);
        public delegate void MyDelegateArg<T>(T arg);

        public delegate TResult MyDelegateReturnOut<out TResult>();
        public delegate TResult MyDelegateReturn<TResult>();

        delegate void Delegate1(object ob);
        delegate void Delegate2(object ob);

        public static void Run()
        {
            Delegate1 deleg1 = FooDelegate;
            Delegate2 deleg2 = FooDelegate;
            //deleg2 = deleg1;

            RunDelegatsArgContvar();
            RunDelegatsReturnCovar();
        }

        private static void RunDelegatsArgAndReturn()
        {
            var delegateObject = new MyDelegate<object, object>(Foo);
            delegateObject(new object());

            var delegateCar = new MyDelegateInOut<Car, Car>(FooCarCar);
            var delegateFord = new MyDelegateInOut<Ford, Ford>(FooFordFord);
            var delegateCarFord = new MyDelegateInOut<Ford, Car>(FooFordCar);
            var delegateCarFordCC = new MyDelegateInOut<Car, Ford>(FooCarFord);
            delegateCarFord = delegateCarFordCC;
            //delegateCarFordCC = delegateCarFord;
        }

        private static void FooDelegate(object ob) { }

        private static Car FooFordCar(Ford o)
        {
            Console.WriteLine(o.ToString());
            return o;
        }

        private static Ford FooCarFord(Car o)
        {
            Console.WriteLine(o.ToString());
            return new Ford();
        }

        private static Ford FooFordFord(Ford o)
        {
            Console.WriteLine(o.ToString());
            return o;
        }

        private static Car FooCarCar(Car o)
        {
            Console.WriteLine(o.ToString());
            return o;
        }



        private static void RunDelegatsReturnCovar()
        {
            //MyDelegateReturn<Ford> delegateDerivedBase = FooArgInBase;
            MyDelegateReturn<Ford> delegateDerivedDerived = FooArgInDerived;
            MyDelegateReturn<Car> delegateBaseBase = FooArgInBase;
            //MyDelegateReturn<Car> delegateBaseBase1 = delegateDerivedDerived;
            FooTakeDelegateReturn(delegateBaseBase);
            //FooTakeDelegate(delegateDerivedDerived);
            MyDelegateReturn<Car> delegateBaseDerived = FooArgInDerived;


            //MyDelegateReturnOut<Ford> delegateOutDerivedBase = FooArgInBase;
            MyDelegateReturnOut<Ford> delegateOutDerivedDerived = FooArgInDerived;
            MyDelegateReturnOut<Car> delegateOutBaseBase = FooArgInBase;
            MyDelegateReturnOut<Car> delegateOutBaseBase1 = delegateOutDerivedDerived;
            FooTakeDelegateReturnOut(delegateOutBaseBase);
            FooTakeDelegateReturnOut(delegateOutDerivedDerived);
            MyDelegateReturnOut<Car> delegateOutBaseDerived = FooArgInDerived;
            Car a = delegateOutBaseDerived();
        }
        private static void FooTakeDelegateReturn(MyDelegateReturn<Car> foo)
        {
        }

        private static void FooTakeDelegateReturnOut(MyDelegateReturnOut<Car> foo)
        {
        }

        private static Car FooArgInBase()
        {
            //return new Ford();
            return new Car();
        }

        private static Ford FooArgInDerived()
        {
            return new Ford();
        }

        private static void RunDelegatsArgContvar()
        {
            MyDelegateArgIn<Car> delegateArgInBase = FooArgInBase;
            delegateArgInBase(new Car());

            //MyDelegateArgIn<Car> delegateArgInBaseDerived = FooArgInDerived;
            //delegateArgInBaseDerived(new Ford());

            MyDelegateArgIn<Ford> delegateArgInDerivedBase = FooArgInBase;
            delegateArgInDerivedBase(new Ford());
            MyDelegateArgIn<Ford> delegateArgInDerivedBase1 = delegateArgInBase;
            delegateArgInDerivedBase1(new Ford());

            MyDelegateArgIn<Ford> delegateArgInDerivedDerived = FooArgInDerived;
            delegateArgInDerivedDerived(new Ford());


            ////////////////////


            MyDelegateArg<Car> delegateArgBase = FooArgInBase;
            delegateArgBase(new Car());

            //MyDelegateArg<Car> delegateArgBaseDerived = FooArgInDerived;
            //delegateArgBaseDerived(new Ford());

            MyDelegateArg<Ford> delegateArgDerivedBase = FooArgInBase;
            delegateArgDerivedBase(new Ford());
            //MyDelegateArg<Ford> delegateArgDerivedBase1 = delegateArgBase;
            //delegateArgDerivedBase1(new Ford());

            MyDelegateArg<Ford> delegateArgDerivedDerived = FooArgInDerived;
            delegateArgDerivedDerived(new Ford());

            FooTakeDelegateArgFord(FooArgInDerived);
            FooTakeDelegateArgInFord(FooArgInDerived);

            FooTakeDelegateArgFord(FooArgInBase);
            FooTakeDelegateArgInFord(FooArgInBase);

            FooTakeDelegateArgCar(FooArgInBase);
            FooTakeDelegateArgInCar(FooArgInBase);

            //FooTakeDelegateArgInCar(delegateArgInDerivedBase1);

            DelegateCar dc = FooArgInBase;
            DelegateFord df = new DelegateFord(FooArgInDerived);
            //dc = FooArgInDerived;
            df = FooArgInBase;

            //dc = df;
            //df = dc;
        }

        delegate void DelegateCar(Car car);
        delegate void DelegateFord(Ford ford);


        private static void FooTakeDelegateArgCar(MyDelegateArg<Car> foo)
        {
            foo(new Ford());
        }

        private static void FooTakeDelegateArgInCar(MyDelegateArgIn<Car> foo)
        {
            foo(new Ford());
        }

        private static void FooTakeDelegateArgFord(MyDelegateArg<Ford> foo)
        {
            foo(new Ford());
        }

        private static void FooTakeDelegateArgInFord(MyDelegateArgIn<Ford> foo)
        {
            foo(new Ford());
        }

        private static void FooArgInDerived(Ford o)
        {
            Console.WriteLine(o.ToString());
        }

        private static void FooArgInBase(Car o)
        {
            Console.WriteLine(o.ToString());
        }

        private static object Foo(object o)
        {
            Console.WriteLine(o.ToString());
            return o;
        }

        //private static void WantDelegate(MyDelegate<T, TResult> d){}

    }
}
