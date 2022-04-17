using System;
using System.Text;

namespace CustomLinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T t)
        {
            value = t;
            next = null;
            prev = null;
            list = null;
        }

        internal T value;
        public T Value { get => value; }

        internal LinkedListNode<T>? next;
        public LinkedListNode<T>? Next { get => next; }

        internal LinkedListNode<T>? prev;
        public LinkedListNode<T>? Prev { get => prev; }

        internal LinkedList<T>? list;
        public LinkedList<T>? List { get => list; }

        public ref T ValueRef { get => ref value; }
    }
}
