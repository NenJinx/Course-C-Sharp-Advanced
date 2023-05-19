
using System.Buffers.Binary;

int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
int rows = dimensions[0];
int cols = dimensions[1];
int[,] matrix = new int[rows, cols];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = array[col];
    }
}
int squareMatrix = 0;
int squareMatrixMax = int.MinValue;
int maxSumRow = 0;
int maxSumCol = 0;
for (int i = 0; i < rows - 2; i++)
{
    for (int j = 0; j < cols - 2; j++)
    {
        squareMatrix = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
             matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
             matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
        if (squareMatrix > squareMatrixMax)
        {
            squareMatrixMax = squareMatrix;
            maxSumRow = i;
            maxSumCol = j;
        }
    }
}
Console.WriteLine($"Sum = {squareMatrixMax}");

for (int i = maxSumRow; i < maxSumRow + 3; i++)
{
    for (int j = maxSumCol; j < maxSumCol + 3; j++)
    {
        Console.Write($"{matrix[i, j]} ");
    }
    Console.WriteLine();
}




