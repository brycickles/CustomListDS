using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListStructure
{
    public class CustomList<T>
    {
        private int count;
        private int capacity;
        private T[] arr;
        
        public int Count
        {
            get
            {
                return count;
            }
        }//count property 
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }
        public T this[int index]  //indexer
        {
            get
            {
                //make a point to replace the .length with capacity property 
                if (index < 0 && index >= arr.Length)
                {
                    //change this to automatically adjust capacity 
                    throw new ArgumentOutOfRangeException("Exceeded Capacity");
                }
                else
                {
                    return arr[index];
                }

            }

            set
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentOutOfRangeException("Exceeded Capacity");
                }
                else
                {
                    arr[index] = value;
                }

            }
        }

        public CustomList()
        {
            count = 0;
            capacity = 4;
            arr = new T[capacity];
        }
        public void Add(T value)
        { 
            if(count != capacity) //if we have space left in the array 
            {
                arr[count] = value; //store value in index of count 
                count++;
            }
            else //else, the array is full and we need to double the capacity to be able to add more to it 
            {
                //double size of capacity
                capacity *= 2;

                //create temp array of size capacity 
                T[] temp = new T[capacity];

                //move values stored in the current array into an array of doubled capacity 
                for(int i = 0; i < count; i++)
                {
                    temp[i] = arr[i];
                }

                //make array original bigger 
                arr = new T[capacity];

                //move everything back to new array 
                for (int a = 0; a < count; a++)
                {
                    arr[a] = temp[a];
                }

                //store value in index of count 
                arr[count] = value; 
                count++;
            }
            
           
        }
        
    }
}
