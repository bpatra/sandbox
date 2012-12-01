using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class BinarySearchTree<T> where T: IComparable<T>
    {
        //private TNode<T> _root;
        
        IEnumerable<T> CollectInOrder(TNode<T> root)
        {
            throw new NotImplementedException();
        }

        TNode<T> Search(T item)
        {
            throw new NotImplementedException();
        }

        TNode<T> Minimum()
        {
            throw new NotImplementedException();
        }


        TNode<T> Minimum(TNode<T> root)
        {
            throw new NotImplementedException();
        }

        TNode<T> Maximum()
        {
            throw new NotImplementedException();
        }

        TNode<T> Maximum(TNode<T> root)
        {
            throw new NotImplementedException();
        }

        TNode<T> Sucessor(TNode<T> node)
        {
            throw new NotImplementedException();
        }

        void Insert(TNode<T> node)
        {
            throw  new NotImplementedException();
        }

        void Delete(TNode<T> node)
        {
            throw  new NotImplementedException();
        }

    }

    public class TNode<S>
    {
        public S Content { get; set; }
        public TNode<S> Parent { get; set; }
        public TNode<S> LeftChild { get; set; }
        public TNode<S> RightChild { get; set; }
    }
}
