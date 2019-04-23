using System;

namespace _63._20
{
    class Program
    {
        //page 63 exercise 20ty 
        //binary tree search min max function
        public static void Main(string[] args)
        {
            //insert three
        }        
    }
    public class Node
    {
        //node value is integer
        public int value;
        public Node left, right;

        public Node(int d)
        {
            value = d;
            left = right = null;
        }
    }
    public class BinaryTree
    {
        public int MinValue(Node node)
        {
            Node parentNode = node;

            //search left side for min element
            while (parentNode.left != null)
            {
                  parentNode = parentNode.left;
            }
            return (parentNode.value);
        }
        public int MaxValue(Node node)
        {
            Node parentNode = node;

            //search right side for max element
            while (parentNode.right != null)
            {
                parentNode = parentNode.right;
            }
            return parentNode.value;
        }
    }
}