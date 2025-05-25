using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    internal class Student
    {
        private string name;
        private int avgGrade;
        public Student(string name, int avggrade)
        {
            this.name = name;
            this.avgGrade = avggrade;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetName(string value)
        {
            this.name = value;
        }
        public int GetAvgGrade()
        {
            return this.avgGrade;
        }
        public void SetAvgGrade(int value)
        {
            this.avgGrade = value;
        }
        public override string ToString()
        {
            return $"Name: {this.name}\n" +
                $"AvgGrade: {this.avgGrade}\n";
        }

    }
}
