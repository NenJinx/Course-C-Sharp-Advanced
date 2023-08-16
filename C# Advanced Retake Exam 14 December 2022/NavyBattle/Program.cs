
using System.ComponentModel;

public class Submarine
{
    public Submarine(int row, int col)
    {
        Row = row;
        Col = col;
        BattleCruiserForDestroyed = 3;
    }

    public int Row { get; set; }
    public int Col { get; set; }
    public int CountBlownMines { get; set; }
    public int BattleCruiserForDestroyed { get; set; }
    public bool IsInside(char[,] field, int row, int col)
    {
        return row >= 0 && row < field.GetLength(0)
        && col >= 0 && col < field.GetLength(1);
    }
    public void Print(char[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }
    public void Move(string command, char[,] battleField)
    {
        int newRow = Row;
        int newCol = Col;
        switch (command)
        {
            case "up": newRow--; break;
            case "down": newRow++; break;
            case "left": newCol--; break;
            case "right": newCol++; break;
        }

        battleField[Row, Col] = '-';

        Row = newRow;
        Col = newCol;
        if (battleField[Row, Col] == '-')
        {
            battleField[Row, Col] = 'S';

        }
        else if (battleField[Row, Col] == '*')
        {
            battleField[Row, Col] = 'S';
            CountBlownMines++;
            if (CountBlownMines == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared!" +
                    $" Last known coordinates [{Row}, {Col}]!");
            }
        }
        else if (battleField[Row,Col] == 'C')
        {
            battleField[Row, Col] = 'S';
            BattleCruiserForDestroyed -= 1;
            if (BattleCruiserForDestroyed == 0)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle" +
                    " cruisers of the enemy!");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] battleField = new char[matrixSize, matrixSize];
            int submarineRow = 0;
            int submarineCol = 0;

            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < battleField.GetLength(1); j++)
                {
                    battleField[i, j] = input[j];
                    if (input[j] == 'S')
                    {
                        submarineRow = i;
                        submarineCol = j;
                    }
                }
            }
            Submarine submarine = new Submarine(submarineRow, submarineCol);
            string command = string.Empty;
            while (submarine.BattleCruiserForDestroyed != 0 
                || submarine.CountBlownMines <= 2)
            {
                command = Console.ReadLine();
                submarine.Move(command, battleField);
            }
            submarine.Print(battleField);
        }
    }
}