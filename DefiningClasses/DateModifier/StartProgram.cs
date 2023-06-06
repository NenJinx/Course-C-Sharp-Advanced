using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class StartProgram
    {
        static void Main(string[] args)
        {
            string firstDateData = Console.ReadLine();
            string secondDateData = Console.ReadLine();
            int difference = DateModifier.CalculateDifference(firstDateData, secondDateData);
            Console.WriteLine(difference);
        }
    }
}
