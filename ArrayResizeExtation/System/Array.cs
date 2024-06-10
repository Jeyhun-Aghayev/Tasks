using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayResizeExtation.System
{
    public class Array<T>
    {
        private T[] data;
        private int size;

        public Array(int size)
        {
            this.size = size;
            this.data = new T[size];
        }

        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public void Resize(int newSize)
        {
            if (newSize < size)
            {
                T[] newData = new T[newSize];
                Array.Copy(data, newData, newSize);
                data = newData;
            }
            else if (newSize > size)
            {
                T[] newData = new T[newSize];
                Array.Copy(data, newData, size);
                data = newData;
            }
            size = newSize;
        }
        public void Resize(int newSize, T[] added)
        {
            T[] newData = new T[newSize];

            if (newSize < size)
            {
                Array.Copy(data, newData, newSize);
                data = newData;
            }
            else if (newSize > size)
            {
                Array.Copy(data, newData, size);
                data = newData;
            }
            size = newSize;
            for (int i = added.Length ; i < newData.Length; i++)
            {
                newData[i] = added[i-added.Length-1];
            }
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", data) + "]";
        }
    }    
}
