using UnityEngine;
using UnityEngine.UI;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize dock widget behaviour.
	/// </summary>
	public class DockWidgetScript : MonoBehaviour
	{
		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		/// <value>Background color.</value>
		public Color backgroundColor
		{
			get
			{
				return mBackgroundColor;
			}
			
			set
			{
				if (mBackgroundColor != value)
				{
					mBackgroundColor = value;
					
					if (IsUICreated())
					{
						mContentBackgroundImage.color = mBackgroundColor;
					}
				}
			}
		}



		private Color mBackgroundColor;

		private RectTransform mContentTransform;
		private Image         mContentBackgroundImage;



		public DockWidgetScript()
			: base()
		{
			mBackgroundColor = new Color(1f, 1f, 1f, 1f);

			mContentTransform       = null;
			mContentBackgroundImage = null;
		}

		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			CreateUI();
		}

		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			mContentTransform = gameObject.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(mContentTransform);
			#endregion

			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			gameObject.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			mContentBackgroundImage = gameObject.AddComponent<Image>();
			mContentBackgroundImage.color = mBackgroundColor;
			#endregion
			
			//===========================================================================
			// Mask Component
			//===========================================================================
			#region Mask Component
			gameObject.AddComponent<Mask>();
			#endregion

			CreateContent(mContentTransform);
		}

		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected virtual void CreateContent(Transform contentTransform)
		{
			// Nothing
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		public virtual void OnResize()
		{
			// Nothing
        }

		/// <summary>
		/// Insert dock widget into specified docking area.
		/// </summary>
		/// <param name="dockingArea">Docking area.</param>
		/// <param name="orientation">Orientation.</param>
		/// <param name="index">Index.</param>
		public void InsertToDockingArea(DockingAreaScript dockingArea, DockingAreaOrientation orientation = DockingAreaOrientation.Horizontal, int index = 0)
		{
			dockingArea.InsertDockWidget(this, orientation, index);
		}

		/// <summary>
		/// Insert dock widget into specified docking area.
		/// </summary>
		/// <param name="dockingArea">Docking area.</param>
		/// <param name="orientation">Orientation.</param>
		/// <param name="index">Index.</param>
		public void InsertToDockingGroup(DockingGroupScript dockingGroup, int index = 0)
		{
			dockingGroup.InsertDockWidget(this, index);
		}

		/// <summary>
		/// Determines whether user interface created or not.
		/// </summary>
		/// <returns><c>true</c> if user interface created; otherwise, <c>false</c>.</returns>
		private bool IsUICreated()
		{
			return (mContentTransform != null);
		}
	}
}

