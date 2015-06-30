using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize dock widget behaviour.
	/// </summary>
	public class DockWidgetScript : MonoBehaviour
	{
		/// <summary>
		/// Gets or sets parent docking group.
		/// </summary>
		/// <value>Parent docking group.</value>
		public DockingGroupScript parent
		{
			get { return mParent;  }
			set { mParent = value; }
		}

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

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>The image.</value>
		public Sprite image
		{
			get
			{
				return mImage; 
			}
			
			set
			{
				if (mImage != value)
				{
					mImage = value;
					
					if (mParent != null)
					{
						mParent.UpdateTabImage(this);
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets token ID for translation.
		/// </summary>
		/// <value>Token ID for translation.</value>
		public R.sections.DockWidgets.strings tokenId
		{
			get
			{
				return mTokenId; 
			}
			
			set
			{
				if (mTokenId != value)
				{
					mTokenId = value;
					
					if (mParent != null)
					{
						mParent.UpdateTab(this);
					}
				}
			}
		}

		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <value>The title.</value>
		public string title
		{
			get
			{
				if (mTokenId == R.sections.DockWidgets.strings.Count)
				{
					return "";
				}
				
				return Translator.getString(mTokenId); 
			}
		}



		private DockingGroupScript             mParent;
		private Color                          mBackgroundColor;
		private Sprite                         mImage;
		private R.sections.DockWidgets.strings mTokenId;

		private RectTransform mContentTransform;
		private Image         mContentBackgroundImage;



		public DockWidgetScript()
			: base()
		{
			mParent          = null;
			mBackgroundColor = Assets.DockWidgets.Colors.background;
			mImage           = Assets.DockWidgets.Textures.icon;
			mTokenId         = R.sections.DockWidgets.strings.Count;

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
		/// Destroy this instance.
		/// </summary>
		public void Destroy()
		{
			UnityEngine.Object.DestroyObject(gameObject);
			
			if (mParent != null)
			{
				mParent.RemoveDockWidget(this);
			}
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
		/// Selects this dock widget.
		/// </summary>
		public void Select()
		{
			mParent.OnSelectTab(this);
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

