using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cmdArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countElementsForEnqueu = cmdArgs[0];
            int elementsForDequeu = cmdArgs[1];
            int elementForSearching = cmdArgs[2];

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < elementsForDequeu; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(elementForSearching))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(queue.Count);
                }
            }
        }
    }
}
