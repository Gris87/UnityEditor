using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace common
{
    /// <summary>
    /// Class that representing tree node with children.
    /// </summary>
    public class TreeNode<T>
    {
        private T                 mData;
        private TreeNode<T>       mParent   = null;
        private List<TreeNode<T>> mChildren = null;



        /// <summary>
        /// Initializes a new instance of the <see cref="common.TreeNode`1"/> class with specified data.
        /// </summary>
        /// <param name="data">Data value.</param>
        public TreeNode(T data)
        {
            mData     = data;
            mParent   = null;
            mChildren = new List<TreeNode<T>>();
        }

        /// <summary>
        /// Creates a new <see cref="common.TreeNode`1"/> instance and adds it to the children list.
        /// </summary>
        /// <returns>The child <see cref="common.TreeNode`1"/> instance.</returns>
        /// <param name="data">Data value.</param>
        public TreeNode<T> AddChild(T data)
        {
            TreeNode<T> node = new TreeNode<T>(data);

            node.mParent = this;
            mChildren.Add(node);

            return node;
        }

        /// <summary>
        /// Creates a new <see cref="common.TreeNode`1"/> instances for each children and adds them to the children list.
        /// </summary>
        /// <returns>The array of <see cref="common.TreeNode`1"/> instances.</returns>
        /// <param name="values">Data values.</param>
        public TreeNode<T>[] AddChildren(params T[] values)
        {
            TreeNode<T>[] res = new TreeNode<T>[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                res[i] = AddChild(values[i]);
            }

            return res;
        }

        /// <summary>
        /// Removes child from the children list.
        /// </summary>
        /// <returns><c>true</c>, if child was removed, <c>false</c> otherwise.</returns>
        /// <param name="node">The child <see cref="common.TreeNode`1"/> instance.</param>
        public bool RemoveChild(TreeNode<T> node)
        {
            bool res = mChildren.Remove(node);

            if (res)
            {
                node.mParent = null;
            }

            return res;
        }

        /// <summary>
        /// Gets or sets the data value.
        /// </summary>
        /// <value>The data value.</value>
        public T Data
        {
            get { return mData;  }
            set { mData = value; }
        }

        /// <summary>
        /// Gets the parent <see cref="common.TreeNode`1"/> instance.
        /// </summary>
        /// <value>The parent <see cref="common.TreeNode`1"/> instance.</value>
        public TreeNode<T> Parent
        {
            get { return mParent; }
        }

        /// <summary>
        /// Gets the children list.
        /// </summary>
        /// <value>The children list.</value>
        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return mChildren.AsReadOnly(); }
        }
    }
}
