using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace common
{
    public class TreeNode<T>
    {
        private T                 mData;
        private TreeNode<T>       mParent;
        private List<TreeNode<T>> mChildren;



        public TreeNode(T data)
        {
            mData     = data;
            mParent   = null;
            mChildren = new List<TreeNode<T>>();
        }

        public TreeNode<T> AddChild(T data)
        {
            TreeNode<T> node = new TreeNode<T>(data);

            node.mParent = this;
            mChildren.Add(node);

            return node;
        }

        public TreeNode<T>[] AddChildren(params T[] values)
        {
            TreeNode<T>[] res = new TreeNode<T>[values.Length];

            for (int i=0; i<values.Length; ++i)
            {
                res[i] = AddChild(values[i]);
            }

            return res;
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return mChildren.Remove(node);
        }

        public T Data
        {  
            get { return mData;  }            
            set { mData = value; }
        }

        public TreeNode<T> Parent
        {   
            get { return mParent; }
        }

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return mChildren.AsReadOnly(); }
        }
    }
}

