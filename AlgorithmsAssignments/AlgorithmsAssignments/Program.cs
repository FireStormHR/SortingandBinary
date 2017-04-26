using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting;
using Dictionaries;

namespace AlgorithmsAssignments
{
  class Program
  {
    const double inf = Double.PositiveInfinity;

    public static double[,] graph3 =
    {
      { inf, inf, -2, inf },
      { 4, inf, 3, inf },
      { inf, inf, inf, 2 },
      { inf, -1, inf, inf }
    };

    static void Main(string[] args)
    {
            int[] myarr = SortFunctions<int>.Sort(new int[] { 6, 2, 8, 12, 49, 3, 1, 10, -5 }, SortingTechniques.MERGE_SORT);
            for (int x = 0; x < myarr.Count(); x = x+1)
            {
                Console.Write(myarr[x]+"   ");
            }
            Console.ReadKey();
            Console.WriteLine("");

            BinarySearchTree<int, int> MyRealTree = new BinarySearchTree<int, int>();
            MyRealTree.Add(8, 8);
            MyRealTree.Add(6, 6);
            MyRealTree.Add(5, 5);
            MyRealTree.Add(2, 2);
            MyRealTree.Add(7, 7);
            MyRealTree.Add(15, 15);
            MyRealTree.Add(20, 20);
            MyRealTree.Add(12, 12);
            MyRealTree.Add(3, 3);

            Console.WriteLine(MyRealTree.ToString());
            Console.ReadKey();
        }
  }
}
