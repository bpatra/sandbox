﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class GenericInsertionSort<T> : ISortable<T> where T : IComparable<T> 
    {
        public void Sort(T[] items)
        {
            for(int i=2; i < items.Length; i++)
            {
                var currentVal = items[i];
                int j = i-1;
                while(currentVal.CompareTo(items[j]) < 1)
                {
                    items[j + 1] = items[j];
                    j++;
                }
                items[j + 1] = currentVal;
            }

        }
    }
}
