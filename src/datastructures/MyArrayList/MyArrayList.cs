using System;
using System.Linq;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            // Write implementation here
            data = new int[capacity];
        }

        public void Add(int n)
        {
            // Write implementation here
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0)
                {
                    data[i] = n;
                    size++;
                    return;
                }
            }

            throw new MyArrayListFullException();
        }

        public int Get(int index)
        {
            if (size == 0 || index >= data.Length || index < 0 || data[index] == 0)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
            
            return data[index];
        }

        public void Set(int index, int n)
        {
            if (size == 0 || index >= data.Length || index < 0 || data[index] == 0)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        public int Capacity()
        {
            // Write implementation here
            return data.Length;
        }

        public int Size()
        {
            // Write implementation here
            return size;
        }

        public void Clear()
        {
            // Write implementation here
            data = new int[data.Length];
            size = 0;
        }

        public int CountOccurences(int n)
        {
            // Write implementation here
            return data.Count(i => i == n);
        }

        public override string ToString()
        {
            var filteredData = data.Where(i => i > 0);
            
            if (!filteredData.Any())
            {
                return "NIL";
            }

            return "[" + string.Join(",", filteredData) + "]";
        }
    }
}
