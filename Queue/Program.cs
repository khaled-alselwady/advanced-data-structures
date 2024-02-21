using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        Queue<string> queue = new Queue<string>();


        // Enqueueing elements into the queue
        queue.Enqueue("Alice");
        queue.Enqueue("Bob");
        queue.Enqueue("Charlie");


        // Peeking at the first element
        Console.WriteLine("First in line: " + queue.Peek());


        // Dequeuing elements from the queue
        Console.WriteLine("Served: " + queue.Dequeue());
        Console.WriteLine("Served: " + queue.Dequeue());


        // Checking if the queue is empty
        if (queue.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
        }
        else
        {
            Console.WriteLine("First in line: " + queue.Peek());
        }


        // Clearing the queue
        queue.Clear();

        Console.ReadKey();
    }
}
