using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }
        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.people.MaxBy(p => p.Age);
        }
    }
}
