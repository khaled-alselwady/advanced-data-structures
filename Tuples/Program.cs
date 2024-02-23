using System;
using System.Collections.Generic;
using System.Linq;


internal class Program
{
    private static void WorkingWithTuple()
    {
        // Declare a tuple directly (it's more concise and easier to read)
        (int, string, double, bool) person = (1, "Alice", 5.5, true);

        // Declare a tuple directly with named elements
        (int ID, string Name, double Height) person2 = (ID: 1, Name: "Alice", Height: 5.5);

        // Declare a tuple using  Tuple Class
        Tuple<int, string, double> person3 = new Tuple<int, string, double>(1, "st", 55.5);

        // Access tuple elements
        Console.WriteLine("ID: " + person.Item1);
        Console.WriteLine("Name: " + person.Item2);
        Console.WriteLine("Height: " + person.Item3 + " feet");
        Console.WriteLine("Is Male: " + person.Item4);

        // Using a method that returns a tuple
        var values = GetValues();
        Console.WriteLine("Number: " + values.Item1);
        Console.WriteLine("Text: " + values.Item2);
    }

    static (int, string) GetValues()
    {
        return (20, "Twenty");
    }

    private static void LinqWithTuple()
    {
        // List of tuples representing ID, Name, and Age
        List<(int Id, string Name, int Age)> people = new List<(int, string, int)>
        {
            (1, "Alice", 30),
            (2, "Bob", 25),
            (3, "Charlie", 35),
            (4, "Diana", 25),
            (5, "Roaa", 25),
            (6, "Khaled", 35)
        };


        // Filter people with age above 30
        var filteredPeople = people.Where(p => p.Age > 30);

        foreach (var person in filteredPeople)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }


        // Grouping people by Age, then ordering within each group
        var GroupPeopleByAge = people.GroupBy(person => person.Age)
                                      .Select( group => new
                                      {
                                          Age = group.Key,
                                          People = group.OrderBy(person => person.Name)
                                       });
        // Displaying the results
        foreach (var Group in GroupPeopleByAge)
        {

            Console.WriteLine($"Age: {Group.Age}");

            foreach(var Person in Group.People)
            {
                Console.WriteLine($"Name: {Person.Name}");
            }

        }
        

        // Find average age
        double averageAge = people.Average(p => p.Age);
        Console.WriteLine("Average Age: " + averageAge);
    }

    static void Main(string[] args)
    {
        //WorkingWithTuple();

        LinqWithTuple();

        Console.ReadKey();
    }
}


