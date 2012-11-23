using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace algorithms
{
    public class InPlaceMergeSort
    {
        public static void Sort(int[] array, int left, int right)
        {
            if (left == right) return;

            int middle = (left + right) / 2;

            Sort(array, left, middle);
            Sort(array, middle +1, right);
            Merge(array, left, right);
        }

        public static void Merge(int[] array, int left, int right)
        {
            int mergedSized = right-left + 1;
            var result = new int[mergedSized];
            int middle = (left + right) / 2;
            int i = 0;
            int j = 0;
            while (i + j < mergedSized)
            {
                int iGlobal = left + i;
                int jGlobal = middle + 1 + j;
                if (i == middle - left +1)
                {
                    result[i + j] = array[jGlobal];
                    j++;
                    continue;
                }
                if (j == right - middle)
                {
                    result[i + j] = array[iGlobal];
                    i++;
                    continue;
                }
                if (array[iGlobal] < array[jGlobal])
                {
                    result[i + j] = array[iGlobal];
                    i++;
                }
                else
                {
                    result[i + j] = array[jGlobal];
                    j++;
                }
            }
            Array.Copy(result, 0, array, left, right - left + 1); 
        }
    }
}
