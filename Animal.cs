using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Animal
    {
        public enum color
        {
            black,
            white,
            brown,
            blue,
            gray,
            orange,
            red,
            yellow,
            green
        }
        public int NumOfLegs { get; set; }        
        public bool IsYonek { get; set; }
        public int LifeEx { get; set; }
        public color Color1 { get; set; }
        public Animal(int numOfLegs, bool isYonek, int lifeEx, color color1)
        {
            NumOfLegs = numOfLegs;
            IsYonek = isYonek;
            LifeEx = lifeEx;
            Color1 = color1;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Animal animal = obj as Animal;
            return NumOfLegs == animal.NumOfLegs && IsYonek == animal.IsYonek && LifeEx == animal.LifeEx && Color1 == animal.Color1;
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Im an animal"); ;
        }

    }
}
