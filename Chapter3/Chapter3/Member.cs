using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Member
    {
        private string name;
        private bool isCoal;

        public Member(string name, bool isCoal)
        {
            this.SetName(name);
            this.SetIsCoal(isCoal);
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public bool GetIsCoal()
        {
            return this.isCoal;
        }

        public void SetIsCoal(bool value)
        {
            this.isCoal = value;
        }

        public override string ToString()
        {
            return $"name: {this.GetName()}\n" +
                $"isCoal: {this.GetIsCoal()}";
        }
    }
}
