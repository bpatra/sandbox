using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class QuickSortLikeSelector<T>  where T : IComparable<T>
    {
        private T[] _items;
        private const int Seed = 199;
        private Random _gen;
        private int _i;

        public T Select(T[] items, int i)
        {
            _items = (T[]) items.Clone();
            _gen = new Random(Seed);
            _i = i - 1;

            return Select(0, items.Length - 1);
        }

        private T Select(int start, int end)
        {
            int k = Partition(start, end); 

            if(k < _i)
            {
                return Select(k +1, end);
            }
            else if(k == _i)
            {
                return _items[k];
            }
            else
            {
                return Select(start, k -1);
            }
        }

        private int Partition(int start, int end)
        {
            int pivotIndex = _gen.Next(start, end + 1);
            Swap(pivotIndex, end);

            int j = start;
            for(int i=start; i <= end -1; i++)
            {
                if(_items[i].CompareTo(_items[j]) < 1)
                {
                    Swap(i, j);
                    j++;
                }
            }
            Swap(j, end);
            return j;
        }

        private void Swap(int i, int j)
        {
            var val = _items[i];
            _items[i] = _items[j];
            _items[j] = val;
        }
    }
}
