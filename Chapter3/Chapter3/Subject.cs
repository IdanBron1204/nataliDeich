using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Subject
    {
        private int Day;
        private int Hour;
        private string Code;
        public Subject(int day, int hour, string code)
        {
            this.Day = day;
            this.Hour = hour;
            this.Code = code;
        }

        public int GetDay()
        {
            return this.Day;
        }

        public void SetDay(int value)
        {
            this.Day = value;
        }

        public int GetHour()
        {
            return this.Hour;
        }

        public void SetHour(int value)
        {
            this.Hour = value;
        }

        public string GetCode()
        {
            return this.Code;
        }

        public void SetCode(string value)
        {
            this.Code = value;
        }
        public bool TestDouble(Subject s)
        {
            if (s.Day == this.Day && s.Hour == this.Hour)
                 return true ;
            return false ;
        }
    }
}
