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
            if (size == array.Length)
            {
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, 0, newArray, 0, array.Length);
                array = newArray;
            }
            array[size] = x;
            size++;
            BubbleUp();
        }
        
        private void BubbleUp()
        {
            int index = size - 1;
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (array[index].CompareTo(array[parent]) < 0)
                {
                    T temp = array[index];
                    array[index] = array[parent];
                    array[parent] = temp;
                }
                else
                {
                    break;
                }
                index = parent;
            }
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (size == 0)
            {
                throw new Exception("Priority queue is empty");
            }
            T result = array[0];
            array[0] = array[size - 1];
            size--;
            BubbleDown();
            return result;
        }

        private void BubbleDown()
        {
            int index = 0;
            while (index < size)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                if (left >= size)
                {
                    break;
                }
                int min = left;
                if (right < size && array[right].CompareTo(array[left]) < 0)
                {
                    min = right;
                }
                if (array[index].CompareTo(array[min]) > 0)
                {
                    T temp = array[index];
                    array[index] = array[min];
                    array[min] = temp;
                }
                else
                {
                    break;
                }
                index = min;
            }
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            
        }

        public void BuildHeap()
        {
            
        }

        public override string ToString()
        {
            string output = "";
            
            for (int i = 0; i < size; i++)
            {
                output += array[i] + (i == size - 1 ? "" : " ");
            }

            return output;
        }
    }
}
