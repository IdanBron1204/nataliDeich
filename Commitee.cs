using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Commitee
    {
        private string name;
        private Member[] members;
        private int count;
        private static int MAX = 16;
        public Commitee(string name, Member[] members, int count)
        {
            this.name = name;
            this.members = members;
            this.count = count;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public Member[] GetMembers()
        {
            return this.members;
        }

        public void SetMembers(Member[] value)
        {
            this.members = value;
        }

        public int GetCount()
        {
            return this.count;
        }

        public void SetCount(int value)
        {
            this.count = value;
        }
        public int Total(bool value)
        {
            int count = 0;
            for (int i = 0; i < count; i++)
            {
                if (this.members[i].GetIsCoal())
                    count++;
            }
            if(value)
                return count;
            return this.count-count;
        }
        public override string ToString()
        {
            return $"name: {this.name}";
        }
    }
}
