using System;
using System.Diagnostics;

namespace BinairZoeken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Maak een array met 10.000 willekeurige getallen
            int[] getallen = new int[10000];
            Random random = new Random();

            for (int i = 0; i < getallen.Length; i++)
            {
                getallen[i] = random.Next(1, 100001);
            }

            // 2. Sorteer de array van laag naar hoog (VERPLICHT voor binair zoeken!)
            Array.Sort(getallen);

            // 3. Vraag aan de gebruiker welk getal gezocht moet worden
            Console.WriteLine("Welk getal wil je zoeken in de gesorteerde array (tussen 1 en 100000)?");
            int target = Convert.ToInt32(Console.ReadLine());

            // 4. Start de timer en voer het binair zoeken uit
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bool gevonden = BinarySearch(getallen, target, 0, getallen.Length - 1);

            stopwatch.Stop();

            // 5. Resultaat tonen op het scherm
            Console.WriteLine("\n--- RESULTAAT BINAIR ZOEKEN ---");
            Console.WriteLine("Is het getal " + target + " gevonden? " + gevonden);
            Console.WriteLine("Looptijd (runtime): " + stopwatch.Elapsed.TotalMilliseconds + " ms");

            // Scherm openhouden tot je op Enter drukt
            Console.WriteLine("\nDruk op enter om af te sluiten...");
            Console.ReadLine();
        }

        // Rekursieve functie voor binair zoeken exact volgens de pseudocode
        static bool BinarySearch(int[] array, int target, int low, int high)
        {
            if (low > high)
            {
                return false;
            }

            int mid = (low + high) / 2;

            if (array[mid] == target)
            {
                return true;
            }
            else if (array[mid] > target)
            {
                return BinarySearch(array, target, low, mid - 1);
            }
            else
            {
                return BinarySearch(array, target, mid + 1, high);
            }
        }
    }

}