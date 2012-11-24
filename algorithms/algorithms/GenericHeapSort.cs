using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class GenericHeapSort<T> : ISortable<T> where T : IComparable<T>
    {
        private T[] _items;
        public void Sort(T[] items)
        {
            _items = items;
            TransformToMaxHeap();
            for (int i = 0; i < _items.Length -1; i++)
            {
                int end = _items.Length - i - 1;
                Swap(0, end);
                MaxHeapGoDown(0, _items.Length - i - 2);
            }
        }

        private void TransformToMaxHeap()
        {
            for(int i = _items.Length; i >=0; i--)
            {
                MaxHeapGoDown(i, _items.Length -1);
            }
        }

        private void MaxHeapGoDown(int index, int end)
        {
            int childLeft = 2*index +1;
            int childRight = 2*index + 2;

            
            int newPosition = index;
            if(childLeft <= end && _items[childLeft].CompareTo(_items[newPosition]) >= 1)
            {
                newPosition = childLeft;
            }
            if (childRight <= end && _items[childRight].CompareTo(_items[newPosition]) >=1 )
            {
                newPosition = childRight;
            }

            if(newPosition != index)
            {
                Swap(index, newPosition);
                MaxHeapGoDown(newPosition, end);
            }

        }

        private void Swap(int i, int j)
        {
            T val = _items[i];
            _items[i] = _items[j];
            _items[j] = val;
        }
    }
}
