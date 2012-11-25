using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class CountingSort : ISortable<int>
    {
        private int _k;
        /// <param name="k">max exclusive expected values for items.</param>
        public CountingSort(int k)
        {
            _k = k;
        }
        
        public void Sort(int[] items)
        {
            var count = new int[_k];
            var tempItems = new int[items.Length];

            for (int i = 0; i < items.Length; i++ )
            {
                Debug.Assert(items[i] <= _k, "all value are expected to be lower or equal "+_k);
                count[items[i]]++;
            }
            
            for(int i=1; i < _k; i++)
            {
                count[i] += count[i - 1];
            }

            for(int j =items.Length-1; j>=0; j--)
            {
                var target = count[items[j]];
                tempItems[--target] = items[j];
                count[items[j]]--;
            }

            Array.Copy(tempItems,items, items.Length);
        }
    }
}
