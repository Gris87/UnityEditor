namespace Common.UI.MenuItems
{
	/// <summary>
	/// Common menu item.
	/// </summary>
	public class CustomMenuItem
	{
		/// <summary>
		/// The <see cref="Common.TreeNode`1"/> instance assigned with this menu item.
		/// </summary>
		protected TreeNode<CustomMenuItem> mNode;
		
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.MenuItems.CustomMenuItem"/> class.
		/// </summary>
		public CustomMenuItem()
		{
			mNode = null;
		}
		
		/// <summary>
		/// Gets the assigned <see cref="Common.TreeNode`1"/> instance.
		/// </summary>
		/// <value>The assigned <see cref="Common.TreeNode`1"/> instance.</value>
		public TreeNode<CustomMenuItem> Node
		{
			get { return mNode; }
		}
	}
}
