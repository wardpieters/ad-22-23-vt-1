using System;

namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            array = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
        }

        public void Add(T x)
        {
            if (size == array.Length - 1)
                EnlargeArray(array.Length * 2 + 1);

            PercolateUp(x);
        }

        private void PercolateUp(T x)
        {
            // percolate up
            int hole = ++size;
            for (; hole > 1 && x.CompareTo(array[hole / 2]) < 0; hole /= 2)
                array[hole] = array[hole / 2];
            array[hole] = x;
        }
        
        private void EnlargeArray(int newSize) {
            var old = array;
            array = new T[newSize];
            for (int i = 0; i < old.Length; i++) {
                array[i] = old[i];
            }
        }

        
        // Removes the smallest item in the priority queue
        public T Remove()
        {
            T minItem = FindMin();
            array[1] = array[size--];
            PercolateDown(1);
            return minItem;
        }
        
        private void PercolateDown(int hole)
        {
            int child;
            T tmp = array[hole];

            for (; hole * 2 <= size; hole = child)
            {
                child = hole * 2;
                if (child != size && array[child + 1].CompareTo(array[child]) < 0)
                    child++;
                if (array[child].CompareTo(tmp) < 0)
                    array[hole] = array[child];
                else
                    break;
            }
            array[hole] = tmp;
        }
        
        private T FindMin()
        {
            if (IsEmpty())
                throw new Exception("Priority queue is empty");
            
            return array[1];
        }
        
        private bool IsEmpty()
        {
            return size == 0;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            Array.Resize(ref array, ++size+1);
            array[size] = x;

        }

        public void BuildHeap()
        {
            for (int i = size / 2; i > 0; i--) {
                PercolateDown(i);
            }
        }

        public override string ToString()
        {
            if (size == 0) return ""; 
            
            string output = "";

            for (int i = 1; i <= size; i++)
            {
                output += $"{array[i]} ";
            }
            
            return output[..^1];

        }
    }
}
