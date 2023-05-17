using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());
int[,] matrix = new int[size, size];
for (int i = 0; i < size; i++)
{
    int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    for (int j = 0; j < size; j++)
    {
        matrix[i, j] = array[j];
    }
    Console.WriteLine();
}
int sumPrimary = 0;
int sumSecondary = 0;

for (int i = 0; i < size; i++)
{
    sumPrimary += matrix[i, i];
    sumSecondary += matrix[size - i - 1, i];
}

int difference = Math.Abs(sumPrimary - sumSecondary);
Console.WriteLine(difference);