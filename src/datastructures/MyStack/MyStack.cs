using System;
using System.Diagnostics;

namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        private MyLinkedListNode<T> first;
        
        public bool IsEmpty()
        {
            return first == null;
        }

        public T Pop()
        {
            if (first == null)
            {
                throw new MyStackEmptyException();
            }

            var firstData = first.data;
            
            first = first.next;
            
            return firstData;
        }

        public void Push(T data)
        {
            first  = new MyLinkedListNode<T>()
            {
                data = data,
                next = first
            };
        }

        public T Top()
        {
            if (first == null)
            {
                throw new MyStackEmptyException();
            }
            
            return first.data;
        }
    }
}
