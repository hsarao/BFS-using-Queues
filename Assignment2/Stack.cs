using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Stack<T> : ICloneable
    {
        public Node<T> Head;
        public int count;

        public Stack()
        {
            this.Head = null;
            this.count = 0;
        }

        public Stack(Node<T> head, int count)
        {
            this.Head = head;
            this.count = count;
        }

        public void Push(T element)
        {
            Node<T> node = new Node<T>(element);
            Node<T> oldNode = Head;
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Head = node;
                Head.SetNext(oldNode);

            }
            count++;
        }

        public T Top()
        {
            if (Head != null)
            {
                return Head.GetElement();
            }
            throw new ApplicationException();
        }

        public T Pop()
        {
            if (Head != null)
            {
                T returnedElement = Head.Element;
                Head = Head.GetNext();
                count--;
                return returnedElement;
            }
            throw new ApplicationException();

        }

        public void Clear()
        {
            count = 0;
            Head = null;
        }

        public int GetSize()
        {
            return this.count;
        }

        public Node<T> GetHead()
        {
            return this.Head;
        }

        public bool IsEmpty()
        {
            return count == 0 ? true : false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
