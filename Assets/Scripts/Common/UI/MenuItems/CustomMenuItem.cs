namespace Common.UI.MenuItems
{
    /// <summary>
    /// Common menu item.
    /// </summary>
    public class CustomMenuItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Common.UI.MenuItems.CustomMenuItem"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool visible
        {
            get { return mVisible;  }
            set { mVisible = value; }
        }

        /// <summary>
        /// Gets the assigned <see cref="Common.TreeNode`1"/> instance.
        /// </summary>
        /// <value>The assigned <see cref="Common.TreeNode`1"/> instance.</value>
        public TreeNode<CustomMenuItem> node
        {
            get { return mNode; }
        }



        private bool mVisible;

        /// <summary>
        /// The <see cref="Common.TreeNode`1"/> instance assigned with this menu item.
        /// </summary>
        protected TreeNode<CustomMenuItem> mNode;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.MenuItems.CustomMenuItem"/> class.
        /// </summary>
        public CustomMenuItem()
        {
            mVisible = true;

            mNode = null;
        }
    }
}
