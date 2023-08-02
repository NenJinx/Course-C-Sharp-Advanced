int n = int.Parse(Console.ReadLine());
//HashSet<int> numbers = new();
//HashSet<List<int>> numbers = new();
//Dictionary<int,List<int>> keyValuePairs = new Dictionary<int,List<int>>();
Dictionary<int, int> numbers = new Dictionary<int, int>(); 
for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());
    if (!numbers.ContainsKey(num))
    {
        numbers[num] = 0;
    }
    numbers[num] += 1;
}
foreach (var item in numbers)
{
    if (item.Value % 2 == 0)
    {
        Console.WriteLine(item.Key);
    }
}
