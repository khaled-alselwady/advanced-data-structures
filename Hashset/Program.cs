using System;
using System.Collections.Generic;
using System.Linq;


internal class Program
{
    static void WorkingWithHashSet()
    {
        // HashSet ensures uniqueness but don't maintain the same order

        HashSet<string> Fruit = new HashSet<string>
        {
            // Adding elements to the HashSet
            "Apple",
            "Banana",
            "Cherry"
        };

        // Trying to add a duplicate element
        Fruit.Add("Apple"); // This will not be added
        Fruit.Add("Apple"); // This will not be added
        Fruit.Add("Apple"); // This will not be added


        // Displaying the elements in the HashSet
        foreach (string fruit in Fruit)
        {
            Console.WriteLine(fruit);
        }


        if (Fruit.Contains("Apple"))
            Console.WriteLine("Apple is found");
        else
            Console.WriteLine("Apple is not found");

        if (Fruit.Contains("apple")) // support case-sensitive
            Console.WriteLine("apple is found");
        else
            Console.WriteLine("apple is not found");


        Fruit.Remove("Banana"); // support case-sensitive

        // Displaying the elements in the HashSet
        Console.WriteLine("Displaying the elements after deleting Banana: ");
        foreach (string fruit in Fruit)
        {
            Console.WriteLine(fruit);
        }

        Fruit.Clear();
    }

    static int[] RemovingDuplicateNumbersFromArray(int[] Numbers)
    {
        HashSet<int> UniqueNumbers = new HashSet<int>(Numbers);

        return UniqueNumbers.ToArray();
    }

    static void LinqWithHashSet()
    {
        HashSet<int> Numbers = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var EvenNumbers = Numbers.Where(Number => Number % 2 == 0);

        Console.WriteLine("Even Numbers: ");
        foreach (int EvenNumber in EvenNumbers)
        {
            Console.WriteLine(EvenNumber);
        }


        var NumbersGreaterThanFive = Numbers.Where(Number => Number > 5);

        Console.WriteLine("Numbers Greater than Five");
        foreach (int Number in NumbersGreaterThanFive)
        {
            Console.WriteLine(Number);
        }


        // Creating and populating a HashSet of strings
        HashSet<string> Names = new HashSet<string> { "Alice", "Bob", "Charlie", "Daisy", "Ethan", "Fiona" };

        var NamesStartWith_C = Names.Where(Name => Name.StartsWith("c"));

        foreach (string Name in NamesStartWith_C)
        {
            Console.WriteLine(Name);
        }

        var NamesLongerThenFourLength = Names.Where(Name => Name.Length > 4);

        foreach (string Name in NamesLongerThenFourLength)
        {
            Console.WriteLine(Name);
        }
    }

    static void SetOperationsInHashSet()
    {
        #region  Union Operation

        HashSet<int> UnionSet1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> UnionSet2 = new HashSet<int> { 3, 4, 5 };

        UnionSet1.UnionWith(UnionSet2);

        Console.WriteLine("Union Numbers of Sets");
        foreach (int Number in UnionSet1)
        {
            Console.WriteLine(Number);
        }

        HashSet<string> UnionSet3 = new HashSet<string> { "aa", "bb", "cc" };
        HashSet<string> UnionSet4 = new HashSet<string> { "AA", "dd", "ff" };

        UnionSet3.UnionWith(UnionSet4); // not supposed the case-sensitive
        Console.WriteLine("Union String of Sets");
        foreach (string Word in UnionSet3)
        {
            Console.WriteLine(Word);
        }
        #endregion

        #region Intersection Operation

        HashSet<int> IntersectionSet1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> IntersectionSet2 = new HashSet<int> { 3, 4, 5 };

        IntersectionSet1.IntersectWith(IntersectionSet2);

        Console.WriteLine("\nIntersection Numbers: ");
        foreach (int Number in IntersectionSet1)
        {
            Console.WriteLine(Number);
        }

        HashSet<string> IntersectionSet3 = new HashSet<string> { "aa", "bb", "cc" };
        HashSet<string> IntersectionSet4 = new HashSet<string> { "AA", "dd", "ff" };

        IntersectionSet3.IntersectWith(IntersectionSet4);

        Console.WriteLine("Intersection String: ");
        foreach (string Number in IntersectionSet3)
        {
            Console.WriteLine(Number);
        }


        #endregion

        #region Difference Operation

        HashSet<int> DifferenceSet1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> DifferenceSet2 = new HashSet<int> { 3, 4, 5 };

        DifferenceSet1.ExceptWith(DifferenceSet2);

        Console.WriteLine("\nDifference Numbers: ");
        foreach (int Number in DifferenceSet1)
        {
            Console.WriteLine(Number);
        }

        HashSet<string> DifferenceSet3 = new HashSet<string> { "aa", "bb", "cc" };
        HashSet<string> DifferenceSet4 = new HashSet<string> { "AA", "dd", "ff" };

        DifferenceSet3.ExceptWith(DifferenceSet4);

        Console.WriteLine("Difference String: ");
        foreach (string Word in DifferenceSet3)
        {
            Console.WriteLine(Word);
        }


        #endregion

        #region Symmetric Difference Operation

        HashSet<int> SymmetricSet1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> SymmetricSet2 = new HashSet<int> { 3, 4, 5 };

        SymmetricSet1.SymmetricExceptWith(SymmetricSet2); // SymmetricExcept removes any duplicate item from both sets but union still keeps the duplicate item and remove it from one set not both

        Console.WriteLine("\nSymmetric Numbers: ");
        foreach (int Number in SymmetricSet1)
        {
            Console.WriteLine(Number);
        }

        HashSet<string> SymmetricSet3 = new HashSet<string> { "aa", "bb", "cc" };
        HashSet<string> SymmetricSet4 = new HashSet<string> { "AA", "dd", "ff" };

        SymmetricSet3.SymmetricExceptWith(SymmetricSet4);

        Console.WriteLine("Symmetric String: ");
        foreach (string Word in SymmetricSet3)
        {
            Console.WriteLine(Word);
        }


        #endregion
    }

