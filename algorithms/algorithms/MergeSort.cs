using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace algorithms
{
    public class MergeSort<T> : ISortable<T>, IParallelSortable<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _maxThreadCount;
        private int _threadSpawnArrayLength;// minimal length or subarray to get thread spawing. This avoid thread spawing for small arrays.

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

        public void ParallelSort(T[] items, int maxThreadCount)
        {
            _items = items;
            _maxThreadCount = maxThreadCount;
            _threadSpawnArrayLength = (int) Math.Pow(2, maxThreadCount);
            ParallelSort(0, items.Length -1);
        }

        private void ParallelSort(int start, int end)
        {
            int length = end - start;
            if (length == 0) return;

            int middle = (start + end) / 2;

            if (_threadCount <= _maxThreadCount && length >= _threadSpawnArrayLength) //do not spawn too much thread.
            {
                Interlocked.Increment(ref _threadCount);
                var context = new SortContext() { Array = _items, Left = middle + 1, Right = end };
                var thread = new Thread(new ParameterizedThreadStart(SortDelegate));
                thread.Start((object)context);
                ParallelSort(start, middle);
                thread.Join();
                Interlocked.Decrement(ref _threadCount);
            }
            else
            {
                ParallelSort( middle + 1, end);
                ParallelSort(start, middle);
            }

            Merge(start, middle, end);
        }

        private int _threadCount = 0;

        private void SortDelegate(object ocontext)
        {
            var context = (SortContext) ocontext;
            ParallelSort(context.Left, context.Right);
        }

        private class SortContext
        {
            public T[] Array { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
        }
    }
}
