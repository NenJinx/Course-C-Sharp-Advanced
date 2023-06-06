using System;
using System.Collections.Generic; 
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> peopleOver30 = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personData = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Person person = new(personData[0], int.Parse(personData[1]));
            if (person.Age > 30)
            {
                peopleOver30.Add(person);
            }
        }
        foreach (var item in peopleOver30)
        {
            Console.WriteLine($"{item.Name} {item.Age}");
        }
        
        
    }
}
