using System.Diagnostics;

namespace AnalyzingSortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            int[] largeArr = GenerateRandomArray(100000, 1, 1000);   // usage 100 thousand values
            stopwatch.Stop();
            DisplayRuntime(stopwatch);

            // Write your function to test each algorithm here



            // Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)


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
            }
        }
    }
}
