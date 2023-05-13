using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

int foodQuantity = int.Parse(Console.ReadLine());
List<int> orders = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
Queue<int> queue = new(orders);
int theBiggestOrder = queue.Max();
Console.WriteLine(theBiggestOrder);
while (queue.Count > 0)
{
}
