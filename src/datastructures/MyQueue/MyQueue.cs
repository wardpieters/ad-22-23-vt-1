using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        public MyLinkedListNode<T> first;
        public MyLinkedListNode<T> last;
        private int size;
        
        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T data)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T> {data = data};
            
            if (IsEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
            
            size++;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }
            
            return first.data;
        }

        public T Dequeue()
        {
            var data = GetFront();

            first = first.next;

            size--;

            return data;
        }

        public void Clear()
        {
            first = null;
            last = null;
            size = 0;
        }
    }
}