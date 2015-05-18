namespace common
{
	namespace ui
	{
		/// <summary>
		/// Menu separator item.
		/// </summary>
		public class MenuSeparatorItem : CustomMenuItem
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="common.ui.MenuSeparatorItem"/> class.
			/// </summary>
			private MenuSeparatorItem()
				: base()
			{
			}

			/// <summary>
			/// Creates <see cref="common.ui.MenuSeparatorItem"/> instance that representing separator and adds it to
			/// <see cref="common.TreeNode`1"/> instance.
			/// </summary>
			/// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
			public static void Create(TreeNode<CustomMenuItem> owner)
			{
				MenuSeparatorItem        item = new MenuSeparatorItem();
				TreeNode<CustomMenuItem> node = owner.AddChild(item);
				
				item.mNode = node;
			}
		}
	}
}

