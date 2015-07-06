using UnityEngine;

using Common.UI.Windows;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking window behaviour.
	/// </summary>
	public class DockingWindowScript : WindowScript
	{
		/// <summary>
		/// Gets or sets the dock widget.
		/// </summary>
		/// <value>The dock widget.</value>
		public DockWidgetScript dockWidget
		{
			get { return mDockWidget;  }
			set { mDockWidget = value; }
		}



		private DockWidgetScript  mDockWidget;

		private DockingAreaScript mDockingAreaScript;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingWindowScript"/> class.
		/// </summary>
		private DockingWindowScript()
			: base()
		{
			mDockWidget        = null;

			mDockingAreaScript = null;

			frame      = WindowFrameType.Drawer;
			allowClose = false;
		}

		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected override void CreateContent(Transform contentTransform, out float width, out float height)
		{
			width  = 100f;
			height = 100f;

			//***************************************************************************
			// DockingArea GameObject
			//***************************************************************************
			#region DockingArea GameObject
			GameObject dockingArea = new GameObject("DockingArea");
			Utils.InitUIObject(dockingArea, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(dockingAreaTransform);
			#endregion
			
			//===========================================================================
			// DockingAreaScript Component
			//===========================================================================
            #region DockingAreaScript Component
			mDockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();

			mDockWidget.InsertToDockingArea(mDockingAreaScript);
            #endregion
            #endregion
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		protected override void OnResize()
		{
			if (mDockingAreaScript != null)
			{
				mDockingAreaScript.OnResize();
			}
        }
    }
}

