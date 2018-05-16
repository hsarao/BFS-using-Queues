using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Queue<T>
    {
        public Node<T> Head;
        public Node<T> Tail;
        public int count;

        public Queue()
        {
            this.Head = null;
            this.count = 0;
        }

        public void Enqueue(T element)
        {
            Node<T> node = new Node<T>(element);
            Node<T> currTail = Tail;
            Tail = node;

            if (count == 0)
            {
                Head = Tail;
            }
            else
            {
                currTail.Next = Tail;
            }
            count++;
        }

        public T Front()
        {
            if (this.Head != null)
            {
                Tail.SetNext(null);
                return Head.GetElement();
            }
            throw new ApplicationException();
        }
        
        public T Dequeue()
        {
            Node<T> currHead = Head;

            if (count != 0)
            {
                this.Head = Head.Next;         
                count--;
                return currHead.GetElement();
            }
            else
            {
                throw new ApplicationException();
            }
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

        public Node<T> GetTail()
        {
            return this.Tail;
        }

        public bool IsEmpty()
        {
            return count == 0 ? true : false;
        }
    }
}
