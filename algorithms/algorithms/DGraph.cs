using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class DGraph
    {
        LList<int>[] _graph;

        public DGraph(int vertexCount)
        {
            _graph = new LList<int>[vertexCount];
        }

        /// <summary>
        ///Mthod to add a new vertex with its neighbors.
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="neighbors"></param>
        public void Add(int vertex, IEnumerable<int> neighbors)
        {
            if (vertex >= _graph.Length)
            {
                throw new ArgumentOutOfRangeException("vertex not compatible with current graph definition");
            }

            var linkedList = new LList<int>();
            foreach (var neighbor in neighbors)
            {
                if (neighbor >= _graph.Length)
                {
                    throw new ArgumentOutOfRangeException("vertex not compatible with current graph definition");
                }
                linkedList.Add(neighbor);
            }
            _graph[vertex] = linkedList;
        }

        public IEnumerable<int> BFS(int root)
        {
            throw new NotImplementedException();
        }
    }
}
