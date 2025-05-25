using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter3.Animal;

namespace Chapter3
{
    public class Dog:Animal
    {
        public int DogAge { get; set; }
        public Dog(int numOfLegs, bool isYonek, int lifeEx, color color1,int dogage)
            :base(numOfLegs, isYonek, lifeEx, color1)
        {            
            DogAge = dogage;
        }
        public override void MakeSound()
        {
            Console.WriteLine("woof woof");
        }         
    }
}
