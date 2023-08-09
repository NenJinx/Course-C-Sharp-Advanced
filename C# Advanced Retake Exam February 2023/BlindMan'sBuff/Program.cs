using System.Data;

namespace BlindMansBuff
{

    class Player
    {
        public Player(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            CountTouched = 0;
            Moves = 0;
        }

        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public int CountTouched { get; set; }
        public int Moves { get; set; }
        bool IsInside(char[,] playingField, int row, int col)
        {
            return row >= 0 && row < playingField.GetLength(0)
            && col >= 0 && col < playingField.GetLength(1);
        }
        public void Move(string command, char[,] field)
        {


            int newRowIndex = this.RowIndex;
            int newColIndex = this.ColIndex;
            switch (command)
            {
                case "up": newRowIndex--; break;
                case "down": newRowIndex++; break;
                case "left": newColIndex--; break;
                case "right": newColIndex++; break;
            }
            if (!IsInside(field, newRowIndex, newColIndex))
            {
                return;
            }
            if (field[newRowIndex, newColIndex] == 'O')
            {
                return;
            }
            field[this.RowIndex, this.ColIndex] = '-';
            if (field[newRowIndex, newColIndex] == '-')
            {
                Moves++;
                field[newRowIndex, newColIndex] = 'B';
            }
            else
            {
                Moves++;
                CountTouched++;
                field[newRowIndex, newColIndex] = 'B';
            }
            RowIndex = newRowIndex;
            ColIndex = newColIndex;
        }
        class Program
        {
            static void Main()
            {
                int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int m = dimensions[0];
                int n = dimensions[1];
                char[,] playground = new char[m, n];
                int playerRow = 0;
                int playerCol = 0;

                for (int i = 0; i < playground.GetLength(0); i++)
                {
                    char[] input = Console.ReadLine().ToCharArray().Where(s => s != ' ').ToArray();
                    for (int j = 0; j < playground.GetLength(1); j++)
                    {
                        playground[i, j] = input[j];
                        if (input[j] == 'B')
                        {
                            playerRow = i;
                            playerCol = j;
                        }
                    }
                }
                Player player = new(playerRow, playerCol);
                string command = string.Empty;
                while ((command = Console.ReadLine()) != "Finish"
                    & player.CountTouched < 3)
                {
                    player.Move(command, playground);
                }

                Console.WriteLine($"Game over!{Environment.NewLine}" +
                                  $"Touched opponents: {player.CountTouched} Moves made: {player.Moves}");
            }
        }
    }
}




