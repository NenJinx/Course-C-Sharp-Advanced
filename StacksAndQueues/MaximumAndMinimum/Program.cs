using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());

Stack<int> stack = new();
for (int i = 0; i < n; i++)
{
    int[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();

    if (cmd[0] == 1)
    {
        stack.Push(cmd[1]);
    }
    else if (cmd[0] == 2)
    {
        stack.Pop();
    }
    else if (cmd[0] == 3)
    {
        if (stack.Any())
        {
            Console.WriteLine(stack.Max());
        }
    }
    else if (cmd[0] == 4)
    {
        if (stack.Any())
        {
            Console.WriteLine(stack.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", stack));
