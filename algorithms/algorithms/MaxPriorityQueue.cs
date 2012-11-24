using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class MaxPriorityQueue<T>
    {
        private KeyValuePair<double,T>[] _items;
        private int[] _heap;
        public MaxPriorityQueue(KeyValuePair<double,T>[] items)
        {
            _items = items;
            _heap = Enumerable.Range(0, _items.Length-1).ToArray();
        }

        public T Maximum()
        {
            throw new NotImplementedException();
        }

        public void Insert(KeyValuePair<double,T> item)
        {
            throw new NotImplementedException();
        }

        public T ExtractMax()
        {
            throw new NotImplementedException();
        }

        public void IncreaseKey(int index, double value)
        {
            throw new NotImplementedException();
        }
    }


}
