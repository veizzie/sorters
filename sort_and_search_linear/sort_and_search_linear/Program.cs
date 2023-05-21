using System;

class Program
{
    static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }

        return array;
    }

    static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, right);
        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static int LinearSearch(int[] array, int key)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == key)
            {
                return i;
            }
        }

        return -1;
    }

    static int CountOccurrences(int[] array, int key, int keyIndex)
    {
        int count = 1;

        int leftIndex = keyIndex - 1;
        while (leftIndex >= 0 && array[leftIndex] == key)
        {
            count++;
            leftIndex--;
        }

        int rightIndex = keyIndex + 1;
        while (rightIndex < array.Length && array[rightIndex] == key)
        {
            count++;
            rightIndex++;
        }

        return count;
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int N = (int)(20 + 0.6 * 24);
        Console.WriteLine("Розмір масиву = {0}", N);

        int[] array = GenerateRandomArray(N, 10, 100);

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("Відсортований масив:");
        PrintArray(array);

        Console.Write("Введіть ключове значення: ");
        int key = int.Parse(Console.ReadLine());
        int keyIndex = LinearSearch(array, key);
        if (keyIndex != -1)
        {
            int count = CountOccurrences(array, key, keyIndex);
            Console.WriteLine($"Кількість входжень ключового значення {key} в масиві: {count}");
        }
        else
        {
            Console.WriteLine("Ключове значення не знайдено в масиві.");
        }
        Console.ReadLine();
    }
}
