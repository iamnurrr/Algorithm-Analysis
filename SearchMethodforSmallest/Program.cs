using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Farklı dizi boyutları için test edeceğiz
        int[] sizes = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };
        int k = 10; // k. en küçük elemanı bulacağız

        foreach (var size in sizes)
        {
            Console.WriteLine($"Dizi Boyutu: {size}");

            // Rastgele dizi oluşturma
            var random = new Random();
            int[] array = Enumerable.Range(0, size).Select(x => random.Next(1, 10000)).ToArray();

            // Yöntem 1: Sıralama ile k. en küçük elemanı bulma
            var sw1 = Stopwatch.StartNew();
            int kthSmallestSorted = FindKthSmallestSorted(array, k);
            sw1.Stop();
            Console.WriteLine($"Yöntem 1 (Sıralama): {sw1.Elapsed.TotalMilliseconds} ms");

            // Yöntem 2: Partial Sort (k elemanı sıralama ve insertion sort)
            var sw2 = Stopwatch.StartNew();
            int kthSmallestPartialSort = FindKthSmallestPartialSort(array, k);
            sw2.Stop();
            Console.WriteLine($"Yöntem 2 (Partial Sort): {sw2.Elapsed.TotalMilliseconds} ms");

            Console.WriteLine();
        }
    }

    static int FindKthSmallestSorted(int[] array, int k)
    {
        // Diziyi sırala
        Array.Sort(array);
        return array[k - 1];
    }

    static int FindKthSmallestPartialSort(int[] array, int k)
    {
        // İlk k elemanı sırala
        Array.Sort(array, 0, k);

        // Kalan elemanları insertion sort mantığı ile karşılaştır
        for (int i = k; i < array.Length; i++)
        {
            if (array[i] < array[k - 1])
            {
                // Yer değiştir
                int temp = array[i];
                array[i] = array[k - 1];
                array[k - 1] = temp;

                // İlk k elemanı yeniden sırala
                Array.Sort(array, 0, k);
            }
        }

        return array[k - 1];
    }
}
