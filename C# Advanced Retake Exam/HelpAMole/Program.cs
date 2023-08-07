using System;

namespace HelpAMole
{
    public class Mole
    {
        public Mole(int moleRow, int moleCol)
        {
            MoleRow = moleRow;
            MoleCol = moleCol;
        }

        public int MoleRow { get; set; }
        public int MoleCol { get; set; }
        public int Points { get; set; }
        bool IsInside(char[,] playingField, int row, int col)
        {
            return row >= 0 && row < playingField.GetLength(0)
            && col >= 0 && col < playingField.GetLength(1);
        }
        public void Move(char[,] playingField, string command)
        {
            int newRow = MoleRow;
            int newCol = MoleCol;
            switch (command)
            {
                case "up": newRow--; break;
                case "down": newRow++; break;
                case "left": newCol--; break;
                case "right": newCol++; break;
            }
            if (!IsInside(playingField, newRow, newCol))
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return;
            }
            playingField[MoleRow, MoleCol] = '-';
            MoleRow = newRow;
            MoleCol = newCol;
            bool doesFind = false;
            if (playingField[newRow, newCol] == 'S')
            {
                playingField[newRow, newCol] = '-';
                for (int row = 0; row < playingField.GetLength(0); row++)
                {
                    for (int col = 0; col < playingField.GetLength(1); col++)
                    {
                        if (playingField[row, col] == 'S')
                        {
                            MoleRow = row;
                            MoleCol = col;
                            playingField[MoleRow, MoleCol] = 'M';
                            if (Points >= 3)
                            {
                                Points -= 3;
                            }
                            doesFind = true;
                            break;
                        }
                    }
                    if (doesFind == true)
                    {
                        break;
                    }
                }
            }
            else if (char.IsDigit(playingField[newRow, newCol]))
            {
                Points += playingField[newRow, newCol] - 48;
                playingField[newRow, newCol] = 'M';
            }
            else
            {
                playingField[newRow, newCol] = 'M';
            }
        }
        //if (doesFind == false)
        //{
        //    moleRow += nextRow;
        //    moleCol += nextCol;
        //}
    }
    public class Program
    {
        static void Main(string[] args)
        {

            int playingFieldSize = int.Parse(Console.ReadLine());
            char[,] playingField = new char[playingFieldSize, playingFieldSize];
            int moleRow = 0;
            int moleCol = 0;
            for (int row = 0; row < playingFieldSize; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < playingFieldSize; col++)
                {
                    playingField[row, col] = input[col];
                    if (input[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }
            Mole mole = new Mole(moleRow, moleCol);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                mole.Move(playingField, command);
                if (mole.Points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of " +
                        $"{mole.Points} points.");
                    PrintMatrix(playingField);
                    return;
                }
            }

            Console.WriteLine("Too bad! The Mole lost this battle!");
            Console.WriteLine($"The Mole lost the game with a total of " +
                    $"{mole.Points} points.");
            PrintMatrix(playingField);

            void PrintMatrix(char[,] playingField)
            {
                for (int row = 0; row < playingFieldSize; row++)
                {
                    for (int col = 0; col < playingFieldSize; col++)
                    {
                        Console.Write(playingField[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}



