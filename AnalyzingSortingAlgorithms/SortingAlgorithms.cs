using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnalyzingSortingAlgorithms
{
    public static class SortingAlgorithms
    {
        public static int[] BubbleSort(int[] array, int n) // Not great for large dat sets
        //Simplest. Reapeatedly swaps the adjacent elements if they are in the wrong order.
        {
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap array[j] and array[j+1]
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                //If no two elements were swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIdx])
                    {
                        minIdx = j;
                    }
                }
                // Swap the found minimum element with the first element
                int temp = array[minIdx];
                array[minIdx] = array[i];
                array[i] = temp;
            }
            return array;
        }

        // Efficient divide and conquer approach. Recursively divides array into halves,
        // recursively sorting the two halves and finally merging them into one sorted array.
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;
            int mid = array.Length / 2;
            int[] left = array.Take(mid).ToArray();
            int[] right = array.Skip(mid).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }
            while (i < left.Length)
            {
                result[k++] = left[i++];
            }
            while (j < right.Length)
            {
                result[k++] = right[j++];
            }
            return result;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSortHelper(array, 0, array.Length - 1);
        }   

        private static int[] QuickSortHelper(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSortHelper(array, low, pi - 1);
                QuickSortHelper(array, pi + 1, high);
            }
            return array;
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    // Swap array[i] and array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            // Swap array[i + 1] and array[high] (or pivot)
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;
            return i + 1;
        }

        //Move from unsorted section to correct place in sorted section. 
        public static int[] InsertionSort(int[] array, int n)
        {
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;

                //  Move elements of arr[0,1,2,.., i-1], that are greater than key
                //    to one position ahead of their current position
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
            return array;
        }

    }
}
