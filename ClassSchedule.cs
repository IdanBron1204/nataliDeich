using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class ClassSchedule
    {
        private Node<Subject> Scedule;
        public ClassSchedule(Node<Subject> scedule)
        {
            this.Scedule = scedule;
        }
        public Node<Subject> GetN()
        {
            return this.Scedule;
        }
        public void SetN(Node<Subject> V)
        {
            this.Scedule=V;
        }
        public int CountN<T>(Node<T> n)
        {
            Node<T> pos = n;
            int count = 0;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
        public bool TestHours()
        {
            return CountN(this.Scedule) > 40;
        }
        public int RemoveC(string Code)
        {
            int count = 0;            
            while (this.Scedule != null&&this.Scedule.GetValue().GetCode() == Code)
            {
                count++;
                this.Scedule = this.Scedule.GetNext();
            }
            Node<Subject> pos = this.Scedule;
            if (pos != null)
            {
                while (pos.GetNext() != null)
                {
                    if (pos.GetNext().GetValue().GetCode() == Code)
                    {
                        count++;
                        pos.SetNext(pos.GetNext().GetNext());
                    }
                    else  pos = pos.GetNext();                   
                }
            }
            return count;
        }
       
        
    }
}
