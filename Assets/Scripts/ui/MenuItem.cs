using System;

using common;



namespace ui
{
    public class MenuItem
    {
        public delegate void OnClickedListener();

        private TreeNode<MenuItem> mNode;
        private string             mName;
        private OnClickedListener  mOnClicked;
        private bool               mEnabled;



        public MenuItem()
        {
            mNode      = null;
            mName      = null;
            mOnClicked = null;
            mEnabled   = false;
        }

        public MenuItem(TreeNode<MenuItem> node, string name, OnClickedListener onClicked, bool enabled = true)
        {
            mNode      = node;
            mName      = name;
            mOnClicked = onClicked;
            mEnabled   = enabled;
        }

        public static TreeNode<MenuItem> Create(TreeNode<MenuItem> owner, string name, OnClickedListener onClicked, bool enabled = true)
        {
            TreeNode<MenuItem> node = owner.AddChild(new MenuItem());

            node.Data.mNode      = node;
            node.Data.mName      = name;
            node.Data.mOnClicked = onClicked;
            node.Data.mEnabled   = enabled;

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

        public OnClickedListener OnClicked
        {
            get { return mOnClicked; }
        }

        public bool Enabled
        {
            get { return mEnabled;  }
            set { mEnabled = value; }
        }
    }
}

