using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public interface IGenericSortable<T> where T : IComparable<T>
    {
        void Sort(T[] items);
    }
}
