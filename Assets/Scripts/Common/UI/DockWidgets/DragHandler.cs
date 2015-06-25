using UnityEngine.Events;
using UnityEngine.EventSystems;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Dragging handler.
	/// </summary>
	public static class DragHandler
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
			/// The top section.
			/// </summary>
			TopSection
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
		/// Gets or sets the handled area.
		/// </summary>
		/// <value>The handled area.</value>
		public static DockingAreaScript handledByArea
		{
			get { return mHandledByArea;  }
			set { mHandledByArea = value; }
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

		/// <summary>
		/// Gets or sets the minimum value.
		/// </summary>
		/// <value>The minimum value.</value>
		public static float minimum
		{
			get { return mMinimum;  }
			set { mMinimum = value; }
		}



		private static DockWidgetScript    mDockWidget;
		private static DockingAreaScript   mHandledByArea;
		private static MouseLocation       mMouseLocation;
		private static float               mMinimum;



		/// <summary>
		/// Initializes the <see cref="Common.UI.DockWidgets.DragHandler"/> class.
		/// </summary>
		static DragHandler()
		{
			mDockWidget    = null;
			mHandledByArea = null;
			mMouseLocation = MouseLocation.Outside;
			mMinimum       = float.MaxValue;
		}
	}
}

