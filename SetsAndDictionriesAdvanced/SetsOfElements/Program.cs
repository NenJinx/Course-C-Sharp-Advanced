int n = int.Parse(Console.ReadLine());
HashSet<string> uniqueUsernames = new HashSet<string>();
for (int i = 0; i < n; i++)
{
    string command = Console.ReadLine();
    uniqueUsernames.Add(command); 
}
Console.WriteLine(string.Join("\n", uniqueUsernames));
