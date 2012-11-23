using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class HeapSort
    {
        public static void MaxHeapify(int[] array, int i, int end)
        {
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;

            int maxIndex = i;
            if (leftChild <= end && array[leftChild] > array[maxIndex])
            {
                maxIndex = leftChild;
            }
            if (rightChild <= end && array[rightChild] > array[maxIndex])
            {
                maxIndex = rightChild;
            }

            if (maxIndex != i)
            {
                int temp = array[maxIndex];
                array[maxIndex] = array[i];
                array[i] = temp;
                MaxHeapify(array, maxIndex, end);
            }
        }

        public static void BuildMaxHeap(int[] array, int end)
        {
            for (int i = end / 2; i >= 0; i--)
            {
                MaxHeapify(array, i, end);
            }
        }

        public static void Sort(int[] array)
        {
            BuildMaxHeap(array, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                var maxVal = array[0];
                array[0] = array[array.Length - i - 1];
                array[array.Length - i - 1] = maxVal;
                MaxHeapify(array, 0, array.Length - i - 2);
            }
        }
    }
}
