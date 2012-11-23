using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace algorithms
{
    public static class MergeSort
    {
        public static int[] Merge(int[] sorted1, int[] sorted2)
        {
            var result = new int[sorted1.Length + sorted2.Length];
            int i = 0;
            int j = 0;
            while (i + j < sorted1.Length + sorted2.Length)
            {
                if (i == sorted1.Length)
                {
                    result[i + j] = sorted2[j];
                    j++;
                    continue;
                }
                if (j == sorted2.Length)
                {
                    result[i + j] = sorted1[i];
                    i++;
                    continue;
                }
                
                if (sorted1[i] < sorted2[j])
                {
                    result[i + j] = sorted1[i];
                    i++;
                }
                else
                {
                    result[i + j] = sorted2[j];
                    j++;
                }
            }

            return result;
        }

        public static int[] Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            Array.Copy(array, leftArray, middle);
            int[] rightArray = new int[array.Length - middle];
            Array.Copy(array, middle, rightArray, 0, array.Length - middle);
            
            int[] sortedLeft = Sort(leftArray);
            int[] sortedRight = Sort(rightArray);
            return Merge(sortedLeft, sortedRight);
        }
    }

}
