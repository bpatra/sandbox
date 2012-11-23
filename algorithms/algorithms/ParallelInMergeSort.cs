using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace algorithms
{
    public class ParallelInMergeSort
    {
        private static int threadCount = 0;

        private static void SortDelegate(object ocontext)
        {
            var context = (SortContext)ocontext;
            ParallelSort(context.Array, context.Left, context.Right);
        }

        public static void ParallelSort(int[] array, int left, int right)
        {
            int length = right - left;
            if (length == 0) return;

            int middle = (left + right) / 2;

            if (threadCount <= 4 && length > array.Length / 16) //do not spawn too much thread.
            {
                Interlocked.Increment(ref threadCount);
                var context = new SortContext() { Array = array, Left = middle + 1, Right = right };
                var thread = new Thread(new ParameterizedThreadStart(SortDelegate));
                thread.Start((object)context);
                ParallelSort(array, left, middle);
                thread.Join();
                Interlocked.Decrement(ref threadCount);
            }
            else
            {
                ParallelSort(array, middle + 1, right);
                ParallelSort(array, left, middle);
            }

            InPlaceMergeSort.Merge(array, left, right);
        }

        private class SortContext
        {
            public int[] Array { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
        }
    }
}
