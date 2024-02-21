using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


internal class Program
{
    static void WorkingWithDictionary()
    {
        Dictionary<string, int> FruitBasket = new Dictionary<string, int>
        {
            { "Apple", 5 },
            { "Banana", 2 },
            { "Orange", 12 }
        };


        // Adding elements
        FruitBasket.Add("Lemon", 5);
        //the following commented line will cause an error because they key is repeated.
        //FruitBasket.Add("Banana", 5);


        // Accessing and updating elements
        FruitBasket["Apple"] = 10;


        Console.WriteLine("\nDictionary Content:");
        // Iterating through the dictionary
        foreach (KeyValuePair<string, int> item in FruitBasket)
        {
            Console.WriteLine($"Fruit: {item.Key}, Quantity: {item.Value}");
        }

        if (FruitBasket.ContainsKey("Apple"))
        {
            Console.WriteLine("Apple is in the basket.");
        }

        if (FruitBasket.TryGetValue("Banana", out int BananaQuantity1))
        {
            Console.WriteLine($"Banana Quantity = {BananaQuantity1}");
        }
        else
        {
            Console.WriteLine("Banana is not found");
        }

        // Removing an element
        FruitBasket.Remove("Banana");

        if (FruitBasket.TryGetValue("Banana", out int BananaQuantity2))
        {
            Console.WriteLine($"Banana Quantity = {BananaQuantity2}");
        }
        else
        {
            Console.WriteLine("Banana is not found");
        }

        Console.WriteLine("\nDictionary Content after removing Banana:");
        // Iterating through the dictionary after removing Banana
        foreach (KeyValuePair<string, int> item in FruitBasket)
        {
            Console.WriteLine($"Fruit: {item.Key}, Quantity: {item.Value}");
        }

    }

    static void LinqWithDictionary()
    {
        // Creating and initializing the dictionary
        Dictionary<string, int> fruitBasket = new Dictionary<string, int>
        {
            { "Apple", 5 },
            { "Banana", 2 },
            { "Orange", 7 }
        };

        #region Projection Operations

        // Selecting keys
        var keys = fruitBasket.Select(pair => pair.Key);
        // keys will be: { "Apple", "Banana", "Orange" }

        Console.WriteLine("Fruit Names:");
        foreach (var item in keys)
        {
            Console.WriteLine($"Fruit: {item}");
        }

        // Selecting values
        var values = fruitBasket.Select(pair => pair.Value);
        // values will be: { 5, 2, 7 }

        // Using LINQ to transform items
        var fruitInfo = fruitBasket.Select(kvp => new { Name = kvp.Key, Quantity = kvp.Value });
         
        // Displaying the transformed items
        Console.WriteLine("\nTransformed Items:");
        foreach (var item in fruitInfo)
        {
            Console.WriteLine($"Fruit: {item.Name}, Quantity: {item.Quantity}");
        }

        #endregion

        #region Combining and Derived Data

        // Combining key and value into a single object
        var combinedData = fruitBasket.Select(pair => $"{pair.Key}: {pair.Value}");
        // combinedData will be a collection of strings representing key-value pairs

        foreach (var item in combinedData)
        {
            Console.WriteLine($"Fruit: {item}");
        }

        // Calculating derived data (e.g., doubling the value)
        var doubledValues = fruitBasket.Select(pair => new KeyValuePair<string, int>(pair.Key, pair.Value * 2));
        // doubledValues will be a new dictionary with the same keys but doubled values

        foreach (var item in doubledValues)
        {
            Console.WriteLine($"Fruit: {item.Key} : {item.Value}");
        }

        #endregion

        #region Filtering and Sorting

        // Using LINQ to filter items
        var filteredFruit = fruitBasket.Where(kvp => kvp.Value > 3);

        Console.WriteLine("\nFiltered Items (Quantity > 3):");
        foreach (var item in filteredFruit)
        {
            Console.WriteLine($"Fruit: {item.Key}, Quantity: {item.Value}");
        }

        // Using LINQ to sort items by quantity
        var sortedByQuantity = fruitBasket.OrderBy(kvp => kvp.Value);

        Console.WriteLine("\nSorted Items (Ascending Order by Quantity):");
        foreach (var item in sortedByQuantity)
        {
            Console.WriteLine($"Fruit: {item.Key}, Quantity: {item.Value}");
        }


        // Using LINQ to sort items by quantity according the length of the key (fruit name)
        var sortedByQuantity2 = fruitBasket.OrderBy(kvp => kvp.Key.Length);

        Console.WriteLine("\nSorted Items (Ascending Order according the length of the key (fruit name)):");
        foreach (var item in sortedByQuantity2)
        {
            Console.WriteLine($"Fruit: {item.Key}, Quantity: {item.Value}");
        }

        // Using LINQ to sort items by quantity in descending order
        var sortedByQuantityDesc = fruitBasket.OrderByDescending(kvp => kvp.Value);

        Console.WriteLine("\nSorted Items (Descending Order by Quantity):");
        foreach (var item in sortedByQuantityDesc)
        {
            Console.WriteLine($"Fruit: {item.Key}, Quantity: {item.Value}");
        }

        #endregion

        #region Aggregation Operations

        // Using LINQ to aggregate data
        int totalQuantity = fruitBasket.Sum(kvp => kvp.Value);
        int maxQuantity = fruitBasket.Max(kvp => kvp.Value);
        int minQuantity = fruitBasket.Min(kvp => kvp.Value);

        var maxFruitName = fruitBasket.Where(kvp => kvp.Value == maxQuantity).Select(kvp => kvp.Key);
        Console.WriteLine("\nFruit(s) with Maximum Quantity:");
        foreach (var fruit in maxFruitName)
        {
            Console.WriteLine($"Fruit: {fruit}");
        }

        var minFruitName = fruitBasket.Where(kvp => kvp.Value == minQuantity).Select(kvp => kvp.Key);
        Console.WriteLine("\nFruit(s) with Minimum Quantity:");
        foreach (var item in minFruitName)
        {
            Console.WriteLine($"Fruit: {item}");
        }

        Console.WriteLine($"\nTotal Quantity of Fruits: {totalQuantity}");

        #endregion
    }

    static void AdvancedLinqWithDictionary()
    {
        Dictionary<string, string> fruitsCategory = new Dictionary<string, string>
        {
            { "Apple", "Tree" },
            { "Banana", "Herb" },
            { "Cherry", "Tree" },
            { "Strawberry", "Bush" },
            { "Raspberry", "Bush" }
        };

        var groupedFruits = fruitsCategory.GroupBy(kpv => kpv.Value);


        foreach (var group in groupedFruits)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var fruit in group)
            {
                Console.WriteLine($" - {fruit.Key}");
            }
        }


        // Another Dictionary for combined queries
        Dictionary<string, int> fruitBasket = new Dictionary<string, int>
        {
            { "Apple", 5 },
            { "Banana", 2 },
            { "Orange", 7 }
        };


        // Combined LINQ queries
        var sortedFilteredFruits = fruitBasket
            .Where(kpv => kpv.Value > 3)
            .OrderBy(kpv => kpv.Key.Length)
            .Select(kpv => new { kpv.Key, kpv.Value });

        Console.WriteLine("\nSorted and Filtered Fruits:");
        foreach (var fruit in sortedFilteredFruits)
        {
            Console.WriteLine($"Fruit: {fruit.Key}, Quantity: {fruit.Value}");
        }
    }

    static void Main(string[] args)
    {
        //LinqWithDictionary();

        AdvancedLinqWithDictionary();

        Console.ReadKey();
    }
}

