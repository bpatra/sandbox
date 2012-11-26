using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class LList<S>
    {
        private Node<S> _sentinel;

        public Node<S> Head { get { return _sentinel.Next; } }
        public S HeadContent { get { return _sentinel.Next.Content; } }

        public LList()
        {
            _sentinel = new Node<S>(default(S)){Previous = null, Next = null};
            _sentinel.Next = _sentinel;
            _sentinel.Previous = _sentinel;
        }


        public void Add(S content)
        {
            var newHead = new Node<S>(content);
            Add(newHead);
        }

        public void Add(Node<S> node)
        {
            node.Next = _sentinel.Next;
            _sentinel.Next.Previous = node;
            _sentinel.Next = node;
            node.Previous = _sentinel;
        }

        public void Delete(Node<S> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }
        
        public Node<S> Search(S s)
        {
            var currentNode = _sentinel.Next;
            while (currentNode != _sentinel)
            {
                if(currentNode.Content.Equals(s))
                {
                    return currentNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            return null;
        }
    }

    public class Node<S>
    {
        public S Content { get; private set; }
        public Node<S> Next { get; set; }
        public Node<S> Previous { get; set; }

        public Node(S content)
        {
            Content = content;
        }
    }
}
