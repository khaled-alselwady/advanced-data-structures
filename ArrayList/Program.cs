using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    private static void WorkingWithHomogeneousArrayList()
    {
        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add(20);
        list.Add(30);


        Console.WriteLine("Elements in ArrayList:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }


        list.Remove(20); // Removing an element
        Console.WriteLine("After removing an element:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private static void WorkingWithHeterogeneousArrayList()
    {
        ArrayList list = new ArrayList(); // Creating an ArrayList
        list.Add(10); // Adding elements
        list.Add("Hello");
        list.Add(true);


        Console.WriteLine("Total elements in ArrayList: " + list.Count);


        Console.WriteLine("Content of ArrayList using index:");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine("Index " + i + ": " + list[i]);
        }
    }

    private static void FilteringArrayListWithLinq()
    {
        ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        //we use cast here to convert it to int first then we apply the filter.
        var evenNumbers = arrayList.Cast<int>().Where(num => num % 2 == 0);


        Console.WriteLine("All even numbers:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }

    private static void AggregateFunctionsInArrayListWithLinq()
    {
        ArrayList arrayList = new ArrayList { 10, 5, 20, 15, 30 };

        var CastArrayList = arrayList.Cast<int>();

        var minValue = CastArrayList.Min();
        var maxValue = CastArrayList.Max();
        var Sum = CastArrayList.Sum();
        var Average = CastArrayList.Average();
        var Count = CastArrayList.Count();

        Console.WriteLine("\nArrayList Items: ");
        for (int i = 0; i < arrayList.Count; i++)
        {
            Console.Write(arrayList[i].ToString() + " ");
        }

        Console.WriteLine("\n\nMinimum value in the ArrayList: " + minValue);
        Console.WriteLine("Maximum value in the ArrayList: " + maxValue);
        Console.WriteLine("Sum values in the ArrayList: " + Sum);
        Console.WriteLine("Average values in the ArrayList: " + Average);
        Console.WriteLine("Count Items in the ArrayList: " + Count);


        arrayList.Sort();
        Console.WriteLine("\nArrayList Items After Sorting: ");
        for (int i = 0; i < arrayList.Count; i++)
        {
            Console.Write(arrayList[i].ToString() + " ");
        }
    }

    private static void CountingOccurrencesOfSpecificElement()
    {
        ArrayList arrayList = new ArrayList { 1, 2, 3, 2, 4, 2, 5 };

        int targetNumber = 2;

        var count = arrayList.Cast<int>().Count(num => num == targetNumber);

        Console.WriteLine($"Number of occurrences of {targetNumber} in the ArrayList: {count}");
    }

    static void Main(string[] args)
    {
        // WorkingWithHomogeneousArrayList();

        //WorkingWithHeterogeneousArrayList();

        //FilteringArrayListWithLinq();

        //AggregateFunctionsInArrayListWithLinq();

        CountingOccurrencesOfSpecificElement();

        Console.ReadKey();
    }
}

