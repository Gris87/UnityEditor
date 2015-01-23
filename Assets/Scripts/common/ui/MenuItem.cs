using UnityEngine.Events;
using System;



namespace common
{
	namespace ui
	{
		/// <summary>
		/// Menu item.
		/// </summary>
		public class MenuItem
		{			
			private TreeNode<MenuItem> mNode        = null;
			private string             mName        = null; // TODO: Name => token id
			private UnityAction        mOnClick     = null;
			private bool               mEnabled     = false;
			private bool               mIsSeparator = false;
			


			/// <summary>
			/// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class.
			/// </summary>
			public MenuItem()
			{
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class with given name and with
			/// assigning to specified <see cref="common.TreeNode`1"/> instance.
			/// </summary>
			/// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
			/// <param name="name">Menu item name.</param>
			/// <param name="onClick">Click event handler.</param>
			/// <param name="enabled">Is this menu item enabled or not.</param>
			public static TreeNode<MenuItem> Create(TreeNode<MenuItem> owner, string name, UnityAction onClick = null, bool enabled = true)
			{
				TreeNode<MenuItem> node = owner.AddChild(new MenuItem());
				
				node.Data.mNode    = node;
				node.Data.mName    = name;
				node.Data.mOnClick = onClick;
				node.Data.mEnabled = enabled;
				
				return node;
			}

			/// <summary>
			/// Creates <see cref="common.ui.MenuItem"/> instance that representing separator and adds it to
			/// <see cref="common.TreeNode`1"/> instance.
			/// </summary>
			/// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
			public static void InsertSeparator(TreeNode<MenuItem> owner)
			{
				TreeNode<MenuItem> node = owner.AddChild(new MenuItem());
				
				node.Data.mNode        = node;
				node.Data.mIsSeparator = true;
			}

			/// <summary>
			/// Gets the assigned <see cref="common.TreeNode`1"/> instance.
			/// </summary>
			/// <value>The assigned <see cref="common.TreeNode`1"/> instance.</value>
			public TreeNode<MenuItem> Node
			{
				get { return mNode; }
			}

			/// <summary>
			/// Gets the menu item name.
			/// </summary>
			/// <value>The menu item name.</value>
			public string Name
			{
				get { return mName; }
			}

			/// <summary>
			/// Gets the click event handler.
			/// </summary>
			/// <value>The click event handler.</value>
			public UnityAction OnClick
			{
				get { return mOnClick; }
			}

			/// <summary>
			/// Gets or sets a value indicating whether this <see cref="common.ui.MenuItem"/> is enabled.
			/// </summary>
			/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
			public bool Enabled
			{
				get { return mEnabled;  }
				set { mEnabled = value; }
			}

			/// <summary>
			/// Gets a value indicating whether this instance is separator.
			/// </summary>
			/// <value><c>true</c> if this instance is separator; otherwise, <c>false</c>.</value>
			public bool IsSeparator
			{
				get { return mIsSeparator; }
			}
		}
	}
}
