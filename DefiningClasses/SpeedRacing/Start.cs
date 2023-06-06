using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Start
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carsProperties = Console.ReadLine().Split(' ');

                string model = carsProperties[0];
                double fuelAmount = double.Parse(carsProperties[1]);
                double fuelConsumptionFor1km = double.Parse(carsProperties[2]);
                Car car = new(model, fuelAmount, fuelConsumptionFor1km);
                cars[model] = car;
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = cmdArgs[0];
                string carModel = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                Car car = cars[carModel];
                car.GetCarMove(amountOfKm);
            }
            foreach (var value in cars.Values)
            {
                Console.WriteLine($"{value.Model} {value.FuelAmount:f2} {value.TravelledDistance}");
            }
        }

    }
}





