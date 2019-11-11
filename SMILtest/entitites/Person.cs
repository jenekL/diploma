using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMILtest.entitites
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public Person(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return Name + " " + Age.ToString() + " " + Sex;
        }
    }
}
