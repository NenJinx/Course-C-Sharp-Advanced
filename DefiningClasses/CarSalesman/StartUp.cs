using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new();
            List<Car> cars = new();

            int countEngines = int.Parse(System.Console.ReadLine());

            for (int i = 0; i < countEngines; i++)
            {
                string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngine(carProperties);
                engines.Add(engine);
            }

            int countCars = int.Parse(System.Console.ReadLine());
            for (int i = 0; i < countCars; i++)
            {
                string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = CreateCar(carProperties, engines);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
        static Engine CreateEngine(string[] carProperties)
        {
            Engine engine = new(carProperties[0], int.Parse(carProperties[1]));

            if (carProperties.Length > 2)
            {
                int displacement;

                bool isDigit = int.TryParse(carProperties[2], out displacement);

                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = carProperties[2];
                }

                if (carProperties.Length > 3)
                {
                    engine.Efficiency = carProperties[3];
                }
            }
            return engine;
        }

        static Car CreateCar(string[] carProperties, List<Engine> engines)
        {
            Engine engine = engines.Find(x => x.Model == carProperties[1]);

            Car car = new(carProperties[0], engine);

            if (carProperties.Length > 2)
            {
                int weight;

                bool isDigit = int.TryParse(carProperties[2], out weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carProperties[2];
                }

                if (carProperties.Length > 3)
                {
                    car.Color = carProperties[3];
                }
            }

            return car;
        }
    }
}