using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class BinarySearchTree<T> where T: IComparable<T>
    {
        private TNode<T> _root;
        
        public List<T> CollectInOrder(TNode<T> startRoot)
        {
            var list = new List<T>();
            CollectInOrder(list, startRoot);
            return list;
        }

        public List<T> CollectInOrder()
        {
            return CollectInOrder(_root);
        }

        private void CollectInOrder(List<T> list, TNode<T> startRoot)
        {
            if(startRoot != null)
            {
                CollectInOrder(list, startRoot.LeftChild);
                list.Add(startRoot.Content);
                CollectInOrder(list, startRoot.RightChild);
            }
        }

        public TNode<T> Search(T item)
        {
            return Search(_root, item);
        }

        public TNode<T> Search(TNode<T> startNode, T item)
        {
            if(startNode == null) return null;
            if(startNode.Content.Equals(item))
            {
                return startNode;
            }
            else if (item.CompareTo(startNode.Content) < 1)
            {
                return Search(startNode.LeftChild, item);
            }
            else
            {
                return Search(startNode.RightChild, item);
            }
        }

        public TNode<T> Minimum()
        {
            return Minimum(_root);
        }


        public TNode<T> Minimum(TNode<T> startNode)
        {
            if(startNode.LeftChild == null)
            {
                return startNode;
            }
            else
            {
                return Minimum(startNode.LeftChild);
            }
        }

        public TNode<T> Maximum()
        {
            return Maximum(_root);
        }

        public TNode<T> Maximum(TNode<T> node)
        {
           if(node.RightChild == null)
           {
               return node;
           }
           else
           {
               return Maximum(node.RightChild);
           }
        }

        public TNode<T> Sucessor(TNode<T> node)
        {
            if(node.RightChild != null)
            {
                return Minimum(node.RightChild);
            }
            else
            {
                var parent = node.Parent;
                while (parent != null && parent.Content.CompareTo(node.Content) < 1)
                {
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        public void Insert(TNode<T> node)
        {

            var currentNode = _root;
            TNode<T> parentCurrentNode = null;
            while(currentNode != null)
            {
                parentCurrentNode = currentNode;
                if(currentNode.Content.CompareTo(node.Content) < 1)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    currentNode = currentNode.LeftChild;
                }
            }

            if(parentCurrentNode==null)
            {
                _root = node;
            }
            else
            {
                node.Parent = parentCurrentNode;
                if(parentCurrentNode.Content.CompareTo(node.Content) < 1)
                {
                    parentCurrentNode.RightChild = node;
                }
                else
                {
                    parentCurrentNode.LeftChild = node;
                }
            }
        }

        public void Delete(TNode<T> node)
        {
           //if(node.LeftChild && node.RightChild ==null)
           //{
           //    if(node.Parent.LeftChild == node)
           //    {
           //        node.Parent.LeftChild.Parent == null;
           //    }
           //}
        }

    }

    public class TNode<S>
    {
        public S Content { get; private set; }
        public TNode<S> Parent { get; set; }
        public TNode<S> LeftChild { get; set; }
        public TNode<S> RightChild { get; set; }

        public TNode(S item)
        {
            Content = item;
        }
    }
}