    static void ComparingSetInHashSet()
    {
        // all of these methods do not matter about the order of elements

        #region SetEquals
        HashSet<int> EqualSet1 = new HashSet<int> { 1, 3, 2 };
        HashSet<int> EqualSet2 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> EqualSet3 = new HashSet<int> { 4, 2, 3 };

        Console.WriteLine("Is Set1 Equals Set2? {0}", EqualSet1.SetEquals(EqualSet2)); // True because the order does not matter
        Console.WriteLine("Is Set1 Equals Set3? {0}", EqualSet1.SetEquals(EqualSet3));

        HashSet<string> EqualSet4 = new HashSet<string> { "aa", "bb", "cc" };
        HashSet<string> EqualSet5 = new HashSet<string> { "aa", "bb", "cc" };
        HashSet<string> EqualSet6 = new HashSet<string> { "aa", "bb", "Cc" };

        Console.WriteLine("Is Set4 Equals Set5? {0}", EqualSet4.SetEquals(EqualSet5));
        Console.WriteLine("Is Set4 Equals Set6? {0}", EqualSet4.SetEquals(EqualSet6));
        #endregion

        #region IsSubset
        HashSet<int> SubsetSet1 = new HashSet<int> { 1, 3, 2 };
        HashSet<int> SubsetSet2 = new HashSet<int> { 1, 2, 3, 4 };

        Console.WriteLine("Is Set1 Subset of Set2? {0}", SubsetSet1.IsSubsetOf(SubsetSet2));
        Console.WriteLine("Is Set2 Subset of Set1? {0}", SubsetSet2.IsSubsetOf(SubsetSet1));

        HashSet<string> SubsetSet3 = new HashSet<string> { "aa", "cc", "bb" };
        HashSet<string> SubsetSet4 = new HashSet<string> { "aa", "bb", "cc", "ll" };

        Console.WriteLine("Is Set3 Subset of Set4? {0}", SubsetSet3.IsSubsetOf(SubsetSet4));
        Console.WriteLine("Is Set4 Subset of Set3? {0}", SubsetSet4.IsSubsetOf(SubsetSet3));
        #endregion

        #region IsSupersetOf
        HashSet<int> SuperSet1 = new HashSet<int> { 1, 3, 2 };
        HashSet<int> SuperSet2 = new HashSet<int> { 1, 2, 3, 4 };

        Console.WriteLine("Is Set1 Superset of Set2? {0}", SuperSet1.IsSupersetOf(SuperSet2));
        Console.WriteLine("Is Set2 Superset of Set1? {0}", SuperSet2.IsSupersetOf(SuperSet1));

        HashSet<string> SuperSet3 = new HashSet<string> { "aa", "cc", "bb" };
        HashSet<string> SuperSet4 = new HashSet<string> { "aa", "bb", "cc", "ll" };

        Console.WriteLine("Is Set3 Superset of Set4? {0}", SuperSet3.IsSupersetOf(SuperSet4));
        Console.WriteLine("Is Set4 Superset of Set3? {0}", SuperSet4.IsSupersetOf(SuperSet3));
        #endregion

        #region Overlaps
        HashSet<int> OverlapsSet1 = new HashSet<int> { 8, 9, 5 };
        HashSet<int> OverlapsSet2 = new HashSet<int> { 1, 2, 3, 4 };

        Console.WriteLine("Is Set1 Overlaps Set2? {0}", OverlapsSet1.Overlaps(OverlapsSet2));

        HashSet<string> OverlapsSet3 = new HashSet<string> { "aa", "xx", "vv" };
        HashSet<string> OverlapsSet4 = new HashSet<string> { "aa", "bb", "cc", "ll" };

        Console.WriteLine("Is Set3 Overlaps Set4? {0}", OverlapsSet3.Overlaps(OverlapsSet4));
        #endregion
    }

    static void Main(string[] args)
    {
        // WorkingWithHashSet();

        //int[] DuplicatedNumbers = { 1, 2, 3, 1, 2, 4 };

        //int[] UniqueNumbers = RemovingDuplicateNumbersFromArray(DuplicatedNumbers);

        //foreach (int Number in UniqueNumbers)
        //{
        //    Console.WriteLine(Number);
        //}

        //LinqWithHashSet();
        //SetOperationsInHashSet();
        ComparingSetInHashSet();

        Console.ReadKey();

    }
}

