using System.ComponentModel.Design;

Queue<int> textile = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> medicaments = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Dictionary<int, string> resourcesAndItems = new()
{
    {30,"Patch" },
    {40,"Bandage" },
    {100,"MedKit" },
};
Dictionary<string, int> items = new();
while (textile.Any() && medicaments.Any())
{
    int result = textile.Dequeue() + medicaments.Peek();
    if (resourcesAndItems.ContainsKey(result))
    {
        if (!items.ContainsKey(resourcesAndItems[result]))
        {
            items.Add(resourcesAndItems[result], 1);
            medicaments.Pop();
        }
        else
        {
            items[resourcesAndItems[result]] += 1;
            medicaments.Pop();
        }
    }

    else if (result > 100)
    {
        medicaments.Pop();
        if (!items.ContainsKey(resourcesAndItems[100]))
        {
            items.Add(resourcesAndItems[100], 0);
        }
        items[resourcesAndItems[100]] += 1;
        int remaining = result - 100;
        int operationAdd = medicaments.Pop() + remaining;
        medicaments.Push(operationAdd);
    }
    else
    {
        int increaseValue = medicaments.Pop() + 10;
        medicaments.Push(increaseValue);
    }
}

if (!textile.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (!textile.Any() && medicaments.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else
{
    Console.WriteLine("Medicaments are empty.");
}
foreach (var item in items.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}
if (textile.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
}
if (medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");

}