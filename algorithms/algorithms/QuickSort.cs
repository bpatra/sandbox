using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public static class QuickSort
    {
        const int seed = 1998;
        static Random gen = new Random(seed);
        public static int Partition(int[] array, int left, int right, int originalPivotIndex)
        {
            int pivotValue = array[originalPivotIndex];
            array[originalPivotIndex] = array[right];
            array[right] = pivotValue;

            int pivotIndex = left;
            for (int i = left; i <= right - 1; i++)
            {
                if (array[i] < pivotValue)
                {
                    int valAtPivot = array[pivotIndex];
                    array[pivotIndex] = array[i];
                    array[i] = valAtPivot;
                    pivotIndex++;
                }
            }

            array[right] = array[pivotIndex];
            array[pivotIndex] = pivotValue;

            return pivotIndex;
        }

        public static void Start(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = gen.Next(left, right);
                int newPivotPos = Partition(array, left, right, pivotIndex);

                Start(array, left, newPivotPos - 1);
                Start(array, newPivotPos + 1, right);
            }
           
        }
    }
}
