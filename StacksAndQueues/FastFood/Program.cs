using System;
using System.Collections.Generic;
using System.Linq;

int foodQuantity = int.Parse(Console.ReadLine());
Queue<int> orders = new(Console.ReadLine().Split(' ').Select(int.Parse));
Console.WriteLine(orders.Max());
while (orders.Any())
{
    foodQuantity -= orders.Peek();
    if (foodQuantity < 0)
    {
        break;
    }
    orders.Dequeue();
}
if (orders.Any())
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
else
{
    Console.WriteLine("Orders complete");
}
