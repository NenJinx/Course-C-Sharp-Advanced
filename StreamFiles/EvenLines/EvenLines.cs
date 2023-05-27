namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader inputStreamReader = new StreamReader(inputFilePath);
            int count = 0;
            StringBuilder modifiedText = new();
            string line;
            while ((line = inputStreamReader.ReadLine()) != null)
            {
                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedLine = ReverseText(replacedSymbols);
                    modifiedText.AppendLine(reversedLine);
                }
                count++;
            }
            return modifiedText.ToString();
        }
        private static string ReplaceSymbols(string text)
        {
            StringBuilder sb = new(text);
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };
            foreach (var symbol in symbolsToReplace)
            {
                sb.Replace(symbol, '@');
            }
            return sb.ToString();
        }
        private static string ReverseText(string words)
        {
            string[] reversedWords = words.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse().ToArray();
            return string.Join(" ", reversedWords);
        }
    }
}
