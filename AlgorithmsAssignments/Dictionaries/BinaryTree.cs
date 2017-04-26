using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
  public interface Dictionary<K, V> where K : IComparable
  {
    void Add(K key, V value);
    void Delete(K key);
    V Find(K key);
  }

  public class Node<K, V> where K : IComparable
  {

    public K Key { get; set; }
    public V Value { get; set; }
    public Node<K, V> Left { get; set; }
    public Node<K, V> Right { get; set; }
    public Node<K, V> Parent { get; set; }

    public Node(K key, V value)
    {
      Key = key;
      Value = value;
    }

    public bool IsLeaf
    {
      get { return Left == null && Right == null; }
    }
  }

  public class BinarySearchTree<K, V> where K : IComparable
  {
    public Node<K, V> Root { get; private set; }
    public int Count { get; private set; } = 0;
    public int TraversalCount
    {
      get
      {
        return InOrderFold((acc, _) => acc += 1, 0, Root);
      }
    }


    public override string ToString()
    {
      return InOrderFold((acc, n) => acc += "(" + n.Key.ToString() + "," + n.Value.ToString() + ")", "", Root);
    }

    private T InOrderFold<T>(Func<T, Node<K, V>, T> op, T accumulator, Node<K, V> node)
    {
      if (node.Left != null)
        accumulator = InOrderFold(op, accumulator, node.Left);
      accumulator = op(accumulator, node);
      if (node.Right != null)
        accumulator = InOrderFold(op, accumulator, node.Right);
      return accumulator;
    }


    public void Add(K key, V value)
    {
        bool Done = false;
        if (this.Root == null)
        {
            this.Root = new Node<K, V>(key, value);
            Done = true;
        }
        var CurrentNode = this.Root;
        
        while (Done == false)
        {
            
            if (key.CompareTo(CurrentNode.Key) >= 0)
            {
                if (CurrentNode.Right == null)
                {
                    CurrentNode.Right = new Node<K, V>(key, value);
                    Done = true;
                }
                else 
                    CurrentNode = CurrentNode.Right;
                
            }




            else if (key.CompareTo(CurrentNode.Key) < 0)
            {
                if (CurrentNode.Left == null)
                {
                    CurrentNode.Left = new Node<K, V>(key, value);
                    Done = true;
                }
                else
                    CurrentNode = CurrentNode.Left;
               
            }
        }


      //COMPLETE THE MISSING ADD METHOD
    }

    private Node<K, V> Traversal(K key, Node<K,V> node)
    {
      if (node == null)
        return null;
      if (key.CompareTo(node.Key) == 0)
        return node;
      else if (key.CompareTo(node.Key) < 0)
        return Traversal(key, node.Left);
      else
        return Traversal(key, node.Right);
    }

    public V Find(K key)
    {
      Node<K,V> node = Traversal(key, Root);
      if (node == null)
        throw new System.ArgumentException("The key is not in the dictionary");
      else
        return node.Value;
    }

    public void Remove(K key)
    {
      Node<K, V> nodeToRemove = Traversal(key, Root);
      if (nodeToRemove == null)
        return;
      Delete(nodeToRemove);
      Count--;
    }

    private void Delete(Node<K, V> node)
    {
      if (node.IsLeaf)
      {
        if (node.Parent.Left == node)
          node.Parent.Left = null;
        else
          node.Parent.Right = null;
      }
      else if (node.Right == null)
      {
        if (node.Parent.Left == node)
          node.Parent.Left = node.Left;
        else
          node.Parent.Right = node.Left;
      }
      else if (node.Left == null)
      {
        if (node.Parent.Left == node)
          node.Parent.Left = node.Right;
        else
          node.Parent.Right = node.Right;
      }
      else
      {
        Node<K, V> pred = node.Left;
        while (pred.Right != null)
          pred = pred.Right;
        node.Key = pred.Key;
        node.Value = pred.Value;
        Delete(pred);
      }
    }
  }
}
