using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.Heap
{
    public abstract class Heap
    {
        /*
         * Implementation of heap datastructure
         * This code is based on video from hackerrank : https://www.youtube.com/watch?v=t0Cq6tVNRBA
         */

        #region Properties
        protected int[] _heap;
        public int[] HeapItems { get { return _heap; } }
        public int Capacity { get { return _heap.Length; } }


        protected int _size = 0;
        public int Size { get { return _size; } }
        #endregion

        #region Constructors
        public Heap(int capacity)
        {
            _heap = new int[capacity];
        }
        #endregion

        #region Common Heap Methods
        public int LeftChildIndex(int parentIndex)
        {
            int leftChildIndex = 2 * parentIndex + 1;
            if (parentIndex >= Capacity || parentIndex < 0 || leftChildIndex >= Capacity || leftChildIndex >= _size) return -1;
            return leftChildIndex;
        }

        public int RightChildIndex(int parentIndex)
        {
            int rightChildIndex = 2 * parentIndex + 2;
            if (parentIndex >= Capacity || parentIndex < 0 || rightChildIndex >= Capacity || rightChildIndex >= _size) return -1;
            return rightChildIndex;
        }

        public int ParentIndex(int childIndex)
        {
            if (childIndex >= Capacity || childIndex < 0) return -1;
            return (childIndex - 1) / 2;
        }

        public bool HasLeftChild(int parentIndex)
        {
            return LeftChildIndex(parentIndex) == -1 ? false : true;
        }

        public bool HasRightChild(int parentIndex)
        {
            return RightChildIndex(parentIndex) == -1 ? false : true;
        }

        public bool HasParent(int childIndex)
        {
            return ParentIndex(childIndex) == -1 ? false : true;
        }

        public int? LeftChild(int parentIndex)
        {
            if (HasLeftChild(parentIndex)) return _heap[LeftChildIndex(parentIndex)];
            return null;
        }

        public int? RightChild(int parentIndex)
        {
            if (HasRightChild(parentIndex)) return _heap[RightChildIndex(parentIndex)];
            return null;
        }

        public int? Parent(int childIndex)
        {
            if (HasParent(childIndex)) return _heap[ParentIndex(childIndex)];
            return null;
        }

        public void Swap(int idxA, int idxB)
        {
            if (_IsIndexInCapacity(idxA) && _IsIndexInCapacity(idxB))
            {
                int temp = _heap[idxA];
                _heap[idxA] = _heap[idxB];
                _heap[idxB] = temp;
            }
        }

        public int? Peek() { return _heap.Length == 0 ? null : (int?)_heap[0]; }

        public int? Poll()
        {
            if (_size == 0) return null;
            int item = _heap[0];
            _heap[0] = _heap[_size - 1];
            _size--;
            _HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            _EnsureExtracapacity();
            _heap[_size] = item;
            _size++;
            _HeapifyUp();
        }

        public void PrintHeap()
        {
            _Visit(0);
        }
        #endregion

        #region Helper Methods
        private void _Visit(int index)
        {
            if (index < _size)
            {
                if (HasLeftChild(index)) _Visit(LeftChildIndex(index));
                Console.WriteLine(_heap[index] + " :: parent : " + Parent(index));
                if (HasRightChild(index)) _Visit(RightChildIndex(index));
            }
        }

        private void _EnsureExtracapacity()
        {
            if (_size == Capacity)
            {
                int[] newHeap = new int[Capacity * 2];
                _heap.CopyTo(newHeap, 0);
                _heap = newHeap;
            }
        }

        private bool _IsIndexInCapacity(int idx)
        {
            return (idx >= 0 && idx < Capacity) ? true : false;
        }
        #endregion

        #region Abstract Methods
        protected abstract void _HeapifyUp();
        protected abstract void _HeapifyDown();
        #endregion


    }
}
