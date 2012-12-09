using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class Queue<T>
    {
        private readonly int _maxSlot;

        public Queue()
        {
            _maxSlot = 1000;
        }

        public Queue(int maxSlot)
        {
            _maxSlot = maxSlot;
        }

        public void EnQueue(T item)
        {
            throw new NotImplementedException();
        }

        public T DeQueue()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
