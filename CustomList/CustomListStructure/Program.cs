﻿using System;
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

            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
            l1.Add(4);
            l1.Add(5);

            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }
            Console.ReadLine();
        }
    }
}

