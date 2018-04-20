using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.HerbSutter.LockFree
{
    class LockFreeConstructions
    {
        private Person _person;
        private static readonly object _sync = new Object();

        public LockFreeConstructions()
        {
            _person = new Person();
        }

        public void ConcurrencyUnsafe(object personDTO)
        {
            var personData = (PersonDTO)personDTO;
            var name = personData.Name;
            var surname = personData.Surname;
            var age = personData.Age;

            _person.Name = name;
            Thread.Sleep(350);
            _person.Surname = surname;
            _person.Age = age;
        }

        public void BasedOnLock(object personDTO)
        {
            var personData = (PersonDTO)personDTO;
            var name = personData.Name;
            var surname = personData.Surname;
            var age = personData.Age;

            lock (_sync)
            {
                _person.Name = name;
                Thread.Sleep(350);
                _person.Surname = surname;
                _person.Age = age;
            }
        }

        private const bool _startValueIsUpdated = true;
        private volatile bool _isUpdated = _startValueIsUpdated;

        public void BasedOnWhile(object personDTO)
        {
            var personData = (PersonDTO)personDTO;
            var name = personData.Name;
            var surname = personData.Surname;
            var age = personData.Age;

            // TODO Not safe
            while (!_isUpdated) { }
            _isUpdated = false;
            _person.Name = name;
            //Thread.Sleep(350);
            _person.Surname = surname;
            _person.Age = age;
            _isUpdated = true;

        }

        public override string ToString()
        {
            return _person.ToString();
        }

        public void CleanUp()
        {
            _person.Name = null;
            _person.Surname = null;
            _person.Age = 0;
            _isUpdated = _startValueIsUpdated;
        }
    }
}
