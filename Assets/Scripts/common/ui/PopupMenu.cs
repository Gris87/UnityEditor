using UnityEngine;
using UnityEngine.Events;
using System;



namespace common
{
	namespace ui
	{
		public class PopupMenu
		{
			private TreeNode<MenuItem> mItems     = null;
			private UnityEvent         mOnDestroy = null;



			public PopupMenu(TreeNode<MenuItem> items)
			{
				mItems     = items;
				mOnDestroy = new UnityEvent();
			}

			public void Destroy()
			{
				Debug.Log("PopupMenu.Destroy");

				mOnDestroy.Invoke();
			}

			public TreeNode<MenuItem> items
			{
				get { return mItems; }
			}
						
			public UnityEvent OnDestroy
			{
				get { return mOnDestroy; }
			}
		}
	}
}
