using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Policy;
using System.Xml.Linq;

namespace Chapter3
{
    internal class ChainT
    {
        public static IntNode Create()
        {
            int value;
            Console.WriteLine("a value of 99 will stop the creation!");
            IntNode n = new IntNode(int.Parse(Console.ReadLine()));
            while (n.GetValue() != 99)
            {
                Console.WriteLine("enter value:");
                value = int.Parse(Console.ReadLine());
                n = new IntNode(value, n);
            }
            return n;
        }
        public static IntNode BuildRandom(int n, int low, int up)
        {
            Random rand = new Random();
            IntNode node = new IntNode(rand.Next(low, up));
            for (int i = 0; i < n - 1; i++)
            {
                node = new IntNode(rand.Next(low, up), node);
            }
            return node;    

        }
        public static void Print<T>(Node<T> chain)
        {
            do
            {
                Console.Write(chain);
                chain = chain.GetNext();
            } while (chain != null);
            Console.WriteLine();
        }
        public static int GetCount<T>(Node<T> chain)
        {
            int count = 0;
            Node<T> pos = chain;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }

        public static int GetSum(IntNode chain)
        {
            int sum = 0;
            do
            {
                sum += chain.GetValue();
                chain = chain.GetNext();
            } while (chain != null);
            return sum;
        }
        public static double GetAverage(IntNode chain)
        {
            double count = 0, sum = 0;
            do
            {
                sum += chain.GetValue();
                count++;
                chain = chain.GetNext();
            } while (chain != null);
            return sum / count;
        }
        public static int GetMax(IntNode chain)
        {
            int max = int.MinValue;
            do
            {
                max = Math.Max(chain.GetValue(), max);
                chain = chain.GetNext();
            } while (chain != null);
            return max;
        }
       
        public static IntNode Insert(IntNode chain, IntNode node, int info)
        {
            IntNode temp = chain.GetNext();
            chain.SetNext(new IntNode(info, temp));
            return chain;
        }
        public static void Delete(IntNode prevNode, IntNode n)
        {
            prevNode.SetNext(prevNode.GetNext().GetNext());
            prevNode.GetNext().SetNext(null);
        }


        public static Node<T> Ex4<T>(T[] OgList)
        {
            if (OgList == null)
                return null;

            Node<T> New = new Node<T>(OgList[0]);
            Node<T> pos = New;

            for (int i = 1; i < OgList.Length; i++)
            {
                pos.SetNext(new Node<T>(OgList[i]));
                pos = pos.GetNext();
            }

            return New;
        }
        public static int Ex6<T>(Node<T> OgList)
        {
            if (OgList == null)
                return 0;
            return 1 + Ex6(OgList.GetNext());
        }

        public static int Ex8<T>(Node<int> OgList, int c)
        {
            if (OgList == null)
                return 0;
            else if (OgList.GetValue() == c)
                return 1 + Ex8<T>(OgList.GetNext(), c);
            return Ex8<T>(OgList.GetNext(), c);
        }
        public static int Ex9<T>(Node<T> node, T c)
        {
            int count = 0;
            do
            {
                if (node.GetValue().Equals(c))
                    count++;
                node = node.GetNext();
            } while (node != null);
            return count;
        }
        public static int Ex10<T>(Node<T> OgList, T c)
        {
            if (OgList == null)
                return 0;
            else if (OgList.GetValue().Equals(c))
                return 1 + Ex10(OgList.GetNext(), c);
            return Ex10(OgList.GetNext(), c);
        }
        public static void Ex1(Node<double> node)
        {
            while (node.HasNext())
            {
                if (node.GetValue() > node.GetNext().GetValue())
                    Console.WriteLine(node);
                node = node.GetNext();
            }
        }
        public static int Ex2(Node<int> node, int n)
        {
            int count = 0;
            while (node != null)
            {
                if (node.GetValue() == n)
                {
                    while (node.HasNext() && node.GetValue() == n)
                        node = node.GetNext();
                    count++;
                }
                node = node.GetNext();
            }
            return count;
        }

        public static Node<T> ReverseList<T>(Node<T> list)
        {
            Node<T> currentNode = list;
            Node<T> pos = null;
            Node<T> nextNode = null;
            while (currentNode != null)
            {
                nextNode = currentNode.GetNext();
                currentNode.SetNext(pos);
                pos = currentNode;
                currentNode = nextNode;
            }
            return pos;
        }

