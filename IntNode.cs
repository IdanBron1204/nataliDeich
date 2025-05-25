using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    internal class IntNode
    {
        private int value;
        private IntNode nextNode;

        public IntNode(int value)
        {
            this.value = value;
            this.nextNode = null;
        }

        public IntNode(int value, IntNode next)
        {
            this.value = value;
            this.nextNode = next;
        }

        public int GetValue()
        {
            return this.value;
        }

        public IntNode GetNext()
        {
            return this.nextNode;
        }

        public bool HasNext()
        {
            return this.nextNode != null;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }

        public void SetNext(IntNode next)
        {
            this.nextNode = next;
        }

        public override string ToString()
        {
            return $"{this.value}\t"
               ;
        }
    }


}
