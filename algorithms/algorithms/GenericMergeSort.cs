using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class GenericMergeSort<T> : ISortable<T> where T : IComparable<T>
    {
        private T[] _items;
        public void Sort(T[] items)
        {
            _items = items;
            Sort(0, _items.Length -1);
        }

        private void Sort(int start, int end)
        {
            if (start >= end) return;

            int middle = (start + end)/2;
            Sort(start, middle);
            Sort(middle +1, end);
            Merge(start, middle, end);
        }

        private void Merge(int start, int inter, int end)
        {
            T[] left = new T[inter - start + 1];
            T[] right = new T[end -inter];
            Array.Copy(_items, start,left,0, inter - start +1);
            Array.Copy(_items,inter, right, 0, end - inter);

            int i = 0;
            int j = 0;
            for(int k=start; k <= end; k++)
            {
                if(i==left.Length)
                {
                    _items[k] = right[j];
                    return;
                }
                
                if(j==right.Length)
                {
                    _items[k] = left[i];
                    return;
                }

                if(left[i].CompareTo(right[j]) < 1)
                {
                    _items[k] = left[i];
                    i++;
                }
                else
                {
                    _items[k] = right[j];
                    j++;
                }

            }
        }
    }
}
