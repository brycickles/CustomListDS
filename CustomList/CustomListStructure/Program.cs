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
        }

    }
}

