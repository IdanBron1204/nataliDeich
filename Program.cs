﻿using Microsoft.Win32.SafeHandles;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.Schema;


namespace Chapter3
{
    public class Program
    {

        static bool Ex1<T>(Node<T> node)
        {
            Node<T> pos = node.GetNext();
            if (node == null) return false;
            while (pos != null && pos != node)
                pos = pos.GetNext();
            return pos == node;
        }
        public static void Ex2(Node<int> lst)
        {
            int s;
            Node<int> first = lst;
            Node<int> pos = lst.GetNext();
            while (pos != lst)
            {
                s = first.GetValue() + pos.GetValue();
                first.SetNext(new Node<int>(s, pos));
                first = pos;
                pos = pos.GetNext();
            }
            s = first.GetValue() + pos.GetValue();
            first.SetNext(new Node<int>(s, pos));
        }
        static bool IsFixed(ClassSchedule cs)
        {
            Node<Subject> pos = cs.GetN();
            int day, hour;
            while (pos.GetNext() != null)
            {
                day = pos.GetValue().GetDay();
                hour = pos.GetValue().GetHour();
                if (pos.GetNext().GetValue().GetDay() < day ||
                    (pos.GetNext().GetValue().GetDay() == day && pos.GetNext().GetValue().GetHour() < hour))
                    return false;
                pos = pos.GetNext();
            }
            return true;
        }
        public static Node<int> Delete(int num, Node<int> list)
        {

            Node<int> dummy = new Node<int>(-999, list);
            Node<int> curr = dummy;

            while (curr.HasNext())
            {
                if (curr.GetNext().GetValue() == num)
                {

                    curr.SetNext(curr.GetNext().GetNext());
                }
                else
                {
                    curr = curr.GetNext();
                }
            }
            return dummy.GetNext();
        }
        static int MaxN(Node<int> N)
        {
            int max = int.MinValue;
            Node<int> pos = N;
            while (pos != null)
            {
                max = Math.Max(max, pos.GetValue());
                pos = pos.GetNext();
            }
            return max;
        }
        static int LengthN<T>(Node<T> N)
        {
            int count = 0;
            Node<T> pos = N;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
        static int TreeHowMuchKids<T>(BinNode<T> tree)
        {
            if (tree == null || !tree.HasRight() && !tree.HasLeft())
                return 0;
            else if ((!tree.HasRight() && tree.HasLeft()) || (tree.HasRight() && !tree.HasLeft()))
                return 1;
            else
                return 2;
        }
        public static bool IsLeaf<T>(BinNode<T> bt)
        {
            return (bt.GetLeft() == bt.GetRight());
        }
        static bool Is_LeftistTree<T>(BinNode<T> binNode)
        {
            if (TreeHowMuchKids(binNode) == 0)
            {
                return true;
            }
            if (binNode.HasLeft() && binNode.HasRight())
            {
                return IsLeaf(binNode.GetRight()) && Is_LeftistTree(binNode.GetLeft());
            }
            return false;
        }
        public static bool What(BinNode<int> t)
        {
            if (t == null || IsLeaf(t))
                return true;
            if (t.GetValue() != t.GetRight().GetValue() + t.GetLeft().GetValue())
                return false;
            return What(t.GetLeft());
        }
        /*static BiList GenerateBilist(Node<int> lst)
        {
            BiList biList = new BiList();
            for(int i =0;i<)

        }*/
        static string TavPlaceExA(Node<TavPlace> N)
        {
            int length = LengthN(N);
            char[] arr = new char[length];
            string text = "";
            Node<TavPlace> pos = N;
            while (pos != null)
            {
                int index = pos.GetValue().GetPlace() - 1;
                arr[index] = pos.GetValue().GetTav();
                pos = pos.GetNext();
            }
            for (int i = 0; i < arr.Length; i++)
                text += arr[i];
            return text;
        }
        static bool TavPlaceExB(Node<TavPlace> N, string[] arr)
        {
            string str = TavPlaceExA(N);
            for (int i = 0; i < arr.Length; i++)
            {
                if (str == arr[i])
                {
                    return true;
                }
            }
            return false;
        }
        public int Tree3ExA(BinNode<string> root)
        {
            if (root == null)
            {
                return 0;
            }
            // אם הצומת הוא עלה (מספר)
            if (root.GetLeft() == null && root.GetRight() == null)
            {
                return int.Parse(root.GetValue());
            }
            // חישוב עבור תתי העצים
            int leftValue = Tree3ExA(root.GetLeft());
            int rightValue = Tree3ExA(root.GetRight());

            // חישוב לפי האופרטור בצומת הנוכחי
            switch (root.GetValue())
            {
                case "+":
                    return leftValue + rightValue;
                case "-":
                    return leftValue - rightValue;
                case "*":
                    return leftValue * rightValue;
                case "/":
                    return leftValue / rightValue;
            }
            return 0;
        }
        static bool Tree3Ex1(BinNode<string> root)
        {
            if (root == null)
                return true;
            if (root.HasLeft() && root.HasRight())
            {
                switch (root.GetValue())
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        return Tree3Ex1(root.GetLeft()) && Tree3Ex1(root.GetRight());
                    default:
                        return false;
                }
            }
            if ((root.HasLeft() && !root.HasRight()) || (!root.HasLeft() && root.HasRight()))
                return false;
            switch (root.GetValue())
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return false;
                default:
                    return true;
            }

        }
        public static int NumNodes(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            return 1 + NumNodes(bt.GetLeft()) + NumNodes(bt.GetRight());
        }
        public static int NumPositive(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.GetValue() > 0)
                return 1 + NumPositive(bt.GetLeft()) + NumPositive(bt.GetRight());
            return NumPositive(bt.GetLeft()) + NumPositive(bt.GetRight());
        }
        public static int SumPositive(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.GetValue() > 0)
            {
                return bt.GetValue() + SumPositive(bt.GetLeft()) + SumPositive(bt.GetRight());
            }
            return SumPositive(bt.GetLeft()) + SumPositive(bt.GetRight());
        }
        public static int CountLeftSons(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.HasLeft())
                return 1 + CountLeftSons(bt.GetLeft()) + CountLeftSons(bt.GetRight());
            return CountLeftSons(bt.GetLeft()) + CountLeftSons(bt.GetRight());
        }
        public static int SumLeftSons(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.HasLeft())
                return bt.GetLeft().GetValue() + SumLeftSons(bt.GetLeft()) + SumLeftSons(bt.GetRight());
            return SumLeftSons(bt.GetRight());
        }

        public static int CountLeaves(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (IsLeaf(bt))
                return 1;
            return CountLeaves(bt.GetLeft()) + CountLeaves(bt.GetRight());
        }
        public static int SumLeaves(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (IsLeaf(bt))
                return bt.GetValue();
            return SumLeaves(bt.GetLeft()) + SumLeaves(bt.GetRight());
        }
        public static int MaxInTree(BinNode<int> bt)
        {
            if (bt == null)
                return 0;
            int maxLeft = MaxInTree(bt.GetLeft());
            int maxRight = MaxInTree(bt.GetRight());

            return Math.Max(bt.GetValue(), Math.Max(maxLeft, maxRight));
        }
        public static int Height(BinNode<int> bt)
        {
            if (bt == null) return -1;
            if (IsLeaf(bt)) return 0;
            return 1 + Math.Max(Height(bt.GetLeft()), Height(bt.GetRight()));
        }
        //          האם עץ מאוזן?
        //          עץ מאוזן - עץ שבו לכל צומת, הפרש הגבהים 
        //          1 של שני בניו אינו עולה על 
        public static bool IsBalancedTree(BinNode<int> bt)
        {
            if (bt == null || IsLeaf(bt))
                return true;
            if (Math.Abs(Height(bt.GetLeft()) - Height(bt.GetRight())) > 1)
                return false;
            return IsBalancedTree(bt.GetLeft()) &&
                    IsBalancedTree(bt.GetRight());
        }


        static void Main(string[] args)
        {
            Queue<int>[] arr = new Queue<int>[2];

            // First queue: 1, 3, 4, 7
            arr[0] = new Queue<int>();
            arr[0].Insert(1);
            arr[0].Insert(3);
            arr[0].Insert(4);
            arr[0].Insert(7);

            // Second queue: 2, 5, 6
            arr[1] = new Queue<int>();
            arr[1].Insert(2);
            arr[1].Insert(5);
            arr[1].Insert(6);

            // Call Complete
            Node<int>[] missing = Complete(arr);

            // Print results
            for (int i = 0; i < missing.Length; i++)
            {
                Console.Write($"Missing in queue {i}: ");
                Node<int> current = missing[i];
                while (current != null)
                {
                    Console.Write(current.GetValue() + " ");
                    current = current.GetNext();
                }
                Console.WriteLine();
            }
        }

        // Your Complete method goes here or imported


        public static Node<int>[] Complete(Queue<int>[] arr)
        {
            Node<int>[] newArr = new Node<int>[arr.Length];
            Node<int> pos;
            Node<int> newNode;
            for (int i = 0; i < arr.Length; i++)
            {
                pos = null;
                newNode = null;
                if (!arr[i].IsEmpty())
                {
                    for (int j = arr[i].Head(); j < QueueMax(arr[i]); j++)
                    {
                        if (!QueueIsExist(arr[i], j))
                        {
                            if (newNode == null)
                            {
                                newNode = new Node<int>(j);
                                pos = newNode;
                            }
                            else
                            {
                                pos.SetNext(new Node<int>(j));
                                pos = pos.GetNext();
                            }
                        }
                    }
                }
                newArr[i] = newNode;
            }
            return newArr;
        }


        static int QueueMin(Queue<int> q)
        {
            int min = q.Head();
            Queue<int> tempQ = new Queue<int>();
            while (!q.IsEmpty())
            {
                int val = q.Remove();
                min = Math.Min(min, val);
                tempQ.Insert(val);
            }
            while (!tempQ.IsEmpty())
                q.Insert(tempQ.Remove());
            return min;
        }
        static int QueueMax(Queue<int> q)
        {
            int max = q.Head();
            Queue<int> tempQ = new Queue<int>();
            while (!q.IsEmpty())
            {
                int val = q.Head();
                max = Math.Max(max, val);
                tempQ.Insert(q.Remove());
            }
            while (!tempQ.IsEmpty())
                q.Insert(tempQ.Remove());
            return max;
        }
        static void Removenum(Queue<int> q, int num)
        {
            Queue<int> tempQ = new Queue<int>();
            while (!q.IsEmpty())
            {
                int val = q.Remove();
                if (val != num)
                    tempQ.Insert(val);
            }
            while (!tempQ.IsEmpty())
                q.Insert(tempQ.Remove());
        }
        static bool IsSidra(Queue<int> queue)
        {
            int n = QueueLength(queue);
            Queue<int> q = QueueClone(queue);
            int num1 = QueueMin(q);
            Removenum(q, num1);
            int secondMin = QueueMin(q);
            int sub = secondMin - num1;
            q = QueueClone(queue);
            for (int i = 0; i < n; i++)
            {
                int expected = num1 + i * sub;
                if (!QueueIsExist(q, expected))
                    return false;
                else
                    Removenum(q, expected);
            }
            return true;
        }

        static bool ExTreeBool(BinNode<string> t)
        {
            if (IsLeaf(t))
            {
                if (t.GetValue() == "true")
                    return true;
                else return false;
            }
            else if (t.GetValue() == "AND")
                return ExTreeBool(t.GetRight()) && ExTreeBool(t.GetLeft());
            else if (t.GetValue() == "OR")
                return ExTreeBool(t.GetRight()) || ExTreeBool(t.GetLeft());
            else
                return !ExTreeBool(ReturnUnNull(t));
        }
        static int ExTreeBoolB(BinNode<string> t)// - o(n)
        {
            int count = 0;// - o(1)
            if (t == null)// - o(1)
            {
                return 0;// - o(1)
            }
            if (ExTreeBool(t))// - o(n)
                count = 1;// - o(1)
            return count + ExTreeBoolB(t.GetLeft()) + ExTreeBoolB(t.GetRight());// - o(1)
        }// n*(n+5) = n^2 + 5n = n^2 = o(n^2)

        static bool IsPivot(Queue<int> queue, int pivot)
        {
            int countMiddle = 0;
            int countOut = 0;
            Queue<int> q = QueueClone(queue);
            if (CountX(q, pivot) != 2 || q.IsEmpty())
                return false;
            while (q.Head() != pivot)
            {
                countOut += q.Remove();
            }
            q.Remove();
            while (q.Head() != pivot)
            {
                countMiddle += q.Remove();
            }
            q.Remove();
            while (!q.IsEmpty())
                countOut += q.Remove();
            return countMiddle == countOut;
        }
        static Node<Queue<int>> IsPivotB(Node<Queue<int>> n, int pivot)
        {
            Node<Queue<int>> d = null;
            while (n != null)
            {
                if (IsPivot(n.GetValue(), pivot))
                {
                    d = new Node<Queue<int>>(n.GetValue(), d);
                }
                n = n.GetNext();
            }
            return d;
        }

        static bool IsNodeKey(Node<Key> nodeK, Node<char> nodeC, int t)
        {
            int passwordLength = ChainT.GetCount(nodeC);

            while (nodeK != null)
            {
                if (ChainT.GetCount(nodeK) < passwordLength)
                    return false;

                Node<Key> tempK = nodeK;
                Node<char> tempC = nodeC;
                int count = 0;
                bool isFirstPress = true;

                while (tempC != null
                       && tempK != null
                       && tempC.GetValue() == tempK.GetValue().GetPress()
                       && (isFirstPress || count + tempK.GetValue().GetSec() <= t))
                {
                    if (isFirstPress)
                    {
                        isFirstPress = false;
                    }
                    else
                    {
                        count += tempK.GetValue().GetSec();
                    }

                    tempC = tempC.GetNext();
                    tempK = tempK.GetNext();
                }

                if (tempC == null && count <= t)
                    return true;

                nodeK = nodeK.GetNext();
            }

            return false;
        }

        static int Tree2Ex1(BinNode<int> b)
        {
            if (b == null)
                return 0;
            return b.GetValue() +
                Tree2Ex1(b.GetLeft()) +
                Tree2Ex1(b.GetRight());
        }
        static int Tree2ExA(BinNode<int> b)
        {
            if (b == null)
                return 0;
            return 1 +
                Tree2ExA(b.GetLeft()) +
                Tree2ExA(b.GetRight());
        }
        static int Tree2Ex2(BinNode<int> b)
        {
            if (b == null)
                return 0;
            if (!b.HasLeft() && !b.HasRight())
                return 1;
            return Tree2Ex2(b.GetLeft()) + Tree2Ex2(b.GetRight());
        }
        static bool Tree2Ex4(BinNode<int> b)
        {
            return Tree2ExA(b) == Math.Pow(2, Height(b) + 1) - 1;
        }

        static int Tree2Ex3(BinNode<int> b, int high, int low)
        {
            if (b == null)
                return 0;
            if (b.GetValue() < high && b.GetValue() > low)
                return 1 + Tree2Ex3(b.GetLeft(), high, low) + Tree2Ex3(b.GetRight(), high, low);
            return Tree2Ex3(b.GetLeft(), high, low) + Tree2Ex3(b.GetRight(), high, low);
        }

        static int TreeLength(BinNode<int> tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return TreeLength(tree.GetLeft()) + TreeLength(tree.GetRight()) + 1;
        }
        static int TreeEx1(BinNode<int> tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return TreeEx1(tree.GetLeft()) + TreeEx1(tree.GetRight()) + tree.GetValue();
        }
        static int TreeEx2(BinNode<int> tree)
        {
            if (tree.GetRight() == null && tree.GetLeft() == null)
            {
                return 1;
            }
            else if (tree == null)
                return 0;
            return TreeEx2(tree.GetLeft()) + TreeEx2(tree.GetRight());
        }
        static int TreeEx3(BinNode<int> tree, int min, int max)
        {
            if (tree == null)
                return 0;
            else if (tree.GetValue() > min && tree.GetValue() < max)
            {
                return 1 + TreeEx3(tree.GetLeft(), min, max) + TreeEx3(tree.GetRight(), min, max);
            }

            return TreeEx3(tree.GetLeft(), min, max) + TreeEx3(tree.GetRight(), min, max);
        }
        static bool TreeIsLeaf(BinNode<int> tree)
        {
            return tree.GetRight() == null && tree.GetLeft() == null;
        }

        static int TreeEx5(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            else if (TreeHowMuchKids(tree) != 1)
                return TreeEx5(tree.GetLeft()) + TreeEx5(tree.GetRight());
            else
            {
                return 1 + TreeEx5(tree.GetLeft()) + TreeEx5(tree.GetRight());
            }

        }
        static int TreeEx6(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            else if (TreeHowMuchKids(tree) != 2)
                return TreeEx6(tree.GetLeft()) + TreeEx6(tree.GetRight());
            else
            {
                return tree.GetValue() + TreeEx6(tree.GetLeft()) + TreeEx6(tree.GetRight());
            }

        }
        static bool TreeIsExist(BinNode<int> tree, int num)
        {
            if (tree == null)
                return false;
            else if (tree.GetValue() == num)
                return true;
            return TreeIsExist(tree.GetLeft(), num) || TreeIsExist(tree.GetRight(), num);
        }
        static int TreeMaxValue(BinNode<int> t)
        {
            if (t == null) return int.MinValue;
            else return Math.Max(t.GetValue(), Math.Max(TreeMaxValue(t.GetLeft()), TreeMaxValue(t.GetRight())));
        }

        static int TreeSubMaxToMin(BinNode<int> t)
        {
            return TreeMaxValue(t) - TreeMinValue(t);
        }
        static int TreeSum(BinNode<int> t)
        {
            if (t == null)
                return 0;
            return t.GetValue() + TreeSum(t.GetLeft()) + TreeSum(t.GetRight());
        }
        static bool TreeFollowedN(BinNode<int> t, int n)
        {
            if (TreeLength(t) == n)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (!TreeIsExist(t, i))
                        return false;
                }
                return true;
            }
            else
                return false;
        }
        static bool TreeDoesHasSingleKids(BinNode<int> t)
        {
            if (t == null)
                return false;
            else if (TreeHowMuchKids(t) == 1)
                return true;
            return false || TreeDoesHasSingleKids(t.GetLeft()) || TreeDoesHasSingleKids(t.GetRight());
        }
        static int TreeMinValue(BinNode<int> t)
        {
            if (t == null) return int.MaxValue;
            else return Math.Min(t.GetValue(), Math.Min(TreeMinValue(t.GetLeft()), TreeMinValue(t.GetRight())));
        }
        static bool TreeIsFullTree(BinNode<int> t)
        {
            return !TreeDoesHasSingleKids(t);
        }
        static BinNode<T> ReturnUnNull<T>(BinNode<T> t)
        {
            if (t.GetLeft() == null)
                return t.GetRight();
            return t.GetLeft();

        }
        static bool TreeIsT2InT1(BinNode<int> t1, BinNode<int> t2)
        {
            if (t2 == null)
                return true;
            return TreeIsExist(t1, t2.GetValue()) &&
                TreeIsT2InT1(t1, t2.GetLeft()) && TreeIsT2InT1(t1, t2.GetRight());
        }

        static Node<int> Split(Node<int> list)
        {
            int n = list.GetValue() % 2;
            Node<int> newN = null, pos = null;
            while (list != null)
            {
                if (list.GetValue() % 2 != n)
                {
                    if (newN == null)
                    {
                        newN = new Node<int>(list.GetValue());
                        pos = newN;
                    }
                    else
                    {
                        pos.SetNext(new Node<int>(list.GetValue()));
                        pos = pos.GetNext();
                    }
                }
                list = list.GetNext();
            }
            return newN;
        }

        static bool Ex6A_(Node<int> node)
        {
            int sum = 0;
            Node<int> pos = node;
            while (pos != null)
            {
                if (sum > pos.GetValue())
                    return false;
                sum += pos.GetValue();
                pos = pos.GetNext();
            }
            return true;
        }
        static Node<int> AddToFinish(Node<int> node, int value)
        {
            if (node == null)
                return new Node<int>(value);
            Node<int> pos = node;
            while (pos.GetNext() != null)
                pos = pos.GetNext();
            pos.SetNext(new Node<int>(value));
            return node;
        }
        static bool Ex6B_(Queue<Node<int>> queue, int num)
        {
            Queue<Node<int>> q = QueueClone(queue);
            while (!q.IsEmpty())
            {
                if (!Ex6A_(AddToFinish(q.Remove(), num)))
                    return false;
            }
            return true;
        }
        static Queue<T> QueueClone<T>(Queue<T> q)
        {
            Queue<T> tmp = new Queue<T>();
            Queue<T> clone = new Queue<T>();
            while (!q.IsEmpty())
            {
                tmp.Insert(q.Head());
                clone.Insert(q.Remove());
            }
            while (!tmp.IsEmpty())
            {
                q.Insert(tmp.Remove());
            }
            return clone;
        }

        static int CountX(Queue<int> q, int num)
        {
            int dummy = -999999999;
            int count = 0;
            q.Insert(dummy);
            while (q.Head() != dummy)
            {
                if (q.Head() == num)
                {
                    count++;
                    q.Remove();
                }
                else { q.Insert(q.Remove()); }
            }
            q.Remove();
            return count;
        }
        static Queue<int> Ex1BTest(Queue<int> q)
        {
            int num;
            Queue<int> temp = QueueClone(q);
            Queue<int> newq = new Queue<int>();
            while (!temp.IsEmpty())
            {
                num = temp.Head();
                int number = CountX(temp, num);
                for (int i = 0; i < number; i++)
                {
                    newq.Insert(num);
                }
                Console.WriteLine(num);
            }
            return newq;
        }
        static void QueueInsertDummy(Queue<string> q)
        {
            int i = 1, j = 1;
            q.Insert("`");
            while (q.Head() != "`")
            {
                q.Insert(q.Remove());
                if ((i + j) % 3 == 0)
                {
                    q.Insert("Dummy");
                    j++;
                }
                i++;
            }
            q.Remove();
        }

        static void QueueDymmy(Queue<int> q)
        {
            int num = -999999;
            q.Insert(num);
            q.Insert(0);
            while (q.Head() != num)
            {
                q.Insert(q.Remove());
            }
            q.Remove();
        }

        static Node<T> QueueToNode<T>(Queue<T> q)
        {
            Node<T> node = new Node<T>(q.Remove());
            Node<T> pos = node;
            while (!q.IsEmpty())
            {
                pos.SetNext(new Node<T>(q.Remove()));
                pos = pos.GetNext();
            }
            return node;
        }
        static Queue<T> NodeToQueue<T>(Node<T> node)
        {
            Queue<T> q = new Queue<T>();
            while (node != null)
            {
                q.Insert(node.GetValue());
                node = node.GetNext();
            }
            return q;
        }
        static bool QueueIsPalindrom<T>(Queue<T> q)
        {
            Queue<T> tmp = QueueReverse(QueueClone(q));
            while (!q.IsEmpty())
            {
                if (!q.Head().Equals(tmp.Head()))
                    return false;
                q.Remove();
                tmp.Remove();
            }
            return true;
        }
        static T QueueRemoveFromPlace<T>(Queue<T> q, int num)
        {
            Queue<T> start = new Queue<T>();
            for (int i = 0; i < num - 1; i++)
                start.Insert(q.Remove());
            T value = q.Remove();
            while (!q.IsEmpty())
                start.Insert(q.Remove());
            while (!start.IsEmpty())
                q.Insert(start.Remove());
            return value;
        }
        static bool QueueIsGrowing(Queue<int> q)
        {
            Queue<int> tmp = QueueClone(q);
            tmp.Remove();
            while (!tmp.IsEmpty())
            {
                if (tmp.Head() <= q.Head())
                    return false;
                tmp.Remove();
                q.Remove();
            }
            return true;
        }
        static void QueueInsertGrowing(Queue<int> q, int num)
        {
            Queue<int> start = new Queue<int>();
            while (q.Head() < num)
                start.Insert(q.Remove());
            start.Insert(num);
            while (!q.IsEmpty())
                start.Insert(q.Remove());
            while (!start.IsEmpty())
                q.Insert(start.Remove());
        }
        static Queue<T> QueueOnlyTwice<T>(Queue<T> q)
        {
            Queue<T> tmp = new Queue<T>();
            Queue<T> full = QueueClone(q);
            while (!q.IsEmpty())
            {
                if (!QueueIsExist(tmp, q.Head()) && HowMuch(full, q.Head()) == 2)
                    tmp.Insert(q.Remove());
                else q.Remove();
            }
            return tmp;
        }
        static int QueueReturnSet(Queue<int> q, int num)
        {
            int count = 0;
            while (!q.IsEmpty())
            {
                if (q.Head() == num && count == 0)
                    count++;
                if (q.Head() == num * -1 && count > 0)
                    return count;
                if (count > 0)
                    count++;
                q.Remove();
            }
            return -1;
        }
        static void QueueJoin<T>(Queue<T> q1, Queue<T> q2)
        {
            Queue<T> tmp = new Queue<T>();
            while (!q1.IsEmpty())
                tmp.Insert(q1.Remove());
            while (!tmp.IsEmpty() && !q2.IsEmpty())
            {
                q1.Insert(tmp.Remove());
                q1.Insert(q2.Remove());
            }
            while (!q2.IsEmpty())
                q1.Insert(q2.Remove());
            while (!tmp.IsEmpty())
                q1.Insert(tmp.Remove());
        }
        static Queue<int> QueueJoinGrowing(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> q = new Queue<int>();
            while (!q1.IsEmpty() && !q2.IsEmpty())
            {
                if (q1.Head() < q2.Head())
                    q.Insert(q1.Remove());
                else q.Insert(q2.Remove());
            }
            while (!q1.IsEmpty())
                q.Insert(q1.Remove());
            while (!q2.IsEmpty())
                q.Insert(q2.Remove());
            return q;
        }
        static void QueueJoinGrowingVoid(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> tmp = new Queue<int>();
            while (!q1.IsEmpty())
                tmp.Insert(q1.Remove());
            while (!tmp.IsEmpty() && !q2.IsEmpty())
            {
                if (tmp.Head() < q2.Head())
                    q1.Insert(tmp.Remove());
                else q1.Insert(q2.Remove());
            }
            while (!tmp.IsEmpty())
                q1.Insert(tmp.Remove());
            while (!q2.IsEmpty())
                q1.Insert(q2.Remove());
        }
        static void QueueJoinPerson(Queue<Person> q1, Queue<Person> q2)
        {
            Queue<Person> tmp = new Queue<Person>();
            while (!q1.IsEmpty())
                tmp.Insert(q1.Remove());
            while (!tmp.IsEmpty() && !q2.IsEmpty())
            {
                if (tmp.Head().GetAge() < q2.Head().GetAge())
                    q1.Insert(tmp.Remove());
                else
                    q1.Insert(q2.Remove());
            }
            while (!tmp.IsEmpty())
                q1.Insert(tmp.Remove());

            while (!q2.IsEmpty())
                q1.Insert(q2.Remove());
        }

        static Queue<T> QueueExA<T>(T[] arr)
        {
            Queue<T> q = new Queue<T>();
            for (int i = 0; i < arr.Length; i++)
                q.Insert(arr[i]);
            return q;
        }
        static int QueueExB(Queue<int> q)
        {
            int count = 0, sum = 0;
            while (!q.IsEmpty())
            {
                count++;
                sum += q.Remove();
            }
            return sum / count;
        }
        static int QueueExC(Queue<int> q)
        {
            int count = 0, sum = 0;
            q.Insert(0);
            while (q.Head() != 0)
            {
                count++;
                sum += q.Head();
                q.Insert(q.Remove());
            }
            return sum / count;
        }
        static int QueueLength<T>(Queue<T> q)
        {
            int count = 0;
            while (!q.IsEmpty())
            {
                count++;
                q.Remove();
            }
            return count;
        }
        static Queue<T> QueueReverse<T>(Queue<T> q)
        {
            if (q.IsEmpty())
                return q;
            T x = q.Remove();
            QueueReverse(q);
            q.Insert(x);
            return q;
        }
        static int QueueSizeR<T>(Queue<T> q)
        {
            if (q.IsEmpty())
                return 0;
            q.Remove();
            return 1 + QueueSizeR(q);
        }

        static bool QueueIsExist<T>(Queue<T> q, T value)
        {
            Queue<T> tmp = QueueClone(q);
            while (!tmp.IsEmpty())
            {
                if (value.Equals(tmp.Remove()))
                    return true;
            }
            return false;
        }

        static bool QueueEx3<T>(Queue<T> q, T value)
        {
            if (q.IsEmpty())
                return false;
            if (value.Equals(q.Remove()))
                return true;
            return QueueEx3(q, value);
        }
        static bool QueueEx4<T>(Queue<T> q, T value)
        {
            int count = 0;
            while (!q.IsEmpty())
            {
                if (value.Equals(q.Remove()))
                    count++;
                else count = 0;
                if (count > 1)
                    return true;
            }
            return false;
        }
        static int HowMuch<T>(Queue<T> q, T value)
        {
            int count = 0;
            Queue<T> tmp = QueueClone(q);
            while (!tmp.IsEmpty())
            {
                if (value.Equals(tmp.Remove()))
                    count++;
            }
            return count;
        }
        static void QueueEx5(Queue<int> q)
        {
            int n;
            Queue<int> tmp = new Queue<int>();
            while (!q.IsEmpty())
            {
                n = q.Remove();
                if (!QueueIsExist(q, n))
                    tmp.Insert(n);
            }
            while (!tmp.IsEmpty())
                q.Insert(tmp.Remove());
        }
        static int[] SortArr(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Swap numbers[j] and numbers[j + 1]
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }
        static int Ex3I(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1] + i)
                    return i;
            }
            return -1;
        }

        public string PrintArr<T>(T[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
                str += $"{arr[i]}, ";
            return str + "\n";
        }
        static void Ex2I(Actor[] arr, int num)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetNumFilms() > num)
                    count++;
            }
            Console.WriteLine(count);
        }

        static void Ex37I(string str)
        {
            string strNew = "", message;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    strNew += str[i];
                }
                if ((str[i] == ' ' || i == str.Length - 1))
                {
                    if (strNew[strNew.Length - 1] == 'a' || strNew[strNew.Length - 1] + "" + strNew[strNew.Length - 2] == "ot")
                        message = "female";
                    else message = "male";
                    Console.WriteLine(strNew + $", {message}");
                    strNew = "";
                }
            }

        }
        static int Ex38I(string str1, string str2)
        {
            string strS = "";
            int index = -1;
            for (int i = 0; i < str1.Length - str2.Length + 1; i++)
            {
                strS = str1.Substring(i, str2.Length);
                if (strS == str2)
                {
                    index = i;
                }
            }
            return index;
        }
        static bool IsPalindrome(int[] arr)
        {
            int left = 0, right = arr.Length - 1;

            while (left < right)
            {
                if (arr[left] != arr[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        static int[] RemoveInt(int[] arr, int index)
        {
            int i = 0, count = 0;
            int[] newArr = new int[arr.Length - 1];
            while (i < arr.Length)
            {
                if (i != index)
                {
                    newArr[count] = arr[i];
                    count++;
                }
                i++;
            }
            return newArr;
        }
        static bool ChatGptArr(int[] arr)
        {
            if (IsPalindrome(arr))
            {
                Console.WriteLine("already palindrom");
                return true;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPalindrome(RemoveInt(arr, i)))
                {
                    Console.WriteLine($"if we remove the idex {i} the num {arr[i]}");
                    return true;
                }
            }
            return false;
        }
        public static int Total(int[] arr, int sumSecond)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += sumSecond / arr[i];
            }
            return sum;
        }
        public static int MinTime(int[] arr, int amount)
        {
            int sec = 1;
            while (Total(arr, sec) < amount)
            {
                sec++;
            }
            return sec;
        }

        public static int BiggestSum(int[] arr)
        {
            int tempsum = 0, maxsum = 0, i = 0;
            while (i != 0 && i < arr.Length)
                i++;
            i++;
            for (; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    tempsum += arr[i];
                else
                {
                    maxsum = Math.Max(tempsum, maxsum);
                    tempsum = 0;
                }
            }
            return maxsum;
        }

        public static int Ex52(Node<int[]> node)
        {
            Node<int[]> list = node;
            int min, max, count = 0;

            while (list.GetValue() != null)
            {
                min = 41; max = 0;
                for (int i = 0; i < list.GetValue().Length; i++)
                {
                    if (list.GetValue()[i] < min)
                        min = list.GetValue()[i];
                    if (list.GetValue()[i] > max)
                        max = list.GetValue()[i];
                }
                if ((max - min) < 20)
                    count++;
                list = list.GetNext();
            }
            return count;
        }
        public static Node<int[]> GetIntList()
        {
            Node<int[]> node = new Node<int[]>(null);

            for (int i = 0; i < 6; i++)
            {
                int[] ints = new int[6];
                Console.WriteLine($"Enter 6 nums for arr num {i + 1}:");
                for (int j = 0; j < 6; j++)
                {
                    ints[j] = int.Parse(Console.ReadLine());
                }
                node = new Node<int[]>(ints, node);
            }
            return node;
        }
        public static bool IsCircle<T>(Node<T> node)
        {
            Node<T> two = node;
            while (two.GetNext() != null)
            {
                node = node.GetNext();
                two = two.GetNext().GetNext();
                if (node == two)
                    return true;
            }
            return false;
        }
        static bool RecEx1(Node<Student> node, string name)
        {
            if (node == null)
                return false;
            if (node.GetValue().GetName() == name)
                return true;
            return RecEx1(node.GetNext(), name);
        }
        static Node<Student> Ex2Student(Node<Student> node)
        {
            Node<Student> pos = node, temp;
            while (pos.GetNext() != null)
            {
                if (pos.GetNext().GetValue().GetAvgGrade() >= 80)
                {
                    temp = pos.GetNext();
                    pos.SetNext(pos.GetNext().GetNext());
                    pos.SetNext(node);
                    node = temp;
                    temp = null;
                }
                pos = pos.GetNext();

            }
            return node;

        }
        public static Node<T> FindMid<T>(Node<T> node)
        {
            if (node == null)
                return null;
            Node<T> pos = node;
            while (pos.GetNext() != null)
            {
                if (pos.GetNext().GetNext() == null)
                    return node;
                node = node.GetNext();
                pos = pos.GetNext().GetNext();
            }
            return node;
        }
        public static bool IsSumEven(Node<int> node)
        {

            if (node.GetNext() == null)
                return node.GetValue() % 2 == 0;
            return (node.GetValue() % 2 == 0) == IsSumEven(node.GetNext());
        }
        public static Node<int> ExBohan(Node<int> node)
        {
            if (node.GetNext() == null)
            {
                if (node.GetValue() % 2 == 0)
                {
                    node.SetNext(new Node<int>(0));
                    return node;
                }
                else
                {
                    return new Node<int>(1, node);
                }
            }
            else
            {
                Node<int> temp = node;
                if (IsSumEven(node.GetNext()))
                {
                    Node<int> insert = new Node<int>(0, node.GetNext());
                    node.SetNext(insert);
                    return node;
                }
                else
                {
                    Node<int> insert = new Node<int>(1);
                    while (temp.GetNext().GetNext() != null)
                        temp = temp.GetNext();
                    insert.SetNext(temp.GetNext());
                    temp.SetNext(insert);
                    return node;
                }
            }
        }

    }

}
