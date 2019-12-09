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
            #region Test Removal Function
            CustomList<int> l1 = new CustomList<int>() { 1, 2, 3, 3, 4, 5, 5, 6, 7 };
            
            Console.WriteLine("Testing Removal Function");
            Console.WriteLine("Current Array Values:");
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }

            Console.WriteLine("Removing all 3's with Remove()");
            l1.Remove(3);

            Console.WriteLine("Displaying new List");
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Removing one 5 with RemoveAt()");
            l1.RemoveAt(5);

            Console.WriteLine("Displaying new List");
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }
            Console.ReadLine();
            Console.Clear();
            #endregion


            #region Test ToString, +/- operators
            Console.WriteLine("Adding Two lists.");

            CustomList<int> lA = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> lB = new CustomList<int>() { 3, 4, 5 };
            CustomList<int> lC = new CustomList<int>();

            lC = lA + lB;

            string listAoutput = lA.ToString();
            string listBOutput = lB.ToString();
            Console.WriteLine("List A contains: {0}", listAoutput);
            Console.WriteLine("List B contains: {0}", listBOutput);

            string lCoutput = lC.ToString();
            Console.WriteLine("List A + List B = {0}", lCoutput);
            Console.ReadLine();


            CustomList<int> listA = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> listB = new CustomList<int>() { 2, 1, 6 };
            Console.WriteLine("List A: {0}\nList B: {1}", listA.ToString(), listB.ToString());

            lC = listA - listB;

            Console.WriteLine("List A - List B: \n{0}", lC.ToString());
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Test Zipper Function
            listA = new CustomList<int>() { 1, 3, 7, 9, 11 };
            listB = new CustomList<int>() { 0, 2, 4, 6, 14 };

            Console.WriteLine("List A: {0}\nList B: {1}", listA.ToString(), listB.ToString());
            lC = new CustomList<int>();
            Console.WriteLine("Zipped!");
            string lCZipped = lC.Zipper(listA, listB);
            Console.WriteLine(lCZipped);
            #endregion

            Console.ReadLine();
        }

    }
}

