using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerAndYield
{
    class Parking : IEnumerable
    {
        private List<Car> _cars = new List<Car>();//коллекция автомобилей
        private const int MAX_CARS = 100;

        public Car this[string number]//получение по индексу равному номеру автомобиля
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == number);
                return car;
            }
        }
        public Car this[int position]
        {
            get
            {
                if (position < _cars.Count)
                {
                    return _cars[position];
                }

                return null;
            }
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;
                }
            }

        }


        public int Count => _cars.Count;
        public string Name { get; set; }
        public int Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is not found");
            }
            if (_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                return _cars.Count-1;
            }
            return -1;
        }
        public void GoOut(string numb)
        {
            if (string.IsNullOrWhiteSpace(numb))
            {
                throw new ArgumentNullException(nameof(numb), "Number is null ar empty");
            }
            var car = _cars.FirstOrDefault(c => c.Number == numb);
            if (car != null)
            {
                _cars.Remove(car);
            }        
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _cars)
            {
                yield return item;
            }
        }
        public IEnumerable GetNames()
        {
            foreach (var item in _cars)
            {
                yield return item.Name;
            }
        }        
    }

    //без использования списка пришлось бы реализовывать самостоятельно класс
    //заменяется Yield'ом
    public class ParkingEnumerator : IEnumerator
    {
        object IEnumerator.Current => throw new NotImplementedException();

        bool IEnumerator.MoveNext()
        {
            throw new NotImplementedException();
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
    }
}
