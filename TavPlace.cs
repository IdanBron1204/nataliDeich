using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class TavPlace
    {
        private char Tav;
        private int Place;

        public TavPlace(char tav, int place)
        {
            this.Tav = tav;
            this.Place = place;
        }

        public char GetTav()
        {
            return this.Tav;
        }

        public void SetTav(char value)
        {
            this.Tav = value;
        }

        public int GetPlace()
        {
            return this.Place;
        }

        public void SetPlace(int value)
        {
            this.Place = value;
        }
    }
}
