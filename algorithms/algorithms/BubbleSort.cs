using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class BubbleSort<T> : ISortable<T> where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            for(int i=0; i < items.Length; i++)
            {
                for(int j= items.Length -1; j >= i+1; j--)
                {
                    if(items[j-1].CompareTo(items[j]) >= 1)
                    {
                        var val = items[j];
                        items[j] = items[j - 1];
                        items[j - 1] = val;
                    }
                }
            }
        }
    }
}
