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
		/// Gets or sets the docking area.
		/// </summary>
		/// <value>The docking area.</value>
		public static DockingAreaScript dockingArea
		{
			get { return mDockingArea;  }
			set { mDockingArea = value; }
		}

		/// <summary>
		/// Gets or sets the docking area orientation.
		/// </summary>
		/// <value>The docking area orientation.</value>
		public static DockingAreaOrientation dockingAreaOrientation
		{
			get { return mDockingAreaOrientation;  }
			set { mDockingAreaOrientation = value; }
		}

		/// <summary>
		/// Gets or sets the docking group.
		/// </summary>
		/// <value>The docking group.</value>
		public static DockingGroupScript dockingGroup
		{
			get { return mDockingGroup;  }
			set { mDockingGroup = value; }
		}

		/// <summary>
		/// Gets or sets the index for insertion.
		/// </summary>
		/// <value>The index for insertion.</value>
		public static int insertIndex
		{
			get { return mInsertIndex;  }
			set { mInsertIndex = value; }
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
		/// Gets or sets the mouse location.
		/// </summary>
		/// <value>The mouse location.</value>
		public static MouseLocation mouseLocation
		{
			get { return mMouseLocation;  }
			set { mMouseLocation = value; }
		}



		private static DockWidgetScript       mDockWidget;
		private static DockingAreaScript      mDockingArea;
		private static DockingAreaOrientation mDockingAreaOrientation;
		private static DockingGroupScript     mDockingGroup;
		private static int                    mInsertIndex;
		private static float                  mMinimum;
		private static MouseLocation          mMouseLocation;



		/// <summary>
		/// Initializes the <see cref="Common.UI.DockWidgets.DragHandler"/> class.
		/// </summary>
		static DragHandler()
		{
			mDockWidget             = null;
			mDockingArea            = null;
			mDockingAreaOrientation = DockingAreaOrientation.None;
			mDockingGroup           = null;
			mInsertIndex            = -1;
			mMinimum                = float.MaxValue;
			mMouseLocation          = MouseLocation.Outside;
		}
	}
}
