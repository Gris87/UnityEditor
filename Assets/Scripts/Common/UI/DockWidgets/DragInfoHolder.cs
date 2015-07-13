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
            get { return sDockWidget;  }
            set { sDockWidget = value; }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public static float minimum
        {
            get { return sMinimum;  }
            set { sMinimum = value; }
        }

        /// <summary>
        /// Gets or sets the docking area.
        /// </summary>
        /// <value>The docking area.</value>
        public static DockingAreaScript dockingArea
        {
            get { return sDockingArea;  }
            set { sDockingArea = value; }
        }

        /// <summary>
        /// Gets or sets the mouse location.
        /// </summary>
        /// <value>The mouse location.</value>
        public static MouseLocation mouseLocation
        {
            get { return sMouseLocation;  }
            set { sMouseLocation = value; }
        }



        private static DockWidgetScript  sDockWidget;
        private static float             sMinimum;
        private static DockingAreaScript sDockingArea;
        private static MouseLocation     sMouseLocation;



        /// <summary>
        /// Initializes the <see cref="Common.UI.DockWidgets.DragInfoHolder"/> class.
        /// </summary>
        static DragInfoHolder()
        {
            sDockWidget    = null;
            sMinimum       = float.MaxValue;
            sDockingArea   = null;
            sMouseLocation = MouseLocation.Outside;
        }
    }
}
