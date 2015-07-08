using UnityEngine;
using UnityEngine.EventSystems;

using Common.UI.Windows;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking window behaviour.
	/// </summary>
	public class DockingWindowScript : WindowScript, IPointerDownHandler
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

			frame           = WindowFrameType.SingleFrame;
			backgroundColor = Assets.DockWidgets.Colors.dockingWindow;
		}

		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected override void CreateContent(Transform contentTransform, out float width, out float height)
		{
			width  = 200f;
			height = 200f;

			//***************************************************************************
			// Header GameObject
			//***************************************************************************
			#region Header GameObject
			GameObject header = new GameObject("Header");
			Utils.InitUIObject(header, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform headerTransform = header.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(headerTransform, 5f);
			#endregion
			#endregion

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
			Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, 5f, 0f, 0f);
			#endregion
			
			//===========================================================================
			// DockingAreaScript Component
			//===========================================================================
            #region DockingAreaScript Component
			mDockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();

			mDockingAreaScript.AddChildlessListener(Close);
			mDockWidget.InsertToDockingArea(mDockingAreaScript);
            #endregion
            #endregion
		}

		/// <summary>
		/// Handler for pointer down event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnPointerDown(PointerEventData eventData)
		{
			// TODO: [Major] Do not let to drag via content
			StartDragging();
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

