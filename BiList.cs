using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class BiList
    {
        private Node<int> lst1;
        private Node<int> lst2;

        public Node<int> GetLst1()
        {
            return lst1;
        }

        public void SetLst1(Node<int> value)
        {
            lst1 = value;
        }

        public Node<int> GetLst2()
        {
            return this.lst2;
        }

        public void SetLst2(Node<int> value)
        {
            this.lst2 = value;
        }

        public BiList()
        {
            SetLst1(null);
            SetLst2(null);
        }
        public void AddNum(int num, int codeList)
        {
            if (codeList == 1)
            {
                if (this.lst1 == null)
                    this.lst1 = new Node<int>(num);
                else
                {
                    Node<int> pos = this.lst1;
                    while (pos.GetNext() != null)
                        pos = pos.GetNext();
                    pos.SetNext(new Node<int>(num));
                }
            }
            if (codeList == 2)
            {
                if (this.lst2 == null)
                    this.lst2 = new Node<int>(num);
                else
                {
                    Node<int> pos = this.lst2;
                    while (pos.GetNext() != null)
                        pos = pos.GetNext();
                    pos.SetNext(new Node<int>(num));
                }
            }
        }
    }
}
