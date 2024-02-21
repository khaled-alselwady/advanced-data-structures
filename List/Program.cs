using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace List
{
    internal class Program
    {
        static void InsertingElementsIntoAList()
        {
            // List initialization
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Adding an element at the end
            Numbers.Add(11);
            Console.WriteLine("Elements After add 11: {0}", string.Join(", ", Numbers));

            // Inserting an element at a specific position
            Numbers.Insert(0, 0);
            Console.WriteLine("Elements After insert 0 at index 0 : {0}", string.Join(", ", Numbers));

            // Inserting multiple elements
            Numbers.InsertRange(5, new List<int> { 55, 56 });
            Console.WriteLine("Elements After insert range {{55, 65}} at index 5 : {0}", string.Join(", ", Numbers));
        }

        static void RemoveItemsFromAList()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, -7, -8, 9, 10 };

            Numbers.Remove(5);
            Console.WriteLine("After Removing 5 : {0}", string.Join(", ", Numbers));

            Numbers.RemoveAt(0);
            Console.WriteLine("After Removing at index 0 : {0}", string.Join(", ", Numbers));

            Numbers.RemoveRange(1, 2);
            Console.WriteLine("After Removing multiple elements : {0}", string.Join(", ", Numbers));

            Numbers.RemoveAll(n => (n < 0));
            Console.WriteLine("After removing all even numbers: " + string.Join(", ", Numbers));

            Numbers.Clear();
            Console.WriteLine("Count = " + Numbers.Count);
        }

        static void LoopingThroughAList()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Using For Loop");
            for (int i = 0; i < Numbers.Count; i++)
            {
                Console.WriteLine(Numbers[i]);
            }

            Console.WriteLine("Using Foreach");
            foreach (int Number in Numbers)
            {
                Console.WriteLine(Number);
            }

            Console.WriteLine("Using Built-in ForEach");
            Numbers.ForEach(Console.WriteLine);


            Console.WriteLine("another example Using Built-in ForEach");
            Numbers.ForEach(n =>
                    {
                        Console.WriteLine();

                        if (n % 2 == 0)
                            Console.WriteLine(n + " is Even");
                        else
                            Console.WriteLine(n + " is Odd");
                    });
        }

        static void AggregatingDataUsingLINQWithList()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Sum " + Numbers.Sum());
            Console.WriteLine("Avg " + Numbers.Average());
            Console.WriteLine("Max " + Numbers.Max());
            Console.WriteLine("Min " + Numbers.Min());
            Console.WriteLine("Count " + Numbers.Count());
        }

        static void FilteringDataUsingLINQWithList()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Even Numbers: " + string.Join(", ", Numbers.Where(element => element % 2 == 0)));
            Console.WriteLine("Odd Numbers: " + string.Join(", ", Numbers.Where(element => element % 2 != 0)));
            Console.WriteLine("Greater than 5: " + string.Join(", ", Numbers.Where(element => element > 5)));
            Console.WriteLine("Every Sconed Number: " + string.Join(", ", Numbers.Where((element, index) => index % 2 == 1))); // (element, index) : in `Where`, we have two overloadings, the first one takes one parameter (element) and the second takes two parameters (element, its index)
            Console.WriteLine("Number between 3 and 8: " + string.Join(", ", Numbers.Where(element => element > 3 && element < 8)));
        }

        static void SortingAList()
        {
            List<int> Numbers = new List<int> { 44, 22, 55, 666, 9, -6, 345, 11, 3, 3 };

            // Default Sorting (Ascending)
            Numbers.Sort();
            Console.WriteLine("Sorted in Ascending Order: " + string.Join(", ", Numbers));

            // Sorting in Descending Order
            Numbers.Reverse();
            Console.WriteLine("Sorted in Descending Order: " + string.Join(", ", Numbers));

            // Sorting with LINQ (More optimize that sort & reverse)
            Console.WriteLine("Sorted Ascending with LINQ: " + string.Join(", ", Numbers.OrderBy(n => n)));
            Console.WriteLine("Sorted Descending with LINQ: " + string.Join(", ", Numbers.OrderByDescending(n => n)));

            Numbers.Sort((a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));
            Console.WriteLine("Sorted by Absolute Values: " + string.Join(", ", Numbers));
        }

        static void Exploring_Contains_Exists_Find_FindAll_Any_Int()
        {
            // List initialization  
            List<int> Numbers = new List<int> { 44, 22, 55, 666, 9, -6, 345, -11, 3, 3 };


            // Using Contains
            Console.WriteLine("List contains 9: " + Numbers.Contains(9));


            // Using Exists (Exists is better than any in case dealing with `List`)
            Console.WriteLine("List contains negative numbers: " + Numbers.Exists(n => n < 0));


            // Using Find
            Console.WriteLine("First negative number: " + Numbers.Find(n => n < 0));


            // Using FindAll
            Console.WriteLine("All negative numbers: " + string.Join(", ", Numbers.FindAll(n => n < 0)));


            // Using Any
            // if don't pass any parameter, it check if the list is empty or not.
            Console.WriteLine("Is List Empty: " + Numbers.Any());
            // here it is the same as Exists() but it worse than it
            Console.WriteLine("Any numbers greater than 100: " + Numbers.Any(n => n > 100));
        }

        static bool IsVowel(char Letter) => "aueioAUEIO".Contains(Letter);

        static bool DoesContainVowel(string Word) => Word.Any(Letter => IsVowel(Letter));

        static int CountVowelLetters(string Word) => Word.Count(Letter => IsVowel(Letter));

        static void Exploring_Contains_Exists_Find_FindAll_Any_String()
        {
            // List initialization  
            List<string> Texts = new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew" };

            // sorted by the length of each item
            Console.WriteLine("All negative numbers: " + Texts.OrderByDescending(word => word.Length).First());

            // Using Contains
            Console.WriteLine("List contains 9: " + Texts.Contains(""));


            // Using Exists (Exists is better than any in case dealing with `List`)
            Console.WriteLine("List contains negative numbers: " + Texts.Exists(n => n == "Khaled"));


            // Using Find
            Console.WriteLine("First negative number: " + Texts.Find(n => n == "M"));


            // Using FindAll to return all the words that does not contain any vowel
            Console.WriteLine("All negative numbers: " + string.Join(", ", Texts.FindAll(n => !DoesContainVowel(n))));

            // Using FindAll to return all the words that have more than two vowels
            Console.WriteLine("All negative numbers: " + string.Join(", ", Texts.FindAll(n => CountVowelLetters(n) == 2)));


            // Using Any
            // if don't pass any parameter, it check if the list is empty or not.
            Console.WriteLine("Any numbers greater than 100: " + Texts.Any());
            // here it is the same as Exists() but it worse than it
            Console.WriteLine("Any numbers greater than 100: " + Texts.Any(n => n == "Khaled"));
        }

        static void Main(string[] args)
        {
            //InsertingElementsIntoAList();
            //RemoveItemsFromAList();
            //LoopingThroughAList();
            //AggregatingDataUsingLINQWithList();
            //FilteringDataUsingLINQWithList();
            //SortingAList();
            //Exploring_Contains_Exists_Find_FindAll_Any_Int();
            Exploring_Contains_Exists_Find_FindAll_Any_String();

            Console.ReadKey();
        }
    }
}
