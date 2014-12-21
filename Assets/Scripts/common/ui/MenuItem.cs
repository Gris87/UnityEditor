using System;

using common;



namespace ui
{
    public class MenuItem
    {
        public delegate void OnClickListener();

        private TreeNode<MenuItem> mNode;
        private string             mName;
        private OnClickListener    mOnClick;
        private bool               mEnabled;



        public MenuItem()
        {
            mNode    = null;
            mName    = null;
            mOnClick = null;
            mEnabled = false;
        }

        public MenuItem(TreeNode<MenuItem> node, string name, OnClickListener onClick, bool enabled = true)
        {
            mNode    = node;
            mName    = name;
            mOnClick = onClick;
            mEnabled = enabled;
        }

        public static TreeNode<MenuItem> Create(TreeNode<MenuItem> owner, string name, OnClickListener onClick, bool enabled = true)
        {
            TreeNode<MenuItem> node = owner.AddChild(new MenuItem());

            node.Data.mNode    = node;
            node.Data.mName    = name;
            node.Data.mOnClick = onClick;
            node.Data.mEnabled = enabled;

            return node;
        }

        public TreeNode<MenuItem> Node
        {
            get { return mNode; }
        }

        public string Name
        {
            get { return mName; }
        }

        public OnClickListener OnClick
        {
            get { return mOnClick; }
        }

        public bool Enabled
        {
            get { return mEnabled;  }
            set { mEnabled = value; }
        }
    }
}

