using System;

namespace QuickSortConsole
{
    public class Program
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    Switch(array, i, storeIndex);
                    storeIndex++;
                }

            Switch(array, storeIndex, end);
            if (storeIndex > start) QuickSort(array, start, storeIndex - 1);
            if (storeIndex < end) QuickSort(array, storeIndex + 1, end);
        }

        public static void Switch(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void QuickSort(int[] array)
        {
            if (array.Length > 1)
            {
                QuickSort(array, 0, array.Length - 1);
            }
        }

        public static int[] GenerateArray(int length)
        {
            Random random = new Random();
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(1, 10);
            return array;
        }

        public static void Main()
        {
            var array = GenerateArray(10);
            QuickSort(array);
            foreach (var e in array)
                Console.WriteLine(e);
        }
    }
}
