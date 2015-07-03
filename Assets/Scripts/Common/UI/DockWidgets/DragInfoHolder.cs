using UnityEngine.Events;
using UnityEngine.EventSystems;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Drag info holder.
	/// </summary>
	public static class DragInfoHolder
	{
		/// <summary>
		/// Mouse location.
		/// </summary>
		public enum MouseLocation
		{
			/// <summary>
			/// Outside of this docking area.
			/// </summary>
			Outside
			,
			/// <summary>
			/// Inside of this docking area.
			/// </summary>
			Inside
			,
			/// <summary>
			/// The left section.
			/// </summary>
			LeftSection
			,
			/// <summary>
			/// The right section.
			/// </summary>
			RightSection
			,
			/// <summary>
			/// The bottom section.
			/// </summary>
			BottomSection
			,
			/// <summary>
			/// In tabs area of docking group.
			/// </summary>
			Tabs
		}



        /// <summary>
		/// Gets or sets the dock widget.
		/// </summary>
		/// <value>The dock widget.</value>
		public static DockWidgetScript dockWidget
		{
			get { return mDockWidget;  }
            set { mDockWidget = value; }
        }

		/// <summary>
		/// Gets or sets the minimum value.
		/// </summary>
		/// <value>The minimum value.</value>
		public static float minimum
		{
			get { return mMinimum;  }
			set { mMinimum = value; }
		}

		/// <summary>
		/// Gets or sets the docking area.
		/// </summary>
		/// <value>The docking area.</value>
		public static DockingAreaScript dockingArea
		{
			get { return mDockingArea;  }
			set { mDockingArea = value; }
		}

		/// <summary>
		/// Gets or sets the mouse location.
		/// </summary>
		/// <value>The mouse location.</value>
		public static MouseLocation mouseLocation
		{
			get { return mMouseLocation;  }
			set { mMouseLocation = value; }
		}



		private static DockWidgetScript  mDockWidget;
		private static float             mMinimum;
		private static DockingAreaScript mDockingArea;
		private static MouseLocation     mMouseLocation;



		/// <summary>
		/// Initializes the <see cref="Common.UI.DockWidgets.DragInfoHolder"/> class.
		/// </summary>
		static DragInfoHolder()
		{
			mDockWidget    = null;
			mMinimum       = float.MaxValue;
			mDockingArea   = null;
			mMouseLocation = MouseLocation.Outside;
		}
	}
}
