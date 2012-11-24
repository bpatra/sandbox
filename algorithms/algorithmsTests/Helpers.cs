using System;

namespace algorithmsTests
{
    public static class Helpers
    {
        public static bool IsSorted(this int[] array)
        {
            for(int i=1; i < array.Length; i++)
            {
                if(array[i-1] > array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSorted<T>(this T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1].CompareTo(array[i])  > 1)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Print(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}