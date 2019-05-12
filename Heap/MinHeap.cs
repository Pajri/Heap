using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.Heap
{
    public class MinHeap : Heap
    {
        /*
         * Implementation of min heap datastructure
         * This code is based on video from hackerrank : https://www.youtube.com/watch?v=t0Cq6tVNRBA
         */

        public MinHeap(int capacity) : base(capacity)
        {
        }

        protected override void _HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = LeftChildIndex(index);
                if (HasRightChild(index) && LeftChild(index) > RightChild(index)) smallerChildIndex = RightChildIndex(index);

                if (_heap[index] < _heap[smallerChildIndex]) break;
                else
                {
                    Swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }

        protected override void _HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && Parent(index) > _heap[index])
            {
                Swap(ParentIndex(index), index);
                index = ParentIndex(index);
            }
        }
    }
}
