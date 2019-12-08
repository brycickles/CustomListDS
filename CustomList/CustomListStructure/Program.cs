using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> l1 = new CustomList<int>();

            //Console.WriteLine("Testing addition function");
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
            l1.Add(4);
            l1.Add(5);
            l1.Add(6);
            l1.Add(7);

            //for (int i = 0; i < l1.Count; i++)
            //{
            //    Console.WriteLine(l1[i]);
            //}
            //Console.ReadLine();
            //Console.Clear();


            Console.WriteLine("Testing Removal Function");
            Console.WriteLine("Current Array Values:");
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }

            Console.WriteLine("Removing 3 with Remove()");
            l1.Remove(3);

            Console.WriteLine("Displaying new List");
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }

            Console.WriteLine("Removing 7 with Remove()");
            l1.Remove(7);

            Console.WriteLine("Displaying new List");
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }
            Console.ReadLine();
            Console.Clear();

            //Console.WriteLine("String representation of array:"); 
            //string arrString = l1.ToString();

            //Console.WriteLine(arrString);
            //Console.ReadLine();


            Console.WriteLine("Adding Two lists.");

            CustomList<int> lA = new CustomList<int>();
            lA.Add(1);
            lA.Add(2);
            lA.Add(3);

            CustomList<int> lB = new CustomList<int>();
            lB.Add(3);
            lB.Add(4);
            lB.Add(5);

            CustomList<int> lC = new CustomList<int>();

            lC = lA + lB;

            string listAoutput = lA.ToString();
            string listBOutput = lB.ToString();
            Console.WriteLine("List A contains: {0}", listAoutput);
            Console.WriteLine("List B contains: {0}", listBOutput);

            string lCoutput = lC.ToString();
            Console.WriteLine("List A + List B = {0}", lCoutput);
            Console.ReadLine();

        }

    }
}

