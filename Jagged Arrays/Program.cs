using System;
using System.Linq;

namespace Jagged_Arrays
{
    internal class Program
    {
        private static void WorkingWithJaggedArray()
        {
            // Declare and initialize the jagged array
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            jaggedArray[1] = new int[] { 0, 2, 4 };
            jaggedArray[2] = new int[] { 11, 22 };


            // Display the array elements
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void MatrixInJaggedArray()
        {
            // Initialize the jagged array with 3 rows
            int[][] matrix = new int[3][];


            // Populate each row with arrays of varying sizes
            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 4, 5 };
            matrix[2] = new int[] { 6, 7, 8, 9 };


            // Display the matrix
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.Write("Row " + row + ": ");
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void DynamicRowInitialization()
        {
            // Declare the jagged array with 3 rows
            int[][] jaggedArray = new int[3][];

            // Initialize each row dynamically
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                // Define the size of each row dynamically
                int size = i + 1; // For demonstration, the size increases with the row index

                // Allocate memory for the current row
                jaggedArray[i] = new int[size];

                // Initialize elements of the current row
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = i * 10 + j; // For demonstration, assigning values based on row and column index
                }
            }

            // Print the jagged array
            Console.WriteLine("Jagged Array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Row {i + 1}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void UsingLINQWithJaggedArrays()
        {
            // Declare and initialize a jagged array
            int[][] jaggedArray = {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9, 10 }
        };


            // Flatten the jagged array and sum all elements
            int totalSum = jaggedArray.SelectMany(subArray => subArray).Sum();
            Console.WriteLine("Total Sum: " + totalSum);


            // Find the maximum element in the jagged array
            int maxElement = jaggedArray.SelectMany(subArray => subArray).Max();
            Console.WriteLine("Maximum Element: " + maxElement);


            // Filter arrays having more than 3 elements and select their first element
            var firstElements = jaggedArray.Where(subArray => subArray.Length > 3)
                                           .Select(subArray => subArray.First());
            Console.Write("First Elements of Long Rows: ");
            foreach (var element in firstElements)
            {
                Console.Write(element + " ");
            }
        }

        static void Main(string[] args)
        {
            //WorkingWithJaggedArray();

            //MatrixInJaggedArray();

            //DynamicRowInitialization();

            UsingLINQWithJaggedArrays();

            Console.ReadKey();
        }
    }
}
