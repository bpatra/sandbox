using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class LList<S>
    {
        private LNode<S> _sentinel;

        public LNode<S> Head { get { return _sentinel.Next; } }
        public S HeadContent { get { return _sentinel.Next.Content; } }
        public LNode<S> Sentinel { get { return _sentinel; } }

        public LList()
        {
            _sentinel = new LNode<S>(default(S)){Previous = null, Next = null};
            _sentinel.Next = _sentinel;
            _sentinel.Previous = _sentinel;
        }


        public void Add(S content)
        {
            var newHead = new LNode<S>(content);
            Add(newHead);
        }

        public void Add(LNode<S> lNode)
        {
            lNode.Next = _sentinel.Next;
            _sentinel.Next.Previous = lNode;
            _sentinel.Next = lNode;
            lNode.Previous = _sentinel;
        }

        public void Delete(LNode<S> lNode)
        {
            lNode.Previous.Next = lNode.Next;
            lNode.Next.Previous = lNode.Previous;
        }
        
        public LNode<S> Search(S s)
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

    public class LNode<S>
    {
        public S Content { get; private set; }
        public LNode<S> Next { get; set; }
        public LNode<S> Previous { get; set; }

        public LNode(S content)
        {
            Content = content;
        }
    }
}
