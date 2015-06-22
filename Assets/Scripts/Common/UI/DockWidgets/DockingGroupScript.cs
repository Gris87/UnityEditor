using System.Collections.Generic;
using UnityEngine;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking group behaviour.
	/// </summary>
	public class DockingGroupScript : MonoBehaviour
	{
		private List<DockWidgetScript> mDockWidgets;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingGroupScript"/> class.
		/// </summary>
		public DockingGroupScript()
		{
			mDockWidgets = new List<DockWidgetScript>();
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		public void OnResize()
		{
			foreach (DockWidgetScript dockWidget in mDockWidgets)
			{
				dockWidget.OnResize();
			}
        }

		/// <summary>
		/// Insert the specified dock widget.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		/// <param name="index">Index.</param>
		public void InsertDockWidget(DockWidgetScript dockWidget, int index = 0)
		{
			mDockWidgets.Insert(index, dockWidget);
		}

		/// <summary>
		/// Removes the dock widget.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		public void RemoveDockWidget(DockWidgetScript dockWidget)
		{
			mDockWidgets.Remove(dockWidget);
		}
	}
}

