using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class Queue<T>
    {
        private readonly int _maxSlot;
        int _head;
        int _tail;
        T[] _array;

        public Queue()
        {
            _maxSlot = 1000;
            Initialize();
        }

        private void Initialize()
        {
            _head = _tail = -1;
            _array = new T[_maxSlot];
        }

        public Queue(int maxSlot)
        {
            if (maxSlot <= 1) throw new ArgumentOutOfRangeException("Handle queue with size > 1 only");
            _maxSlot = maxSlot;
            Initialize();
        }

        public void EnQueue(T item)
        {
            if (_tail == -1)
            {
                 _tail = _head = 0;
            }
            else
            {
                int count = Count();
                _tail = (_tail + 1) % _maxSlot;
            }

            _array[_tail] = item;
        }

        public T DeQueue()
        {
            if (Count() == 0) throw new InvalidOperationException("cannot dequeue empty queue");
            var value = _array[_head];
            _head = _head + 1 % _maxSlot;
            return value;
        }

        public int Count()
        {
            if (_tail == -1) return 0;
            var result = _tail - _head + 1;
            if (result < 0) result+= _maxSlot;
            return  result % _maxSlot;
        }
    }
}
