using System;
using System.Linq;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        public MyLinkedListNode<T> last;
        private int size;

        public MyLinkedList()
        {
            // Write implementation here
            size = 0;
        }

        public void AddFirst(T data)
        {
            first = new MyLinkedListNode<T>
            {
                data = data,
                next = first,
            };
            
            size++;

            if (size == 1) last = first;
        }

        private void AddLast(T data)
        {
            if (size == 0 ) AddFirst(data);

            last.next = new MyLinkedListNode<T>
            {
                data = data
            };

            last = last.next;

            size++;
        }

        public T GetFirst()
        {
            if (first == null)
            {
                throw new MyLinkedListEmptyException();
            }
            
            return first.data;
        }

        public void RemoveFirst()
        {
            if (first == null)
            {
                throw new MyLinkedListEmptyException();
            }
            
            first = first.next;

            if (first == null) last = first;

            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            last = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > size) throw new MyLinkedListIndexOutOfRangeException();

            if (index == 0) AddFirst(data);
            if (index > 0 && index < size) AddMiddle(index, data);
            if (index == size) AddLast(data);
        }

        private void AddMiddle(int index, T data)
        {
            MyLinkedListNode<T> node = first;
            for (int i = 1; i < index; i++)
            {
                node = node.next;
            }
            
            node.next = new MyLinkedListNode<T>
            {
                data = data,
                next = node.next,
            };

            size++;
        }

        public override string ToString()
        {
            if (first == null) return "NIL";
            
            string output = "[";

            var node = first;
            while (node != null)
            {
                output += node.data + (node.next == null ? "" : ",");
                node = node.next;
            }

            output += "]";

            return output;
        }
    }
}