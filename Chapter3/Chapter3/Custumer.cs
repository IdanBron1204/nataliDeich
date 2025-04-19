using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Custumer
    {
        public string Name {  get; set; }
        public string LastName { get; set; }
        public Custumer(string name, string lastName) 
        { 
            Name = name;
            LastName = lastName;            
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Lastname: {LastName}";
        }
    }
}
