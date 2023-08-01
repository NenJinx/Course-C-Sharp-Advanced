int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> colorsAndClothes = new();

for (int i = 0; i < n; i++)
{
    string[] inputData = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries). 
        ToArray();
    string color = inputData[0];
    List<string> clothes = inputData[1].Split(",").ToList();
    if (!colorsAndClothes.ContainsKey(inputData[0]))
    {
        colorsAndClothes[color] = new();
    }
    foreach (var item in clothes)
    {
        if (colorsAndClothes[color].ContainsKey(item))
        {
            colorsAndClothes[color][item] += 1;
        }
        else
        {
            colorsAndClothes[color][item] = 1;
        }

    }
}
string[] soughtAfterGarment = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string currentColor = string.Empty;
foreach (var item in colorsAndClothes)
{
    Console.WriteLine($"{item.Key} clothes:");
    currentColor = item.Key;
    foreach (var garment in colorsAndClothes[item.Key])
    {
        if (currentColor == soughtAfterGarment[0] && garment.Key == soughtAfterGarment[1])
        {
            Console.WriteLine($"* {garment.Key} - {garment.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {garment.Key} - {garment.Value}");
        }
    }
}