        public static Node<int> MinToStart(Node<int> node)
        {
            Node<int> temp = node;
            Node<int> Nmin = new Node<int>(int.MaxValue);
            while (temp != null)
            {
                if (temp.GetValue() < Nmin.GetValue())
                {
                    Nmin = temp;
                }
                temp = temp.GetNext();
            }
            if (node == Nmin)
                return node;
            temp = node;
            while (temp.GetNext() != Nmin)
            {
                temp = temp.GetNext();
            }
            temp.SetNext(temp.GetNext().GetNext());
            Nmin.SetNext(node);
            return Nmin;
        }
        public static Node<int> OnlyEvenOpp(Node<int> node)
        {
            Node<int> newNode = null;
            while (node != null)
            {
                if (node.GetValue() % 2 == 0)
                {
                    newNode = new Node<int>(node.GetValue(), newNode);
                }
                node = node.GetNext();
            }
            return newNode;
        }
        public static Node<int> OnlyEven(Node<int> node)
        {
            Node<int> newNode = null;
            Node<int> first = null;
            while (node != null)
            {
                if (node.GetValue() % 2 == 0)
                {
                    if (first == null)
                    {
                        first = new Node<int>(node.GetValue());
                        newNode = first;
                    }
                    else
                    {
                        newNode.SetNext(new Node<int>(node.GetValue()));
                        newNode = newNode.GetNext();
                    }

                }
                node = node.GetNext();
            }
            return first;
        }
        public static Node<T> ReverseListRec<T>(Node<T> list)
        {
            Node<T> p;
            if (list.GetNext() == null)
                return list;
            p = ReverseListRec(list.GetNext());
            list.GetNext().SetNext(list);
            list.SetNext(null);
            return p;
        }
        public static Node<int> Target26(Node<int> list)
        {
            Node<int> prev = list;
            Node<int> pos = list.GetNext();
            while (pos != null)
            {
                if (pos.GetValue() % 2 == 0)
                {
                    prev.SetNext(pos.GetNext());
                    pos.SetNext(list);
                    list = pos;
                    pos = prev.GetNext();
                }
                else
                {
                    pos = pos.GetNext();
                    prev = prev.GetNext();
                }
            }
            return list;
        }
        public static void Target32(Node<int> list)
        {
            int zugi = list.GetValue() % 2;
            Node<int> prev = list.GetNext();
            Node<int> pos = list.GetNext().GetNext();
            Node<int> temp = null;
            while (pos != null)
            {
                if (prev.GetValue() % 2 == zugi)
                {
                    prev.SetNext(pos.GetNext());
                    pos.SetNext(list);
                    list = pos;
                    pos = pos.GetNext();
                }
                else
                {
                    pos = pos.GetNext();
                    prev = prev.GetNext();
                }
            }

        }
        public static Node<int> Sum2Lists(Node<int> list1, Node<int> list2)
        {
            Node<int> dummy = new Node<int>(-999);
            Node<int> pos = dummy;
            while (list1 != null && list2 != null)
            {
                pos.SetNext(new Node<int>(list1.GetValue() + list2.GetValue()));
                pos = pos.GetNext();
                list1 = list1.GetNext();
                list2 = list2.GetNext();

            }

            while (list1 != null)
            {
                pos.SetNext(new Node<int>(list1.GetValue()));
                pos = pos.GetNext();
                list1 = list1.GetNext();
            }
            while (list2 != null)
            {
                pos.SetNext(new Node<int>(list2.GetValue()));
                pos = pos.GetNext();
                list2 = list2.GetNext();
            }
            return dummy.GetNext();
        }
        public static bool IsExist2(int number, Node<int> list)
        {
            Node<int> temp = list;
            while (temp != null)
            {
                if (temp.GetValue() == number)
                    return true;
                temp = temp.GetNext();
            }
            return false;
        }
        public static Node<int> Ex2xE(Node<int> list1, Node<int> list2)
        {
            Node<int> dummy = new Node<int>(-999);
            Node<int> pos = dummy;
            while (list1 != null)
            {
                if (IsExist2(list1.GetValue(), list2) && !IsExist2(list1.GetValue(), dummy))
                {
                    pos.SetNext(new Node<int>(list1.GetValue()));
                    pos = pos.GetNext();
                }

                list1 = list1.GetNext();
            }
            return dummy.GetNext();
        }
        public static Node<int> Ex4xE(Node<int> list1, Node<int> list2)
        {
            Node<int> dummy = new Node<int>(-999);
            Node<int> pos = dummy;
            while (list1 != null && list2 != null)
            {

                if (list1.GetValue() < list2.GetValue())
                {
                    pos.SetNext(new Node<int>(list1.GetValue()));
                    list1 = list1.GetNext();
                    pos = pos.GetNext();
                }
                else
                {
                    pos.SetNext(new Node<int>(list2.GetValue()));
                    list2 = list2.GetNext();
                    pos = pos.GetNext();
                }

            }
            while (list1 != null)
            {
                pos.SetNext(new Node<int>(list1.GetValue()));
                pos = pos.GetNext();
                list1 = list1.GetNext();
            }
            while (list2 != null)
            {
                pos.SetNext(new Node<int>(list2.GetValue()));
                pos = pos.GetNext();
                list2 = list2.GetNext();
            }
            return dummy.GetNext();
        }
        public static int Length(Node<int> list)
        {
            if (list == null)
                return 0;
            return 1 + Length(list.GetNext());
        }
        public static int Ex5xE(Node<int> list1, Node<int> list2)
        {
            if (Length(list1) > Length(list2))
                return -1;
            else if (Length(list1) < Length(list2))
                return -2;
            else
            {
                while (list1 != null && list2 != null)
                {
                    if (list1.GetValue() > list2.GetValue())
                        return -1;
                    else if (list1.GetValue() < list2.GetValue())
                        return -2;
                    list1 = list1.GetNext();
                    list2 = list2.GetNext();
                }
            }
            return 0;
        }
        static Node<int> DeleteF(Node<int> node)
        {
            return node.GetNext();
        }

