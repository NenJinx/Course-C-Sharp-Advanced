using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight,string cargoType, double tire1Pressure,
            int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure,int  tire3Age,double tire4Pressure, 
            int tire4Age)
        {
            Model = model;
            Engine = new(engineSpeed, enginePower);
            Cargo = new(cargoWeight, cargoType);
            Tires = new Tire[4];
            Tires[0] = new(tire1Pressure, tire1Age);
            Tires[1] = new(tire2Pressure, tire2Age);
            Tires[2] = new(tire3Pressure, tire3Age);
            Tires[3] = new(tire4Pressure, tire4Age);        
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
