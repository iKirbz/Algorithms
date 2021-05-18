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
            int length = 500;
            int[] array = GetIntArray(length);

            Console.WriteLine("Generating array..." + "\n");
            Console.WriteLine(string.Join(", ", array));

            int value = array[250];

            Console.WriteLine($"Seraching for {value}");

            Stopwatch timer = new Stopwatch();

            timer.Start();
            int index = BinarySearch(array, value);
            timer.Stop();


            Console.WriteLine($"{timer.ElapsedMilliseconds} ms");
            Console.WriteLine(index);

            Console.ReadLine();
        }

        private static int[] GetIntArray(int length)
        {
            Random rnd = new Random();

            int[] array = new int[length];

            int lastNumber = 0;

            for (int i = 0; i < length; i++)
            {
                array[i] = lastNumber;

                lastNumber += rnd.Next(0, 10);
            }

            return array;
        }

        private static int BinarySearch(int[] array, int value)
        {
            int lastIndex = 0;
            int boundaryStart = (int)array.Length/2;
            int boundaryEnd = array.Length-1;

            while((boundaryEnd - boundaryStart) == 0)
            {
                if (array[lastIndex] == value)
                {
                    return lastIndex;
                }
                else if (array[lastIndex] > value)
                {
                    boundaryEnd = lastIndex;
                    lastIndex = (int)(boundaryEnd - boundaryStart);
                }
                else
                {
                    boundaryStart = lastIndex;
                    lastIndex = (int)(boundaryEnd - boundaryStart);
                }
            }

            return -1;
        }
    }
}
