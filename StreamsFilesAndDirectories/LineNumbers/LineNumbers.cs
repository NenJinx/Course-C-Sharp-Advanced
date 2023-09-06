//namespace LineNumbers
//{
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    public class LineNumbers
//    {
//        static void Main()
//        {
//            string inputFilePath = @"..\..\..\text.txt";
//            string outputFilePath = @"..\..\..\output.txt";
//            ProcessLines(inputFilePath, outputFilePath);
//        }
//        public static void ProcessLines(string inputFilePath, string outputFilePath)
//        {
//            StringBuilder modifiedText = new();
//            string[] inputFile = File.ReadAllLines(inputFilePath);
//            for (int i = 0; i < inputFile.Length; i++)
//            {
//                int countLetters = inputFile[i].Count(char.IsLetter);
//                int countSymbols = inputFile[i].Count(char.IsPunctuation);
//                modifiedText.AppendLine($"{i + 1}: {inputFile[i]} ({countLetters})({countSymbols})");
//            }
//            File.WriteAllText(outputFilePath, modifiedText.ToString());
//        }
//    }
//}
using System;
using System.Collections.Generic;


namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companiesAndWorkers = new Dictionary<string, List<string>>();
            String[] separator = { " -> " };
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string companyName = cmdArgs[0];
                string employeeID = cmdArgs[1];

                if (!companiesAndWorkers.ContainsKey(companyName))
                {
                    companiesAndWorkers[companyName] = new List<string>();
                }
                if (companiesAndWorkers[companyName].Contains(employeeID))
                {
                    continue;
                }
                companiesAndWorkers[companyName].Add(employeeID);
            }
            foreach (var companyName in companiesAndWorkers)
            {
                Console.WriteLine($"{companyName.Key}");
                foreach (var employeeID in companyName.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}