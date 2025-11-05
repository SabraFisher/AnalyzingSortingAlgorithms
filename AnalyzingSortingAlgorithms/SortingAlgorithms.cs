using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzingSortingAlgorithms
{
    public class SortingAlgorithms
    {
        public int[] BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap array[j] and array[j+1]
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        public int[] InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;
                // Move elements of array[0..i-1], that are greater than key,
                // to one position ahead of their current position
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
            return array;
        }

        public int[] SelectionSort(int[] array)
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

        public int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;
            int mid = array.Length / 2;
            int[] left = array.Take(mid).ToArray();
            int[] right = array.Skip(mid).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }

        private int[] Merge(int[] left, int[] right)
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

        public int[] QuickSort(int[] array)
        {
            return QuickSortHelper(array, 0, array.Length - 1);
        }   

        private int[] QuickSortHelper(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSortHelper(array, low, pi - 1);
                QuickSortHelper(array, pi + 1, high);
            }
            return array;
        }

        private int Partition(int[] array, int low, int high)
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


    }
}
