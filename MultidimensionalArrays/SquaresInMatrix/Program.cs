int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
int rows = dimensions[0];
int cols = dimensions[1];
char[,] chars = new char[rows, cols];
for (int row = 0; row < chars.GetLength(0); row++)
{
    char[] array = Console.ReadLine().Split(' ').Select(n => char.Parse(n)).ToArray();
    for (int col = 0; col < chars.GetLength(1); col++)
    {
        chars[row, col] = array[col];
    }
}

int squareMatrix = 0;
for (int i = 0; i < rows - 1; i++)
{
    for (int j = 0; j < cols - 1; j++)
    {
        if (chars[i, j] == chars[i, j + 1] &&
            chars[i, j] == chars[i + 1, j] && chars[i, j] == chars[i + 1, j + 1])
        {
            squareMatrix++;
        }
    }
}
Console.WriteLine(squareMatrix);
