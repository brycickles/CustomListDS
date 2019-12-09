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
            #region Test RemovalAt Function
            CustomList<int> l1 = new CustomList<int>() { 1, 2, 3 };
            
            Console.WriteLine("Removing 9 (not present) with RemoveAt()");
            l1.RemoveAt(9);

            Console.WriteLine("Displaying List Without 9");
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
            CustomList<int> listC = new CustomList<int>();

            Console.WriteLine("List A: {0}\nList B: {1}\n List C: {2}", listA.ToString(), listB.ToString(), listC.ToString());
            lC = new CustomList<int>();

            Console.WriteLine("List A and B Zipped!");
            lC = lC.ZipperMerge(listA, listB);
            Console.WriteLine(lC.ToString());

           

            listA = new CustomList<int> {  1, 3, 5 }; 
            listC = new CustomList<int> {  };
            Console.WriteLine("List A and C Zipped!\nList A is now 1, 3, 5");
            lC = lC.ZipperMerge(listA, listC);
            Console.WriteLine(lC.ToString());
            #endregion




            Console.ReadLine();
        }

    }
}

