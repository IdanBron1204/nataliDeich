using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Key
    {
        private char press;
        private int sec;

        public Key(char press, int sec)
        {
            this.SetPress(press);
            this.SetSec(sec);
        }

        public char GetPress()
        {
            return this.press;
        }

        public void SetPress(char value)
        {
            this.press = value;
        }

        public int GetSec()
        {
            return this.sec;
        }

        public void SetSec(int value)
        {
            this.sec = value;
        }
    }
}
