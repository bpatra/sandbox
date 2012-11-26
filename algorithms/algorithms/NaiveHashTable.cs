using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{

    public class NaiveHashTable<T>
    {
        LList<Pair<T>>[] _list;
        const int N = 5;

        public NaiveHashTable()
        {
            _list = new LList<Pair<T>>[N];
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
                    currentNode = currentNode.Next;
                }
                throw new KeyNotFoundException("Key not found in hashtable");
            }
            set
            {
                int hash = HashFunction(key);
                if (_list[hash] != null)
                {
                    //Check that the key is not present
                    var currentNode = _list[hash].Head;
                    while (currentNode != null)
                    {
                        if (currentNode.Content.Key == key)
                        {
                            throw new ArgumentException("A value with the same key already exists");
                        }
                        currentNode = currentNode.Next;
                    }
                    _list[hash].Add(new Pair<T> { Key = key, Value = value });
                }
                else
                {
                    _list[hash] = new LList<Pair<T>>();
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
}
