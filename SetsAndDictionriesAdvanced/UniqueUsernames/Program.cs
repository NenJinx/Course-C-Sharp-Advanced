int[] countNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
    Select(int.Parse).ToArray();
int n = countNumbers[0];
int m = countNumbers[1];
HashSet<int> firstSet = new();
HashSet<int> secondSet = new();
int value = 0;
for (int i = 0; i < n; i++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}
for (int i = 0; i < m; i++)
{
   secondSet.Add(int.Parse(Console.ReadLine()));
}
firstSet.IntersectWith(secondSet);
Console.WriteLine(string.Join(" ", firstSet));