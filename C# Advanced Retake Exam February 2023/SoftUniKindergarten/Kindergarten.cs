
using System;
using System.Collections.Generic;
using System.Linq;


namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount { get { return this.Registry.Count; } }


        public bool AddChild(Child child)
        {
            if (Capacity > 0)
            {
                Registry.Add(child);
                Capacity -= 1;
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool RemoveChild(string name)
        {
            string[] fullName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstName = fullName[0];
            string lastName = fullName[1];
            Child childForRemoving = Registry.FirstOrDefault(x => x.FirstName == firstName
            && x.LastName == lastName);
            bool isRemoved = Registry.Remove(childForRemoving);
            if (isRemoved == true)
            {
                Capacity++;
            }
            return isRemoved;
        }
        public Child GetChild(string name)
        {
            string[] fullName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstName = fullName[0];
            string lastName = fullName[1];
            Child searchedChild = Registry.FirstOrDefault(x => x.FirstName == firstName
            && x.LastName == lastName);

            return searchedChild;
        }
        public string RegistryReport()
        {
            return $"Registered children in {Name}:" + Environment.NewLine +
                string.Join(Environment.NewLine, Registry.OrderByDescending(c => c.Age)
                .ThenBy(c => c.LastName)
                .ThenBy(c => c.FirstName)).TrimEnd();
        }
    }
}

