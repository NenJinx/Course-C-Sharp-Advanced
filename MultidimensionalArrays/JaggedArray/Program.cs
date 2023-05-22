using System.Data;

int rows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[rows][];
for (int row = 0; row < rows; row++)
{
    int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray();

    jaggedArray[row] = cols;
}
for (int i = 0; i < rows - 1; i++)
{
    if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
    {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            jaggedArray[i][j] *= 2;
            jaggedArray[i + 1][j] *= 2;
        }
    }
    else
    {
        for (int x = 0; x < jaggedArray[i].Length; x++)
        {
            jaggedArray[i][x] /= 2;
        }
        for (int y = 0; y < jaggedArray[i + 1].Length; y++)
        {
            jaggedArray[i + 1][y] /= 2;
        }
    }
}
string command = string.Empty;
while ((command = Console.ReadLine()) != "End")
{
    string[] cmdArgs = command.Split(" ",StringSplitOptions.RemoveEmptyEntries).
            ToArray();
    string commandName = cmdArgs[0];
    int row = int.Parse(cmdArgs[1]);
    int col = int.Parse(cmdArgs[2]);
    int value = int.Parse(cmdArgs[3]);
    if (isValid(row, col, cmdArgs))
    {
        if (commandName == "Add")
        {
            jaggedArray[row][col] += value;
        }
        else
        {
            jaggedArray[row][col] -= value;
        }
    }
}
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write($"{jaggedArray[row][col]} ");
    }
    Console.WriteLine();
}
bool isValid(int row, int col, string[] tokens)
{
    return
        tokens.Length == 4
        && row >= 0 && row < rows
        && col >= 0 && col < jaggedArray[row].Length;
}