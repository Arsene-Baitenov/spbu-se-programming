using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private int count;
        public int Count { get => count; }

        private LinkedListNode<T>? first;
        public LinkedListNode<T>? First { get => first; }

        private LinkedListNode<T>? last;
        public LinkedListNode<T>? Last { get => last; }

        public LinkedList()
        {
            count = 0;
            first = null;
            last = null;
        }
        public LinkedList(IEnumerable<T> arr)
        {
            //throw new NotImplementedException();
            foreach (var item in arr)
            {
                AddLast(item);
            }
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != null)
            {
                throw new InvalidOperationException("The LinkedList node already belongs to a LinkedList.");
            }
            node.list = this;
            node.prev = null;
            if (first == null)
            {
                node.next = null;
                last = node;
            }
            else
            {
                first.prev = node;
                node.next = first;
            }
            first = node;
            ++count;
        }
        public void AddFirst(T _value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(_value);
            node.list = this;
            if (first == null)
            {
                last = node;
            }
            else
            {
                first.prev = node;
                node.next = first;
            }
            first = node;
            ++count;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != null)
            {
                throw new InvalidOperationException("The LinkedList node already belongs to a LinkedList.");
            }
            node.list = this;
            node.next = null;
            if (first == null)
            {
                node.prev = null;
                first = node;
            }
            else
            {
                last.next = node;
                node.prev = last;
            }
            last = node;
            ++count;
        }
        public void AddLast(T _value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(_value);
            node.list = this;
            if (first == null)
            {
                first = node;
            }
            else
            {
                last.next = node;
                node.prev = last;
            }
            last = node;
            ++count;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != this)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            if (newNode == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (newNode.list != null)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            newNode.list = this;
            newNode.prev = node;
            newNode.next = node.next;
            if (last == node)
            {
                last = newNode;
            }
            else
            {
                node.next.prev = newNode;
            }
            node.next = newNode;
            ++count;
        }
        public void AddAfter(LinkedListNode<T> node, T _value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != this)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            LinkedListNode<T> newNode = new LinkedListNode<T>(_value);
            newNode.list = this;
            newNode.prev = node;
            newNode.next = node.next;
            if (last == node)
            {
                last = newNode;
            }
            else
            {
                node.next.prev = newNode;
            }
            node.next = newNode;
            ++count;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != this)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            if (newNode == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (newNode.list != null)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            newNode.list = this;
            newNode.next = node;
            newNode.prev = node.prev;
            if (first == node)
            {
                first = newNode;
            }
            else
            {
                node.prev.next = newNode;
            }
            node.prev = newNode;
            ++count;
        }
        public void AddBefore(LinkedListNode<T> node, T _value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != this)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            LinkedListNode<T> newNode = new LinkedListNode<T>(_value);
            newNode.list = this;
            newNode.next = node;
            newNode.prev = node.prev;
            if (first == node)
            {
                first = newNode;
            }
            else
            {
                node.prev.next = newNode;
            }
            node.prev = newNode;
            ++count;
        }

        public void Clear()
        {
            LinkedListNode<T>? curr = first;
            while (curr != null)
            {
                LinkedListNode<T>? temp = curr.next;
                curr.prev = null;
                curr.next = null;
                curr.list = null;
                curr = temp;
            }
            first = null;
            last = null;
            count = 0;
        }

        public bool Contains(T key)
        {
            foreach (T it in this)
            {
                if (it.Equals(key)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, Int32 index)
        {
            if (index > array.Length)
            {
                throw new ArgumentOutOfRangeException("Must be less than or equal to the size of the collection.");
            }
            if (array.Length - index < count)
            {
                throw new ArgumentException("Insufficient space in the target location to copy the information.");
            }
            Int32 i = index;
            foreach (T it in this)
            {
                array[i] = it;
                ++i;
            }
        }

        public LinkedListNode<T>? Find(T key)
        {
            LinkedListNode<T>? curr = first;
            while (curr != null)
            {
                if (curr.value.Equals(key))
                {
                    return curr;
                }
                curr = curr.next;
            }
            return null;
        }
        public LinkedListNode<T>? FindLast(T key)
        {
            LinkedListNode<T>? curr = last;
            while (curr != null)
            {
                if (curr.value.Equals(key))
                {
                    return curr;
                }
                curr = curr.prev;
            }
            return null;
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    LinkedListNode<T>? curr = first;

        //    while (curr != null)
        //    {
        //        yield return curr.value;
        //        curr = curr.Next;
        //    }
        //}

        public void Remove(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            if (node.list != this)
            {
                throw new InvalidOperationException("The LinkedList node does not belong to current LinkedList.");
            }
            if (first == node)
            {
                first = node.next;
            }
            else
            {
                node.prev.next = node.next;
            }
            if (last == node)
            {
                last = node.prev;
            }
            else
            {
                node.next.prev = node.prev;
            }
            node.next = null;
            node.prev = null;
            node.list = null;
            --count;
        }
        public bool Remove(T key)
        {
            LinkedListNode<T>? node = Find(key);
            if (node == null)
            {
                return false;
            }
            else
            {
                if (first == node)
                {
                    first = node.next;
                }
                else
                {
                    node.prev.next = node.next;
                }
                if (last == node)
                {
                    last = node.prev;
                }
                else
                {
                    node.next.prev = node.prev;
                }
                node.next = null;
                node.prev = null;
                node.list = null;
                --count;
                return true;
            }
        }
        public void RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }
            LinkedListNode<T> node = first;
            first = node.next;
            if (last == node)
            {
                last = node.prev;
            }
            else
            {
                node.next.prev = node.prev;
            }
            node.next = null;
            node.prev = null;
            node.list = null;
            --count;
        }
        public void RemoveLast()
        {
            if (last == null)
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }
            LinkedListNode<T> node = last;
            if (first == node)
            {
                first = node.next;
            }
            else
            {
                node.prev.next = node.next;
            }
            last = node.prev;
            node.next = null;
            node.prev = null;
            node.list = null;
            --count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected class LinkedListEnumerator<T> : IEnumerator<T>
        {
            private LinkedListNode<T>? prevfirst;
            private LinkedListNode<T>? curr;
            public LinkedListEnumerator(LinkedListNode<T>? _first)
            {
                prevfirst = new LinkedListNode<T>(default(T));
                prevfirst.next = _first;
                curr = prevfirst;
            }
            public T Current
            {
                get
                {
                    if (curr == prevfirst)
                    {
                        throw new ArgumentException(nameof(curr));
                    }
                    return curr.value;
                }
            }
            object IEnumerator.Current { get => Current; }
            public bool MoveNext()
            {
                if (curr.next != null)
                {
                    curr = curr.next;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset()
            {
                curr = prevfirst;
            }
            void IDisposable.Dispose() { }
        }
    }
}
