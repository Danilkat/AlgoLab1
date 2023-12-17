using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    internal class DoublyLinkedList<T>
    {
        private DoubleListNode<T> head;
        private DoubleListNode<T> tail;
        public int Size { get; private set; }

        public void AddToFront(T data)
        {
            var newNode = new DoubleListNode<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            Size++;
        }

        public void AddToBack(T data)
        {
            var newNode = new DoubleListNode<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            Size++;
        }

        public void Remove(T data)
        {
            var current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }
                    Size--;

                    return;
                }

                current = current.Next;
            }
        }

        public void InsertAfter(T existingData, T newData)
        {
            var newNode = new DoubleListNode<T>(newData);
            var current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, existingData))
                {
                    newNode.Next = current.Next;
                    newNode.Previous = current;

                    if (current.Next != null)
                    {
                        current.Next.Previous = newNode;
                    }
                    else
                    {
                        tail = newNode;
                    }

                    current.Next = newNode;
                    Size++;
                    return;
                }

                current = current.Next;
            }
        }

        public void PrintList()
        {
            var current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
