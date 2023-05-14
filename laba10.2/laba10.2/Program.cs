using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] banknotes = GenerateRandomBanknotes(100);

            Console.WriteLine("Исходный массив:");
            PrintArray(banknotes);

            CountingSort(banknotes);

            Console.WriteLine("Отсортированный массив:");
            PrintArray(banknotes);
        }

        static int[] GenerateRandomBanknotes(int size)
        {
            int[] banknotes = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                int index = random.Next(7);
                int denomination;

                switch (index)
                {
                    case 0:
                        denomination = 1;
                        break;
                    case 1:
                        denomination = 2;
                        break;
                    case 2:
                        denomination = 5;
                        break;
                    case 3:
                        denomination = 10;
                        break;
                    case 4:
                        denomination = 20;
                        break;
                    case 5:
                        denomination = 50;
                        break;
                    default:
                        denomination = 100;
                        break;
                }

                banknotes[i] = denomination;
            }

            return banknotes;
        }

        static void CountingSort(int[] arr)
        {
            int max = GetMaxValue(arr);
            int[] counts = new int[max + 1];
            int[] sortedArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                counts[arr[i]]++;
            }

            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                sortedArr[counts[arr[i]] - 1] = arr[i];
                counts[arr[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedArr[i];
            }
        }

        static int GetMaxValue(int[] arr)
        {
            int max = int.MinValue;

            foreach (int num in arr)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }


    }
}
