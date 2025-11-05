using System.Diagnostics;

//  Merge Sort and Quick Sort have better time complexity compared to Bubble Sort and Insertion Sort for large datasets.
// Their performance in specific scenarios (small datasets, poor implementations, or nearly sorted data) can be less
// favorable due to constant factors and overhead. 

namespace AnalyzingSortingAlgorithms
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Console.WriteLine("Generating large random array...");
            stopwatch.Start(); 
            int[] largeArr = GenerateRandomArray(100000, 1, 1000);   // usage 100 thousand values
            stopwatch.Stop();
            DisplayRuntime(stopwatch);


            // Sort largeArr smallest to largest
            int[] smallToLarge = SortingAlgorithms.QuickSort(largeArr);

            // Sort largeArr largest to smallest
            int[] largeToSmall = smallToLarge.Reverse().ToArray();


            int[] nearlySortedArr = new int[100000];
            //start with a sorted array
            Array.Copy(smallToLarge, nearlySortedArr, 100000);
            //leave first 33000 elements sorted
            // reverse the next 33000 elements to create some disorder
            Array.Reverse(nearlySortedArr, 33000, 33000);
            //randomly swap elements in the last 66000 elements to create a nearly sorted array
            for (int i = 66000; i < 99000; i++)
            {
                int idx1 = new Random().Next(0, nearlySortedArr.Length);
                int idx2 = new Random().Next(0, nearlySortedArr.Length);
                // Swap elements at idx1 and idx2
                int temp = nearlySortedArr[idx1];
                nearlySortedArr[idx1] = nearlySortedArr[idx2];
                nearlySortedArr[idx2] = temp;
            }




            // Write your functions to test each sorting algorithm here
            Console.WriteLine("\nTesting on Randomized Array:\n");

            stopwatch.Start();  ///SECOND LONGEST
            Console.WriteLine("Algorithm: Quick Sort    ");
            SortingAlgorithms.QuickSort(largeArr);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();  ///// TAKES THE LONGEST
            Console.WriteLine("Algorithm: Merge Sort  ");
            SortingAlgorithms.MergeSort(largeArr);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Bubble Sort  ");
            SortingAlgorithms.BubbleSort(largeArr, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Insertion Sort  ");
            SortingAlgorithms.InsertionSort(largeArr, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            // Now test on sorted array small to large
            Console.WriteLine("\nTesting on Sorted Array (Small to Large):\n");
            stopwatch.Start();
            Console.WriteLine("Algorithm: Quick Sort    ");
            SortingAlgorithms.QuickSort(smallToLarge);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Merge Sort  ");
            SortingAlgorithms.MergeSort(smallToLarge);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Bubble Sort  ");
            SortingAlgorithms.BubbleSort(smallToLarge, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Insertion Sort  ");
            SortingAlgorithms.InsertionSort(smallToLarge, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            // Now test on nearly sorted array large to small
            Console.WriteLine("\nTesting on Sorted Array (Large to Small):\n");
            stopwatch.Start();
            Console.WriteLine("Algorithm: Quick Sort    ");
            SortingAlgorithms.QuickSort(largeToSmall);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Merge Sort  ");
            SortingAlgorithms.MergeSort(largeToSmall);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Bubble Sort  ");
            SortingAlgorithms.BubbleSort(largeToSmall, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Insertion Sort  ");
            SortingAlgorithms.InsertionSort(largeToSmall, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);


            // Now test on nearly sorted array
            Console.WriteLine("\nTesting on Nearly Sorted Array:\n");
            stopwatch.Start(); 
            Console.WriteLine("Algorithm: Quick Sort    ");
            SortingAlgorithms.QuickSort(nearlySortedArr);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();  
            Console.WriteLine("Algorithm: Merge Sort  ");
            SortingAlgorithms.MergeSort(nearlySortedArr);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Bubble Sort  ");
            SortingAlgorithms.BubbleSort(nearlySortedArr, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            stopwatch.Start();
            Console.WriteLine("Algorithm: Insertion Sort  ");
            SortingAlgorithms.InsertionSort(nearlySortedArr, 100000);
            stopwatch.Stop();
            DisplayRuntime(stopwatch);




            // function
            static int[] GenerateRandomArray(int length, int minValue, int maxValue)
            {
                Random rand = new Random();
                int[] array = new int[length];

                for (int i = 0; i < length; i++)
                {
                    array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
                }

                return array;
            }

            static void DisplayRuntime(Stopwatch stopwatch)
            {
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Time Taken: " + elapsedTime);
                stopwatch.Reset();
            }
        }
    }
}