        static void DeleteKnownNode(Node<int> list, Node<int> ToDel)
        {
            while (list.GetNext() != ToDel)
                list = list.GetNext();
            Node<int> del = list.GetNext();
            list.SetNext(del.GetNext());
            del.SetNext(null);
        }
        static Node<int> DeleteFirst(Node<int> list)
        {
            Node<int> del = list;
            list = list.GetNext();
            del.SetNext(null);
            return list;
        }
        static void Ex1(Node<int> list)
        {
            Node<int> next;
            while (list.HasNext())
            {
                next = list.GetNext();
                if (list.GetValue() > next.GetValue())
                    Console.Write(list.GetValue() + " ");
                list = list.GetNext();
            }
        }
        static bool Ex3(Node<int> list)
        {
            double average = GetAverage(list);
            int smaller = 0, larger = 0;
            while (list != null)
            {
                if (list.GetValue() < average)
                    smaller++;
                if (list.GetValue() > average)
                    larger++;
                list = list.GetNext();
            }
            return smaller == larger;
        }
        static double GetAverage(Node<int> list)
        {
            int sum = 0, count = 0;
            while (list != null)
            {
                sum += list.GetValue();
                count++;
                list = list.GetNext();
            }
            return (double)sum / count;
        }
        public static Node<T> Clone<T>(Node<T> list)
        {
            Node<T> clone = new Node<T>(list.GetValue());
            Node<T> last = clone;
            list = list.GetNext();
            while (list != null)
            {
                last.SetNext(new Node<T>(list.GetValue()));
                last = last.GetNext();
                list = list.GetNext();
            }
            return clone.GetNext();
        }
        static Node<int> Ex8(int beginner, int num)
        {
            Node<int> list = new Node<int>(beginner);
            Node<int> pos = list;
            for (int i = 0; i < num - 1; i++)
            {
                pos.SetNext(new Node<int>(++beginner));
                pos = pos.GetNext();
            }
            return list;
        }
        public static Node<int> Target10(Node<int> list)
        {
            Node<int> new_list = new Node<int>(list.GetValue());
            Node<int> pos = new_list;
            while (list != null)
            {
                if (!IsExist(new_list, list.GetValue()))
                {
                    pos.SetNext(new Node<int>(list.GetValue()));
                    pos = pos.GetNext();
                }
                list = list.GetNext();
            }
            return new_list;
        }

