using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class SmartHomeHub
    {
        Refrigerator Refrigerator = new Refrigerator();

        public void SendToSpeaker()
        {
            if (Refrigerator.IsClosed)
            {
                Console.WriteLine("beep beep beep");
            }
        }
    }
}
