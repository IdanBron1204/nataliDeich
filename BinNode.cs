using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{

    public class BinNode<T>
    {
        private BinNode<T> left;//(L,0,R)
        private T value;
        private BinNode<T> right;//(NULL,VALUE,NULL)

        public BinNode(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public BinNode(BinNode<T> left, T value, BinNode<T> right)
        {
            this.left = left;
            this.value = value;
            this.right = right;
        }

        public T GetValue()
        {
            return value;
        }

        public BinNode<T> GetLeft()
        {
            return left;
        }

        public BinNode<T> GetRight()
        {
            return right;
        }

        public bool HasLeft()
        {
            return (left != null);
        }

        public bool HasRight()
        {
            return (right != null);
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetLeft(BinNode<T> left)
        {
            this.left = left;
        }

        public void SetRight(BinNode<T> right)
        {
            this.right = right;
        }

        // This method was added to use for printing Tree
        public override string ToString()
        {
            return "(" + this.left + "," + this.value + "," + this.right + ")";
        }

    }




}

