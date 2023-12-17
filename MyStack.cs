using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    internal class MyStack<T>
    {
        private ListNode<T> top;
        private int count;

        public MyStack()
        {
            top = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            ListNode<T> newNode = new ListNode<T>(item);
            newNode.Next = top;
            top = newNode;
            count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T data = top.Data;
            top = top.Next;
            count--;

            return data;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return top.Data;
        }

        public void Clear()
        {
            top = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            ListNode<T> current = top;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}
