using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class GenericQuickSort<T> : ISortable<T> where T : IComparable<T> 
    {
        Random _gen;
        T[] _items;
        public GenericQuickSort(int seed)
        {
            _gen = new Random(seed);
        }

        public void Sort(T[] items)
        {
            if(items==null) throw new ArgumentNullException();
            _items = items;
            Sort(0, items.Length -1);
        }

        private void Sort(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = _gen.Next(startIndex, endIndex + 1);
                pivotIndex = PlacePivot(startIndex, endIndex, pivotIndex);
                Sort(startIndex, pivotIndex - 1);
                Sort(pivotIndex + 1, endIndex);
            }
        }

        private int PlacePivot( int startIndex, int endIndex, int originalPivotPos)
        {   
            Swap(endIndex, originalPivotPos);

            T pivotVal = _items[endIndex];
            int finalPivotPos = startIndex;
            for(int i=startIndex; i < endIndex; i++)
            {
                if(_items[i].CompareTo(pivotVal) < 1)
                {
                    Swap(i, finalPivotPos);
                    finalPivotPos++;
                }
                
            }
            Swap(endIndex, finalPivotPos);
            return finalPivotPos;

        }

        void Swap(int i, int j)
        {
            T val = _items[i];
            _items[i] = _items[j];
            _items[j] = val;
        }
    }
}
