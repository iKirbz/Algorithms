using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate sorted int array
            int length = 1000000;
            int[] array = GetIntArray(length);

            Console.WriteLine($"Generating array with {length} values..." + "\n");

            // get random value form array
            Random rnd = new Random();
            int value = array[rnd.Next(array.Length)];

            Console.WriteLine($"Searching for {value}:" + "\n");

            // binary search
            Console.WriteLine(" --- Binary Search --- ");
            TimeSearch(BinarySearch, array, value);

            // normal search
            Console.WriteLine(" --- Normal Search --- ");
            TimeSearch(NormalSearch, array, value);

            Console.ReadLine();
        }

        private static int[] GetIntArray(int length)
        {
            Random rnd = new Random();

            int[] array = new int[length];

            int number = 0;

            for (int i = 0; i < length; i++)
            {
                number += rnd.Next(1, 10);

                array[i] = number;
            }

            return array;
        }

        private static void TimeSearch(Func<int[], int, int> SearchMethod, int[] array, int value)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            int index = SearchMethod(array, value);
            timer.Stop();

            // display time elapsed

            Console.WriteLine($"Index found: {index}");

            string microseconds = (timer.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L))).ToString("D4");
            Console.WriteLine($"Time elapsed: {microseconds} microseconds" + "\n");
        }

        private static int BinarySearch(int[] array, int value)
        {
            int middle;

            int min = 0;
            int max = array.Length - 1;

            while(min <= max)
            {
                middle = (min + max) / 2;

                if (array[middle] == value)
                {
                    return middle;

                }
                else if (array[middle] > value)
                {
                    max = middle-1;
                }
                else
                {
                    min = middle+1;
                }
            }

            return -1;
        }

        private static int NormalSearch(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
