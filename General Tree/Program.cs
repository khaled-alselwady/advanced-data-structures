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

}

public class Tree<T>
{
    public TreeNode<T> Root { get; private set; }

    public Tree(T RootValue)
    {
        this.Root = new TreeNode<T>(RootValue);
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

        PrintTree(CompanyTree.Root);


        //var Grandpa = new Tree<string>("Mahmoud");
        //var Faten = new TreeNode<string>("Faten");
        //var Mosa = new TreeNode<string>("Mosa");
        //var Maher = new TreeNode<string>("Maher");

        //Grandpa.Root.AddChild(Faten);
        //Grandpa.Root.AddChild(Maher);
        //Grandpa.Root.AddChild(Mosa);

        //Faten.AddChild(new TreeNode<string>("Khaled"));
        //Faten.AddChild(new TreeNode<string>("Ahamd"));
        //Faten.AddChild(new TreeNode<string>("Waleed"));
        //Faten.AddChild(new TreeNode<string>("Abood"));
        //Faten.AddChild(new TreeNode<string>("Mariam"));

        //Mosa.AddChild(new TreeNode<string>("Abood"));
        //Mosa.AddChild(new TreeNode<string>("Mohammed"));
        //Mosa.AddChild(new TreeNode<string>("Yousef"));
        //Mosa.AddChild(new TreeNode<string>("Lamies"));

        //PrintTree(Grandpa.Root);
        Console.ReadKey();
    }

    static void PrintTree<T>(TreeNode<T> Node, string Indent = " ")
    {
        Console.WriteLine(Indent + Node.Value);

        foreach (var Chile in Node.Children)
        {
            PrintTree(Chile, Indent + "  ");
        }
    }

}

