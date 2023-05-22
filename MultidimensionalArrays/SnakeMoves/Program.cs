int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
int rows = dimensions[0];
int cols = dimensions[1];
char[,] matrix = new char[rows, cols];
string snake = Console.ReadLine();
int counter = 0;
for (int row = 0; row < rows; row++)
{
    if (row % 2 == 1)
    {
        for (int x = cols - 1; x >= 0; x--)
        {
            if (counter == snake.Length)
            {
                counter = 0;
            }
            matrix[row, x] = snake[counter];
            counter++;
            
        }
        for (int y = row; y <= row; y++)
        {
            for (int t = 0; t < cols; t++)
            {
                Console.Write(matrix[y, t]);
            }
        }
        Console.WriteLine();
    }
    if (row % 2 == 1)
    {
        continue;
    }
    for (int col = 0; col < cols; col++)
    {       
        if (counter == snake.Length)
        {
            counter = 0;
        }
        matrix[row, col] = snake[counter];
        counter++;
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}

