using System;
using System.Collections.Generic;
using System.Linq;

namespace Barista
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> drinks = new Dictionary<string, int>();

            Dictionary<int, string> drinksQuantities = new Dictionary<int, string>()
            {
                { 50, "Cortado"} ,
                { 75, "Espresso"} ,
                { 100, "Capuccino"} ,
                { 150, "Americano"} ,
                { 200, "Latte"}
            };
            while (coffee.Any() && milk.Any())
            {
                int sumValue = coffee.Dequeue() + milk.Peek();
                if (drinksQuantities.ContainsKey(sumValue))
                {
                    string drinkName = drinksQuantities[sumValue];
                    if (!drinks.ContainsKey(drinkName))
                    {
                        drinks.Add(drinkName, 0);
                    }
                    drinks[drinkName] += 1;
                    milk.Pop();
                }
                else
                {
                    int increasedValue = milk.Pop() - 5;
                    milk.Push(increasedValue);
                }
            }
            if (!coffee.Any() && !milk.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else if (coffee.Any() && milk.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else if (coffee.Any() && !milk.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
                Console.WriteLine($"Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                Console.WriteLine($"Coffee left: none");
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            foreach (var item in drinks.OrderBy(d => d.Value).ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
