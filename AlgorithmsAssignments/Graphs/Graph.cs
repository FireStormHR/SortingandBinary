using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{

  public class Graph
  {
    public double[,] AdjacencyMatrix { get; private set; }
    public int Count { get { return AdjacencyMatrix.GetLength(0); } }

    public Graph(double[,] matrix)
    {
      if (matrix.GetLength(0) != matrix.GetLength(1))
        throw new System.ArgumentException("The adjacency matrix must be a square matrix");
      AdjacencyMatrix = matrix;
    }

    private string DrawSinglePath(int[] steps)
    {
      const string arrow = " -> ";
      string s = "";
      for (int i = 0; i < Count; i++)
      {
        int current = steps[i];
        Stack<int> path = new Stack<int>();
        path.Push(i);
        while (current != -1)
        {
          path.Push(current);
          current = steps[current];
        }

        while (path.Count > 0)
        {
          s += "(" + path.Peek() + ")" + (path.Count == 1 ? "" : arrow);
          path.Pop();
        }

        s += "\n===================\n";
      }
      return s;
    }

    private string DrawAllPaths(int[,] steps)
    {
      const string arrow = " -> ";
      string s = "";
      for (int i = 0; i < Count; i++)
      {
        s += "\n\nSOURCE : " + i + "\n";
        for (int j = 0; j < Count; j++)
        {
          s += "(" + i + ")";
          int current = steps[i, j];
          while (current != -1)
          {
            s += arrow + "(" + current + ")";
            current = steps[current, j];
          }
          s += "\n";
        }
        
      }
      return s;
    }

    public string DrawShortestPaths(int source)
    {
      int[] prev = SingleSourceShortestPath(source).Item2;
      return DrawSinglePath(prev);
    }

    public string DrawAllShortestPaths()
    {
      int[,] next = AllPairShortestPath().Item2;
      return DrawAllPaths(next);   
    }

    public override string ToString()
    {
      string s = "";
      for (int i = 0; i < Count; i++)
      {
        List<int> neighbors = Neighbors(i);
        s += "(" + i + ") ===> (";
        for (int j = 0; j < neighbors.Count; j++)
        {
          s += j == neighbors.Count - 1 ? neighbors[j].ToString() : neighbors[j] + ",";
        }
        s += ")\n";
      }
      return s;
    }

    private List<int> Neighbors(int node)
    {
      List<int> neighbors = new List<int>();
      for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
      {
        if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
          neighbors.Add(i);
      }
      return neighbors;
    }

    public Tuple<double[], int[]> SingleSourceShortestPath(int source) //distance and prev arrays
    {
      double[] distance = new double[Count];
      int[] prev = new int[Count];
      List<int> Q = new List<int>(Count);

      for (int i = 0; i < Count; i++)
      {
        distance[i] = Double.PositiveInfinity;
        prev[i] = -1;
        Q.Add(i);
      }

      distance[source] = 0;
      while (Q.Count > 0)
      {
        int firstUnvisited = Q.First();
        double min = distance[firstUnvisited];
        int minIndex = firstUnvisited;
        for (int i = 0; i < Q.Count; i++)
        {
          if (distance[Q[i]] < min)
          {
            minIndex = Q[i];
            min = distance[Q[i]];
          }
        }

        Q.Remove(minIndex);
        List<int> neighbors = Neighbors(minIndex);

        //COMPLETE THE MISSING PART OF DIJKSTRA ALGORITHM
      }

      return new Tuple<double[], int[]>(distance, prev);
    }

    public Tuple<double[,], int[,]> AllPairShortestPath()
    {
      double[,] distance = new double[Count, Count];
      int[,] next = new int[Count, Count];
      for (int i = 0; i < Count; i++)
        for (int j = 0; j < Count; j++)
        {
          distance[i, j] = Double.PositiveInfinity;
          next[i, j] = -1;
        }
      for (int i = 0; i < Count; i++)
        distance[i, i] = 0;
      for (int i = 0; i < Count; i++)
        for (int j = 0; j < Count; j++)
          if (AdjacencyMatrix[i, j] != Double.PositiveInfinity)
          {
            distance[i, j] = AdjacencyMatrix[i, j];
            next[i, j] = j;
          }

      for (int k = 0; k < Count; k++)
      {
        //COMPLETE THE MISSING PART OF FLOYD-WARSHALL ALGORITHM
      }
      return new Tuple<double[,], int[,]>(distance, next);
    }
  }
}