        static bool Ex4(Node<int> list, int num)
        {
            Node<int> pos = list;
            int count = 1;
            while (pos.HasNext())
            {
                if (pos.GetValue() + 1 == pos.GetNext().GetValue())
                    count++;
                else
                    count = 1;
                if (count == num)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }
        static bool IsSidra(Node<int> list)
        {
            int delta = list.GetNext().GetValue() - list.GetValue();
            list = list.GetNext();
            while (list.HasNext())
            {
                if ((list.GetValue() + delta) != list.GetNext().GetValue())
                    return false;
                list = list.GetNext();
            }
            return true;
        }
        static Node<int> Ex9(Node<int> list1)
        {
            Node<int> dummy = new Node<int>(-999);
            Node<int> list2 = dummy;
            int sum = list1.GetValue();
            while (list1.GetNext() != null)
            {
                if (list1.GetValue() <= list1.GetNext().GetValue())
                    sum += list1.GetNext().GetValue();
                else
                {
                    list2.SetNext(new Node<int>(sum));
                    list2 = list2.GetNext();
                    sum = list1.GetNext().GetValue();
                }
                list1 = list1.GetNext();
            }
            list2.SetNext(new Node<int>(sum));
            return dummy.GetNext();
        }
        public static Node<int> Ex1Pg3(Node<int> node, int num)
        {
            node = new Node<int>(-999, node);
            Node<int> list = node;
            while (list != null)
            {
                if (list.GetNext().GetValue() == num)
                    list.SetNext(list.GetNext().GetNext());
                else
                    list = list.GetNext();
            }
            return node.GetNext();
        }
        public static Node<int> Ex4Pg3(Node<int> list)
        {
            int count = CountNodesRec(list);
            Node<int> pos = list;
            if (count % 2 != 0)
            {
                while (pos.GetNext().HasNext())
                    pos = pos.GetNext();
                pos.SetNext(null);
                list = list.GetNext();
            }
            else
            {
                for (int i = 1; i < count / 2 - 1; i++)
                    pos = pos.GetNext();
                if (pos.GetNext().GetValue() >= pos.GetNext().GetNext().GetValue())
                    pos.SetNext(pos.GetNext().GetNext());
                else
                    pos.GetNext().SetNext(pos.GetNext().GetNext().GetNext());
            }
            return list;
        }
        public static int CountNodesRec<T>(Node<T> chain)
        {
            if (chain.GetNext() == null)
                return 1;
            return 1 + CountNodesRec(chain.GetNext());
        }
        public static Node<int> DeleteMax(Node<int> list)
        {
            int max = list.GetValue();
            Node<int> pos = list.GetNext();
            while (pos != null)
            {
                if (pos.GetValue() > max)
                    max = pos.GetValue();
                pos = pos.GetNext();
            }
            return DeleteNodes(list, max);
        }
        public static Node<int> DeleteNMax(Node<int> list, int n)
        {
            for (int i = 0; i < n; i++)
                list = DeleteMax(list);
            return list;
        }



        public static Node<int> DeleteNodes(Node<int> nodeL, int max)
        {
            if (nodeL.GetValue() == max)
                return nodeL.GetNext();
            Node<int> pos = nodeL;
            while (pos.GetNext() != null && pos.GetNext().GetValue() != max)
                pos = pos.GetNext();

            if (pos.GetNext().GetValue() == max)
                pos.SetNext(pos.GetNext().GetNext());

            return nodeL;
        }
        public static Node<int> Connect(Node<int> list1, Node<int> list2)
        {
            Node<int> res = null;
            while (list1 != null)
            {
                if (IsExist(list2, list1.GetValue()))
                    res = new Node<int>(list1.GetValue(), res);
                list1 = list1.GetNext();
            }
            return res;
        }
        public static bool IsExist<T>(Node<T> node, T value)
        {
            while (node != null)
            {
                if (node.GetValue().Equals(value))
                    return true;
                node = node.GetNext();
            }
            return false;
        }
        public static Node<int> ConnentNodubble(Node<int> list1, Node<int> list2)
        {
            Node<int> newL = new Node<int>(999);
            Node<int> pos = newL;
            while (list1 != null)
            {
                if (IsExist(list2, list1.GetValue()))
                {
                    if (!IsExist(newL, list1.GetValue()))
                    {
                        pos.SetNext(new Node<int>(list1.GetValue()));
                        pos = pos.GetNext();
                    }
                }
                list1 = list1.GetNext();
            }
            return newL.GetNext();
        }
        public static Node<int> SumLists(Node<int> list1, Node<int> list2)
        {
            Node<int> newL = new Node<int>(-999);
            Node<int> last = newL;

            while (list1 != null && list2 != null)
            {
                last.SetNext(new Node<int>(list1.GetValue() + list2.GetValue()));
                last = last.GetNext();
                list1 = list1.GetNext();
                list2 = list2.GetNext();
            }

            while (list1 != null)
            {
                last.SetNext(new Node<int>(list1.GetValue()));
                last = last.GetNext();
                list1 = list1.GetNext();
            }

            while (list2 != null)
            {
                last.SetNext(new Node<int>(list2.GetValue()));
                last = last.GetNext();
                list2 = list2.GetNext();
            }

            return newL.GetNext();
        }
        public static Node<int> CreateSorted(Node<int> list1, Node<int> list2)
        {
            Node<int> NewL = new Node<int>(-999);
            Node<int> last = NewL;
            while (list1 != null && list2 != null)
            {
                if (list1.GetValue() < list2.GetValue())
                {
                    last.SetNext(new Node<int>(list1.GetValue()));
                    list1 = list1.GetNext();
                }
                else
                {
                    last.SetNext(new Node<int>(list2.GetValue()));
                    list2 = list2.GetNext();
                }
                last = last.GetNext();
            }
            while (list1 != null)
            {
                last.SetNext(new Node<int>(list1.GetValue()));
                list1 = list1.GetNext();
                last = last.GetNext();
            }
            while (list2 != null)
            {
                last.SetNext(new Node<int>(list2.GetValue()));
                list2 = list2.GetNext();
                last = last.GetNext();
            }
            return NewL.GetNext();
        }
        public static Node<char> Target6A(Node<char> list1, Node<char> list2)
        {
            Node<char> dummy = new Node<char>('~'); //dummy
            Node<char> pos = dummy;
            while (list1 != null)
            {
                if (IsExist(list2, list1.GetValue()))
                {
                    pos.SetNext(new Node<char>(list1.GetValue()));
                    pos = pos.GetNext();
                }
                list1 = list1.GetNext();
            }
            return dummy.GetNext();
        }
        public static Node<char> Target6B(Node<char> list1, Node<char> list2)
        {
            Node<char> dummy = new Node<char>('~', list1); //dummy
            list1 = dummy;
            while (list1.HasNext())
            {
                if (!IsExist(list2, list1.GetNext().GetValue()))
                    list1.SetNext(list1.GetNext().GetNext());
                else
                    list1 = list1.GetNext();
            }
            return dummy.GetNext();
        }
        public static Node<string> DeleteV(Node<string> list)
        {
            list = new Node<string>("Dummy", list);
            Node<string> pos = list;
            while (pos.HasNext())
            {
                if (pos.GetNext().GetValue()[0] == 'V')
                    pos.SetNext(pos.GetNext().GetNext());
                else
                    pos = pos.GetNext();
            }
            return list.GetNext();
        }
        public static void NoDuplication(Node<string> list)
        {
            while (list.HasNext())
            {
                Node<string> pos = list;
                while (pos.HasNext())
                {
                    if (pos.GetNext().GetValue().Equals(list.GetValue()))
                        pos.SetNext(pos.GetNext().GetNext());
                    else
                        pos = pos.GetNext();
                }
                list = list.GetNext();
            }
        }
        public static int NumsOfNumber(Node<int> list, int x)
        {
            if (list == null)
                return 0;
            if (list.GetValue() == x)
                return 1 + NumsOfNumber(list.GetNext(), x);
            return NumsOfNumber(list.GetNext(), x);
        }
        public static void Insert<T>(Node<T> node, T value)
        {
            Node<T> temp = new Node<T>(value);
            temp.SetNext(node.GetNext());
            node.SetNext(temp);
        }
        public static void Remove(Node<int> list, int y)
        {
            Node<int> current = list;
            while (current.GetNext() != null)
            {
                if (current.GetNext().GetValue() == y)
                    current.SetNext(current.GetNext().GetNext());
                else
                    current = current.GetNext();
            }
        }
        public static void Bohan(Node<int> list)
        {
            Node<int> pos = list;
            while (pos != null)
            {
                int num = NumsOfNumber(pos, pos.GetValue());
                Remove(pos, pos.GetValue());
                Insert<int>(pos, num);
                pos = pos.GetNext().GetNext();
            }
        }
        public static Node<T> RecD<T>(Node<T> node)
        {
            return RecD(node, node);
            
        }
        private static Node<T> RecD<T>(Node<T> node,Node<T> pos)
        {
            if (pos.GetNext() == null||node==null)
            {
                return new Node<T>(node.GetValue());
            }
            return RecD(node.GetNext(),pos.GetNext().GetNext());
        }
        public static bool IsExist6(Node<char> node, char c)
        {
            Node<char> temp = node;
            while (temp != null)
            {
                if(temp.GetValue()==c)
                    return true;
                temp = temp.GetNext();
            }
            return false;
        }
        

    }


}
