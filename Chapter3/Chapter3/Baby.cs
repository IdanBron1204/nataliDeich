using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Baby
    {
        private string name;
        private bool isBro;

        public Baby(string name, bool isBro) 
        {
            this.name = name;
            this.isBro = isBro; 
        }
        public Baby(string name) 
        {
            this.name = name; 
            this.isBro = false;
        }
    }
    public class Gan
    {
        private Baby[] arrBabies;
        private int current;
        public Gan()
        {
            this.arrBabies = new Baby[2];
            this.current = 0;
        }
        public void AddBaby(Baby baby)
        {
            if (current < arrBabies.Length)
            {
                this.arrBabies[current] = baby;
                this.current++;
            }
        }
    }
}
