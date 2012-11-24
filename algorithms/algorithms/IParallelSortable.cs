using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public interface IParallelSortable<T> where T : IComparable<T>
    {
        void ParallelSort(T[] items, int cpuCount);
    }
}
