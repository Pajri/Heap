using Heap.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        /*
         * Implementation of heap data structure to track median value
         * This code is created based on video from hackerrank : https://www.youtube.com/watch?v=VmogG01IjYc
         */
        static void Main(string[] args)
        {
            int[] input = new int[]{ 1, 3, 2, 4, 6, 7, 8, 5, 9, 0 };
            MinHeap minHeap = new MinHeap(input.Length);
            MaxHeap maxHeap = new MaxHeap(input.Length);
            double[] median = new double[input.Length];

            int i = 0;
            foreach (int val in input)
            {
                _AddNumber(val, minHeap, maxHeap);
                _Rebalance(minHeap, maxHeap);
                double medianVal = _GetMedian(minHeap, maxHeap);
                median[i++] = medianVal;
            }

            Console.WriteLine(string.Join("\n", median));
            Console.ReadLine();
        }

        private static double _GetMedian(MinHeap minHeap, MaxHeap maxHeap)
        {
            if(minHeap.Size > maxHeap.Size)
            {
                return (double)minHeap.Peek();
            }else if(minHeap.Size < maxHeap.Size)
            {
                return (double)maxHeap.Peek();
            }
            else
            {
                return (double) (maxHeap.Peek() + minHeap.Peek()) / 2;
            }
        }

        private static void _Rebalance(MinHeap minHeap, MaxHeap maxHeap)
        {
            if(Math.Abs(minHeap.Size - maxHeap.Size) >= 2)
            {
                if(maxHeap.Size > minHeap.Size)
                {
                    int rootMaxHeap = (int)maxHeap.Poll();
                    minHeap.Add(rootMaxHeap);
                }
                else
                {
                    int rootMinHeap = (int)minHeap.Poll();
                    maxHeap.Add(rootMinHeap);
                }
            }
        }

        private static void _AddNumber(int val, MinHeap minHeap, MaxHeap maxHeap)
        {
            if (maxHeap.Size == 0 || val < maxHeap.Peek()) maxHeap.Add(val);
            else minHeap.Add(val);
        }
    }
}
