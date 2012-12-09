using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class Graph<T>
    {
        LList<T>[] _graph;
        public Graph()
        {
            _graph = new LList<T>[0];
        }

        public void Add(T target, IEnumerable<T> neighbors)
        {
            var newGraph = new LList<T>[_graph.Length + 1];
            Array.Copy(_graph, newGraph, _graph.Length);

            var linkedList = new LList<T>();
            foreach (var neighbor in neighbors)
            {
                linkedList.Add(neighbor);
            }
            newGraph[newGraph.Length - 1] = linkedList;
        }

        public IEnumerable<T> BFS()
        {
            throw new NotImplementedException();
        }
    }
}
