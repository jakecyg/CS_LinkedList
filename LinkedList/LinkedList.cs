using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Size { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        internal bool IsEmpty() => Size == 0;

        internal void AddFirst(T toAdd)
        {
            Node<T> newNode = new Node<T>(toAdd, previousNode: null, nextNode: Head);

            if (Size == 0) Tail = newNode;
            else Head.Previous = newNode;
            Head = newNode;
            Size++;
        }

        internal T GetFirst() => IsEmpty() ? throw new ApplicationException() : Head.Element;

        internal T GetLast() => Size == 0 ? throw new ApplicationException() : Tail.Element;

        internal void Clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        internal T SetFirst(T employee)
        {
            if (IsEmpty()) throw new ApplicationException();
            T oldHead = Head.Element;
            Head.Element = employee;
            return oldHead;
        }

        internal T SetLast(T employee1)
        {
            if (IsEmpty()) throw new ApplicationException();
            T oldTail = Tail.Element;
            Tail.Element = employee1;
            return oldTail;
        }
        internal void AddLast(T addedEmployee)
        {
            Node<T> toAdd = new Node<T>(addedEmployee, previousNode: Tail, nextNode: null);
            if (Tail != null) Tail.Next = toAdd;
            if (Size == 0) Head = toAdd;
            Tail = toAdd;
            Size++;
        }
        internal void tripleSizeCheck(int pos)
        {
            if (IsEmpty() || pos < 1 || pos > Size) throw new ApplicationException();
        }
        internal T RemoveFirst()
        {
            if (IsEmpty()) throw new ApplicationException();
            else if (Size == 1)
            {
                T removedHead = Head.Element;
                Clear();
                return removedHead;
            }
            else
            {
                T removedHead = Head.Element;
                Node<T> newHead = Head.Next;
                Head = newHead;
                Head.Previous = null;
                Size--;
                return removedHead;
            }
        }
        internal T RemoveLast()
        {
            if (IsEmpty()) throw new ApplicationException();
            else if (Size == 1)
            {
                T removedTail = Tail.Element;
                Clear();
                return removedTail;
            }
            else
            {
                T removedTail = Tail.Element;
                Node<T> newTail = Tail.Previous;
                Tail = newTail;
                Tail.Next = null;
                Size--;
                return removedTail;
            }
        }

        internal Node<T> getNodeByPosition(int pos)
        {
            Node<T> returnNode = new Node<T>();
            Node<T> headNode = Head;

            if (pos == 1) return this.Head;
            if (pos == this.Size) return this.Tail;
            for (int i = 2; i <= pos; i++)
            {
                headNode = headNode.Next;
                returnNode = headNode;
            }
            return returnNode;
        }
        internal Node<T> getNodeByElement(T element)
        {
            if (IsEmpty()) throw new ApplicationException();
            if (element == null) throw new ArgumentNullException();
            Node<T> returnNode = new Node<T>();
            Node<T> headNode = Head;
            int count = 0;
            for (int i = 1; i <= Size; i++)
            {
                if (headNode.Element.CompareTo(element) == 0)
                {
                    count++;
                    return headNode;
                }
                headNode = headNode.Next;
            }
            return count == 0 ? throw new ApplicationException() : returnNode;
        }

        internal T removeNode(Node<T> removedNode)
        {
            if (removedNode.Previous == null) RemoveFirst();
            else if (removedNode.Next == null) RemoveLast();
            else
            {
                Node<T> firstChangeNode = removedNode.Previous;
                Node<T> secondChangeNode = removedNode.Next;
                firstChangeNode.Next = secondChangeNode;
                secondChangeNode.Previous = firstChangeNode;
                Size--;
            }
            return removedNode.Element;
        }
        internal T removeNodeByPosition(int pos)
        {
            Node<T> removedNode = getNodeByPosition(pos);
            return removeNode(removedNode);
        }

        internal T Get(int pos)
        {
            tripleSizeCheck(pos);
            return getNodeByPosition(pos).Element;
        }

        internal T Get(T employee) => getNodeByElement(employee).Element;
        internal void addNodeAfter(Node<T> oldNode, Node<T> toAddNode)
        {
            if (oldNode.Next == null) AddLast(toAddNode.Element);
            else
            {
                Node<T> oldNodeNext = oldNode.Next;
                toAddNode.Next = oldNodeNext;
                toAddNode.Previous = oldNode;
                oldNode.Next = toAddNode;
                oldNodeNext.Previous = toAddNode;
                Size++;
            }
        }
        internal void AddAfter(T addEmployee, int pos)
        {
            tripleSizeCheck(pos);
            Node<T> oldNode = getNodeByPosition(pos);
            Node<T> toAddNode = new Node<T>(addEmployee);
            addNodeAfter(oldNode, toAddNode);
        }
        internal void AddAfter(T addEmployee, T oldEmployee)
        {
            Node<T> oldNode = getNodeByElement(oldEmployee);
            Node<T> toAddNode = new Node<T>(addEmployee);
            addNodeAfter(oldNode, toAddNode);
        }

        internal void addNodeBefore(Node<T> oldNode, Node<T> toAddNode)
        {
            if (oldNode.Previous == null) AddFirst(toAddNode.Element);
            else
            {
                Node<T> oldNodePrev = oldNode.Previous;
                toAddNode.Next = oldNode;
                toAddNode.Previous = oldNodePrev;
                oldNode.Previous = toAddNode;
                oldNodePrev.Next = toAddNode;
                Size++;
            }
        }
        internal void AddBefore(T addEmployee, int pos)
        {
            tripleSizeCheck(pos);
            Node<T> oldNode = getNodeByPosition(pos);
            Node<T> toAddNode = new Node<T>(addEmployee);
            addNodeBefore(oldNode, toAddNode);
        }
        internal void AddBefore(T addEmployee, T oldEmployee)
        {
            Node<T> oldNode = getNodeByElement(oldEmployee);
            Node<T> toAddNode = new Node<T>(addEmployee);
            addNodeBefore(oldNode, toAddNode);
        }

        internal T Remove(int pos)
        {
            tripleSizeCheck(pos);
            return removeNodeByPosition(pos);
        }

        internal T Remove(T employee)
        {
            Node<T> removedNode = getNodeByElement(employee);
            return removeNode(removedNode);

        }
        internal T setNodeByPosition(T setToEmployee, Node<T> setFromEmployee)
        {
            if (setFromEmployee.Previous == null) return SetFirst(setToEmployee);
            else if (setFromEmployee.Next == null) return SetLast(setToEmployee);
            else
            {
                Node<T> changeToNode = new Node<T>(setToEmployee);
                Node<T> firstChangeNode = setFromEmployee.Previous;
                Node<T> secondChangeNode = setFromEmployee.Next;
                firstChangeNode.Next = changeToNode;
                secondChangeNode.Previous = changeToNode;
            }
            return setFromEmployee.Element;
        }
        internal T Set(T setToEmployee, int pos)
        {
            tripleSizeCheck(pos);
            Node<T> setFromEmployee = getNodeByPosition(pos);
            return setNodeByPosition(setToEmployee, setFromEmployee);
        }
        internal T Set(T setToEmployee, T oldEmployee)
        {
            Node<T> setFromEmployee = getNodeByElement(oldEmployee);
            return setNodeByPosition(setToEmployee, setFromEmployee);
        }

        internal void Insert(T employee)
        {
            Node<T> insertNode = new Node<T>(employee);
            if (IsEmpty())
            {
                Head = insertNode;
                Tail = insertNode;
                Size++;
            }
            else
            {
                Node<T> headNode = Head;
                for (int i = 1; i <= Size; i++)
                {
                    if (headNode.Element.CompareTo(employee) > 0 || headNode.Element.CompareTo(employee) == 0)
                    {
                        AddBefore(employee, headNode.Element);
                        break;
                    }
                    if (i == Size)
                    {
                        AddAfter(employee, headNode.Element);
                        break;
                    }
                    headNode = headNode.Next;
                }
            }
        }

        internal void SortAscending()
        {
            if (Size > 1)
            {
                for (int i = 0; i < Size; i++)
                {
                    Node<T> temp = Head;
                    Node<T> next = Head.Next;
                    for (int j = 0; j < Size - 1; j++)
                    {
                        if (temp.Element.CompareTo(temp.Next.Element) > 0)
                        {
                            T holdMyNode = temp.Element;
                            temp.Element = temp.Next.Element;
                            temp.Next.Element = holdMyNode;
                        }
                        temp = next;
                        next = next.Next;
                    }
                }
            }
        }
    }
}
