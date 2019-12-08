﻿using System;
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
        private T lastItemRemoved;
        private T lastElementPrinted;
        private T[] arr;
        StringBuilder sb = new StringBuilder("this is a stringbuilder");
        
        
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
        public T LastItemRemoved 
        {
            get
            {
                return lastItemRemoved;
            }
        }
        public T LastElementPrinted
        {
            get 
            {
                return lastElementPrinted;
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

        public void Remove(T value)
        {
            if (count == 0)
            {
                //do nothing 
            } 
            else
            {
                //declare new aray
                T[] temp = new T[capacity];
                int j = 0;
                //iterate through array and add to temp array if value at index i does not match value to be removed
                for (int i = 0; i < count; j++)
                {            
                    if(arr[j].Equals(value))
                    {
                        lastItemRemoved = value; //set property value of lastItemRemoved
                        count--; //decrement count of array 
                    }
                    else
                    {
                        temp[i] = arr[j];
                        i++;
                    }
                    
                }

                //these two below lines handle resizing the array to exactly the value it needs to be 
                capacity = count; 
                arr = new T[capacity];

                ////now temp array is assigned all values except removed value. Reassign to array 
                for(int a = 0; a < count; a++)
                {
                   
                   arr[a] = temp[a];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder arrString = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if(i == count -1) //if its the last element in the array 
                {
                    arrString.Append(arr[i]);
                }
                else
                {
                    arrString.Append(arr[i] + ", ");
                }
            }
            return arrString.ToString(); 
        }

        public static CustomList<T> operator +(CustomList<T> listA, CustomList<T> listB)
        {
            CustomList<T> listC = new CustomList<T>();

            //combine both lists into one
            //Add all of first list into new list 
            for(int i = 0; i < listA.Count; i++)
            {
                listC.Add(listA[i]);
            }

            //add second to array 
            for (int i = 0; i < listB.Count; i++)
            {
                listC.Add(listB[i]);
            }         
            return listC;
        }

        public static CustomList<T> operator -(CustomList<T> listA, CustomList<T> listB)
        {
            CustomList<T> listC = new CustomList<T>();

            //iterate through list a, store in temporary list 



            return listC;
        }










    }
}
