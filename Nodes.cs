using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgoLab1
{
    internal class ListNode<T>
    {
        public T Data { get; }
        public ListNode<T> Next { get; set; }

        public ListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    internal class DoubleListNode<T>
    {
        public T Data { get; }
        public DoubleListNode<T> Next { get; set; }
        public DoubleListNode<T> Previous { get; set; }

        public DoubleListNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }
}
