using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new(
                    cmdArgs[0],
                    int.Parse(cmdArgs[1]),
                    int.Parse(cmdArgs[2]),
                    int.Parse(cmdArgs[3]),
                    cmdArgs[4],
                    double.Parse(cmdArgs[5]),
                    int.Parse(cmdArgs[6]),
                    double.Parse(cmdArgs[7]),
                    int.Parse(cmdArgs[8]),
                    double.Parse(cmdArgs[9]),
                    int.Parse(cmdArgs[10]),
                    double.Parse(cmdArgs[11]),
                    int.Parse(cmdArgs[12]));

                cars.Add(car);
            }
            string command = Console.ReadLine();
            string[] filteredCar;
            if (command == "fragile")
            {                    
                filteredCar = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).
                    Select(c => c.Model)
                    .ToArray();
            }
            else
            {
                filteredCar = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).
                    Select(c => c.Model)
                    .ToArray();
            }
            foreach (var car in filteredCar) 
            {
                Console.WriteLine(car);
            }
        }
    }
}
