using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomListStructure
{
    public class CustomList<T> : IEnumerable
    {
        #region Private Variables and Public Properties
        //private variables
        private int count;
        private int capacity;
        private T lastItemRemoved;
        private T lastElementPrinted;
        private T[] arr;        
        
        //properties
        public int Count
        {
            get
            {
                return count;
            }
        }
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
        #endregion

        #region Indexer and Numerator
        //indexer
        public T this[int index]  
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

        //Numerator
        IEnumerator IEnumerable.GetEnumerator()
        {
        return arr.GetEnumerator();

        }
        #endregion

        #region  Constructor
        public CustomList()
        {
            count = 0;
            capacity = 4;
            arr = new T[capacity];
        }
        #endregion

        #region Overloads/Overrides/Methods
        //Methods
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
        public void RemoveAt(T value)
        {
            if (count == 0)
            {
                //do nothing 
            }
            else
            {                
                bool hasBeenRemovedAlready = false;
                T[] temp = new T[capacity];
                int j = 0;
                //iterate through array and add to temp array if value at index i does not match value to be removed
                for (int i = 0; i < count;)
                {
                    if(i == count -1) //if i is last element in array
                    {
                        break;
                    }
                    else if (arr[i].Equals(value))
                    {
                        if (hasBeenRemovedAlready == true)
                        {
                            temp[i] = arr[j];
                            i++;
                            j++;
                        }
                        if (hasBeenRemovedAlready == false)
                        {
                            lastItemRemoved = value; //set property value of lastItemRemoved 
                            hasBeenRemovedAlready = true;
                            temp[i] = arr[j + 1];                            
                            j++;
                        }                        
                    }
                    else
                    {                        
                        temp[i] = arr[j];
                        i++;
                        j++;
                    }

                }

                if (hasBeenRemovedAlready == true)
                {
                    count--;
                }
                //these two below lines handle resizing the array to exactly the value it needs to be 
                capacity = count;
                arr = new T[capacity];

                ////now temp array is assigned all values except removed value. Reassign to array 
                for (int a = 0; a < count; a++)
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
        public string Zipper(CustomList<int> first, CustomList<int> second)
        {
            CustomList<int> result = new CustomList<int>();
            for (int a = 0; a < first.Count; a++)
            {
                result.Add(first[a]);
            }
            for (int b = 0; b < first.Count; b++)
            {
                result.Add(second[b]);
            }
            //create a alist of size necessary to store both lists worth of numbers into. This will be rewritten anyway. 

            int firstIndex = 0, secondIndex = 0, resultIndex = 0;

            while (firstIndex < first.Count && secondIndex < second.Count) //keeps each limited to actual size of each list
            {
                if (first[firstIndex] < second[secondIndex])
                {
                    result[resultIndex++] = first[firstIndex++];
                }
                else
                {
                    result[resultIndex++] = second[secondIndex++];
                }
            }

            if (firstIndex < first.Count)
            {
                for (int a = firstIndex; a < first.Count; a++)
                    result[resultIndex] = first[a];
            }

            if (secondIndex < second.Count)
            {
                for (int a = secondIndex; a < second.Count; a++)
                    result[resultIndex++] = second[a];
            }

            return result.ToString();
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
            CustomList<T> newList = new CustomList<T>();
            bool doesMatch = false; 
            //iterate through list a, store in temporary list 

            // (10 points): As a developer, I want to be able to overload the – operator, so that I can subtract one instance of a custom list class from another instance of a custom list class.
            //-	List<int> one = new List<int>() { 1, 3, 5 }; and List<int> two = new List<int>() { 2, 1, 6 };
            //-	List<int> result = one - two;
            //-	result has 3,5
            
            //first, add the three from A to list C. This will always happen as we are subrtacting from A 
            for( int i = 0; i < listA.Count; i++)
            {
                newList.Add(listA[i]);
            }
            
            for(int j = 0; j < newList.Count; j++)
            {
                for(int k = 0; k < listB.Count; k++){

                    if (newList[j].Equals(listB[k]))
                    {
                        doesMatch = true;

                    }

                }
                if(doesMatch == true)
                {
                    newList.Remove(newList[j]);
                    doesMatch = false; 
                }
                
                //wheck though loop and set boolean condition = true 

            }


            return newList;
        }
        #endregion
    }
}
