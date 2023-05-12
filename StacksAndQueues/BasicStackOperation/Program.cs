using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cmdArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countElementsForPush = cmdArgs[0];
            int elementsForPop = cmdArgs[1];
            int elementForSearching = cmdArgs[2];

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countElementsForPush; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < elementsForPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementForSearching))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(stack.Count);
            }
        }
    }
}
