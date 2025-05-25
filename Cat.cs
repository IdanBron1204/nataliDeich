using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Cat : Animal
    {
        public int CatAge { get; set; }
        public Cat(int numOfLegs, bool isYonek, int lifeEx, color color1, int catage)
            : base(numOfLegs, isYonek, lifeEx, color1)
        {
            CatAge = catage;
        }
        public override void MakeSound()
        {
            Console.WriteLine("meow");
        }

    }
}
