using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] arrayLength = { 100, 500, 1000, 5000, 10000 };

        foreach (int length in arrayLength)
        {
            //CREATE RANDOM ARRAY 
            int[] array = createRandomArray(length);
            //RUN BUBBLE SORT AND MEASURE TİME
            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort(array);
            sw.Stop();
            // Print results
            Console.WriteLine($"Array Length: {length}, Time: {sw.ElapsedMilliseconds} ms");
        }
    }

    static int[] createRandomArray(int length)
    {
        Random random = new Random();
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(1,10000); 
        }
        return array;
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j <n-i-1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    //SWAP
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}