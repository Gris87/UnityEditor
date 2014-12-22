using UnityEngine.Events;
using System;



namespace common
{
	namespace ui
	{
		public class MenuItem
		{			
			private TreeNode<MenuItem> mNode        = null;
			private string             mName        = null;
			private UnityAction        mOnClick     = null;
			private bool               mEnabled     = false;
			private bool               mIsSeparator = false;
			
			
			
			public MenuItem()
			{
			}
			
			public MenuItem(TreeNode<MenuItem> node, string name, UnityAction onClick = null, bool enabled = true)
			{
				mNode    = node;
				mName    = name;
				mOnClick = onClick;
				mEnabled = enabled;
			}
			
			public static TreeNode<MenuItem> Create(TreeNode<MenuItem> owner, string name, UnityAction onClick = null, bool enabled = true)
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
			
			public UnityAction OnClick
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
