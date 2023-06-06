namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder modifiedText = new();
            string[] inputFile = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < inputFile.Length; i++)
            {
                int countLetters = inputFile[i].Count(char.IsLetter);
                int countSymbols = inputFile[i].Count(char.IsPunctuation);
                modifiedText.AppendLine($"{i + 1}: {inputFile[i]} ({countLetters})({countSymbols})");
            }
            File.WriteAllText(outputFilePath, modifiedText.ToString());
        }
    }
}
