using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public Node(T newElement = default(T), Node<T> previousNode = null, Node<T> nextNode = null)
        {
            this.Element = newElement;
            this.Previous = previousNode;
            this.Next = nextNode;
        }
    }
}
