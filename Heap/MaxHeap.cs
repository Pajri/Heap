using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.Heap
{
    public class MaxHeap : Heap
    {
        /*
         * Implementation of max heap datastructure
         * This code is based on video from hackerrank : https://www.youtube.com/watch?v=t0Cq6tVNRBA
         */

        public MaxHeap(int capacity) : base(capacity)
        {
        }

        protected override void _HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int biggerChildIndex = LeftChildIndex(index);
                if (LeftChild(index) < RightChild(index)) biggerChildIndex = RightChildIndex(index);

                if (_heap[index] > _heap[biggerChildIndex]) break;
                else
                {
                    Swap(index, biggerChildIndex);
                }

                index = biggerChildIndex;
            }
        }

        protected override void _HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && Parent(index) < _heap[index])
            {
                Swap(ParentIndex(index), index);
                index = ParentIndex(index);
            }
        }
    }
}
