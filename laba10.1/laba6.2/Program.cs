using System;
using System.Diagnostics;
using System.IO;

namespace SortingAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr1 = generateRandomArray();
            
            compareSelectionSort(arr1);
            compareInsertionSort(arr1);
            compareBubbleSort(arr1);
            
        }

        static void compareSelectionSort(int[] arr1)
        {
            int[] arr2 = sortArray(arr1, true);
            int[] arr3 = sortArray(arr1, false);

            Stopwatch stopwatch = new Stopwatch();

            using (StreamWriter writer = new StreamWriter("./sorted.dat"))
            {

                // Сортировка слиянием
                Console.WriteLine("Сортировка слиянием:");
                writer.WriteLine("Сортировка слиянием:");

                stopwatch.Restart();
                MergeSortDescending(arr1);
                stopwatch.Stop();
                checkSorted(arr1);
                Console.WriteLine($"Рандомный массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine($"Рандомный массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");

                stopwatch.Restart();
                MergeSortDescending(arr2);
                stopwatch.Stop();
                Console.WriteLine($"Возрастающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine($"Возрастающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");

                stopwatch.Restart();
                MergeSortDescending(arr3);
                stopwatch.Stop();
                Console.WriteLine($"Убывающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine($"Убывающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
            }

        }

        static void compareInsertionSort(int[] arr1)
        {
            int[] arr2 = sortArray(arr1, true);
            int[] arr3 = sortArray(arr1, false);

            Stopwatch stopwatch = new Stopwatch();

            using (StreamWriter writer = new StreamWriter("./sorted.dat", true))
            {
                // Сортировка пирамидальная
                Console.WriteLine("\nСортировка пирамидальная:");
                writer.WriteLine("\nСортировка пирамидальная:");


                stopwatch.Restart();
                HeapSortDescending(arr1);
                checkSorted(arr1);
                stopwatch.Stop();
                Console.WriteLine(
                    $"Рандомный массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine(
                    $"Рандомный массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");


                stopwatch.Restart();
                HeapSortDescending(arr2);
                stopwatch.Stop();
                Console.WriteLine(
                    $"Возрастающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine(
                    $"Возрастающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");


                stopwatch.Restart();
                HeapSortDescending(arr3);
                stopwatch.Stop();
                Console.WriteLine(
                    $"Убывающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine(
                    $"Убывающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
            }

        }
        
        static void compareBubbleSort(int[] arr1)
        {
            int[] arr2 = sortArray(arr1, true);
            int[] arr3 = sortArray(arr1, false);

            Stopwatch stopwatch = new Stopwatch();

            using (StreamWriter writer = new StreamWriter("./sorted.dat", true))
            {
                // Сортировка быстрая
                Console.WriteLine("\nСортировка быстрая:");
                writer.WriteLine("\nСортировка быстрая:");


                stopwatch.Restart();
                QuickSortDescending(arr1, 0, arr1.Length - 1);
                checkSorted(arr1);
                stopwatch.Stop();
                Console.WriteLine(
                    $"Рандомный массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine(
                    $"Рандомный массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");


                stopwatch.Restart();
                QuickSortDescending(arr2, 0, arr2.Length - 1);
                stopwatch.Stop();
                Console.WriteLine(
                    $"Возрастающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine(
                    $"Возрастающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");


                stopwatch.Restart();
                QuickSortDescending(arr3, 0, arr3.Length - 1);
                stopwatch.Stop();
                Console.WriteLine(
                    $"Убывающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
                writer.WriteLine(
                    $"Убывающий массив: {stopwatch.Elapsed.Seconds}:{stopwatch.ElapsedMilliseconds % 1000} sec");
            }
        }

        public static int[] generateRandomArray()
        {
            Random random = new Random();

            int[] arr = new int[10000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next();
            }

            return arr;
        }

        public static int[] sortArray(int[] arr, bool state)
        {
            if (state)
            {
                int n = arr.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }

                return arr;
            } else if (!state)
            {
                int n = arr.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }

                return arr;
            }
            return null;
        }


        // слиянием
        static void MergeSortDescending(int[] arr)
        {
            if (arr.Length <= 1)
                return;

            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);

            MergeSortDescending(left);
            MergeSortDescending(right);

            MergeDescending(arr, left, right);
        }

        static void MergeDescending(int[] arr, int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] >= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }

                k++;
            }

            while (j < right.Length)
            {
                arr[k] = right[j];
                j++;
                k++;
            }

            while (i < left.Length)
            {
                arr[k] = left[i];
                i++;
                k++;
            }
        }


        //пирамидальная
        static void HeapSortDescending(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyDescending(arr, n, i);
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                HeapifyDescending(arr, i, 0);
            }
        }

        static void HeapifyDescending(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                HeapifyDescending(arr, n, largest);
            }
        }


        //быстрая
        static void QuickSortDescending(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = PartitionDescending(arr, low, high);

                QuickSortDescending(arr, low, pivotIndex - 1);
                QuickSortDescending(arr, pivotIndex + 1, high);
            }
        }

        static int PartitionDescending(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] > pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;

            return i + 1;
        }


        public static bool isSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        static void checkSorted(int[] array)
        {
            if (isSorted(array))
            {
                Console.WriteLine("Массив был успешно отсортирован.");
            }
            else
            {
                Console.WriteLine("Массив не был отсортирован.");
            }
        }
    }
}