using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
  public enum SortingTechniques { MERGE_SORT };

  public class SortFunctions<T> where T : IComparable
  {

    private static T[] Merge(T[] arr, int left, int middle, int right)
    {
      int i, j, k;
      T[] arr1 = new T[middle - left + 1];
      T[] arr2 = new T[right - middle];
      for (i = 0, k = left; i < arr1.Length; i++, k++)
        arr1[i] = arr[k];
      for (j = 0, k = middle + 1; j < arr2.Length; j++, k++)
        arr2[j] = arr[k];
      i = j = 0;
      k = left;
      while (i < arr1.Length && j < arr2.Length)
      {
        if (arr1[i].CompareTo(arr2[j]) <= 0)
          arr[k++] = arr1[i++];
        else
          arr[k++] = arr2[j++];
      }
      if (i == arr1.Length)
      {
        for (; j < arr2.Length; j++, k++)
          arr[k] = arr2[j];
      }
      else
      {
        for (; i < arr1.Length; i++, k++)
          arr[k] = arr1[i];
      }
      return arr;
    }

    private static T[] MergeSort(T[] arr, int leftBoundary, int rightBoundary)
    {
            if (leftBoundary+1 < rightBoundary)
            {
                MergeSort(arr, leftBoundary, rightBoundary-(rightBoundary - leftBoundary)/2);
                MergeSort(arr, leftBoundary+(rightBoundary - leftBoundary) / 2+1, rightBoundary);
                
            }
            Merge(arr, leftBoundary, leftBoundary+(rightBoundary-leftBoundary)/2, rightBoundary);
            return arr;


      //COMPLETE THE MERGE SORT METHOD


    }

    public static T[] Sort(T[] arr, SortingTechniques sortingAlgorithm)
    {
      switch (sortingAlgorithm)
      {
        case SortingTechniques.MERGE_SORT:
          return MergeSort(arr, 0, arr.Length - 1);
        default:
          break;
      }
      return arr;
    }
  }
}
