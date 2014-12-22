using System;



namespace common
{
	namespace ui
	{
		public class MenuItem
		{
			public delegate void OnClickListener();
			
			private TreeNode<MenuItem> mNode;
			private string             mName;
			private OnClickListener    mOnClick;
			private bool               mEnabled;
			private bool               mIsSeparator;
			
			
			
			public MenuItem()
			{
				mNode        = null;
				mName        = null;
				mOnClick     = null;
				mEnabled     = false;
				mIsSeparator = false;
			}
			
			public MenuItem(TreeNode<MenuItem> node, string name, OnClickListener onClick, bool enabled = true)
			{
				mNode        = node;
				mName        = name;
				mOnClick     = onClick;
				mEnabled     = enabled;
				mIsSeparator = false;
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

			public static void InsertSeparator(TreeNode<MenuItem> owner)
			{
				TreeNode<MenuItem> node = owner.AddChild(new MenuItem());
				
				node.Data.mNode        = node;
				node.Data.mIsSeparator = true;
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

			public bool IsSeparator
			{
				get { return mIsSeparator; }
			}
		}
	}
}
