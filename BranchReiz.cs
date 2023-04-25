using System;
using System.Collections.Generic;

public class BranchReiz
{
    public string Name { get; set; }
    public List<Branch> Branches { get; set; }

    public Branch(string name)
    {
        Name = name;
        Branches = new List<Branch>();
    }

    public override string ToString()
    {
        return $"{Name}: {string.Join(", ", Branches)}";
    }
}

public class Program
{
    public static int CalculateDepth(Branch branch, int depth = 0)
    {
        if (branch.Branches.Count == 0)
        {
            return depth;
        }
        else
        {
            int maxDepth = 0;
            foreach (var subBranch in branch.Branches)
            {
                int subDepth = CalculateDepth(subBranch, depth + 1);
                if (subDepth > maxDepth)
                {
                    maxDepth = subDepth;
                }
            }
            return maxDepth;
        }
    }

    public static void Main()
    {
        // create structure
        var branch1 = new Branch("Branch 1");
        var branch2 = new Branch("Branch 2");
        var branch3 = new Branch("Branch 3");
        var branch4 = new Branch("Branch 4");
        var branch5 = new Branch("Branch 5");
        var branch6 = new Branch("Branch 6");
        var branch7 = new Branch("Branch 7");
        var branch8 = new Branch("Branch 8");

        branch7.Branches.Add(branch8);
        branch6.Branches.Add(branch7);
        branch5.Branches.Add(branch6);
        branch4.Branches.Add(branch5);
        branch3.Branches.Add(branch);
        branch2.Branches.Add(branch3);
        branch1.Branches.Add(branch2);

        //to calculate depth
        int depth = CalculateDepth(branch1);
        Console.WriteLine($"The depth of the provided structure is: {depth}");
    }
}
