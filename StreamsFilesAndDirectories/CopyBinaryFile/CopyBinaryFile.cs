namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream file = new(inputFilePath, FileMode.Open);
            {
                FileStream newFile = new(outputFilePath, FileMode.Create);
                file.CopyTo(newFile);
            }

        }
    }
}
