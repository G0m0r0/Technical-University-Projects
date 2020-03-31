using System;
using System.Collections.Generic;

namespace trees
{
    class Program
    {
        static void Main(string[] args)
        {
            //not finished

        }
    }
    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if(value==null)
            {
                throw new ArgumentException("Cannot insert null value!");
            }
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }
       public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
