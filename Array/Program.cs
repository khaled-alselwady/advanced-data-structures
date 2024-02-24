using System;
using System.Linq;

internal class Program
{
    private static void LinqWithArray()
    {
        // Array of numbers
        int[] Numbers = { 1, 2, 3, 4, 5 };


        // Using LINQ to filter and transform data
        var EvenNumbers = Numbers.Where(n => n % 2 == 0);


        // Displaying results
        Console.WriteLine("Squares of even numbers:");
        foreach (var num in EvenNumbers)
        {
            Console.WriteLine(num);
        }
    }

    private static void CopyingArray()
    {
        // Original array
        int[] original = { 1, 2, 3, 4, 5 };


        // Array to hold the copy
        int[] copy = new int[5];


        // Copying array
        Array.Copy(original, copy, original.Length);


        // Displaying the copied array
        Console.WriteLine("Copied Array:");
        foreach (int element in copy)
        {
            Console.WriteLine(element);
        }
    }

    private static void SortingArrayAndFindSpecificIndex()
    {
        // Initializing an array
        int[] numbers = { 5, 3, 1, 4, 4, 2 };


        // Sorting the array
        Array.Sort(numbers);


        // Display the sorted array
        Console.WriteLine("Sorted array:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }


        // Searching for an element, this will return the index for the element you searched for.
        int index = Array.IndexOf(numbers, 4);
        Console.WriteLine("\nIndex of 4: " + index);

        int LastIndex = Array.LastIndexOf(numbers, 4);
        Console.WriteLine("\nLast Index of 4: " + LastIndex);
    }

    private static void AdvancedLinqWithArray()
    {
        // Array of people with Name and Age
        var people = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 },
            new { Name = "Charlie", Age = 35 },
            new { Name = "Diana", Age = 30 },
            new { Name = "Ethan", Age = 25 }
        };


        // Grouping people by Age, then ordering within each group
        var groupedByAge = people.GroupBy(p => p.Age)
                                 .Select(group => new
                                 {
                                     Age = group.Key,
                                     People = group.OrderBy(p => p.Name)
                                 });


        // Displaying the results
        foreach (var group in groupedByAge)
        {
            Console.WriteLine($"Age Group: {group.Age}");
            foreach (var person in group.People)
            {
                Console.WriteLine($" - {person.Name}");
            }
        }
    }

    private static void FilteringAndAggregationOnArray()
    {
        // Array of numbers
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        // Filtering to get only even numbers
        var evenNumbers = numbers.Where(n => n % 2 == 0);


        // Aggregating - calculating the sum of even numbers
        int sumOfEvenNumbers = evenNumbers.Sum();


        // Displaying the results
        Console.WriteLine("Even Numbers:");
        foreach (var num in evenNumbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine($"\nSum of Even Numbers: {sumOfEvenNumbers}");
    }

    private static void JoiningAndProjection()
    {
        // Array of employees
        var employees = new[]
        {
            new { Id = 1, Name = "Alice", DepartmentId = 2 },
            new { Id = 2, Name = "Bob", DepartmentId = 1 }
        };


        // Array of departments
        var departments = new[]
        {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" }
        };


        // Joining employees with departments and projecting the result
        var employeeDetails = employees.Join(departments,
                                             e => e.DepartmentId,
                                             d => d.Id,
                                             (e, d) => new { e.Name, Department = d.Name });


        // Displaying the results
        foreach (var detail in employeeDetails)
        {
            Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department}");
        }
    }

    static void Main(string[] args)
    {
        //SortingArrayAndFindSpecificIndex();

        //CopyingArray();

        //LinqWithArray();

        //AdvancedLinqWithArray();

        //FilteringAndAggregationOnArray();

        JoiningAndProjection();

        Console.ReadKey();
    }
}

