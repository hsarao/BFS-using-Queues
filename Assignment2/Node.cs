using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Node class to maintain two links per node
    /// </summary>
    /// <typeparam name="T">Any generic type of data</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Properties of node class
        /// </summary>
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public T Element { get; set; }

        /// <summary>
        /// Cosntructor to initialize the private fields to default values
        /// </summary>
        public Node()
        {
            this.Element = default(T);
           // this.Previous = null;
            this.Next = null;
        }

        /// <summary>
        /// Constructor initializes only the passed element
        /// </summary>
        /// <param name="element"></param>
        public Node(T element)
        {
            this.Element = element;
            //this.Previous = null;
            this.Next = null;
        }

        /// <summary>
        /// Constructor to initialize private fields using the parmeter values
        /// </summary>
        /// <param name="element">The element of the node</param>
        /// <param name="previousNode">The node previous to current node</param>
        /// <param name="nextNode">The next node to the current node</param>
        public Node(T element, Node<T> previousNode, Node<T> nextNode)
        {
            this.Element = element;
            this.Next = nextNode;
            //this.Previous = previousNode;
        }

        public T GetElement()
        {
            return this.Element;
        }

        public Node<T> GetNext()
        {
            return this.Next;
        }

        public void SetElement(T element)
        {
            this.Element = element;
        }

        public void SetNext(Node<T> node)
        {
            this.Next = node;
        }

        //public void SetPrevious(Node<T> node)
        //{
        //    this.Previous = node;
        //}

        //public Node<T> GetPrevious()
        //{
        //    return this.Previous;
        //}
    }
}
