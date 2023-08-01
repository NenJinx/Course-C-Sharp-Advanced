int n = int.Parse(Console.ReadLine());
SortedSet<string> result = new();
for (int i = 0; i < n; i++)
{
    string[] cmdArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries). 
            ToArray();
    for (int j = 0; j < cmdArgs.Length; j++)
    {
        result.Add(cmdArgs[j]);
    }
}
Console.WriteLine(string.Join(" ",result));
