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
            last = new MyLinkedListNode<T>
            {
                data = data,
                prev = last,
            };
            
            if (first == null)
            {
                first = new MyLinkedListNode<T>
                {
                    data = data,
                };
            }

            size++;
        }

        public T GetFront()
        {
            if (first == null)
            {
                throw new MyQueueEmptyException();
            }
            
            return first.data;
        }

        public T Dequeue()
        {
            if (last == null)
            {
                throw new MyQueueEmptyException();
            }

            last = last.prev;

            size--;

            return last.data;
        }

        public void Clear()
        {
            first = null;
            last = null;
            size = 0;
        }
    }
}