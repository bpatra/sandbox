﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class MaxPriorityQueue<T>
    {
        private KeyValuePair<double,T>[] _items;
        private int[] _heap;

        public int Count
        {
            get { return _heap.Length; }
        }

        public MaxPriorityQueue(KeyValuePair<double,T>[] items)
        {
            if(items == null || items.Length == 0) throw  new ArgumentException("Max priority queue cannot be null or empty");

            _items = (KeyValuePair<double,T>[]) items.Clone();
            _heap = Enumerable.Range(0, _items.Length).ToArray();
            BuildMaxHeap();
        }

        private void MaxHeapify(int i, int end)
        {
            int leftChild = 2*i + 1;
            int rightChild = 2*i + 2;

            int nextPosition = i;
            if(leftChild <= end && _items[_heap[leftChild]].Key >= _items[_heap[nextPosition]].Key)
            {
                nextPosition = leftChild;
            }
            if(rightChild <= end && _items[_heap[rightChild]].Key >= _items[_heap[nextPosition]].Key)
            {
                nextPosition = rightChild;
            }
            if(nextPosition != i)
            {
                int val = _heap[nextPosition];
                _heap[nextPosition] = _heap[i];
                _heap[i] = val;
                MaxHeapify(nextPosition, end);
            }
        }

        private void BuildMaxHeap()
        {
            for(int i = _heap.Length /2; i >=0; i--)
            {
                MaxHeapify(i,_heap.Length -1);
            }
        }

        public T Maximum()
        {
            return _items[_heap[0]].Value;
        }

        public void Insert(KeyValuePair<double,T> item)
        {
            var newItems = new KeyValuePair<double, T>[_items.Length + 1];
            Array.Copy(_items, 0, newItems, 0 , _items.Length);
            _items = newItems;
            _items[_items.Length - 1] = item;

            var newHeap = new int[_heap.Length +1];
            Array.Copy(_heap,0, newHeap,0, _heap.Length);
            _heap = newHeap;

            _heap[_heap.Length-1] = _items.Length - 1;

            IncreaseKey(_heap.Length - 1, item.Key); //force heapification of the heap.
        }

        public T ExtractMax()
        {
            if(_heap.Length ==0) throw new ArgumentOutOfRangeException("Cannot ExtractMax in empty queue");

            var val = Maximum();

            _items[_heap[0]] = new KeyValuePair<double, T>(double.NaN, default(T));

            var temp = _heap[0];
            _heap[0] = _heap[_heap.Length - 1];
            _heap[_heap.Length - 1] = temp;

            var newHeap = new int[_heap.Length - 1];
            Array.Copy(_heap, 0 , newHeap,0, newHeap.Length);
            _heap = newHeap;
            
            MaxHeapify(0,_heap.Length -1);

            return val;
        }

        public void IncreaseKey(int index, double value)
        {
            if(index >= _heap.Length) throw new IndexOutOfRangeException("Index is not valid for queue");

            var oldKvP = _items[_heap[index]];
            _items[_heap[index]] = new KeyValuePair<double, T>(value, oldKvP.Value);

            int targetIndex = index;
            int parentIndex = (targetIndex - 1)/2;
            while(parentIndex >= 0 && _items[_heap[parentIndex]].Key < _items[_heap[targetIndex]].Key)
            {
                int temp = _heap[parentIndex];
                _heap[parentIndex] = _heap[targetIndex];
                _heap[targetIndex] = temp;

                targetIndex = parentIndex;
                parentIndex = (targetIndex - 1) / 2;
            }
        }
    }


}
