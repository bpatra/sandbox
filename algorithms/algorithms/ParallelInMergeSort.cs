using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace algorithms
{
    public class ParallelInMergeSort
    {
        public static int threadCount = 0;
        public static void SortDelegate(object ocontext)
        {
            var context = (SortContext)ocontext;
            ParallelSort2(context.Array, context.Left, context.Right);
        }

        //public static void ParallelSort(int[] array, int left, int right)
        //{
        //    if (left == right) return;

        //    int middle = (left + right) / 2;

        //    var context = new SortContext() { Array = array, Left = middle + 1, Right = right };
        //    var thread = new Thread(new ParameterizedThreadStart(SortDelegate));
        //    thread.Start((object)context);
        //    ParallelSort(array, left, middle);

        //    thread.Join();
        //    InPlaceMergeSort.Merge(array, left, right);
        //}

        public static void ParallelSort2(int[] array, int left, int right)
        {
            int length = right - left;
            if (length == 0) return;

            int middle = (left + right) / 2;

            if (threadCount <= 10 && length > array.Length / 16)
            {
                Interlocked.Increment(ref threadCount);
                var context = new SortContext() { Array = array, Left = middle + 1, Right = right };
                var thread = new Thread(new ParameterizedThreadStart(SortDelegate));
                thread.Start((object)context);
                ParallelSort2(array, left, middle);
                thread.Join();
                Interlocked.Decrement(ref threadCount);
            }
            else
            {
                ParallelSort2(array, middle + 1, right);
                ParallelSort2(array, left, middle);
            }

            InPlaceMergeSort.Merge(array, left, right);
        }

        public class SortContext
        {
            public int[] Array { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
        }
    }
}
