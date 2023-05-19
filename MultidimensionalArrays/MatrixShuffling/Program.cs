using System.Net.WebSockets;
using System;
using System.Linq;

int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int rows = dimensions[0];
int cols = dimensions[1];
string[,] matrix = new string[rows, cols];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = inputData[col];
    }
}
string command = string.Empty;
while ((command = Console.ReadLine()) != "END")
{
    string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    if (cmdArgs.Length == 5)
    {
        string commandName = cmdArgs[0];
        if (commandName == "swap")
        {
            int firstCoordinatesForRow = int.Parse(cmdArgs[1]);
            int firstCoordinatesForCol = int.Parse(cmdArgs[2]);
            int secondCoordinatesForRow = int.Parse(cmdArgs[3]);
            int secondCoordinatesForCol = int.Parse(cmdArgs[4]);
            if (firstCoordinatesForRow >= 0 && firstCoordinatesForRow < matrix.Length
                && firstCoordinatesForCol >= 0 && firstCoordinatesForCol < matrix.Length &&
                secondCoordinatesForRow >= 0 && secondCoordinatesForRow < matrix.Length &&
                secondCoordinatesForCol >= 0 && secondCoordinatesForCol < matrix.Length)
            {
                //if (firstCoordinatesForCol == secondCoordinatesForCol &&
                //    firstCoordinatesForRow == secondCoordinatesForRow)
                //{
                //    Console.WriteLine("Invalid input!");
                //}
                //else
                //{
                string number = matrix[firstCoordinatesForRow, firstCoordinatesForCol];
                matrix[firstCoordinatesForRow, firstCoordinatesForCol] = matrix[secondCoordinatesForRow, secondCoordinatesForCol];
                matrix[secondCoordinatesForRow, secondCoordinatesForCol] = number;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                // }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}