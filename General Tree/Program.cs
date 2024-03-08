using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Value { get; set; }

    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T value)
    {
        this.Value = value;
        this.Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> Child)
    {
        Children.Add(Child);
    }

    public TreeNode<T> Find(T Value)
    {
        if (EqualityComparer<T>.Default.Equals(this.Value, Value))
            return this;

        foreach (var Child in Children)
        {
            var Found = Child.Find(Value);

            if (Found != null)
                return Found;
        }

        return null;
    }


}

public class Tree<T>
{
    public TreeNode<T> Root { get; private set; }

    public Tree(T RootValue)
    {
        this.Root = new TreeNode<T>(RootValue);
    }

    public TreeNode<T> Find(T Value)
    {
        return this.Root?.Find(Value);
    }

    public void PrintTree(string Indent = " ")
    {
        _PrintTree(this.Root, Indent);
    }

    private static void _PrintTree(TreeNode<T> Node, string Indent = " ")
    {
        Console.WriteLine(Indent + Node.Value);

        foreach (var Child in Node.Children)
        {
            _PrintTree(Child, Indent + "  ");
        }
    }

}

public class Program
{
    static void Main(string[] args)
    {
        var CompanyTree = new Tree<string>("CEO");
        var Finance = new TreeNode<string>("CFO");
        var Tech = new TreeNode<string>("CTO");
        var Marketing = new TreeNode<string>("CMO");

        // Add departments to CEO
        CompanyTree.Root.AddChild(Finance);
        CompanyTree.Root.AddChild(Tech);
        CompanyTree.Root.AddChild(Marketing);

        // Add employees to departments
        Finance.AddChild(new TreeNode<string>("Accountant"));
        Tech.AddChild(new TreeNode<string>("Developer"));
        Tech.AddChild(new TreeNode<string>("UX Designer"));
        Marketing.AddChild(new TreeNode<string>("Social Media Manager"));

        // Printing the tree
        CompanyTree.PrintTree();

        Console.WriteLine("\nFinding Developer...");
        if (CompanyTree.Find("Developer") is null)
            Console.WriteLine("Not Found :-(");
        else
            Console.WriteLine("Found :-)");

        Console.WriteLine("\nFinding DBA...");
        if (CompanyTree.Find("DBA") is null)
            Console.WriteLine("Not Found :-(");
        else
            Console.WriteLine("Found :-)");

        Console.ReadKey();
    }
}

