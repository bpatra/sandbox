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

        public List<int> BFS(int root)
        {
            int[] status = new int[_graph.Length];//O for unvisited, 1 for enqueue, 2 for visited.
            var list = new List<int>();
            
            var queue = new Queue<int>(_graph.Length + 1);
            queue.EnQueue(root);
            list.Add(root);
            status[root] = 1;
            while(queue.Count > 0)
            {
                var element = queue.DeQueue();
                var child = _graph[element].Head;
                while(child != _graph[element].Sentinel)
                {
                    if(status[child.Content]==0)
                    {
                        status[child.Content] = 1;
                        list.Add(child.Content);
                        queue.EnQueue(child.Content);
                    }
                    child = child.Next;
                }
               
            }
            return list;

        }
    }
}
