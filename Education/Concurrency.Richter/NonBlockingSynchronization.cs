using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Richter
{
    class NonBlockingSynchronization
    {
        private volatile int _sync = 0;
        private volatile int _lockValue = 1;
        private volatile int _unLockValue = 0;
        private readonly Person _person = new Person("", -1);

        public void Update(Person person)
        {
            while (Interlocked.Exchange(ref _sync, _lockValue) == _lockValue){}

            _person.Name = person.Name;
            Thread.Sleep(300);
            _person.Age = person.Age;
            Interlocked.Exchange(ref _sync, _unLockValue);
            return;
        }

        public override string ToString()
        {
            while (Interlocked.Exchange(ref _sync, _lockValue) == _lockValue) { }
            var str = String.Concat(_person.Name, " ", _person.Age);
            Interlocked.Exchange(ref _sync, _unLockValue);

            return str;
        }
    }
}
