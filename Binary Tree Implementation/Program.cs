using System;
using System.Collections.Generic;

namespace BinaryTreeImplementation
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(T value)
        {
            /*
            We use Level-order insertion strategy,
            Level-order insertion: in a binary tree is a strategy that fills the tree level by level, 
            from left to right. This approach ensures that every level of the tree is completely 
            filled before any nodes are added to a new level, 
            and each parent node has at most two children before moving on to the next node in the 
            sequence.

            */

            var newNode = new BinaryTreeNode<T>(value);

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == null)
                    return;

                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        public void PrintTree()
        {
            _PrintTree(Root, 0);
        }

        private void _PrintTree(BinaryTreeNode<T> root, int space)
        {
            const int COUNT = 10; // Distance between levels to adjust the visual representation

            if (root == null)
                return;

            space += COUNT;
            _PrintTree(root.Right, space); // Print right subtree first, then root, and left subtree last

            Console.WriteLine();

            for (int i = COUNT; i < space; i++)
                Console.Write(" ");

            Console.WriteLine(root.Value); // Print the current node after space

            _PrintTree(root.Left, space); // Recur on the left child
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");


            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(8);
            binaryTree.Insert(1);
            binaryTree.Insert(4);
            binaryTree.Insert(6);
            binaryTree.Insert(9);
            //binaryTree.Insert(55);

            binaryTree.PrintTree();

            Console.ReadKey();
        }
    }
}
