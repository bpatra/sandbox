using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{

    public class NodeList<S>
    {
        Node<S> _head;

        public Node<S> Head{get {return _head;}}

        public void Add(S content)
        {
            var node = new Node<S>(content, _head);
            _head = node;
        }


        public class Node<S>
        {
            S _content;
            public S Content {get {return _content;}}
            public Node<S> Right {get {return _right;}}
            private Node<S> _right;
            public Node(S content, Node<S> right)
            {
                _content = content;
                _right = right;
            }
        }
    }

    public class NaiveHashTable<T>
    {
        NodeList<Pair<T>>[] _list;
        const int N = 5;

        public NaiveHashTable()
        {
            _list = new NodeList<Pair<T>>[N];
        }

        public T this[string key]
        {
            get
            {
                int hash = HashFunction(key);
                var nodellist = _list[hash];
                var currentNode = nodellist.Head;
                while( currentNode != null)
                {
                    if(currentNode.Content.Key == key)
                    {
                        return currentNode.Content.Value;
                    }
                    currentNode = currentNode.Right;
                }
                return default(T);
            }
            set
            {
                int hash = HashFunction(key);
                if (_list[hash] != null)
                {
                    _list[hash].Add(new Pair<T> { Key = key, Value = value });
                }
                else
                {
                    _list[hash] = new NodeList<Pair<T>>();
                    _list[hash].Add(new Pair<T> { Key = key, Value = value });
                }
            }

        }

        int HashFunction(string key)
        {
            var gen = new Random(key.GetHashCode());
            return gen.Next(0, N);
        }
    }

    public class Pair<T>
    {
        public T Value {get; set;}
        public string Key{get;set;}
    }

    public class Person
    {
        public string Name;
        public string Adress;
        public int Age;
    }
}
