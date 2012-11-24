using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public interface ISortable<T> where T :IComparable<T>
    {
        void Sort(T[] items);
    }
}
