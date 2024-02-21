using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        // Pushing elements onto the stack
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Peeking at the top element
        Console.WriteLine("Top element: " + stack.Peek());


        // Popping elements from the stack
        Console.WriteLine("Popped: " + stack.Pop());
        Console.WriteLine("Popped: " + stack.Pop());


        // Checking if the stack is empty
        if (stack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
        }
        else
        {
            Console.WriteLine("Top element: " + stack.Peek());
        }

        // Clearing the stack
        stack.Clear();

        Console.ReadKey();
    }
}
