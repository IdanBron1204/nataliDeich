using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.SetName(name);
            this.SetAge(age);
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public int GetAge()
        {
            return this.age;
        }

        public void SetAge(int value)
        {
            this.age = value;
        }
    }
}
